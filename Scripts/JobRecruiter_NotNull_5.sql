/****** Script for SelectTopNRows command from SSMS  ******/


 Delete FROM [JobPortal].[dbo].[JobDetails] where CompanyName is null
 Go
 Delete FROM [JobPortal].[dbo].[JobDetails] where CompanyLocation is null 
 Go
 Delete From [JobPortal].[dbo].[JobDetails] where UserId in (Select UserId FROM [JobPortal].[dbo].[JobRecruiter] where Mobile is null Or Email is null Or 
 CompanyName is null Or firstName is null Or lastName is null)
 Go
 Delete FROM [JobPortal].[dbo].[JobRecruiter] where Mobile is null Or Email is null Or 
 CompanyName is null Or firstName is null Or lastName is null
 Go
 ALTER TABLE [JobPortal].[dbo].[JobRecruiter]
ALTER COLUMN firstName NVARCHAR(50) NOT NULL
Go
ALTER TABLE [JobPortal].[dbo].[JobRecruiter]
ALTER COLUMN lastName NVARCHAR(50) NOT NULL
 Go
 ALTER TABLE [JobPortal].[dbo].[JobRecruiter]
ALTER COLUMN Email NVARCHAR(50) NOT NULL
Go
ALTER TABLE [JobPortal].[dbo].[JobRecruiter]
ALTER COLUMN Mobile NVARCHAR(50) NOT NULL
Go
ALTER TABLE [JobPortal].[dbo].[JobRecruiter]
ALTER COLUMN CompanyName NVARCHAR(50) NOT NULL
Go
ALTER TABLE [JobPortal].[dbo].[JobRecruiter]
ALTER COLUMN CreatedAt datetime NOT NULL
Go
ALTER TABLE [JobPortal].[dbo].[JobRecruiter]
ALTER COLUMN CreatedAt datetime NOT NULL