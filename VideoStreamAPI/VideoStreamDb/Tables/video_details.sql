CREATE TABLE [dbo].[video_details]
(
	[video_id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [video_name] NCHAR(50) NULL, 
    [video_length] INT NULL
)
