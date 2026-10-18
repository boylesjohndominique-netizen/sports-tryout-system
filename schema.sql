-- =====================================================================
-- Sports Tryout Management System - MySQL Database Schema & Seed Script
-- Target Database: sports_tryout_db
-- =====================================================================

CREATE DATABASE IF NOT EXISTS `sports_tryout_db` 
CHARACTER SET utf8mb4 
COLLATE utf8mb4_unicode_ci;

USE `sports_tryout_db`;

-- ---------------------------------------------------------------------
-- Table: Users
-- ---------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `Users` (
    `UserID` INT AUTO_INCREMENT PRIMARY KEY,
    `Username` VARCHAR(50) NOT NULL UNIQUE,
    `PasswordHash` VARCHAR(255) NOT NULL,
    `FullName` VARCHAR(100) NOT NULL,
    `Role` VARCHAR(20) NOT NULL,
    `IsActive` TINYINT(1) NOT NULL DEFAULT 1,
    `DateCreated` DATETIME DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ---------------------------------------------------------------------
-- Table: Sports
-- ---------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `Sports` (
    `SportID` INT AUTO_INCREMENT PRIMARY KEY,
    `SportName` VARCHAR(100) NOT NULL UNIQUE,
    `Description` TEXT,
    `IsActive` TINYINT(1) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ---------------------------------------------------------------------
-- Table: SportCoaches (Coaches assigned to sports)
-- ---------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `SportCoaches` (
    `SportCoachID` INT AUTO_INCREMENT PRIMARY KEY,
    `SportID` INT NOT NULL,
    `UserID` INT NOT NULL,
    CONSTRAINT `fk_sc_sport` FOREIGN KEY (`SportID`) REFERENCES `Sports`(`SportID`) ON DELETE CASCADE,
    CONSTRAINT `fk_sc_user` FOREIGN KEY (`UserID`) REFERENCES `Users`(`UserID`) ON DELETE CASCADE,
    CONSTRAINT `uq_sport_coach` UNIQUE (`SportID`, `UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ---------------------------------------------------------------------
-- Table: Students (Applicant Master List)
-- ---------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `Students` (
    `StudentID` INT AUTO_INCREMENT PRIMARY KEY,
    `StudentNumber` VARCHAR(50) NOT NULL UNIQUE,
    `FirstName` VARCHAR(100) NOT NULL,
    `LastName` VARCHAR(100) NOT NULL,
    `CourseYear` VARCHAR(50) NULL,
    `Gender` VARCHAR(20) NULL,
    `ContactNumber` VARCHAR(50) NULL,
    `Email` VARCHAR(100) NULL,
    `DateRegistered` DATETIME DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ---------------------------------------------------------------------
-- Table: Registrations (Student Tryout Registrations per Sport)
-- ---------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `Registrations` (
    `RegistrationID` INT AUTO_INCREMENT PRIMARY KEY,
    `StudentID` INT NOT NULL,
    `SportID` INT NOT NULL,
    `RegistrationDate` DATETIME DEFAULT CURRENT_TIMESTAMP,
    `SelectionStatus` VARCHAR(50) NOT NULL DEFAULT 'Pending',
    `SelectionDate` DATETIME NULL,
    `SelectionRemarks` TEXT NULL,
    `SelectionBy` VARCHAR(100) NULL,
    CONSTRAINT `fk_reg_student` FOREIGN KEY (`StudentID`) REFERENCES `Students`(`StudentID`) ON DELETE CASCADE,
    CONSTRAINT `fk_reg_sport` FOREIGN KEY (`SportID`) REFERENCES `Sports`(`SportID`) ON DELETE CASCADE,
    CONSTRAINT `uq_student_sport` UNIQUE (`StudentID`, `SportID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ---------------------------------------------------------------------
-- Table: Schedules (Tryout Schedules)
-- ---------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `Schedules` (
    `ScheduleID` INT AUTO_INCREMENT PRIMARY KEY,
    `SportID` INT NOT NULL,
    `TryoutDate` VARCHAR(50) NOT NULL,
    `TryoutTime` VARCHAR(50) NOT NULL,
    `Venue` VARCHAR(100) NOT NULL,
    `Status` VARCHAR(50) NOT NULL DEFAULT 'Upcoming',
    `Notes` TEXT NULL,
    CONSTRAINT `fk_sched_sport` FOREIGN KEY (`SportID`) REFERENCES `Sports`(`SportID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ---------------------------------------------------------------------
-- Table: Evaluations (Athlete Evaluation Scores & Remarks)
-- ---------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `Evaluations` (
    `EvaluationID` INT AUTO_INCREMENT PRIMARY KEY,
    `RegistrationID` INT NOT NULL,
    `EvaluatorUserID` INT NOT NULL,
    `SkillScore` DECIMAL(5,2) NOT NULL DEFAULT 0.00,
    `SpeedScore` DECIMAL(5,2) NOT NULL DEFAULT 0.00,
    `AgilityScore` DECIMAL(5,2) NOT NULL DEFAULT 0.00,
    `EnduranceScore` DECIMAL(5,2) NOT NULL DEFAULT 0.00,
    `TeamworkScore` DECIMAL(5,2) NOT NULL DEFAULT 0.00,
    `DisciplineScore` DECIMAL(5,2) NOT NULL DEFAULT 0.00,
    `OverallPerformanceScore` DECIMAL(5,2) NOT NULL DEFAULT 0.00,
    `FinalScore` DECIMAL(5,2) NOT NULL DEFAULT 0.00,
    `Remarks` TEXT NULL,
    `EvaluationDate` DATETIME DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT `fk_eval_reg` FOREIGN KEY (`RegistrationID`) REFERENCES `Registrations`(`RegistrationID`) ON DELETE CASCADE,
    CONSTRAINT `fk_eval_user` FOREIGN KEY (`EvaluatorUserID`) REFERENCES `Users`(`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ---------------------------------------------------------------------
-- Seed Default Users (Passwords hashed with SHA-256)
-- admin: admin123
-- coach: coach123
-- staff: staff123
-- ---------------------------------------------------------------------
INSERT INTO `Users` (`Username`, `PasswordHash`, `FullName`, `Role`, `IsActive`)
VALUES 
    ('admin', '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9', 'System Administrator', 'Admin', 1),
    ('coach', '777a025f5ca4a20f7bafee940f2820e28e1f4bbcbd9dd774bbce883166ef7c55', 'Sample Coach', 'Coach', 1),
    ('staff', '10176e7b7b24d317acfcf8d2064cfd2f24e154f7b5a96603077d5ef813d6a6b6', 'Sample Registrar', 'Staff', 1)
ON DUPLICATE KEY UPDATE 
    `PasswordHash` = VALUES(`PasswordHash`),
    `FullName` = VALUES(`FullName`),
    `Role` = VALUES(`Role`),
    `IsActive` = VALUES(`IsActive`);

-- ---------------------------------------------------------------------
-- Seed Default Starter Sports
-- ---------------------------------------------------------------------
INSERT INTO `Sports` (`SportName`, `Description`, `IsActive`)
VALUES 
    ('Basketball', 'Men and Women Basketball tryouts', 1),
    ('Volleyball', 'Men and Women Volleyball tryouts', 1),
    ('Football', 'Association Football / Soccer tryouts', 1),
    ('Badminton', 'Singles and Doubles Badminton tryouts', 1),
    ('Table Tennis', 'Table Tennis tryouts', 1)
ON DUPLICATE KEY UPDATE 
    `Description` = VALUES(`Description`),
    `IsActive` = VALUES(`IsActive`);
