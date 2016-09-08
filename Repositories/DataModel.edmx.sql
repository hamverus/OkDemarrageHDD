
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/28/2016 21:03:54
-- Generated from EDMX file: C:\Users\GsrMed\documents\visual studio 2015\Projects\OKDemarrageIntegration\Repositories\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [test];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ValOKdIntegrt_LigneDem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ValOKdIntegrt] DROP CONSTRAINT [FK_ValOKdIntegrt_LigneDem];
GO
IF OBJECT_ID(N'[dbo].[FK_ValOKdIntegrt_OKDesription]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ValOKdIntegrt] DROP CONSTRAINT [FK_ValOKdIntegrt_OKDesription];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[LigneDem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LigneDem];
GO
IF OBJECT_ID(N'[dbo].[OKDesription]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OKDesription];
GO
IF OBJECT_ID(N'[dbo].[Pilote]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pilote];
GO
IF OBJECT_ID(N'[dbo].[Pilote Fini]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pilote Fini];
GO
IF OBJECT_ID(N'[dbo].[ValOKdIntegrt]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ValOKdIntegrt];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'LigneDem'
CREATE TABLE [dbo].[LigneDem] (
    [id] int IDENTITY(1,1) NOT NULL,
    [description] varchar(max)  NULL
);
GO

-- Creating table 'OKDesription'
CREATE TABLE [dbo].[OKDesription] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Postes] varchar(max)  NULL,
    [description] varchar(max)  NULL,
    [Module] varchar(max)  NULL
);
GO

-- Creating table 'Pilotes'
CREATE TABLE [dbo].[Pilotes] (
    [Matricule] nvarchar(50)  NOT NULL,
    [Nom] nvarchar(50)  NULL,
    [Prenom] nvarchar(50)  NULL,
    [Poste] nvarchar(50)  NULL
);
GO

-- Creating table 'Pilote_Finis'
CREATE TABLE [dbo].[Pilote_Finis] (
    [Matricule] nvarchar(50)  NOT NULL,
    [Date] datetime  NULL,
    [Nom] nvarchar(50)  NULL,
    [Prenom] nvarchar(50)  NULL
);
GO

-- Creating table 'ValOKdIntegrts'
CREATE TABLE [dbo].[ValOKdIntegrts] (
    [id] int IDENTITY(1,1) NOT NULL,
    [date] datetime  NULL,
    [ok] binary(5)  NULL,
    [nok] binary(5)  NULL,
    [na] binary(5)  NULL,
    [idDescription] int  NULL,
    [idLigne] int  NULL,
    [commentaire] varchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'LigneDem'
ALTER TABLE [dbo].[LigneDem]
ADD CONSTRAINT [PK_LigneDem]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'OKDesription'
ALTER TABLE [dbo].[OKDesription]
ADD CONSTRAINT [PK_OKDesription]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Matricule] in table 'Pilotes'
ALTER TABLE [dbo].[Pilotes]
ADD CONSTRAINT [PK_Pilotes]
    PRIMARY KEY CLUSTERED ([Matricule] ASC);
GO

-- Creating primary key on [Matricule] in table 'Pilote_Finis'
ALTER TABLE [dbo].[Pilote_Finis]
ADD CONSTRAINT [PK_Pilote_Finis]
    PRIMARY KEY CLUSTERED ([Matricule] ASC);
GO

-- Creating primary key on [id] in table 'ValOKdIntegrts'
ALTER TABLE [dbo].[ValOKdIntegrts]
ADD CONSTRAINT [PK_ValOKdIntegrts]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Matricule] in table 'Pilotes'
ALTER TABLE [dbo].[Pilotes]
ADD CONSTRAINT [FK_Pilote_Pilote_Fini]
    FOREIGN KEY ([Matricule])
    REFERENCES [dbo].[Pilote_Finis]
        ([Matricule])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [idLigne] in table 'ValOKdIntegrts'
ALTER TABLE [dbo].[ValOKdIntegrts]
ADD CONSTRAINT [FK_ValOKdIntegrt_LigneDem]
    FOREIGN KEY ([idLigne])
    REFERENCES [dbo].[LigneDem]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ValOKdIntegrt_LigneDem'
CREATE INDEX [IX_FK_ValOKdIntegrt_LigneDem]
ON [dbo].[ValOKdIntegrts]
    ([idLigne]);
GO

-- Creating foreign key on [idDescription] in table 'ValOKdIntegrts'
ALTER TABLE [dbo].[ValOKdIntegrts]
ADD CONSTRAINT [FK_ValOKdIntegrt_OKDesription]
    FOREIGN KEY ([idDescription])
    REFERENCES [dbo].[OKDesription]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ValOKdIntegrt_OKDesription'
CREATE INDEX [IX_FK_ValOKdIntegrt_OKDesription]
ON [dbo].[ValOKdIntegrts]
    ([idDescription]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------