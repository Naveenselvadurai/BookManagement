USE [book management]
GO

/****** Object:  UserDefinedTableType [dbo].[BookTableType]    Script Date: 2/10/2025 8:50:37 PM ******/
DROP TYPE [dbo].[BOOK_TABLE_TYPE]
GO

/****** Object:  UserDefinedTableType [dbo].[BookTableType]    Script Date: 2/10/2025 8:50:37 PM ******/
CREATE TYPE [DBO].[BOOK_TABLE_TYPE] AS TABLE(
	[PUBLISHER] [NVARCHAR](100) NULL,
	[TITLE] [NVARCHAR](200) NULL,
	[AUTHORLASTNAME] [NVARCHAR](100) NULL,
	[AUTHORFIRSTNAME] [NVARCHAR](100) NULL,
	[PRICE] [DECIMAL](10, 2) NULL
)
GO
