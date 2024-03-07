-- Erstellen der Tabelle für LocationTypes
CREATE TABLE LocationTypes (
    LocationTypeId INT PRIMARY KEY,
    TypeName VARCHAR(255) NOT NULL,
    IconPath VARCHAR(255) -- Pfad zum Icon für die visuelle Darstellung im Frontend
);

-- Erstellen der Tabelle für Locations
CREATE TABLE Locations (
    LocationId INT PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Latitude DECIMAL(9, 6) NOT NULL, -- Breitengrad
    Longitude DECIMAL(9, 6) NOT NULL, -- Längengrad
    LocationTypeId INT,
    FOREIGN KEY (LocationTypeId) REFERENCES LocationTypes(LocationTypeId)
);

-- Erweiterung der Tabelle LocationTypes
ALTER TABLE LocationTypes
ADD Description VARCHAR(255); -- Beschreibung des Ortstyps

-- Erstellen der Tabelle Attributes für dynamische Eigenschaften
CREATE TABLE Attributes (
    AttributeId INT PRIMARY KEY,
    LocationTypeId INT,
    Key VARCHAR(255) NOT NULL,
    Value VARCHAR(255) NOT NULL,
    FOREIGN KEY (LocationTypeId) REFERENCES LocationTypes(LocationTypeId)
);

-- Erstellen der Tabelle Reviews für Benutzerbewertungen
CREATE TABLE Reviews (
    ReviewId INT PRIMARY KEY,
    LocationId INT,
    UserId INT,
    Rating INT NOT NULL,
    Comment TEXT,
    FOREIGN KEY (LocationId) REFERENCES Locations(LocationId)
);