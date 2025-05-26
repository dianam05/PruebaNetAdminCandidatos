   CREATE DATABASE GestionCanditadosDb;
   GO

   USE GestionCanditadosDb;
   GO

   --Tabla Candidates
   CREATE TABLE Candidates (
       IdCandidate INT IDENTITY(1,1) PRIMARY KEY,   
       Name NVARCHAR(100),                    
       Surname NVARCHAR(100),                 
       Birthdate DATETIME,                     
       Email NVARCHAR(255),                  
       InsertDate DATETIME, 
       ModifyDate DATETIME   
   );
   GO

   --Tabla CandidateExperience
   CREATE TABLE CandidateExperience (
       IdCandidateExperience INT IDENTITY(1,1) PRIMARY KEY,  
       IdCandidate INT NOT NULL,                            
       Company NVARCHAR(255),                         
       Job NVARCHAR(100),                            
       Description NVARCHAR(MAX),                   
       Salary DECIMAL(18, 2),                   
       BeginDate DATE,                            
       EndDate DATE,                              
       InsertDate DATETIME,      
       ModifyDate DATETIME,     
       FOREIGN KEY (IdCandidate) REFERENCES Candidates(IdCandidate) 
   );
   GO