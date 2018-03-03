GO
USE [HRM_System]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 03-Mar-18 3:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[admin_name] [nvarchar](250) NULL,
	[admin_email] [nvarchar](250) NULL,
	[admin_password] [nvarchar](250) NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Attendence]    Script Date: 03-Mar-18 3:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attendence](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[atten_emp_id] [int] NULL,
	[atten_status] [bit] NOT NULL,
	[atten_leave_type_id] [int] NULL,
	[atten_date] [datetime] NULL,
	[atten_reason] [nvarchar](max) NULL,
 CONSTRAINT [PK_Attendence] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Award]    Script Date: 03-Mar-18 3:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Award](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[award_emp_id] [int] NULL,
	[award_name] [nvarchar](100) NULL,
	[award_reason] [nvarchar](max) NULL,
	[award_cash_price] [float] NULL,
	[award_date] [datetime] NULL,
 CONSTRAINT [PK_Award] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departament]    Script Date: 03-Mar-18 3:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departament](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[depart_name] [nvarchar](100) NULL,
 CONSTRAINT [PK_Departament] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Designation]    Script Date: 03-Mar-18 3:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Designation](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[desig_name] [nvarchar](100) NULL,
	[depart_id] [int] NULL,
 CONSTRAINT [PK_Designation] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 03-Mar-18 3:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[emp_fullname] [nvarchar](100) NULL,
	[emp_fathername] [nvarchar](50) NULL,
	[emp_dateof_birth] [datetime] NULL,
	[emp_gender_id] [int] NULL,
	[emp_phone] [nvarchar](50) NULL,
	[emp_address] [nvarchar](500) NULL,
	[emp_photo] [nvarchar](max) NULL,
	[emp_email] [nvarchar](100) NULL,
	[emp_password] [nvarchar](500) NULL,
	[emp_dep_id] [int] NULL,
	[emp_desig_id] [int] NULL,
	[emp_date_of_joining] [date] NULL,
	[emp_exit_date] [datetime] NULL,
	[emp_work_status] [bit] NOT NULL,
	[emp_salary] [float] NULL,
	[emp_resume] [nvarchar](max) NULL,
	[emp_offer_letter] [nvarchar](max) NULL,
	[emp_joining_letter] [nvarchar](max) NULL,
	[emp_contact_and_argue] [nvarchar](max) NULL,
	[emp_ID_proof] [nvarchar](max) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gender]    Script Date: 03-Mar-18 3:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gender](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[gender_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Holiday]    Script Date: 03-Mar-18 3:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Holiday](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[holiday_name] [nvarchar](100) NULL,
	[holiday_date] [datetime] NULL,
 CONSTRAINT [PK_Holiday] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Leave_App]    Script Date: 03-Mar-18 3:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Leave_App](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[leave_emp_id] [int] NULL,
	[leave_date] [datetime] NULL,
	[leave_reason] [nvarchar](max) NULL,
	[leave_status_id] [int] NULL,
 CONSTRAINT [PK_Leave_App] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Leave_status]    Script Date: 03-Mar-18 3:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Leave_status](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[status_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Leave_status] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Leave_type]    Script Date: 03-Mar-18 3:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Leave_type](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Leave_type] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notice_Board]    Script Date: 03-Mar-18 3:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notice_Board](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[notice_title] [nvarchar](100) NULL,
	[notice_content] [nvarchar](max) NULL,
	[notice_status] [bit] NOT NULL,
	[notice_depart_id] [int] NULL,
 CONSTRAINT [PK_Notice_Board] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Admin] ON 

INSERT [dbo].[Admin] ([id], [admin_name], [admin_email], [admin_password]) VALUES (1, N'admin', N'admin', N'admin')
SET IDENTITY_INSERT [dbo].[Admin] OFF
SET IDENTITY_INSERT [dbo].[Attendence] ON 

INSERT [dbo].[Attendence] ([id], [atten_emp_id], [atten_status], [atten_leave_type_id], [atten_date], [atten_reason]) VALUES (47, 8, 0, 1, CAST(N'2018-02-23T00:00:00.000' AS DateTime), N'Emisi golunu toyudu')
INSERT [dbo].[Attendence] ([id], [atten_emp_id], [atten_status], [atten_leave_type_id], [atten_date], [atten_reason]) VALUES (48, 6, 1, NULL, CAST(N'2018-02-23T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Attendence] ([id], [atten_emp_id], [atten_status], [atten_leave_type_id], [atten_date], [atten_reason]) VALUES (49, 7, 1, NULL, CAST(N'2018-02-23T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Attendence] ([id], [atten_emp_id], [atten_status], [atten_leave_type_id], [atten_date], [atten_reason]) VALUES (50, 9, 1, NULL, CAST(N'2018-02-23T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Attendence] ([id], [atten_emp_id], [atten_status], [atten_leave_type_id], [atten_date], [atten_reason]) VALUES (51, 6, 0, 2, CAST(N'2018-02-23T00:00:00.000' AS DateTime), N'Qizdirmasi qalxib ')
INSERT [dbo].[Attendence] ([id], [atten_emp_id], [atten_status], [atten_leave_type_id], [atten_date], [atten_reason]) VALUES (52, 7, 1, NULL, CAST(N'2018-02-23T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Attendence] ([id], [atten_emp_id], [atten_status], [atten_leave_type_id], [atten_date], [atten_reason]) VALUES (53, 8, 1, NULL, CAST(N'2018-02-23T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Attendence] ([id], [atten_emp_id], [atten_status], [atten_leave_type_id], [atten_date], [atten_reason]) VALUES (54, 9, 1, NULL, CAST(N'2018-02-23T00:00:00.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Attendence] OFF
SET IDENTITY_INSERT [dbo].[Award] ON 

INSERT [dbo].[Award] ([id], [award_emp_id], [award_name], [award_reason], [award_cash_price], [award_date]) VALUES (1, 6, N'Ayin ishchisi', N'Ish saatindan elave ishlediyi uchun', 50, CAST(N'2018-02-13T00:00:00.000' AS DateTime))
INSERT [dbo].[Award] ([id], [award_emp_id], [award_name], [award_reason], [award_cash_price], [award_date]) VALUES (2, 7, N'Ayin ishchisi', N'Bu ay yaxhi ishlediyi uchun', 70, CAST(N'2018-02-11T00:00:00.000' AS DateTime))
INSERT [dbo].[Award] ([id], [award_emp_id], [award_name], [award_reason], [award_cash_price], [award_date]) VALUES (3, 9, N'Lahiye bitmesi', N'Son lahiyeni vaxdindan tez bitirdiyi uchun ', 50, CAST(N'2018-01-09T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Award] OFF
SET IDENTITY_INSERT [dbo].[Departament] ON 

INSERT [dbo].[Departament] ([id], [depart_name]) VALUES (6, N'Java')
INSERT [dbo].[Departament] ([id], [depart_name]) VALUES (8, N'C#')
SET IDENTITY_INSERT [dbo].[Departament] OFF
SET IDENTITY_INSERT [dbo].[Designation] ON 

INSERT [dbo].[Designation] ([id], [desig_name], [depart_id]) VALUES (4, N'Senior Java Developer', 6)
INSERT [dbo].[Designation] ([id], [desig_name], [depart_id]) VALUES (5, N'Fresher Java Developer', 6)
INSERT [dbo].[Designation] ([id], [desig_name], [depart_id]) VALUES (6, N'Junior Java Devloper', 6)
INSERT [dbo].[Designation] ([id], [desig_name], [depart_id]) VALUES (12, N'Senour C# Developer', 8)
INSERT [dbo].[Designation] ([id], [desig_name], [depart_id]) VALUES (13, N'Junior C# Developer', 8)
INSERT [dbo].[Designation] ([id], [desig_name], [depart_id]) VALUES (14, N'Fresher C# Developer', 8)
SET IDENTITY_INSERT [dbo].[Designation] OFF
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([id], [emp_fullname], [emp_fathername], [emp_dateof_birth], [emp_gender_id], [emp_phone], [emp_address], [emp_photo], [emp_email], [emp_password], [emp_dep_id], [emp_desig_id], [emp_date_of_joining], [emp_exit_date], [emp_work_status], [emp_salary], [emp_resume], [emp_offer_letter], [emp_joining_letter], [emp_contact_and_argue], [emp_ID_proof]) VALUES (6, N'Elcin Quliyev', N'Tahir', CAST(N'2018-02-06T00:00:00.000' AS DateTime), 1, N'qwsertyu', N'wertyui', N'02212018102055778AM52318_1400148330.jpg', N'serdtyu', N'ertui', 6, 4, CAST(N'2017-12-13' AS Date), NULL, 1, 46456, N'02212018174941679PMresume.pdf', N'c:\users\sakit\source\repos\HRM_Management_System\HRM_Management_System\Files\02212018114022987AMoffer_letter.pdf', N'02212018113323131AMjoining_letter.pdf', N'02212018111422726AMcontact_and_argue.pdf', N'02212018110823824AMID_proof.pdf')
INSERT [dbo].[Employee] ([id], [emp_fullname], [emp_fathername], [emp_dateof_birth], [emp_gender_id], [emp_phone], [emp_address], [emp_photo], [emp_email], [emp_password], [emp_dep_id], [emp_desig_id], [emp_date_of_joining], [emp_exit_date], [emp_work_status], [emp_salary], [emp_resume], [emp_offer_letter], [emp_joining_letter], [emp_contact_and_argue], [emp_ID_proof]) VALUES (7, N'Mehemmed Eliyev', N'Elxan', CAST(N'1992-02-08T00:00:00.000' AS DateTime), 1, N'055-255-65-36', N'Xirdalan sheh', N'02212018135523360PMphoto.jpg', N'mehemmed@gmail.com', N'123', 6, 4, CAST(N'2018-01-05' AS Date), NULL, 1, 500, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Employee] ([id], [emp_fullname], [emp_fathername], [emp_dateof_birth], [emp_gender_id], [emp_phone], [emp_address], [emp_photo], [emp_email], [emp_password], [emp_dep_id], [emp_desig_id], [emp_date_of_joining], [emp_exit_date], [emp_work_status], [emp_salary], [emp_resume], [emp_offer_letter], [emp_joining_letter], [emp_contact_and_argue], [emp_ID_proof]) VALUES (8, N'Bil Gates', N'Juhannes', CAST(N'1983-10-10T00:00:00.000' AS DateTime), 1, N'050-569-89-74', N'ABS -in Elsoltanli kendinnen', N'02212018191206862PMbill-gates.jpg', N'bill@gmail.com', N'123', 8, 5, CAST(N'2017-12-01' AS Date), NULL, 1, 350.78, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Employee] ([id], [emp_fullname], [emp_fathername], [emp_dateof_birth], [emp_gender_id], [emp_phone], [emp_address], [emp_photo], [emp_email], [emp_password], [emp_dep_id], [emp_desig_id], [emp_date_of_joining], [emp_exit_date], [emp_work_status], [emp_salary], [emp_resume], [emp_offer_letter], [emp_joining_letter], [emp_contact_and_argue], [emp_ID_proof]) VALUES (9, N'Sakit Memmedli', N'Elsad', CAST(N'1996-04-08T00:00:00.000' AS DateTime), 1, N'070-875-65-79', N'Absheron ray Mehdiabad qes', N'02212018192334424PMresume.JPG', N'memmedlisakit@gmail.com', N'sakit9696', 8, 5, CAST(N'2017-06-21' AS Date), NULL, 1, 700, N'02212018192334429PMresume.pdf', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Employee] OFF
SET IDENTITY_INSERT [dbo].[Gender] ON 

INSERT [dbo].[Gender] ([id], [gender_name]) VALUES (1, N'Male')
INSERT [dbo].[Gender] ([id], [gender_name]) VALUES (2, N'Female')
SET IDENTITY_INSERT [dbo].[Gender] OFF
SET IDENTITY_INSERT [dbo].[Holiday] ON 

INSERT [dbo].[Holiday] ([id], [holiday_name], [holiday_date]) VALUES (1, N'Novruz Bayrami', CAST(N'2018-03-20T00:00:00.000' AS DateTime))
INSERT [dbo].[Holiday] ([id], [holiday_name], [holiday_date]) VALUES (2, N'Sunday', CAST(N'2018-02-25T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Holiday] OFF
SET IDENTITY_INSERT [dbo].[Leave_App] ON 

INSERT [dbo].[Leave_App] ([id], [leave_emp_id], [leave_date], [leave_reason], [leave_status_id]) VALUES (1, 8, CAST(N'2018-02-05T00:00:00.000' AS DateTime), N'Emoglumun Toyudu gele bilmeyecem.', 2)
INSERT [dbo].[Leave_App] ([id], [leave_emp_id], [leave_date], [leave_reason], [leave_status_id]) VALUES (2, 9, CAST(N'2018-02-27T00:00:00.000' AS DateTime), N'Voynkomat chaqirib rayna getmeliyem', 1)
INSERT [dbo].[Leave_App] ([id], [leave_emp_id], [leave_date], [leave_reason], [leave_status_id]) VALUES (3, 8, CAST(N'2018-02-23T00:00:00.000' AS DateTime), N'Mashini usdaya aparmaliyam tekerlerde yaman razval var', 3)
INSERT [dbo].[Leave_App] ([id], [leave_emp_id], [leave_date], [leave_reason], [leave_status_id]) VALUES (1002, 7, CAST(N'2018-03-05T00:00:00.000' AS DateTime), N'Dish hekimine getmeliyem', 2)
INSERT [dbo].[Leave_App] ([id], [leave_emp_id], [leave_date], [leave_reason], [leave_status_id]) VALUES (1003, 7, CAST(N'2018-03-20T00:00:00.000' AS DateTime), N'Bayramla elaqeder gele bilmeyecem', 1)
SET IDENTITY_INSERT [dbo].[Leave_App] OFF
SET IDENTITY_INSERT [dbo].[Leave_status] ON 

INSERT [dbo].[Leave_status] ([id], [status_name]) VALUES (1, N'Waiting')
INSERT [dbo].[Leave_status] ([id], [status_name]) VALUES (2, N'Accepted')
INSERT [dbo].[Leave_status] ([id], [status_name]) VALUES (3, N'Rejected')
SET IDENTITY_INSERT [dbo].[Leave_status] OFF
SET IDENTITY_INSERT [dbo].[Leave_type] ON 

INSERT [dbo].[Leave_type] ([id], [type_name]) VALUES (1, N'with permission')
INSERT [dbo].[Leave_type] ([id], [type_name]) VALUES (2, N'with out permission')
SET IDENTITY_INSERT [dbo].[Leave_type] OFF
SET IDENTITY_INSERT [dbo].[Notice_Board] ON 

INSERT [dbo].[Notice_Board] ([id], [notice_title], [notice_content], [notice_status], [notice_depart_id]) VALUES (2, N'Yeni dil oyrenmek', N'Java developerler Ruby oyrenmelidir Rubyde yazilmali Web app var.', 1, 6)
INSERT [dbo].[Notice_Board] ([id], [notice_title], [notice_content], [notice_status], [notice_depart_id]) VALUES (3, N'Maas Artirilmasi', N'Butun Ishchilerin maasi 25% artilir', 1, NULL)
INSERT [dbo].[Notice_Board] ([id], [notice_title], [notice_content], [notice_status], [notice_depart_id]) VALUES (4, N'C# Developer Meeting', N'Boyuk bir HRM lahiyesi gelib onu muzakire etmek lazmdi.', 1, 8)
INSERT [dbo].[Notice_Board] ([id], [notice_title], [notice_content], [notice_status], [notice_depart_id]) VALUES (5, N'Java dev', N'Mobile Android app yazilmalidi.', 1, 6)
INSERT [dbo].[Notice_Board] ([id], [notice_title], [notice_content], [notice_status], [notice_depart_id]) VALUES (6, N'Bayram Tebriki', N'18 Mart Boyuk zalda bayram tebriki merasimi olacaq', 1, NULL)
INSERT [dbo].[Notice_Board] ([id], [notice_title], [notice_content], [notice_status], [notice_depart_id]) VALUES (7, N'Imtahan', N'Microsoft MSSA Certificatena hazirliq uchun kitablar  verilecek', 1, 8)
SET IDENTITY_INSERT [dbo].[Notice_Board] OFF
ALTER TABLE [dbo].[Attendence]  WITH CHECK ADD  CONSTRAINT [FK_Attendence_Employee] FOREIGN KEY([atten_emp_id])
REFERENCES [dbo].[Employee] ([id])
GO
ALTER TABLE [dbo].[Attendence] CHECK CONSTRAINT [FK_Attendence_Employee]
GO
ALTER TABLE [dbo].[Attendence]  WITH CHECK ADD  CONSTRAINT [FK_Attendence_Leave_type] FOREIGN KEY([atten_leave_type_id])
REFERENCES [dbo].[Leave_type] ([id])
GO
ALTER TABLE [dbo].[Attendence] CHECK CONSTRAINT [FK_Attendence_Leave_type]
GO
ALTER TABLE [dbo].[Award]  WITH CHECK ADD  CONSTRAINT [FK_Award_Employee] FOREIGN KEY([award_emp_id])
REFERENCES [dbo].[Employee] ([id])
GO
ALTER TABLE [dbo].[Award] CHECK CONSTRAINT [FK_Award_Employee]
GO
ALTER TABLE [dbo].[Designation]  WITH CHECK ADD  CONSTRAINT [FK_Designation_Designation] FOREIGN KEY([depart_id])
REFERENCES [dbo].[Departament] ([id])
GO
ALTER TABLE [dbo].[Designation] CHECK CONSTRAINT [FK_Designation_Designation]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Departament] FOREIGN KEY([emp_dep_id])
REFERENCES [dbo].[Departament] ([id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Departament]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Designation] FOREIGN KEY([emp_desig_id])
REFERENCES [dbo].[Designation] ([id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Designation]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Gender] FOREIGN KEY([emp_gender_id])
REFERENCES [dbo].[Gender] ([id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Gender]
GO
ALTER TABLE [dbo].[Leave_App]  WITH CHECK ADD  CONSTRAINT [FK_Leave_App_Employee] FOREIGN KEY([leave_emp_id])
REFERENCES [dbo].[Employee] ([id])
GO
ALTER TABLE [dbo].[Leave_App] CHECK CONSTRAINT [FK_Leave_App_Employee]
GO
ALTER TABLE [dbo].[Leave_App]  WITH CHECK ADD  CONSTRAINT [FK_Leave_App_Leave_status] FOREIGN KEY([leave_status_id])
REFERENCES [dbo].[Leave_status] ([id])
GO
ALTER TABLE [dbo].[Leave_App] CHECK CONSTRAINT [FK_Leave_App_Leave_status]
GO
ALTER TABLE [dbo].[Notice_Board]  WITH CHECK ADD  CONSTRAINT [FK_Notice_Board_Departament] FOREIGN KEY([notice_depart_id])
REFERENCES [dbo].[Departament] ([id])
GO
ALTER TABLE [dbo].[Notice_Board] CHECK CONSTRAINT [FK_Notice_Board_Departament]
GO
USE [master]
GO
ALTER DATABASE [HRM_System] SET  READ_WRITE 
GO
