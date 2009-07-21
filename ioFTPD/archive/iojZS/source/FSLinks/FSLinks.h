// Copyright 2000 Mikael Nordell (tamlin@algonet.se)
// Distributed without warranties. Use as you see fit, except for
// commercial purposes.
#if !defined(TMN_FSLINKS_H)
#define TMN_FSLINKS_H

#include "TMN_Win2k.h"

namespace FSLinks {

BOOL CreateJunctionPoint(LPCTSTR szMountDir, LPCTSTR szDestDir);
BOOL DeleteJunctionPoint(LPCTSTR szMountDir);
DWORD GetJunctionPointInfo(	LPCTSTR szMountDir,
							LPTSTR  szDestBuff,
							DWORD   dwBuffSize);

}	// namespace FSLinks

#endif	// TMN_FSLINKS_H
