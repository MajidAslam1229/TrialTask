IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230222192205_Intial migration')
BEGIN
    CREATE TABLE [QuizAnswers] (
        [Id] int NOT NULL IDENTITY,
        [QuestionId] int NOT NULL,
        [Answer] nvarchar(max) NULL,
        [IsRight] bit NOT NULL,
        [CreatedBy] nvarchar(max) NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedBy] nvarchar(max) NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_QuizAnswers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230222192205_Intial migration')
BEGIN
    CREATE TABLE [QuizQuestions] (
        [Id] int NOT NULL IDENTITY,
        [QuizId] int NOT NULL,
        [Question] nvarchar(max) NULL,
        [IsMandatory] bit NOT NULL,
        [CreatedBy] nvarchar(max) NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedBy] nvarchar(max) NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_QuizQuestions] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230222192205_Intial migration')
BEGIN
    CREATE TABLE [QuizResults] (
        [Id] int NOT NULL IDENTITY,
        [RollNumber] nvarchar(max) NULL,
        [QuizId] int NOT NULL,
        [QuestionId] int NOT NULL,
        [AnswerId] int NOT NULL,
        [CreatedBy] nvarchar(max) NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedBy] nvarchar(max) NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_QuizResults] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230222192205_Intial migration')
BEGIN
    CREATE TABLE [QuizStatuses] (
        [Id] int NOT NULL IDENTITY,
        [Status] nvarchar(max) NULL,
        CONSTRAINT [PK_QuizStatuses] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230222192205_Intial migration')
BEGIN
    CREATE TABLE [Quizzes] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        [QuizStatusId] int NOT NULL,
        [Active] bit NOT NULL,
        [CreatedBy] nvarchar(max) NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedBy] nvarchar(max) NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Quizzes] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230222192205_Intial migration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230222192205_Intial migration', N'7.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230222211444_Add relationships between tables')
BEGIN
    CREATE TABLE [QuizAnswersQuizQuestions] (
        [QuizId] int NOT NULL,
        [QuizQuestionsId] int NOT NULL,
        CONSTRAINT [PK_QuizAnswersQuizQuestions] PRIMARY KEY ([QuizId], [QuizQuestionsId]),
        CONSTRAINT [FK_QuizAnswersQuizQuestions_QuizAnswers_QuizId] FOREIGN KEY ([QuizId]) REFERENCES [QuizAnswers] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_QuizAnswersQuizQuestions_QuizQuestions_QuizQuestionsId] FOREIGN KEY ([QuizQuestionsId]) REFERENCES [QuizQuestions] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230222211444_Add relationships between tables')
BEGIN
    CREATE INDEX [IX_QuizQuestions_QuizId] ON [QuizQuestions] ([QuizId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230222211444_Add relationships between tables')
BEGIN
    CREATE INDEX [IX_QuizAnswersQuizQuestions_QuizQuestionsId] ON [QuizAnswersQuizQuestions] ([QuizQuestionsId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230222211444_Add relationships between tables')
BEGIN
    ALTER TABLE [QuizQuestions] ADD CONSTRAINT [FK_QuizQuestions_Quizzes_QuizId] FOREIGN KEY ([QuizId]) REFERENCES [Quizzes] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230222211444_Add relationships between tables')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230222211444_Add relationships between tables', N'7.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230222214534_DateTime field make nullable')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Quizzes]') AND [c].[name] = N'UpdatedDate');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Quizzes] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Quizzes] ALTER COLUMN [UpdatedDate] datetime2 NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230222214534_DateTime field make nullable')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[QuizQuestions]') AND [c].[name] = N'UpdatedDate');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [QuizQuestions] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [QuizQuestions] ALTER COLUMN [UpdatedDate] datetime2 NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230222214534_DateTime field make nullable')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[QuizAnswers]') AND [c].[name] = N'UpdatedDate');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [QuizAnswers] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [QuizAnswers] ALTER COLUMN [UpdatedDate] datetime2 NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230222214534_DateTime field make nullable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230222214534_DateTime field make nullable', N'7.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230222222208_DateTime field make nullabless')
BEGIN
    ALTER TABLE [QuizQuestions] DROP CONSTRAINT [FK_QuizQuestions_Quizzes_QuizId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230222222208_DateTime field make nullabless')
BEGIN
    DROP TABLE [QuizAnswersQuizQuestions];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230222222208_DateTime field make nullabless')
BEGIN
    DROP INDEX [IX_QuizQuestions_QuizId] ON [QuizQuestions];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230222222208_DateTime field make nullabless')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230222222208_DateTime field make nullabless', N'7.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230222224651_Add references')
BEGIN
    CREATE TABLE [QuizAnswersQuizQuestions] (
        [QuizAnswersId] int NOT NULL,
        [QuizQuestionsId] int NOT NULL,
        CONSTRAINT [PK_QuizAnswersQuizQuestions] PRIMARY KEY ([QuizAnswersId], [QuizQuestionsId]),
        CONSTRAINT [FK_QuizAnswersQuizQuestions_QuizAnswers_QuizAnswersId] FOREIGN KEY ([QuizAnswersId]) REFERENCES [QuizAnswers] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_QuizAnswersQuizQuestions_QuizQuestions_QuizQuestionsId] FOREIGN KEY ([QuizQuestionsId]) REFERENCES [QuizQuestions] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230222224651_Add references')
BEGIN
    CREATE INDEX [IX_QuizQuestions_QuizId] ON [QuizQuestions] ([QuizId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230222224651_Add references')
BEGIN
    CREATE INDEX [IX_QuizAnswersQuizQuestions_QuizQuestionsId] ON [QuizAnswersQuizQuestions] ([QuizQuestionsId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230222224651_Add references')
BEGIN
    ALTER TABLE [QuizQuestions] ADD CONSTRAINT [FK_QuizQuestions_Quizzes_QuizId] FOREIGN KEY ([QuizId]) REFERENCES [Quizzes] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230222224651_Add references')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230222224651_Add references', N'7.0.3');
END;
GO

COMMIT;
GO

