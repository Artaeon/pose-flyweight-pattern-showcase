-- Datenbank erstellen
CREATE DATABASE MapAppDB
GO

-- In die Datenbank wechseln
USE MapAppDB
GO

-- Erstellen der Tabelle für LocationTypes
CREATE TABLE MapAppDB.dbo.LocationTypes (
    LocationTypeId INT PRIMARY KEY,
    TypeName VARCHAR(255) NOT NULL,
    IconPath VARCHAR(255) -- Pfad zum Icon für die visuelle Darstellung im Frontend
);

-- Erstellen der Tabelle für Locations
CREATE TABLE MapAppDB.dbo.Locations (
    LocationId INT PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Latitude DECIMAL(9, 6) NOT NULL, -- Breitengrad
    Longitude DECIMAL(9, 6) NOT NULL, -- Längengrad
    LocationTypeId INT,
    FOREIGN KEY (LocationTypeId) REFERENCES LocationTypes(LocationTypeId)
);

-- Erstellen der Tabelle Attributes für dynamische Eigenschaften
CREATE TABLE MapAppDB.dbo.Attributes (
    AttributeId INT PRIMARY KEY,
    LocationTypeId INT,
    Name VARCHAR(255) NOT NULL,
    Value VARCHAR(255) NOT NULL,
    FOREIGN KEY (LocationTypeId) REFERENCES LocationTypes(LocationTypeId)
);

-- Erstellen der Tabelle Reviews für Benutzerbewertungen
CREATE TABLE MapAppDB.dbo.Reviews (
    ReviewId INT PRIMARY KEY,
    LocationId INT,
    UserId INT,
    Rating INT NOT NULL,
    Comment TEXT,
    FOREIGN KEY (LocationId) REFERENCES Locations(LocationId)
);