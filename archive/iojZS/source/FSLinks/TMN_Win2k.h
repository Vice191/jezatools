// Copyright 2000 Mikael Nordell (tamlin@algonet.se)
// Distributed without warranties. Use as you see fit, except for
// commercial purposes.
#if !defined(TMN_WIN2K_H)
#define TMN_WIN2K_H

#define WIN32_LEAN_AND_MEAN
#define _WIN32_WINNT 0x500
#define NOMCX
#define NOIME
#define NOSERVICE
#define NOGDI
#define NOUSER
#define NOHELP
#define NOSYSPARAMSINFO
#define NOWINABLE

#include <windows.h>
#include <winioctl.h>

#if defined(__cplusplus)
extern "C" {
#endif

// Since MS apparently removed this struct (and its documentation) from
// the W2k SDK, but still refer to it in 'winioctl.h' for the specific
// IOCTLs, I decided to rename it and make it available.
// I've made some modifications to this one for easier access.
//
// Structure for FSCTL_SET_REPARSE_POINT, FSCTL_GET_REPARSE_POINT, and
// FSCTL_DELETE_REPARSE_POINT.
// This version of the reparse data buffer is only for Microsoft tags.

struct TMN_REPARSE_DATA_BUFFER
{
    DWORD  ReparseTag;
    WORD   ReparseDataLength;
    WORD   Reserved;

	// IO_REPARSE_TAG_MOUNT_POINT specifics follow
    WORD   SubstituteNameOffset;
    WORD   SubstituteNameLength;
    WORD   PrintNameOffset;
    WORD   PrintNameLength;
    WCHAR  PathBuffer[1];

	// Some helper functions
	bool Init(LPCSTR szJunctionPoint);
	bool Init(LPCWSTR wszJunctionPoint);
	int BytesForIoControl() const;
};

#define TMN_REPARSE_DATA_BUFFER_HEADER_SIZE \
			FIELD_OFFSET(TMN_REPARSE_DATA_BUFFER, SubstituteNameOffset)


// These have the wrong values in pre-W2k SDKs, why I redefine them here.
#if !defined(FSCTL_SET_REPARSE_POINT) || \
	(FSCTL_SET_REPARSE_POINT != 0x900a4)
#undef FSCTL_SET_REPARSE_POINT
#define FSCTL_SET_REPARSE_POINT  CTL_CODE(FILE_DEVICE_FILE_SYSTEM, 41, METHOD_BUFFERED, FILE_ANY_ACCESS)
#endif

#if !defined(FSCTL_DELETE_REPARSE_POINT) || \
	(FSCTL_DELETE_REPARSE_POINT != 0x900ac)
#undef FSCTL_DELETE_REPARSE_POINT
#define FSCTL_DELETE_REPARSE_POINT      CTL_CODE(FILE_DEVICE_FILE_SYSTEM, 43, METHOD_BUFFERED, FILE_ANY_ACCESS)
#endif


#if 0


#ifndef ERROR_INVALID_REPARSE_DATA
//  The data present in the reparse point buffer is invalid.
#define ERROR_INVALID_REPARSE_DATA       4392L
#endif

#ifndef ERROR_INVALID_REPARSE_DATA
//  The tag present in the reparse point buffer is invalid.
#define ERROR_REPARSE_TAG_INVALID        4393L
#endif

#ifndef ERROR_INVALID_REPARSE_DATA
//  There is a mismatch between the tag specified in the request and the tag present in the reparse point.
#define ERROR_REPARSE_TAG_MISMATCH       4394L
#endif

#endif	// 0


#if defined(__cplusplus)
}
#endif

#endif	// TMN_WIN2K_H

