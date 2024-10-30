CREATE DATABASE IF NOT EXISTS imedical_database;
USE imedical_database;

DROP TABLE IF EXISTS recentsearches;

CREATE TABLE RecentSearches (
    id INT AUTO_INCREMENT PRIMARY KEY,
    city VARCHAR(255) NOT NULL
);
