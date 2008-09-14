USE [jcTBot]
GO
/****** Object:  Table [dbo].[BuildingGIDs]    Script Date: 09/14/2008 19:26:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BuildingGIDs]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[BuildingGIDs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BuildingName] [nvarchar](50) NOT NULL,
	[BuildingGID] [int] NOT NULL,
 CONSTRAINT [PK_BuildingGIDs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 09/14/2008 19:26:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tasks]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Tasks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TaskName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Villages]    Script Date: 09/14/2008 19:26:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Villages]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Villages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VillageId] [int] NOT NULL,
	[VillageName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Villages_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[TaskList]    Script Date: 09/14/2008 19:26:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TaskList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TaskList](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VillageID] [int] NOT NULL,
	[TaskId] [int] NOT NULL,
	[BuildLevel] [int] NOT NULL,
	[NextCheck] [datetime] NOT NULL,
 CONSTRAINT [PK_TaskList_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Production]    Script Date: 09/14/2008 19:26:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Production]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Production](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VillageID] [int] NOT NULL,
	[Warehouse] [int] NULL,
	[Granary] [int] NULL,
	[Wood] [int] NULL,
	[Clay] [int] NULL,
	[Iron] [int] NULL,
	[Crop] [int] NULL,
	[WoodPerHour] [int] NULL,
	[ClayPerHour] [int] NULL,
	[IronPerHour] [int] NULL,
	[CropPerHour] [int] NULL,
 CONSTRAINT [PK_Production_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Resources]    Script Date: 09/14/2008 19:26:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Resources]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Resources](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VillageID] [int] NOT NULL,
	[ResourcesId] [int] NULL,
	[ResourcesName] [nvarchar](50) NULL,
	[ResourcesLevel] [int] NULL,
 CONSTRAINT [PK_Resources_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Buildings]    Script Date: 09/14/2008 19:26:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Buildings]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Buildings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VillageID] [int] NOT NULL,
	[BuildingId] [int] NULL,
	[BuildingName] [nvarchar](50) NULL,
	[BuildingLevel] [int] NULL,
 CONSTRAINT [PK_Buildings_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  StoredProcedure [dbo].[InsertTask]    Script Date: 09/14/2008 19:26:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertTask]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Andrej Jeznik
-- Create date: 11.09.2008
-- Description:	Insert new task
-- =============================================
CREATE PROCEDURE [dbo].[InsertTask] 
	-- Add the parameters for the stored procedure here
	(@VillageId int
	,@TaskId int
	,@BuildLevel int 
	,@NextCheck datetime)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
INSERT INTO [jcTBot].[dbo].[TaskList]
           ([VillageID]
           ,[TaskId]
           ,[BuildLevel]
           ,[NextCheck])
     VALUES
           (@VillageId
           ,@TaskId
           ,@BuildLevel
           ,@NextCheck)
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetTaskList]    Script Date: 09/14/2008 19:26:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetTaskList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Andrej Jeznik
-- Create date: 11.09.2008
-- Description:	Get current tasks list
-- =============================================
CREATE PROCEDURE [dbo].[GetTaskList]
	-- Add the parameters for the stored procedure here
	-- <@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	-- <@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT [Id]
      ,(SELECT [VillageName] FROM [jcTBot].[dbo].[Villages] WHERE [jcTBot].[dbo].[Villages].[Id] = [jcTBot].[dbo].[TaskList].[VillageID]) AS VillageName
      ,(SELECT [TaskName] FROM [jcTBot].[dbo].[Tasks] WHERE [jcTBot].[dbo].[Tasks].[Id] = [jcTBot].[dbo].[TaskList].[TaskId]) AS TaskName
      ,[BuildLevel]
      ,[NextCheck]
  FROM [jcTBot].[dbo].[TaskList]
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetProductionForVillages]    Script Date: 09/14/2008 19:26:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetProductionForVillages]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Andrej Jeznik
-- Create date: 12.09.2008
-- Description:	Get production, warehouse and granary capacity
-- =============================================
CREATE PROCEDURE [dbo].[GetProductionForVillages] 
	-- Add the parameters for the stored procedure here
	-- <@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	-- <@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT [Id]
      ,(SELECT [VillageName] FROM [jcTBot].[dbo].[Villages] WHERE [jcTBot].[dbo].[Villages].[Id] = [jcTBot].[dbo].[Production].[VillageID]) AS VillageName
      ,(SELECT [VillageId] FROM [jcTBot].[dbo].[Villages] WHERE [jcTBot].[dbo].[Villages].[Id] = [jcTBot].[dbo].[Production].[VillageID]) AS VillageId
      ,[Warehouse]
      ,[Granary]
      ,[Wood]
      ,[Clay]
      ,[Iron]
      ,[Crop]
      ,[WoodPerHour]
      ,[ClayPerHour]
      ,[IronPerHour]
      ,[CropPerHour]
  FROM [jcTBot].[dbo].[Production]	
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetBuildingsGIDsNamesAndIDs]    Script Date: 09/14/2008 19:26:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetBuildingsGIDsNamesAndIDs]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Andrej Jeznik
-- Create date: 14.09.2008
-- Description:	Gets buildings GIDs andresources IDs
-- =============================================
CREATE PROCEDURE [dbo].[GetBuildingsGIDsNamesAndIDs] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Id], [BuildingName] FROM [jcTBot].[dbo].[BuildingGIDs]
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetTaskNames]    Script Date: 09/14/2008 19:26:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetTaskNames]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Andrej Jeznik
-- Create date: 12.09.2008
-- Description:	Get available task names
-- =============================================
CREATE PROCEDURE [dbo].[GetTaskNames] 
	-- Add the parameters for the stored procedure here
	-- <@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	-- <@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [TaskName] FROM [jcTBot].[dbo].[Tasks]
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetTaskNamesAndIDs]    Script Date: 09/14/2008 19:26:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetTaskNamesAndIDs]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Andrej Jeznik
-- Create date: 14.09.2008
-- Description:	Get available task names and ids
-- =============================================
CREATE PROCEDURE [dbo].[GetTaskNamesAndIDs] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Id], [TaskName] FROM [jcTBot].[dbo].[Tasks]
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[InsertVillage]    Script Date: 09/14/2008 19:26:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertVillage]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Andrej Jeznik
-- Create date: 11.09.2008
-- Description:	Insert new village
-- =============================================
CREATE PROCEDURE [dbo].[InsertVillage] 
	-- Add the parameters for the stored procedure here
	(@VillageId int
	,@VillageName nvarchar(50))
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
IF NOT EXISTS (SELECT [VillageId] FROM [jcTBot].[dbo].[Villages] WHERE @VillageId = [dbo].[Villages].[VillageId])
INSERT INTO [jcTBot].[dbo].[Villages]
           ([VillageId]
           ,[VillageName])
     VALUES
           (@VillageId
           ,@VillageName)
END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetVillagesNamesAndIDs]    Script Date: 09/14/2008 19:26:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetVillagesNamesAndIDs]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Andrej Jeznik
-- Create date: 11.09.2008
-- Description:	Gets Villages (Names and IDs) list
-- =============================================
CREATE PROCEDURE [dbo].[GetVillagesNamesAndIDs] 
	-- Add the parameters for the stored procedure here
	-- <@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	-- <@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [VillageId], [VillageName] FROM [dbo].[Villages]
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetVillageNames]    Script Date: 09/14/2008 19:26:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetVillageNames]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Andrej Jeznik
-- Create date: 14.09.2008
-- Description:	Gets villages names
-- =============================================
CREATE PROCEDURE [dbo].[GetVillageNames] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [VillageName] FROM [jcTBot].[dbo].[Villages]
END
' 
END
GO
USE [jcTBot]
GO
USE [jcTBot]
GO
USE [jcTBot]
GO
USE [jcTBot]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TaskList_Tasks]') AND parent_object_id = OBJECT_ID(N'[dbo].[TaskList]'))
ALTER TABLE [dbo].[TaskList]  WITH CHECK ADD  CONSTRAINT [FK_TaskList_Tasks] FOREIGN KEY([TaskId])
REFERENCES [dbo].[Tasks] ([Id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TaskList_Villages]') AND parent_object_id = OBJECT_ID(N'[dbo].[TaskList]'))
ALTER TABLE [dbo].[TaskList]  WITH CHECK ADD  CONSTRAINT [FK_TaskList_Villages] FOREIGN KEY([VillageID])
REFERENCES [dbo].[Villages] ([Id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Production_Villages]') AND parent_object_id = OBJECT_ID(N'[dbo].[Production]'))
ALTER TABLE [dbo].[Production]  WITH CHECK ADD  CONSTRAINT [FK_Production_Villages] FOREIGN KEY([VillageID])
REFERENCES [dbo].[Villages] ([Id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Resources_Villages]') AND parent_object_id = OBJECT_ID(N'[dbo].[Resources]'))
ALTER TABLE [dbo].[Resources]  WITH CHECK ADD  CONSTRAINT [FK_Resources_Villages] FOREIGN KEY([VillageID])
REFERENCES [dbo].[Villages] ([Id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Buildings_Villages]') AND parent_object_id = OBJECT_ID(N'[dbo].[Buildings]'))
ALTER TABLE [dbo].[Buildings]  WITH CHECK ADD  CONSTRAINT [FK_Buildings_Villages] FOREIGN KEY([VillageID])
REFERENCES [dbo].[Villages] ([Id])
