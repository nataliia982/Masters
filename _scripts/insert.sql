USE [Socio]
GO
SET IDENTITY_INSERT [dbo].[Conversations] ON 

INSERT [dbo].[Conversations] ([Id], [DateCreated], [IsDeleted]) VALUES (1013, CAST(N'2017-12-27 20:42:33.530' AS DateTime), 0)
INSERT [dbo].[Conversations] ([Id], [DateCreated], [IsDeleted]) VALUES (1014, CAST(N'2017-12-27 20:42:46.437' AS DateTime), 0)
INSERT [dbo].[Conversations] ([Id], [DateCreated], [IsDeleted]) VALUES (1015, CAST(N'2017-12-27 22:06:42.260' AS DateTime), 0)
INSERT [dbo].[Conversations] ([Id], [DateCreated], [IsDeleted]) VALUES (1016, CAST(N'2017-12-27 22:06:53.650' AS DateTime), 0)
INSERT [dbo].[Conversations] ([Id], [DateCreated], [IsDeleted]) VALUES (1017, CAST(N'2017-12-27 22:07:01.837' AS DateTime), 0)
INSERT [dbo].[Conversations] ([Id], [DateCreated], [IsDeleted]) VALUES (1018, CAST(N'2017-12-27 22:07:11.590' AS DateTime), 0)
INSERT [dbo].[Conversations] ([Id], [DateCreated], [IsDeleted]) VALUES (1019, CAST(N'2017-12-27 22:08:26.597' AS DateTime), 0)
INSERT [dbo].[Conversations] ([Id], [DateCreated], [IsDeleted]) VALUES (1020, CAST(N'2017-12-27 22:08:40.807' AS DateTime), 0)
INSERT [dbo].[Conversations] ([Id], [DateCreated], [IsDeleted]) VALUES (1021, CAST(N'2017-12-27 22:09:30.583' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Conversations] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Login], [Password], [Email], [IsBanned], [Role], [Name], [Surname], [Position], [BirthDate], [Phone], [ProfileImageUrl], [WebsiteLink], [FacebookLink], [TwitterLink], [City], [DateCreated], [IsDeleted]) VALUES (1, N'palayda', N'1', N'palayda@gmail.com', 0, N'User', N'Rostyk', N'Palayda', N'IOS Developer', CAST(N'1995-12-12 19:29:31.117' AS DateTime), N'+12345677889', N'assets/user-images/user6.png', N'www.yoursite.com', N'palayda', N'palayda', N'Lviv', CAST(N'2017-10-01 19:30:08.140' AS DateTime), 0)
INSERT [dbo].[Users] ([Id], [Login], [Password], [Email], [IsBanned], [Role], [Name], [Surname], [Position], [BirthDate], [Phone], [ProfileImageUrl], [WebsiteLink], [FacebookLink], [TwitterLink], [City], [DateCreated], [IsDeleted]) VALUES (2, N'marta', N'1', N'maher@gmail.com', 0, N'User', N'Marta', N'Maherovska', N'.NET developer', CAST(N'1996-12-13 17:14:17.807' AS DateTime), N'+234567890', N'assets/user-images/user5.png', N'www.yoursite.com', N'maherovska', N'maherovska', N'Lviv', CAST(N'2017-10-01 17:14:45.980' AS DateTime), 0)
INSERT [dbo].[Users] ([Id], [Login], [Password], [Email], [IsBanned], [Role], [Name], [Surname], [Position], [BirthDate], [Phone], [ProfileImageUrl], [WebsiteLink], [FacebookLink], [TwitterLink], [City], [DateCreated], [IsDeleted]) VALUES (3, N'banned', N'1', N'aaa@aaa.aaa', 1, N'User', N'Olene', N'Diduh', N'Teacher', CAST(N'1980-05-31 13:09:08.223' AS DateTime), N'', N'assets/user-images/user1.png', N'www.yoursite.com', NULL, NULL, N'Odessa', CAST(N'2017-10-01 13:10:06.013' AS DateTime), 0)
INSERT [dbo].[Users] ([Id], [Login], [Password], [Email], [IsBanned], [Role], [Name], [Surname], [Position], [BirthDate], [Phone], [ProfileImageUrl], [WebsiteLink], [FacebookLink], [TwitterLink], [City], [DateCreated], [IsDeleted]) VALUES (4, N'ivan', N'1', N'ivan@gmail.com', 0, N'User', N'Ivan', N'Holub', N'Doctor', CAST(N'2017-06-12 12:11:47.663' AS DateTime), N'+7867564', N'assets/user-images/user2.png', NULL, NULL, NULL, N'London', CAST(N'2017-10-01 12:12:30.567' AS DateTime), 0)
INSERT [dbo].[Users] ([Id], [Login], [Password], [Email], [IsBanned], [Role], [Name], [Surname], [Position], [BirthDate], [Phone], [ProfileImageUrl], [WebsiteLink], [FacebookLink], [TwitterLink], [City], [DateCreated], [IsDeleted]) VALUES (5, N'mmarta', N'1', N'marta@gmail.com', 0, N'User', N'Sasha', N'Matviy', N'Java Developer', CAST(N'2017-10-24 21:11:03.623' AS DateTime), N'+78787', N'assets/user-images/user3.png', NULL, NULL, NULL, N'Kyiv', CAST(N'2017-10-01 21:11:50.203' AS DateTime), 0)
INSERT [dbo].[Users] ([Id], [Login], [Password], [Email], [IsBanned], [Role], [Name], [Surname], [Position], [BirthDate], [Phone], [ProfileImageUrl], [WebsiteLink], [FacebookLink], [TwitterLink], [City], [DateCreated], [IsDeleted]) VALUES (6, N'rostyk', N'1', N'test@test.com', 0, N'User', N'Oleh', N'Kinah', N'Dancer', CAST(N'1997-11-17 12:26:13.547' AS DateTime), N'1234567', N'assets/user-images/user4.png', N'www.yoursite.com', NULL, NULL, N'Harkiv', CAST(N'2017-11-17 12:26:46.557' AS DateTime), 0)
INSERT [dbo].[Users] ([Id], [Login], [Password], [Email], [IsBanned], [Role], [Name], [Surname], [Position], [BirthDate], [Phone], [ProfileImageUrl], [WebsiteLink], [FacebookLink], [TwitterLink], [City], [DateCreated], [IsDeleted]) VALUES (7, N'admin', N'1', N'admin@admin.com', 0, N'Admin', N'Admin', N'Admin', N'Admin', CAST(N'2017-11-26 14:25:44.483' AS DateTime), N'', N'', N'', N'', N'', N'', CAST(N'2017-11-26 14:26:11.763' AS DateTime), 0)
INSERT [dbo].[Users] ([Id], [Login], [Password], [Email], [IsBanned], [Role], [Name], [Surname], [Position], [BirthDate], [Phone], [ProfileImageUrl], [WebsiteLink], [FacebookLink], [TwitterLink], [City], [DateCreated], [IsDeleted]) VALUES (8, N'oleh', N'1', N'oleh@gmail.com', 0, N'User', N'Oleh', N'Homyn', N'.NET developer', CAST(N'1996-12-27 22:00:02.917' AS DateTime), N'+1234567890', N'assets/user-images/user12.png', N'www.yoursite.com', N'homyn', N'homyn', N'Lviv', CAST(N'2017-12-27 22:00:02.917' AS DateTime), 0)
INSERT [dbo].[Users] ([Id], [Login], [Password], [Email], [IsBanned], [Role], [Name], [Surname], [Position], [BirthDate], [Phone], [ProfileImageUrl], [WebsiteLink], [FacebookLink], [TwitterLink], [City], [DateCreated], [IsDeleted]) VALUES (9, N'roman', N'1', N'roma@gmail.com', 0, N'User', N'Roman', N'Pretsel', N'.NET developer', CAST(N'1996-12-27 22:00:02.917' AS DateTime), N'+32345678956', N'assets/user-images/user13.png', N'www.yoursite.com', N'pretsel', N'pretsel', N'Lviv', CAST(N'2017-12-27 22:00:37.957' AS DateTime), 0)
INSERT [dbo].[Users] ([Id], [Login], [Password], [Email], [IsBanned], [Role], [Name], [Surname], [Position], [BirthDate], [Phone], [ProfileImageUrl], [WebsiteLink], [FacebookLink], [TwitterLink], [City], [DateCreated], [IsDeleted]) VALUES (10, N'mykola', N'1', N'malyk@gmail.com', 0, N'User', N'Mykola', N'Malyk', N'.NET developer', CAST(N'1996-12-27 22:00:02.917' AS DateTime), N'+23456789034', N'assets/user-images/user10.png', N'www.yoursite.com', N'malyk', N'malyk', N'Lviv', CAST(N'2017-12-27 22:01:55.747' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Users] OFF
SET IDENTITY_INSERT [dbo].[Messages] ON 

INSERT [dbo].[Messages] ([Id], [Body], [DateCreated], [IsDeleted], [User_Id], [Conversation_Id]) VALUES (1030, N'TEST', CAST(N'2017-12-27 20:42:37.653' AS DateTime), 0, 2, 1013)
INSERT [dbo].[Messages] ([Id], [Body], [DateCreated], [IsDeleted], [User_Id], [Conversation_Id]) VALUES (1031, N'Hello!', CAST(N'2017-12-27 20:42:51.850' AS DateTime), 0, 2, 1014)
INSERT [dbo].[Messages] ([Id], [Body], [DateCreated], [IsDeleted], [User_Id], [Conversation_Id]) VALUES (1032, N'Hello', CAST(N'2017-12-27 22:06:46.443' AS DateTime), 0, 10, 1015)
INSERT [dbo].[Messages] ([Id], [Body], [DateCreated], [IsDeleted], [User_Id], [Conversation_Id]) VALUES (1033, N'Hello', CAST(N'2017-12-27 22:06:56.330' AS DateTime), 0, 10, 1016)
INSERT [dbo].[Messages] ([Id], [Body], [DateCreated], [IsDeleted], [User_Id], [Conversation_Id]) VALUES (1034, N'Hello', CAST(N'2017-12-27 22:07:05.803' AS DateTime), 0, 10, 1017)
INSERT [dbo].[Messages] ([Id], [Body], [DateCreated], [IsDeleted], [User_Id], [Conversation_Id]) VALUES (1035, N'Hi!', CAST(N'2017-12-27 22:07:14.720' AS DateTime), 0, 10, 1018)
INSERT [dbo].[Messages] ([Id], [Body], [DateCreated], [IsDeleted], [User_Id], [Conversation_Id]) VALUES (1036, N'Hi', CAST(N'2017-12-27 22:08:21.643' AS DateTime), 0, 9, 1017)
INSERT [dbo].[Messages] ([Id], [Body], [DateCreated], [IsDeleted], [User_Id], [Conversation_Id]) VALUES (1037, N'HI', CAST(N'2017-12-27 22:08:30.467' AS DateTime), 0, 9, 1019)
INSERT [dbo].[Messages] ([Id], [Body], [DateCreated], [IsDeleted], [User_Id], [Conversation_Id]) VALUES (1038, N'hello', CAST(N'2017-12-27 22:08:43.310' AS DateTime), 0, 9, 1020)
INSERT [dbo].[Messages] ([Id], [Body], [DateCreated], [IsDeleted], [User_Id], [Conversation_Id]) VALUES (1039, N'hi!', CAST(N'2017-12-27 22:09:08.327' AS DateTime), 0, 8, 1016)
INSERT [dbo].[Messages] ([Id], [Body], [DateCreated], [IsDeleted], [User_Id], [Conversation_Id]) VALUES (1040, N'hi!', CAST(N'2017-12-27 22:09:13.867' AS DateTime), 0, 8, 1020)
INSERT [dbo].[Messages] ([Id], [Body], [DateCreated], [IsDeleted], [User_Id], [Conversation_Id]) VALUES (1041, N'hi', CAST(N'2017-12-27 22:09:33.277' AS DateTime), 0, 8, 1021)
INSERT [dbo].[Messages] ([Id], [Body], [DateCreated], [IsDeleted], [User_Id], [Conversation_Id]) VALUES (1042, N'hi', CAST(N'2017-12-27 22:09:54.877' AS DateTime), 0, 10, 1015)
INSERT [dbo].[Messages] ([Id], [Body], [DateCreated], [IsDeleted], [User_Id], [Conversation_Id]) VALUES (1043, N'test', CAST(N'2017-12-27 22:10:36.597' AS DateTime), 0, 1, 1013)
INSERT [dbo].[Messages] ([Id], [Body], [DateCreated], [IsDeleted], [User_Id], [Conversation_Id]) VALUES (1044, N'hi', CAST(N'2017-12-27 22:10:41.207' AS DateTime), 0, 1, 1018)
INSERT [dbo].[Messages] ([Id], [Body], [DateCreated], [IsDeleted], [User_Id], [Conversation_Id]) VALUES (1045, N'hi', CAST(N'2017-12-27 22:10:47.240' AS DateTime), 0, 1, 1019)
SET IDENTITY_INSERT [dbo].[Messages] OFF
INSERT [dbo].[UserEntityConversationEntities] ([UserEntity_Id], [ConversationEntity_Id]) VALUES (1, 1013)
INSERT [dbo].[UserEntityConversationEntities] ([UserEntity_Id], [ConversationEntity_Id]) VALUES (2, 1013)
INSERT [dbo].[UserEntityConversationEntities] ([UserEntity_Id], [ConversationEntity_Id]) VALUES (2, 1014)
INSERT [dbo].[UserEntityConversationEntities] ([UserEntity_Id], [ConversationEntity_Id]) VALUES (6, 1014)
INSERT [dbo].[UserEntityConversationEntities] ([UserEntity_Id], [ConversationEntity_Id]) VALUES (2, 1015)
INSERT [dbo].[UserEntityConversationEntities] ([UserEntity_Id], [ConversationEntity_Id]) VALUES (10, 1015)
INSERT [dbo].[UserEntityConversationEntities] ([UserEntity_Id], [ConversationEntity_Id]) VALUES (8, 1016)
INSERT [dbo].[UserEntityConversationEntities] ([UserEntity_Id], [ConversationEntity_Id]) VALUES (10, 1016)
INSERT [dbo].[UserEntityConversationEntities] ([UserEntity_Id], [ConversationEntity_Id]) VALUES (9, 1017)
INSERT [dbo].[UserEntityConversationEntities] ([UserEntity_Id], [ConversationEntity_Id]) VALUES (10, 1017)
INSERT [dbo].[UserEntityConversationEntities] ([UserEntity_Id], [ConversationEntity_Id]) VALUES (1, 1018)
INSERT [dbo].[UserEntityConversationEntities] ([UserEntity_Id], [ConversationEntity_Id]) VALUES (10, 1018)
INSERT [dbo].[UserEntityConversationEntities] ([UserEntity_Id], [ConversationEntity_Id]) VALUES (1, 1019)
INSERT [dbo].[UserEntityConversationEntities] ([UserEntity_Id], [ConversationEntity_Id]) VALUES (9, 1019)
INSERT [dbo].[UserEntityConversationEntities] ([UserEntity_Id], [ConversationEntity_Id]) VALUES (8, 1020)
INSERT [dbo].[UserEntityConversationEntities] ([UserEntity_Id], [ConversationEntity_Id]) VALUES (9, 1020)
INSERT [dbo].[UserEntityConversationEntities] ([UserEntity_Id], [ConversationEntity_Id]) VALUES (2, 1021)
INSERT [dbo].[UserEntityConversationEntities] ([UserEntity_Id], [ConversationEntity_Id]) VALUES (8, 1021)
SET IDENTITY_INSERT [dbo].[FeedMessages] ON 

INSERT [dbo].[FeedMessages] ([Id], [FeedText], [WasEdited], [DateCreated], [IsDeleted], [ToUser_Id], [FromUser_Id]) VALUES (1, N'Test post', 0, CAST(N'2017-11-17 12:26:13.547' AS DateTime), 0, 2, 1)
INSERT [dbo].[FeedMessages] ([Id], [FeedText], [WasEdited], [DateCreated], [IsDeleted], [ToUser_Id], [FromUser_Id]) VALUES (9, N'test', 1, CAST(N'2017-11-23 23:07:48.363' AS DateTime), 0, 2, 2)
INSERT [dbo].[FeedMessages] ([Id], [FeedText], [WasEdited], [DateCreated], [IsDeleted], [ToUser_Id], [FromUser_Id]) VALUES (14, N'test 123', 1, CAST(N'2017-11-23 23:22:14.687' AS DateTime), 0, 1, 2)
INSERT [dbo].[FeedMessages] ([Id], [FeedText], [WasEdited], [DateCreated], [IsDeleted], [ToUser_Id], [FromUser_Id]) VALUES (18, N'jhjgjhgjh', 0, CAST(N'2017-11-24 12:41:31.890' AS DateTime), 0, 2, 1)
INSERT [dbo].[FeedMessages] ([Id], [FeedText], [WasEdited], [DateCreated], [IsDeleted], [ToUser_Id], [FromUser_Id]) VALUES (22, N'dddd', 0, CAST(N'2017-11-26 18:57:34.117' AS DateTime), 0, 3, 3)
INSERT [dbo].[FeedMessages] ([Id], [FeedText], [WasEdited], [DateCreated], [IsDeleted], [ToUser_Id], [FromUser_Id]) VALUES (27, N'123', 0, CAST(N'2017-11-27 20:17:33.513' AS DateTime), 0, 1, 7)
SET IDENTITY_INSERT [dbo].[FeedMessages] OFF