DROP DATABASE IF EXISTS TRACKING_IMPORTS;
CREATE DATABASE IF NOT EXISTS TRACKING_IMPORTS;
USE TRACKING_IMPORTS;

-- Utilisateurs et rôles
CREATE TABLE Roles (
    RoleId INT AUTO_INCREMENT PRIMARY KEY,
    Nom VARCHAR(50) NOT NULL
);

CREATE TABLE Utilisateurs (
    UtilisateurId INT AUTO_INCREMENT PRIMARY KEY,
    Nom VARCHAR(100),
    Email VARCHAR(100) UNIQUE NOT NULL,
    MotDePasseHash TEXT NOT NULL,
    RoleId INT,
    TwoFactorEnabled BOOLEAN DEFAULT FALSE,
    FOREIGN KEY (RoleId) REFERENCES Roles(RoleId)
);

-- Transporteurs
CREATE TABLE Transporteurs (
    TransporteurId INT AUTO_INCREMENT PRIMARY KEY,
    Nom VARCHAR(100),
    Coordonnees TEXT,
    Capacites TEXT,
    Certifications TEXT
);

-- Transitaires
CREATE TABLE Transitaires (
    TransitaireId INT AUTO_INCREMENT PRIMARY KEY,
    Nom VARCHAR(100),
    Licences TEXT,
    ZonesOperation TEXT
);

-- Fournisseurs
CREATE TABLE Fournisseurs (
    FournisseurId INT AUTO_INCREMENT PRIMARY KEY,
    Nom VARCHAR(100),
    Catalogues TEXT,
    Accreditations TEXT
);

-- Clients
CREATE TABLE Clients (
    ClientId INT AUTO_INCREMENT PRIMARY KEY,
    NomEntreprise VARCHAR(100),
    ContactEmail VARCHAR(100),
    Telephone VARCHAR(50)
);

-- Documents
CREATE TABLE Documents (
    DocumentId INT AUTO_INCREMENT PRIMARY KEY,
    Type ENUM('Facture', 'BL', 'Certificat', 'Autre') NOT NULL,
    NomFichier VARCHAR(255),
    UrlFichier TEXT,
    DateAjout DATETIME DEFAULT CURRENT_TIMESTAMP,
    UtilisateurId INT,
    FOREIGN KEY (UtilisateurId) REFERENCES Utilisateurs(UtilisateurId)
);

-- Appels d'offres
CREATE TABLE AppelsOffres (
    AppelId INT AUTO_INCREMENT PRIMARY KEY,
    Titre VARCHAR(255),
    Description TEXT,
    Criteres TEXT,
    DateCreation DATETIME DEFAULT CURRENT_TIMESTAMP,
    Statut ENUM('Ouvert', 'Fermé', 'Attribué') DEFAULT 'Ouvert',
    ClientId INT,
    FOREIGN KEY (ClientId) REFERENCES Clients(ClientId)
);

-- Offres soumises
CREATE TABLE Soumissions (
    SoumissionId INT AUTO_INCREMENT PRIMARY KEY,
    AppelId INT,
    FournisseurId INT,
    Prix DECIMAL(10,2),
    DelaiLivraison INT,
    NoteQualite DECIMAL(3,2),
    FOREIGN KEY (AppelId) REFERENCES AppelsOffres(AppelId),
    FOREIGN KEY (FournisseurId) REFERENCES Fournisseurs(FournisseurId)
);

-- Tracking
CREATE TABLE Tracking (
    TrackingId INT AUTO_INCREMENT PRIMARY KEY,
    ConteneurId VARCHAR(100),
    Latitude DOUBLE,
    Longitude DOUBLE,
    DateHeure DATETIME,
    Statut TEXT
);
