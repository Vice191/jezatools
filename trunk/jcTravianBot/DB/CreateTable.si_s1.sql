USE [TravianMap]
GO
/****** Object:  Table [dbo].[si_s3]    Script Date: 04/09/2008 21:57:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[si_s1](
	[id] [int] NOT NULL,
	[x] [int] NOT NULL,
	[y] [int] NOT NULL,
	[tid] [int] NOT NULL,
	[vid] [int] NOT NULL,
	[village] [nchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[uid] [int] NOT NULL,
	[player] [nchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[aid] [int] NOT NULL,
	[aliance] [nchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[population] [int] NOT NULL
) ON [PRIMARY]
