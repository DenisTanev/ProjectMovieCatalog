CREATE TABLE movies
(
Id INT IDENTITY PRIMARY KEY,
Title VARCHAR(100) NOT NULL,
Genre VARCHAR(100) NOT NULL,
Views INT,
MonthWithMostViews VARCHAR(100),
Director VARCHAR(100),
Producer VARCHAR(100),
Year INT,
);