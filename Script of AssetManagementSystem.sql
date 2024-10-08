USE [AssetManagementSystem_db_WebApi]
GO
/****** Object:  Table [dbo].[Asset_Definition]    Script Date: 30-09-2024 19:18:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asset_Definition](
	[ad_id] [int] IDENTITY(1,1) NOT NULL,
	[ad_name] [varchar](100) NOT NULL,
	[ad_type_id] [int] NULL,
	[ad_class] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ad_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Asset_Master]    Script Date: 30-09-2024 19:18:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asset_Master](
	[am_id] [int] IDENTITY(1,1) NOT NULL,
	[am_atype_id] [int] NULL,
	[am_make_id] [int] NULL,
	[am_ad_id] [int] NULL,
	[am_model] [varchar](100) NULL,
	[am_snumber] [varchar](50) NULL,
	[am_myyear] [int] NULL,
	[am_pdate] [date] NOT NULL,
	[am_warranty] [int] NULL,
	[am_from] [date] NULL,
	[am_to] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[am_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Asset_Type]    Script Date: 30-09-2024 19:18:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asset_Type](
	[at_id] [int] IDENTITY(1,1) NOT NULL,
	[at_name] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[at_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 30-09-2024 19:18:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[l_id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Usertype] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[l_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Purchase_Order]    Script Date: 30-09-2024 19:18:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchase_Order](
	[pd_id] [int] IDENTITY(1,1) NOT NULL,
	[pd_order_no] [varchar](50) NOT NULL,
	[pd_ad_id] [int] NULL,
	[pd_type_id] [int] NULL,
	[pd_qty] [int] NOT NULL,
	[pd_vendor_id] [int] NULL,
	[pd_date] [date] NOT NULL,
	[pd_ddate] [date] NOT NULL,
	[pd_status] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[pd_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRegistration]    Script Date: 30-09-2024 19:18:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRegistration](
	[u_id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Age] [int] NOT NULL,
	[Gender] [varchar](10) NOT NULL,
	[Address] [varchar](255) NULL,
	[PhoneNumber] [varchar](15) NULL,
	[l_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[u_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vendor]    Script Date: 30-09-2024 19:18:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vendor](
	[vd_id] [int] IDENTITY(1,1) NOT NULL,
	[vd_name] [varchar](100) NOT NULL,
	[vd_type] [varchar](40) NULL,
	[vd_atype_id] [int] NULL,
	[vd_from] [date] NOT NULL,
	[vd_to] [date] NOT NULL,
	[vd_addr] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[vd_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Asset_Definition] ON 

INSERT [dbo].[Asset_Definition] ([ad_id], [ad_name], [ad_type_id], [ad_class]) VALUES (1, N'Geo-magnetic sensor', 3, N'HW')
INSERT [dbo].[Asset_Definition] ([ad_id], [ad_name], [ad_type_id], [ad_class]) VALUES (2, N'Mobile phone', 1, N'HW')
INSERT [dbo].[Asset_Definition] ([ad_id], [ad_name], [ad_type_id], [ad_class]) VALUES (3, N'Laser printer-colour', 2, N'HW')
INSERT [dbo].[Asset_Definition] ([ad_id], [ad_name], [ad_type_id], [ad_class]) VALUES (4, N'Laptop', 5, N'HW')
INSERT [dbo].[Asset_Definition] ([ad_id], [ad_name], [ad_type_id], [ad_class]) VALUES (5, N'Desktop', 6, N'HW')
INSERT [dbo].[Asset_Definition] ([ad_id], [ad_name], [ad_type_id], [ad_class]) VALUES (6, N'Mobile charger', 1, N'HW')
INSERT [dbo].[Asset_Definition] ([ad_id], [ad_name], [ad_type_id], [ad_class]) VALUES (7, N'Printer charger', 2, N'HW')
INSERT [dbo].[Asset_Definition] ([ad_id], [ad_name], [ad_type_id], [ad_class]) VALUES (8, N'Thermal printer', 2, N'HW')
INSERT [dbo].[Asset_Definition] ([ad_id], [ad_name], [ad_type_id], [ad_class]) VALUES (9, N'Lora gateway ICFOSS', 4, N'SW')
SET IDENTITY_INSERT [dbo].[Asset_Definition] OFF
GO
SET IDENTITY_INSERT [dbo].[Asset_Master] ON 

INSERT [dbo].[Asset_Master] ([am_id], [am_atype_id], [am_make_id], [am_ad_id], [am_model], [am_snumber], [am_myyear], [am_pdate], [am_warranty], [am_from], [am_to]) VALUES (2, 1, 11, 1, N'Galaxy S21', N'SN123456', 2021, CAST(N'2024-01-15' AS Date), 24, CAST(N'2024-01-15' AS Date), CAST(N'2026-01-15' AS Date))
INSERT [dbo].[Asset_Master] ([am_id], [am_atype_id], [am_make_id], [am_ad_id], [am_model], [am_snumber], [am_myyear], [am_pdate], [am_warranty], [am_from], [am_to]) VALUES (3, 2, 12, 2, N'Redmi Note 10', N'SN654321', 2021, CAST(N'2024-02-20' AS Date), 12, CAST(N'2024-02-20' AS Date), CAST(N'2025-02-20' AS Date))
INSERT [dbo].[Asset_Master] ([am_id], [am_atype_id], [am_make_id], [am_ad_id], [am_model], [am_snumber], [am_myyear], [am_pdate], [am_warranty], [am_from], [am_to]) VALUES (4, 3, 13, 3, N'LaserJet Pro', N'SN789012', 2020, CAST(N'2024-03-10' AS Date), 36, CAST(N'2024-03-10' AS Date), CAST(N'2027-03-10' AS Date))
INSERT [dbo].[Asset_Master] ([am_id], [am_atype_id], [am_make_id], [am_ad_id], [am_model], [am_snumber], [am_myyear], [am_pdate], [am_warranty], [am_from], [am_to]) VALUES (5, 4, 14, 4, N'MacBook Air', N'SN345678', 2022, CAST(N'2024-04-01' AS Date), 24, CAST(N'2024-04-01' AS Date), CAST(N'2026-04-01' AS Date))
INSERT [dbo].[Asset_Master] ([am_id], [am_atype_id], [am_make_id], [am_ad_id], [am_model], [am_snumber], [am_myyear], [am_pdate], [am_warranty], [am_from], [am_to]) VALUES (6, 1, 15, 5, N'Vivo V21', N'SN987654', 2021, CAST(N'2024-05-05' AS Date), 18, CAST(N'2024-05-05' AS Date), CAST(N'2025-11-05' AS Date))
SET IDENTITY_INSERT [dbo].[Asset_Master] OFF
GO
SET IDENTITY_INSERT [dbo].[Asset_Type] ON 

INSERT [dbo].[Asset_Type] ([at_id], [at_name]) VALUES (1, N'Mobile')
INSERT [dbo].[Asset_Type] ([at_id], [at_name]) VALUES (2, N'Thermal Printer')
INSERT [dbo].[Asset_Type] ([at_id], [at_name]) VALUES (3, N'Sensor')
INSERT [dbo].[Asset_Type] ([at_id], [at_name]) VALUES (4, N'Gateway')
INSERT [dbo].[Asset_Type] ([at_id], [at_name]) VALUES (5, N'Laptop')
INSERT [dbo].[Asset_Type] ([at_id], [at_name]) VALUES (6, N'Boom Barrier')
SET IDENTITY_INSERT [dbo].[Asset_Type] OFF
GO
SET IDENTITY_INSERT [dbo].[Login] ON 

INSERT [dbo].[Login] ([l_id], [Username], [Password], [Usertype]) VALUES (1, N'Merin', N'Merin@123', N'Admin')
INSERT [dbo].[Login] ([l_id], [Username], [Password], [Usertype]) VALUES (2, N'Sanjay', N'San@123', N'Purchase Manager')
INSERT [dbo].[Login] ([l_id], [Username], [Password], [Usertype]) VALUES (3, N'Rohit', N'Roh@123', N'Admin')
INSERT [dbo].[Login] ([l_id], [Username], [Password], [Usertype]) VALUES (4, N'Rani', N'Rani@123', N'Purchase Manager')
SET IDENTITY_INSERT [dbo].[Login] OFF
GO
SET IDENTITY_INSERT [dbo].[Purchase_Order] ON 

INSERT [dbo].[Purchase_Order] ([pd_id], [pd_order_no], [pd_ad_id], [pd_type_id], [pd_qty], [pd_vendor_id], [pd_date], [pd_ddate], [pd_status]) VALUES (2, N'PO001', 1, 1, 10, 11, CAST(N'2024-09-01' AS Date), CAST(N'2024-09-10' AS Date), N'Pending')
INSERT [dbo].[Purchase_Order] ([pd_id], [pd_order_no], [pd_ad_id], [pd_type_id], [pd_qty], [pd_vendor_id], [pd_date], [pd_ddate], [pd_status]) VALUES (3, N'PO002', 2, 2, 5, 12, CAST(N'2024-09-02' AS Date), CAST(N'2024-09-12' AS Date), N'Confirmed')
INSERT [dbo].[Purchase_Order] ([pd_id], [pd_order_no], [pd_ad_id], [pd_type_id], [pd_qty], [pd_vendor_id], [pd_date], [pd_ddate], [pd_status]) VALUES (4, N'PO003', 3, 3, 20, 13, CAST(N'2024-09-03' AS Date), CAST(N'2024-09-15' AS Date), N'Shipped')
INSERT [dbo].[Purchase_Order] ([pd_id], [pd_order_no], [pd_ad_id], [pd_type_id], [pd_qty], [pd_vendor_id], [pd_date], [pd_ddate], [pd_status]) VALUES (5, N'PO004', 4, 4, 15, 14, CAST(N'2024-09-04' AS Date), CAST(N'2024-09-20' AS Date), N'Delivered')
SET IDENTITY_INSERT [dbo].[Purchase_Order] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRegistration] ON 

INSERT [dbo].[UserRegistration] ([u_id], [FirstName], [LastName], [Age], [Gender], [Address], [PhoneNumber], [l_id]) VALUES (1, N'Merin', N'Anna', 28, N'Female', N'Trivandrum', N'9876543210', 1)
INSERT [dbo].[UserRegistration] ([u_id], [FirstName], [LastName], [Age], [Gender], [Address], [PhoneNumber], [l_id]) VALUES (2, N'Sanjay', N'Kumar', 35, N'Male', N'Kollam', N'9876543211', 2)
INSERT [dbo].[UserRegistration] ([u_id], [FirstName], [LastName], [Age], [Gender], [Address], [PhoneNumber], [l_id]) VALUES (3, N'Rohit', N'Sharma', 30, N'Male', N'Thrissur', N'9876543212', 3)
INSERT [dbo].[UserRegistration] ([u_id], [FirstName], [LastName], [Age], [Gender], [Address], [PhoneNumber], [l_id]) VALUES (4, N'Rani', N'Verma', 32, N'Female', N'Kottayam', N'9876543213', 4)
SET IDENTITY_INSERT [dbo].[UserRegistration] OFF
GO
SET IDENTITY_INSERT [dbo].[Vendor] ON 

INSERT [dbo].[Vendor] ([vd_id], [vd_name], [vd_type], [vd_atype_id], [vd_from], [vd_to], [vd_addr]) VALUES (9, N'Samsung', N'Supplier', 1, CAST(N'2023-01-01' AS Date), CAST(N'2025-01-01' AS Date), N'Seoul, South Korea')
INSERT [dbo].[Vendor] ([vd_id], [vd_name], [vd_type], [vd_atype_id], [vd_from], [vd_to], [vd_addr]) VALUES (10, N'MI', N'Supplier', 1, CAST(N'2023-02-15' AS Date), CAST(N'2025-02-15' AS Date), N'Beijing, China')
INSERT [dbo].[Vendor] ([vd_id], [vd_name], [vd_type], [vd_atype_id], [vd_from], [vd_to], [vd_addr]) VALUES (11, N'Vivo', N'Supplier', 1, CAST(N'2023-03-10' AS Date), CAST(N'2025-03-10' AS Date), N'Dongguan, China')
INSERT [dbo].[Vendor] ([vd_id], [vd_name], [vd_type], [vd_atype_id], [vd_from], [vd_to], [vd_addr]) VALUES (12, N'Softland India', N'Supplier', 1, CAST(N'2023-04-05' AS Date), CAST(N'2025-04-05' AS Date), N'Bangalore, India')
INSERT [dbo].[Vendor] ([vd_id], [vd_name], [vd_type], [vd_atype_id], [vd_from], [vd_to], [vd_addr]) VALUES (13, N'Mobio', N'Supplier', 2, CAST(N'2023-05-20' AS Date), CAST(N'2025-05-20' AS Date), N'Delhi, India')
INSERT [dbo].[Vendor] ([vd_id], [vd_name], [vd_type], [vd_atype_id], [vd_from], [vd_to], [vd_addr]) VALUES (14, N'ICFOSS', N'Supplier', 3, CAST(N'2023-06-01' AS Date), CAST(N'2025-06-01' AS Date), N'Thiruvananthapuram, India')
INSERT [dbo].[Vendor] ([vd_id], [vd_name], [vd_type], [vd_atype_id], [vd_from], [vd_to], [vd_addr]) VALUES (15, N'WiFi Solutions', N'Supplier', 4, CAST(N'2023-07-15' AS Date), CAST(N'2025-07-15' AS Date), N'Chennai, India')
INSERT [dbo].[Vendor] ([vd_id], [vd_name], [vd_type], [vd_atype_id], [vd_from], [vd_to], [vd_addr]) VALUES (16, N'Talent Services', N'Supplier', 5, CAST(N'2023-08-10' AS Date), CAST(N'2025-08-10' AS Date), N'Mumbai, India')
SET IDENTITY_INSERT [dbo].[Vendor] OFF
GO
ALTER TABLE [dbo].[Asset_Definition]  WITH CHECK ADD FOREIGN KEY([ad_type_id])
REFERENCES [dbo].[Asset_Type] ([at_id])
GO
ALTER TABLE [dbo].[Asset_Master]  WITH CHECK ADD FOREIGN KEY([am_ad_id])
REFERENCES [dbo].[Asset_Definition] ([ad_id])
GO
ALTER TABLE [dbo].[Asset_Master]  WITH CHECK ADD FOREIGN KEY([am_atype_id])
REFERENCES [dbo].[Asset_Type] ([at_id])
GO
ALTER TABLE [dbo].[Asset_Master]  WITH CHECK ADD FOREIGN KEY([am_make_id])
REFERENCES [dbo].[Vendor] ([vd_id])
GO
ALTER TABLE [dbo].[Purchase_Order]  WITH CHECK ADD FOREIGN KEY([pd_ad_id])
REFERENCES [dbo].[Asset_Definition] ([ad_id])
GO
ALTER TABLE [dbo].[Purchase_Order]  WITH CHECK ADD FOREIGN KEY([pd_type_id])
REFERENCES [dbo].[Asset_Type] ([at_id])
GO
ALTER TABLE [dbo].[Purchase_Order]  WITH CHECK ADD FOREIGN KEY([pd_vendor_id])
REFERENCES [dbo].[Vendor] ([vd_id])
GO
ALTER TABLE [dbo].[UserRegistration]  WITH CHECK ADD FOREIGN KEY([l_id])
REFERENCES [dbo].[Login] ([l_id])
GO
ALTER TABLE [dbo].[Vendor]  WITH CHECK ADD FOREIGN KEY([vd_atype_id])
REFERENCES [dbo].[Asset_Type] ([at_id])
GO
ALTER TABLE [dbo].[Asset_Master]  WITH CHECK ADD CHECK  (([am_myyear]>(0)))
GO
ALTER TABLE [dbo].[Login]  WITH CHECK ADD  CONSTRAINT [chk_Usertype] CHECK  (([Usertype]='Purchase Manager' OR [Usertype]='Admin'))
GO
ALTER TABLE [dbo].[Login] CHECK CONSTRAINT [chk_Usertype]
GO
ALTER TABLE [dbo].[Purchase_Order]  WITH CHECK ADD CHECK  (([pd_qty]>(0)))
GO
