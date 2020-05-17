IF NOT EXISTS (
        SELECT *
        FROM sys.databases
        WHERE name = 'Fakultet'
        )
BEGIN
    CREATE DATABASE [Fakultet]
END
GO

USE [Fakultet]
GO
/****** Object:  Table [dbo].[Ispit]    Script Date: 5/17/2020 12:07:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ispit](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[bi] [int] NULL,
	[predmet_id] [int] NULL,
	[ocena] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 5/17/2020 12:07:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[bi] [int] IDENTITY(1,1) NOT NULL,
	[godina_studija] [int] NULL,
	[grupa_id] [int] NULL,
	[Ime_i_prezime] [varchar](255) NULL,
	[datum_rodjenja] [datetime] NULL,
	[Grad] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[bi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Ispit] ON 

INSERT [dbo].[Ispit] ([id], [bi], [predmet_id], [ocena]) VALUES (16, 23, 2, 10)
INSERT [dbo].[Ispit] ([id], [bi], [predmet_id], [ocena]) VALUES (18, 24, 2, 9)
INSERT [dbo].[Ispit] ([id], [bi], [predmet_id], [ocena]) VALUES (19, 25, 3, 10)
INSERT [dbo].[Ispit] ([id], [bi], [predmet_id], [ocena]) VALUES (20, 26, 4, 9)
INSERT [dbo].[Ispit] ([id], [bi], [predmet_id], [ocena]) VALUES (22, 28, 1, 6)
SET IDENTITY_INSERT [dbo].[Ispit] OFF
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([bi], [godina_studija], [grupa_id], [Ime_i_prezime], [datum_rodjenja], [Grad]) VALUES (23, 3, 2, N'Filip Vujanovic', CAST(N'1992-08-27T00:00:00.000' AS DateTime), N'Cacak')
INSERT [dbo].[Student] ([bi], [godina_studija], [grupa_id], [Ime_i_prezime], [datum_rodjenja], [Grad]) VALUES (24, 3, 2, N'Jela Popovic', CAST(N'1965-11-10T00:00:00.000' AS DateTime), N'Sombor')
INSERT [dbo].[Student] ([bi], [godina_studija], [grupa_id], [Ime_i_prezime], [datum_rodjenja], [Grad]) VALUES (25, 3, 3, N'Vladimir Vujanovic', CAST(N'1965-08-16T00:00:00.000' AS DateTime), N'Kraljevo')
INSERT [dbo].[Student] ([bi], [godina_studija], [grupa_id], [Ime_i_prezime], [datum_rodjenja], [Grad]) VALUES (26, 3, 3, N'Slobodan Popovic', CAST(N'1987-06-20T00:00:00.000' AS DateTime), N'Nis')
INSERT [dbo].[Student] ([bi], [godina_studija], [grupa_id], [Ime_i_prezime], [datum_rodjenja], [Grad]) VALUES (27, 3, 3, N'Dejan Jovanovski', CAST(N'1984-01-05T00:00:00.000' AS DateTime), N'Beograd')
INSERT [dbo].[Student] ([bi], [godina_studija], [grupa_id], [Ime_i_prezime], [datum_rodjenja], [Grad]) VALUES (28, 1, 3, N'Nevena Vasovic', CAST(N'1989-02-10T00:00:00.000' AS DateTime), N'Novi sad')
SET IDENTITY_INSERT [dbo].[Student] OFF
/****** Object:  StoredProcedure [dbo].[BrisanjeIspita]    Script Date: 5/17/2020 12:07:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[BrisanjeIspita]  
(  
   @id int  
)  
as   
begin  
   Delete from Ispit where id=@id 
End
GO
/****** Object:  StoredProcedure [dbo].[BrisanjeStudenta]    Script Date: 5/17/2020 12:07:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[BrisanjeStudenta]  
(  
   @bi int  
)  
as   
begin  
   Delete from Student where bi=@bi  
End
GO
/****** Object:  StoredProcedure [dbo].[DodajIspit]    Script Date: 5/17/2020 12:07:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DodajIspit]  
(  
   @bi int,  
   @predmet_id int,  
   @ocena int
)  
as  
begin  
   Insert into Ispit values(@bi,@predmet_id,@ocena)  
End
GO
/****** Object:  StoredProcedure [dbo].[DodajStudenta]    Script Date: 5/17/2020 12:07:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[DodajStudenta]  
(  
   @godina_studija int,  
   @grupa_id int,  
   @Ime_i_prezime nvarchar (100) ,
   @datum_rodjenja datetime,
   @Grad nvarchar (100)
)  
as  
begin  
   Insert into Student values(@godina_studija,@grupa_id,@Ime_i_prezime,@datum_rodjenja,@Grad)  
End
GO
/****** Object:  StoredProcedure [dbo].[IzmenaIspita]    Script Date: 5/17/2020 12:07:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[IzmenaIspita]  
(   @id int,
	@bi int,
   @predmet_id int,  
   @ocena int
)  
as  
begin  
   Update  Ispit set bi=@bi,
   predmet_id=@predmet_id,
   ocena=@ocena
   where id=@id
End
GO
/****** Object:  StoredProcedure [dbo].[IzmenaStudenta]    Script Date: 5/17/2020 12:07:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[IzmenaStudenta]  
(  @bi int,
   @godina_studija int,  
   @grupa_id int,  
   @Ime_i_prezime nvarchar (100) ,
   @datum_rodjenja datetime,
   @Grad nvarchar (100)
)  
as  
begin  
   Update  Student set godina_studija=@godina_studija,
   grupa_id=@grupa_id,
   Ime_i_prezime=@Ime_i_prezime,
   datum_rodjenja=@datum_rodjenja,
   Grad = @Grad
   where bi=@bi
End
GO
/****** Object:  StoredProcedure [dbo].[SortirajGradove]    Script Date: 5/17/2020 12:07:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SortirajGradove]  

as   
begin  
select top(5) grad,avg(ocena) as ocena from Student
inner join Ispit on Student.bi = Ispit.bi
where godina_studija = 3
group by grad
order by ocena desc
End
GO
/****** Object:  StoredProcedure [dbo].[SortirajStudente]    Script Date: 5/17/2020 12:07:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SortirajStudente]  

as   
begin  
select Ime_i_prezime as 'Ime i prezime',ocena from Ispit 
inner join Student on Ispit.bi = Student.bi
where Ispit.bi = Student.bi
order by ocena desc

			 End



GO
/****** Object:  StoredProcedure [dbo].[VratiIspite]    Script Date: 5/17/2020 12:07:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[VratiIspite]  
as  
begin  
   select * from Ispit
End
GO
/****** Object:  StoredProcedure [dbo].[VratiNajstarijeStudente]    Script Date: 5/17/2020 12:07:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[VratiNajstarijeStudente]  

as   
begin  
Select * From  Student s
Where datum_rodjenja = (Select Min(datum_rodjenja)
             From Student
             Where grupa_id = s.grupa_id)
			 End
GO
/****** Object:  StoredProcedure [dbo].[VratiStudente]    Script Date: 5/17/2020 12:07:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[VratiStudente]  
as  
begin  
   select * from Student
End
GO
