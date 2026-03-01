-- Flight Search Engine Database Script
CREATE DATABASE FlightSearchEngineDB;
GO

USE FlightSearchEngineDB;
GO

-- 1. Create Tables
CREATE TABLE Flights (
    FlightId INT PRIMARY KEY IDENTITY(1,1),
    FlightName NVARCHAR(100) NOT NULL,
    FlightType NVARCHAR(50) NOT NULL,
    Source NVARCHAR(100) NOT NULL,
    Destination NVARCHAR(100) NOT NULL,
    PricePerSeat DECIMAL(18,2) NOT NULL
);

CREATE TABLE Hotels (
    HotelId INT PRIMARY KEY IDENTITY(1,1),
    HotelName NVARCHAR(100) NOT NULL,
    HotelType NVARCHAR(50) NOT NULL,
    Location NVARCHAR(100) NOT NULL,
    PricePerDay DECIMAL(18,2) NOT NULL
);
GO

-- 2. Insert Sample Data
INSERT INTO Flights (FlightName, FlightType, Source, Destination, PricePerSeat) VALUES 
('IndiGo 101', 'Domestic', 'Delhi', 'Mumbai', 5000.00),
('Air India 202', 'Domestic', 'Delhi', 'Bangalore', 6000.00),
('SpiceJet 303', 'Domestic', 'Mumbai', 'Delhi', 4500.00),
('Vistara 404', 'Domestic', 'Bangalore', 'Delhi', 5500.00),
('Emirates 505', 'International', 'Delhi', 'Dubai', 15000.00);

INSERT INTO Hotels (HotelName, HotelType, Location, PricePerDay) VALUES 
('Taj Mahal Palace', 'Luxury', 'Mumbai', 10000.00),
('Leela Palace', 'Luxury', 'Bangalore', 12000.00),
('Radisson Blu', 'Premium', 'Delhi', 8000.00),
('Atlantis The Palm', 'Luxury', 'Dubai', 35000.00);
GO

-- 3. Stored Procedures
-- sp_GetSources
CREATE PROCEDURE sp_GetSources
AS
BEGIN
    SELECT DISTINCT Source FROM Flights ORDER BY Source;
END
GO

-- sp_GetDestinations
CREATE PROCEDURE sp_GetDestinations
AS
BEGIN
    SELECT DISTINCT Destination FROM Flights ORDER BY Destination;
END
GO

-- sp_SearchFlights
CREATE PROCEDURE sp_SearchFlights
    @Source NVARCHAR(100),
    @Destination NVARCHAR(100),
    @Persons INT
AS
BEGIN
    SELECT 
        FlightId, 
        FlightName, 
        FlightType, 
        Source, 
        Destination, 
        (PricePerSeat * @Persons) AS TotalCost
    FROM Flights
    WHERE Source = @Source AND Destination = @Destination;
END
GO

-- sp_SearchFlightsWithHotels
CREATE PROCEDURE sp_SearchFlightsWithHotels
    @Source NVARCHAR(100),
    @Destination NVARCHAR(100),
    @Persons INT
AS
BEGIN
    SELECT 
        f.FlightId, 
        f.FlightName, 
        f.Source, 
        f.Destination, 
        h.HotelName, 
        ((f.PricePerSeat * @Persons) + h.PricePerDay) AS TotalCost
    FROM Flights f
    INNER JOIN Hotels h ON f.Destination = h.Location
    WHERE f.Source = @Source AND f.Destination = @Destination;
END
GO
