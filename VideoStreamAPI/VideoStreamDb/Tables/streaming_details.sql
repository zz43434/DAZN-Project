CREATE TABLE [dbo].[streaming_details]
(
	[client_id] UNIQUEIDENTIFIER NOT NULL , 
    [video_id] UNIQUEIDENTIFIER NOT NULL, 
    [started_watching] DATETIME NOT NULL, 
    [ended_watching] DATETIME NULL, 
    PRIMARY KEY ([client_id])
)
