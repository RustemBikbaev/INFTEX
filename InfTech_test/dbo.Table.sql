CREATE TABLE [dbo].[Table]
(
	[Folder_code]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (400) NOT NULL,
    [Parent_folder_code] NVARCHAR (400) NOT NULL,
    PRIMARY KEY CLUSTERED ([Folder_code] ASC)
)
