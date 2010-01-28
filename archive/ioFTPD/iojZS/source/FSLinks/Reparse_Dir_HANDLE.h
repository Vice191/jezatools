// Copyright 2000 Mikael Nordell (tamlin@algonet.se)
// Distributed without warranties. Use as you see fit, except for
// commercial purposes.
#ifndef REPARSE_DIR_HANDLE_H
#define REPARSE_DIR_HANDLE_H

#include "TMN_Win2k.h"

namespace FSLinks {

class Reparse_Dir_HANDLE
{
public:
	Reparse_Dir_HANDLE(LPCTSTR szDir, bool bWriteable = false);
	~Reparse_Dir_HANDLE();

	operator	HANDLE()		{ return m_hDir; }
	bool		IsValid() const	{ return m_hDir != INVALID_HANDLE_VALUE; }

	bool SetReparsePoint(const TMN_REPARSE_DATA_BUFFER& rdb);
	bool DeleteReparsePoint();

private:
	Reparse_Dir_HANDLE(const Reparse_Dir_HANDLE& rhs);
	Reparse_Dir_HANDLE& operator=(const Reparse_Dir_HANDLE& rhs);

	HANDLE m_hDir;
};

}	// end of namespace FSLinks

#endif	// REPARSE_DIR_HANDLE_H


