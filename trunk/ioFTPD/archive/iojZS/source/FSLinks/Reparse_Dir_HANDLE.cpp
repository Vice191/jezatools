// Copyright 2000 Mikael Nordell (tamlin@algonet.se)
// Distributed without warranties. Use as you see fit, except for
// commercial purposes.
// Reparse_Dir_HANDLE.cpp
#include "Reparse_Dir_HANDLE.h"

namespace FSLinks {


Reparse_Dir_HANDLE::Reparse_Dir_HANDLE(LPCTSTR szDir, bool bWriteable)
:	m_hDir(
		CreateFile(	szDir,
					GENERIC_READ | (bWriteable ? GENERIC_WRITE : 0),
					0,
					0,
					OPEN_EXISTING,
					FILE_FLAG_BACKUP_SEMANTICS | FILE_FLAG_OPEN_REPARSE_POINT,
					0)
	)
{
}

Reparse_Dir_HANDLE::~Reparse_Dir_HANDLE()
{
	if (m_hDir != INVALID_HANDLE_VALUE) {
		::CloseHandle(m_hDir);
	}
}

bool Reparse_Dir_HANDLE::SetReparsePoint(const TMN_REPARSE_DATA_BUFFER& rdb)
{
	if (!IsValid()) {
		return false;
	}

	DWORD dwBytes;
	const BOOL bOK =
		DeviceIoControl(m_hDir,
						FSCTL_SET_REPARSE_POINT,
						(LPVOID)&rdb,
						rdb.BytesForIoControl(),
						NULL,
						0,
						&dwBytes,
						0);
	return bOK != 0;
}

bool Reparse_Dir_HANDLE::DeleteReparsePoint()
{
	if (!IsValid()) {
		return false;
	}

	REPARSE_GUID_DATA_BUFFER rgdb = { 0 };
	rgdb.ReparseTag = IO_REPARSE_TAG_MOUNT_POINT;
	DWORD dwBytes;
	const BOOL bOK =
		DeviceIoControl(m_hDir,
						FSCTL_DELETE_REPARSE_POINT,
						&rgdb,
						REPARSE_GUID_DATA_BUFFER_HEADER_SIZE,
						NULL,
						0,
						&dwBytes,
						0);
	return bOK != 0;
}

}	// end of namespace FSLinks

