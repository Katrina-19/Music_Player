CREATE TABLE Users (
	[UserId] INT Identity NOT NULL,
	[Name] NVARCHAR(MAX) NULL,
	[Email] NVARCHAR(MAX) NULL,
	[Password] NVARCHAR(MAX) NULL,
	CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED ([UserId] ASC)
);

CREATE TABLE UserLines (
	[UserLineId] INT IDENTITY NOT NULL,
	[Song_SongID] INT NULL,
	[User_UserId] INT NULL,
	CONSTRAINT [PK_dbo.UserLines] PRIMARY KEY CLUSTERED ([UserLineId] ASC),
	CONSTRAINT [FK_dbo.UserLines_dbo.Song_SongID] FOREIGN KEY
		([Song_SongID]) REFERENCES [dbo].[Songs] ([SongID]),
	CONSTRAINT [FK_dbo.UserLines_dbo.User_UserId] FOREIGN KEY
		([User_UserId]) REFERENCES [dbo].[Users] ([UserId])
);