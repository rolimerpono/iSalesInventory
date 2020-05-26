USE [iSalesInventory]
GO
/****** Object:  Table [dbo].[tbl_Vendor]    Script Date: 05/26/2020 21:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Vendor](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VENDOR] [nvarchar](50) NOT NULL,
	[ADDRESS] [nvarchar](500) NULL,
	[CONTACT_PERSON] [nvarchar](50) NULL,
	[TELEPHONE_NUMBER] [nvarchar](15) NULL,
	[EMAIL] [nvarchar](50) NULL,
	[PHONE_NUMBER] [nvarchar](15) NULL,
	[FAX_NUMBER] [nvarchar](15) NULL,
	[STATUS] [nvarchar](8) NULL,
 CONSTRAINT [PK_tbl_Vendor] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[VENDOR] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_Vendor] ON
INSERT [dbo].[tbl_Vendor] ([ID], [VENDOR], [ADDRESS], [CONTACT_PERSON], [TELEPHONE_NUMBER], [EMAIL], [PHONE_NUMBER], [FAX_NUMBER], [STATUS]) VALUES (6, N'ONE SAN MIGUEL', N'ORTIGAS SHAW', N'REX', N'0920101010101', N'SANMIGUEL@YAHOO.COM', N'09201010101', N'55201010', N'ACTIVE')
INSERT [dbo].[tbl_Vendor] ([ID], [VENDOR], [ADDRESS], [CONTACT_PERSON], [TELEPHONE_NUMBER], [EMAIL], [PHONE_NUMBER], [FAX_NUMBER], [STATUS]) VALUES (7, N'ROBINSON', N'ORTIGAS', N'JAMES', N'09200304810', N'@GMAIL.COM', N'2023042034', N'1231203123', N'ACTIVE')
SET IDENTITY_INSERT [dbo].[tbl_Vendor] OFF
/****** Object:  Table [dbo].[tbl_Vat]    Script Date: 05/26/2020 21:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Vat](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[VAT] [decimal](6, 2) NULL,
	[TRANSACTION_DATE] [nvarchar](10) NULL,
	[TRANSACT_BY] [nvarchar](50) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_Vat] ON
INSERT [dbo].[tbl_Vat] ([ID], [VAT], [TRANSACTION_DATE], [TRANSACT_BY]) VALUES (1, CAST(10.00 AS Decimal(6, 2)), N'2020-05-07', N'rolly')
SET IDENTITY_INSERT [dbo].[tbl_Vat] OFF
/****** Object:  Table [dbo].[tbl_UserAccess]    Script Date: 05/26/2020 21:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_UserAccess](
	[SALES] [bit] NULL,
	[PRODUCT] [bit] NULL,
	[VENDOR] [bit] NULL,
	[STOCK] [bit] NULL,
	[CATEGORY] [bit] NULL,
	[BRAND] [bit] NULL,
	[RECORDS] [bit] NULL,
	[SYSTEM_SETTINGS] [bit] NULL,
	[USER_SETTINGS] [bit] NULL,
	[ROLE] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_tbl_UserAccess] PRIMARY KEY CLUSTERED 
(
	[ROLE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tbl_UserAccess] ([SALES], [PRODUCT], [VENDOR], [STOCK], [CATEGORY], [BRAND], [RECORDS], [SYSTEM_SETTINGS], [USER_SETTINGS], [ROLE]) VALUES (1, 1, 1, 1, 1, 1, 1, 1, 1, N'ADMINISTRATOR')
INSERT [dbo].[tbl_UserAccess] ([SALES], [PRODUCT], [VENDOR], [STOCK], [CATEGORY], [BRAND], [RECORDS], [SYSTEM_SETTINGS], [USER_SETTINGS], [ROLE]) VALUES (1, 0, 0, 0, 0, 0, 0, 0, 0, N'CASHIER')
INSERT [dbo].[tbl_UserAccess] ([SALES], [PRODUCT], [VENDOR], [STOCK], [CATEGORY], [BRAND], [RECORDS], [SYSTEM_SETTINGS], [USER_SETTINGS], [ROLE]) VALUES (0, 0, 0, 0, 0, 0, 1, 0, 0, N'CLERK')
INSERT [dbo].[tbl_UserAccess] ([SALES], [PRODUCT], [VENDOR], [STOCK], [CATEGORY], [BRAND], [RECORDS], [SYSTEM_SETTINGS], [USER_SETTINGS], [ROLE]) VALUES (0, 0, 0, 1, 0, 0, 1, 0, 0, N'USER')
/****** Object:  Table [dbo].[tbl_User]    Script Date: 05/26/2020 21:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_User](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[FIRST_NAME] [nvarchar](50) NULL,
	[MIDDLE_NAME] [nvarchar](50) NULL,
	[LAST_NAME] [nvarchar](50) NULL,
	[CONTACT_NO] [nvarchar](15) NULL,
	[USERNAME] [nvarchar](15) NOT NULL,
	[PASSWORD] [nvarchar](15) NULL,
	[ROLE] [nvarchar](15) NULL,
	[STATUS] [nvarchar](10) NULL,
	[ALLOW_VOID] [bit] NULL,
 CONSTRAINT [PK_tbl_User] PRIMARY KEY CLUSTERED 
(
	[USERNAME] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_User] ON
INSERT [dbo].[tbl_User] ([ID], [FIRST_NAME], [MIDDLE_NAME], [LAST_NAME], [CONTACT_NO], [USERNAME], [PASSWORD], [ROLE], [STATUS], [ALLOW_VOID]) VALUES (3, N'RIO', N'RIO', N'RIO', N'0239429342', N'john', N'john', N'CLERK', N'ACTIVE', 0)
INSERT [dbo].[tbl_User] ([ID], [FIRST_NAME], [MIDDLE_NAME], [LAST_NAME], [CONTACT_NO], [USERNAME], [PASSWORD], [ROLE], [STATUS], [ALLOW_VOID]) VALUES (2, N'ROLIMER', N'E', N'PONO', N'2034204230', N'rolly', N'rolly', N'ADMINISTRATOR', N'ACTIVE', 1)
SET IDENTITY_INSERT [dbo].[tbl_User] OFF
/****** Object:  Table [dbo].[tbl_Stocks]    Script Date: 05/26/2020 21:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Stocks](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[REFERRENCE_NO] [nvarchar](15) NULL,
	[PRODUCT_CODE] [nvarchar](15) NULL,
	[QTY] [int] NULL,
	[TRANSACTION_DATE] [nvarchar](10) NULL,
	[TRANSACT_BY] [nvarchar](50) NULL,
	[VENDOR_ID] [int] NULL,
	[REMARKS] [nvarchar](200) NULL,
	[STATUS] [nvarchar](15) NULL,
 CONSTRAINT [PK_tbl_StockIn] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_Stocks] ON
INSERT [dbo].[tbl_Stocks] ([ID], [REFERRENCE_NO], [PRODUCT_CODE], [QTY], [TRANSACTION_DATE], [TRANSACT_BY], [VENDOR_ID], [REMARKS], [STATUS]) VALUES (88, N'REF-000000001', N'PCD-000000001', 200, N'2020-05-15', N'ROLIMER PONO', 6, N'', N'IN')
INSERT [dbo].[tbl_Stocks] ([ID], [REFERRENCE_NO], [PRODUCT_CODE], [QTY], [TRANSACTION_DATE], [TRANSACT_BY], [VENDOR_ID], [REMARKS], [STATUS]) VALUES (89, N'REF-000000001', N'PCD-000000010', 200, N'2020-05-15', N'ROLIMER PONO', 6, N'', N'IN')
INSERT [dbo].[tbl_Stocks] ([ID], [REFERRENCE_NO], [PRODUCT_CODE], [QTY], [TRANSACTION_DATE], [TRANSACT_BY], [VENDOR_ID], [REMARKS], [STATUS]) VALUES (90, N'REF-000000001', N'PCD-000000011', 200, N'2020-05-15', N'ROLIMER PONO', 6, N'', N'IN')
INSERT [dbo].[tbl_Stocks] ([ID], [REFERRENCE_NO], [PRODUCT_CODE], [QTY], [TRANSACTION_DATE], [TRANSACT_BY], [VENDOR_ID], [REMARKS], [STATUS]) VALUES (91, N'REF-000000001', N'PCD-000000012', 200, N'2020-05-15', N'ROLIMER PONO', 6, N'', N'IN')
INSERT [dbo].[tbl_Stocks] ([ID], [REFERRENCE_NO], [PRODUCT_CODE], [QTY], [TRANSACTION_DATE], [TRANSACT_BY], [VENDOR_ID], [REMARKS], [STATUS]) VALUES (92, N'REF-000000001', N'PCD-000000013', 200, N'2020-05-15', N'ROLIMER PONO', 6, N'', N'IN')
INSERT [dbo].[tbl_Stocks] ([ID], [REFERRENCE_NO], [PRODUCT_CODE], [QTY], [TRANSACTION_DATE], [TRANSACT_BY], [VENDOR_ID], [REMARKS], [STATUS]) VALUES (93, N'REF-000000002', N'PCD-000000001', 5, N'2020-05-15', N'ROLIMER PONO', 6, N'EXPIRED ITEMS', N'OUT')
SET IDENTITY_INSERT [dbo].[tbl_Stocks] OFF
/****** Object:  Table [dbo].[tbl_SoldItems]    Script Date: 05/26/2020 21:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_SoldItems](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[TRANSACTION_NO] [nvarchar](20) NOT NULL,
	[PRODUCT_CODE] [nvarchar](15) NULL,
	[PRICE] [decimal](6, 2) NULL,
	[QTY] [int] NULL,
	[DISCOUNT_PERCENTAGE] [decimal](6, 2) NULL,
	[DISCOUNT] [decimal](6, 2) NULL,
	[VAT_PERCENTAGE] [decimal](6, 2) NULL,
	[VAT] [decimal](6, 2) NULL,
	[TOTAL] [decimal](6, 2) NULL,
	[TRANSACTION_DATE] [nvarchar](10) NULL,
	[TRANSACT_BY] [nvarchar](50) NULL,
	[STATUS] [nvarchar](15) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_SoldItems] ON
INSERT [dbo].[tbl_SoldItems] ([ID], [TRANSACTION_NO], [PRODUCT_CODE], [PRICE], [QTY], [DISCOUNT_PERCENTAGE], [DISCOUNT], [VAT_PERCENTAGE], [VAT], [TOTAL], [TRANSACTION_DATE], [TRANSACT_BY], [STATUS]) VALUES (195, N'2020051900000001', N'PCD-000000010', CAST(850.10 AS Decimal(6, 2)), 1, CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(850.10 AS Decimal(6, 2)), N'2020-05-19', N'ROLIMER PONO', N'SOLD')
INSERT [dbo].[tbl_SoldItems] ([ID], [TRANSACTION_NO], [PRODUCT_CODE], [PRICE], [QTY], [DISCOUNT_PERCENTAGE], [DISCOUNT], [VAT_PERCENTAGE], [VAT], [TOTAL], [TRANSACTION_DATE], [TRANSACT_BY], [STATUS]) VALUES (196, N'2020051900000001', N'PCD-000000011', CAST(950.70 AS Decimal(6, 2)), 1, CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(950.70 AS Decimal(6, 2)), N'2020-05-19', N'ROLIMER PONO', N'SOLD')
INSERT [dbo].[tbl_SoldItems] ([ID], [TRANSACTION_NO], [PRODUCT_CODE], [PRICE], [QTY], [DISCOUNT_PERCENTAGE], [DISCOUNT], [VAT_PERCENTAGE], [VAT], [TOTAL], [TRANSACTION_DATE], [TRANSACT_BY], [STATUS]) VALUES (197, N'2020051900000001', N'PCD-000000012', CAST(980.60 AS Decimal(6, 2)), 1, CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(10.00 AS Decimal(6, 2)), CAST(98.06 AS Decimal(6, 2)), CAST(882.54 AS Decimal(6, 2)), N'2020-05-19', N'ROLIMER PONO', N'SOLD')
SET IDENTITY_INSERT [dbo].[tbl_SoldItems] OFF
/****** Object:  Table [dbo].[tbl_Role]    Script Date: 05/26/2020 21:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Role](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ROLE] [nvarchar](50) NOT NULL,
	[STATUS] [nvarchar](10) NULL,
 CONSTRAINT [PK_tbl_Role] PRIMARY KEY CLUSTERED 
(
	[ROLE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_Role] ON
INSERT [dbo].[tbl_Role] ([ID], [ROLE], [STATUS]) VALUES (1, N'ADMINISTRATOR', N'ACTIVE')
INSERT [dbo].[tbl_Role] ([ID], [ROLE], [STATUS]) VALUES (4, N'CASHIER', N'ACTIVE')
INSERT [dbo].[tbl_Role] ([ID], [ROLE], [STATUS]) VALUES (3, N'CLERK', N'ACTIVE')
INSERT [dbo].[tbl_Role] ([ID], [ROLE], [STATUS]) VALUES (2, N'USER', N'ACTIVE')
SET IDENTITY_INSERT [dbo].[tbl_Role] OFF
/****** Object:  Table [dbo].[tbl_Product]    Script Date: 05/26/2020 21:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Product](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[PRODUCT_CODE] [nvarchar](15) NOT NULL,
	[BAR_CODE] [nvarchar](15) NULL,
	[DESCRIPTION] [nvarchar](50) NULL,
	[BRAND_ID] [int] NULL,
	[CATEGORY_ID] [int] NULL,
	[PRICE] [decimal](6, 2) NULL,
	[REORDER_LEVEL] [int] NULL,
	[IS_VATABLE] [bit] NULL,
 CONSTRAINT [PK_tbl_Product] PRIMARY KEY CLUSTERED 
(
	[PRODUCT_CODE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_Product] ON
INSERT [dbo].[tbl_Product] ([ID], [PRODUCT_CODE], [BAR_CODE], [DESCRIPTION], [BRAND_ID], [CATEGORY_ID], [PRICE], [REORDER_LEVEL], [IS_VATABLE]) VALUES (9, N'PCD-000000001', N'000101010102', N'COKE SAKTO', 4, 6, CAST(550.30 AS Decimal(6, 2)), 20, 1)
INSERT [dbo].[tbl_Product] ([ID], [PRODUCT_CODE], [BAR_CODE], [DESCRIPTION], [BRAND_ID], [CATEGORY_ID], [PRICE], [REORDER_LEVEL], [IS_VATABLE]) VALUES (10, N'PCD-000000010', N'2010100202022', N'SWAK NOODLES', 3, 7, CAST(850.10 AS Decimal(6, 2)), 20, 0)
INSERT [dbo].[tbl_Product] ([ID], [PRODUCT_CODE], [BAR_CODE], [DESCRIPTION], [BRAND_ID], [CATEGORY_ID], [PRICE], [REORDER_LEVEL], [IS_VATABLE]) VALUES (11, N'PCD-000000011', N'1023402340011', N'3N1 NESCAFE', 2, 8, CAST(950.70 AS Decimal(6, 2)), 10, 0)
INSERT [dbo].[tbl_Product] ([ID], [PRODUCT_CODE], [BAR_CODE], [DESCRIPTION], [BRAND_ID], [CATEGORY_ID], [PRICE], [REORDER_LEVEL], [IS_VATABLE]) VALUES (12, N'PCD-000000012', N'1010101010101', N'STAR MARGARINE', 2, 9, CAST(980.60 AS Decimal(6, 2)), 10, 1)
INSERT [dbo].[tbl_Product] ([ID], [PRODUCT_CODE], [BAR_CODE], [DESCRIPTION], [BRAND_ID], [CATEGORY_ID], [PRICE], [REORDER_LEVEL], [IS_VATABLE]) VALUES (13, N'PCD-000000013', N'1010101010101', N'GREEN CROSS ALCOHOL', 1, 7, CAST(900.00 AS Decimal(6, 2)), 10, 1)
INSERT [dbo].[tbl_Product] ([ID], [PRODUCT_CODE], [BAR_CODE], [DESCRIPTION], [BRAND_ID], [CATEGORY_ID], [PRICE], [REORDER_LEVEL], [IS_VATABLE]) VALUES (14, N'PCD-000000014', N'1010210301321', N'BAYGON SPRAY', 1, 7, CAST(800.25 AS Decimal(6, 2)), 10, 0)
SET IDENTITY_INSERT [dbo].[tbl_Product] OFF
/****** Object:  Table [dbo].[tbl_Category]    Script Date: 05/26/2020 21:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Category](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CATEGORY] [nvarchar](15) NOT NULL,
	[STATUS] [nvarchar](8) NULL,
 CONSTRAINT [PK_tbl_Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[CATEGORY] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_Category] ON
INSERT [dbo].[tbl_Category] ([ID], [CATEGORY], [STATUS]) VALUES (5, N'BEVERAGES', N'ACTIVE')
INSERT [dbo].[tbl_Category] ([ID], [CATEGORY], [STATUS]) VALUES (6, N'DRINKS', N'ACTIVE')
INSERT [dbo].[tbl_Category] ([ID], [CATEGORY], [STATUS]) VALUES (7, N'HOUSE HOLD', N'ACTIVE')
INSERT [dbo].[tbl_Category] ([ID], [CATEGORY], [STATUS]) VALUES (8, N'TEA', N'ACTIVE')
INSERT [dbo].[tbl_Category] ([ID], [CATEGORY], [STATUS]) VALUES (9, N'FOOD', N'ACTIVE')
SET IDENTITY_INSERT [dbo].[tbl_Category] OFF
/****** Object:  Table [dbo].[tbl_CancelledOrder]    Script Date: 05/26/2020 21:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_CancelledOrder](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[TRANSACTION_NO] [nvarchar](25) NULL,
	[PRODUCT_CODE] [nvarchar](15) NULL,
	[PRICE] [decimal](6, 2) NULL,
	[QTY] [int] NULL,
	[DISCOUNT_PERCENTAGE] [decimal](6, 6) NULL,
	[DISCOUNT] [decimal](6, 2) NULL,
	[VAT_PERCENTAGE] [decimal](6, 2) NULL,
	[VAT] [decimal](6, 2) NULL,
	[TOTAL] [decimal](6, 2) NULL,
	[TRANSACTION_DATE] [nvarchar](10) NULL,
	[TRANSACT_BY] [nvarchar](15) NULL,
	[VOID_BY] [nvarchar](15) NULL,
	[REASON] [nvarchar](100) NULL,
	[ACTION] [nvarchar](50) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_CancelledOrder] ON
INSERT [dbo].[tbl_CancelledOrder] ([ID], [TRANSACTION_NO], [PRODUCT_CODE], [PRICE], [QTY], [DISCOUNT_PERCENTAGE], [DISCOUNT], [VAT_PERCENTAGE], [VAT], [TOTAL], [TRANSACTION_DATE], [TRANSACT_BY], [VOID_BY], [REASON], [ACTION]) VALUES (19, N'2020051500000001', N'PCD-000000001', CAST(550.30 AS Decimal(6, 2)), 5, CAST(0.000000 AS Decimal(6, 6)), CAST(0.00 AS Decimal(6, 2)), CAST(10.00 AS Decimal(6, 2)), CAST(275.15 AS Decimal(6, 2)), CAST(2201.20 AS Decimal(6, 2)), N'2020-05-15', N'ROLIMER PONO', N'ROLIMER E PONO', N'EXPIRED ITEMS', N'REMOVE TO STOCKS')
SET IDENTITY_INSERT [dbo].[tbl_CancelledOrder] OFF
/****** Object:  Table [dbo].[tbl_Brand]    Script Date: 05/26/2020 21:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Brand](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[BRAND] [nvarchar](15) NOT NULL,
	[STATUS] [nvarchar](8) NULL,
 CONSTRAINT [PK_tbl_Brand] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[BRAND] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_Brand] ON
INSERT [dbo].[tbl_Brand] ([ID], [BRAND], [STATUS]) VALUES (1, N'UNILIVER', N'ACTIVE')
INSERT [dbo].[tbl_Brand] ([ID], [BRAND], [STATUS]) VALUES (2, N'MAGNOLIA', N'ACTIVE')
INSERT [dbo].[tbl_Brand] ([ID], [BRAND], [STATUS]) VALUES (3, N'NISSIN', N'ACTIVE')
INSERT [dbo].[tbl_Brand] ([ID], [BRAND], [STATUS]) VALUES (4, N'COCA COLA', N'ACTIVE')
SET IDENTITY_INSERT [dbo].[tbl_Brand] OFF
/****** Object:  Default [DF_tbl_Vat_VAT]    Script Date: 05/26/2020 21:07:56 ******/
ALTER TABLE [dbo].[tbl_Vat] ADD  CONSTRAINT [DF_tbl_Vat_VAT]  DEFAULT ((0)) FOR [VAT]
GO
/****** Object:  Default [DF_tbl_Vat_TRANSACTION_DATE]    Script Date: 05/26/2020 21:07:56 ******/
ALTER TABLE [dbo].[tbl_Vat] ADD  CONSTRAINT [DF_tbl_Vat_TRANSACTION_DATE]  DEFAULT (N'N''convert(nvarchar(10),getdate(),101)') FOR [TRANSACTION_DATE]
GO
/****** Object:  Default [DF_tbl_Vat_TRANSACT_BY]    Script Date: 05/26/2020 21:07:56 ******/
ALTER TABLE [dbo].[tbl_Vat] ADD  CONSTRAINT [DF_tbl_Vat_TRANSACT_BY]  DEFAULT (N'Admin') FOR [TRANSACT_BY]
GO
