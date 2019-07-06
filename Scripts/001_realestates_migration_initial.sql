IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Regions] (
    [Id] int NOT NULL IDENTITY,
    [IdRegion] int NOT NULL,
    [Title] nvarchar(max) NULL,
    CONSTRAINT [PK_Regions] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Districts] (
    [Id] int NOT NULL IDENTITY,
    [IdDistrict] int NOT NULL,
    [Title] nvarchar(max) NULL,
    [RegionId] int NULL,
    CONSTRAINT [PK_Districts] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Districts_Regions_RegionId] FOREIGN KEY ([RegionId]) REFERENCES [Regions] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Buildings] (
    [Id] int NOT NULL IDENTITY,
    [IdBuilding] int NOT NULL,
    [QueueNumber] int NOT NULL,
    [BuildingNumber] nvarchar(max) NULL,
    [NameRC] nvarchar(max) NULL,
    [DistrictId] int NULL,
    CONSTRAINT [PK_Buildings] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Buildings_Districts_DistrictId] FOREIGN KEY ([DistrictId]) REFERENCES [Districts] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Apartments] (
    [Id] int NOT NULL IDENTITY,
    [IdApartment] int NOT NULL,
    [QuantitiesOfRooms] int NOT NULL,
    [CommonArea] real NOT NULL,
    [KitchenArea] real NOT NULL,
    [Floor] int NOT NULL,
    [Cost] real NOT NULL,
    [BuildingId] int NULL,
    CONSTRAINT [PK_Apartments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Apartments_Buildings_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [Buildings] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Apartments_BuildingId] ON [Apartments] ([BuildingId]);

GO

CREATE INDEX [IX_Buildings_DistrictId] ON [Buildings] ([DistrictId]);

GO

CREATE INDEX [IX_Districts_RegionId] ON [Districts] ([RegionId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190702015618_InitialCreate', N'2.2.4-servicing-10062');

GO

