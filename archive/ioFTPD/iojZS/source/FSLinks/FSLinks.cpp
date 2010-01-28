// Copyright 2000 Mikael Nordell (tamlin@algonet.se)
// Distributed without warranties. Use as you see fit, except for
// commercial purposes.
#include "FSLinks.h"
#include "Reparse_Dir_HANDLE.cpp"
#include "Misc.cpp"
//#include <cstdio>

namespace FSLinks {

BOOL CreateJunctionPoint(LPCTSTR szMountDir, LPCTSTR szDestDirArg)
{
	if (!szMountDir || !szDestDirArg || !szMountDir[0] || !szDestDirArg[0]) {
		return false;
	}

	TCHAR szDestDir[1024];
	if (szDestDirArg[0] == '\\' && szDestDirArg[1] == '?') {
		lstrcpy(szDestDir, szDestDirArg);
	} else {
		lstrcpy(szDestDir, TEXT("\\??\\"));
		TCHAR szFullDir[1024];
		LPTSTR pFilePart;
		if (!GetFullPathName(szDestDirArg, 1024, szFullDir, &pFilePart) ||
			GetFileAttributes(szFullDir) == -1)
		{
			return false;
		}
		lstrcat(szDestDir, szFullDir);
	}

	char szBuff[MAXIMUM_REPARSE_DATA_BUFFER_SIZE] = { 0 };
	TMN_REPARSE_DATA_BUFFER& rdb = *(TMN_REPARSE_DATA_BUFFER*)szBuff;

	return	rdb.Init(szDestDir) && 
			Reparse_Dir_HANDLE(szMountDir, true).SetReparsePoint(rdb);
}

BOOL DeleteJunctionPoint(LPCTSTR szDir)
{
	return Reparse_Dir_HANDLE(szDir, true).DeleteReparsePoint();
}

DWORD GetJunctionPointInfo(	LPCTSTR szMountDir,
							LPTSTR  szDestBuff,
							DWORD   dwBuffSize)
{
	const DWORD dwFA = GetFileAttributes(szMountDir);
	if (dwFA == 0xffffffff || !(dwFA & FILE_ATTRIBUTE_REPARSE_POINT)) {
		SetLastError(ERROR_PATH_NOT_FOUND);
		return 0;
	}

	Reparse_Dir_HANDLE hDir(szMountDir);

	if (!hDir.IsValid()) {
		SetLastError(ERROR_PATH_NOT_FOUND);
		return 0;
	}

	char szBuff[MAXIMUM_REPARSE_DATA_BUFFER_SIZE];
	TMN_REPARSE_DATA_BUFFER& rdb = *(TMN_REPARSE_DATA_BUFFER*)szBuff;

	DWORD dwBytesReturned;
	if (!DeviceIoControl(hDir,
						FSCTL_GET_REPARSE_POINT,
						NULL,
						0,
						(LPVOID)&rdb,
						MAXIMUM_REPARSE_DATA_BUFFER_SIZE,
						&dwBytesReturned,
						0) /*||
		!IsReparseTagValid(rdb.ReparseTag)*/)
	{
		return 0;
	}

	if (dwBuffSize < rdb.SubstituteNameLength / sizeof(TCHAR) + sizeof(TCHAR))
	{
		return rdb.SubstituteNameLength / sizeof(TCHAR) + sizeof(TCHAR);
	}

#ifdef UNICODE
	lstrcpy(szDestBuff, rdb.PathBuffer);
#else
	if (!WideCharToMultiByte(CP_THREAD_ACP,
							0,
							rdb.PathBuffer,
							rdb.SubstituteNameLength / sizeof(WCHAR) + 1,
							szDestBuff,
							dwBuffSize,
							"",
							FALSE))
	{
		printf("WideCharToMultiByte failed (%d)\n", GetLastError());
		return 0;
	}
#endif
	return rdb.SubstituteNameLength / sizeof(TCHAR);
}

}	// namespace FSLinks

