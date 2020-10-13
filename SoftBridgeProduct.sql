USE [SnowBridgeDatabase]
GO

/****** Object:  Table [dbo].[SoftBridgeProducts]    Script Date: 13-10-2020 16:07:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SoftBridgeProducts](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Description] [varchar](max) NOT NULL,
	[Price] [numeric](18, 2) NOT NULL,
	[ImageURL] [varchar](max) NOT NULL,
 CONSTRAINT [PK_SoftBridgeProducts] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


