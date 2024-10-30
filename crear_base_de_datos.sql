CREATE DATABASE IF NOT EXISTS imedical_database;
USE imedical_database;

CREATE TABLE RecentSearches (
    id INT AUTO_INCREMENT PRIMARY KEY,
    city VARCHAR(255) NOT NULL
);
