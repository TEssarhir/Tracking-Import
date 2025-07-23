USE TRACKING_IMPORTS;

-- Rôles
INSERT INTO Roles (Nom) VALUES
('Admin'),
('Fournisseur'),
('Transitaire'),
('Transporteur'),
('Client');

-- Utilisateurs
INSERT INTO Utilisateurs (Nom, Email, MotDePasseHash, RoleId, TwoFactorEnabled) VALUES
('Alice Admin', 'admin@example.com', 'hashed-password-1', 1, TRUE),
('Bob Fournisseur', 'fournisseur@example.com', 'hashed-password-2', 2, FALSE),
('Carla Transitaire', 'transitaire@example.com', 'hashed-password-3', 3, FALSE),
('Dan Transporteur', 'transporteur@example.com', 'hashed-password-4', 4, TRUE),
('Eve Client', 'client@example.com', 'hashed-password-5', 5, TRUE);

-- Transporteurs
INSERT INTO Transporteurs (Nom, Coordonnees, Capacites, Certifications) VALUES
('Transco', '123 Route A, Paris', '20 camions, réfrigérés', 'ISO 9001, TAPA'),
('SpeedLog', '456 Rue B, Lyon', '15 camions, 10 remorques', 'ADR, GMP');

-- Transitaires
INSERT INTO Transitaires (Nom, Licences, ZonesOperation) VALUES
('OceanTrans', 'Licence EU-T123', 'Europe, Asie'),
('SkyCargo', 'Licence INT-C456', 'Amérique du Nord, Afrique');

-- Fournisseurs
INSERT INTO Fournisseurs (Nom, Catalogues, Accreditations) VALUES
('Fournisol', 'Matériaux de construction, Équipements industriels', 'ISO 14001'),
('TechParts', 'Pièces électroniques, composants', 'CE, RoHS');

-- Clients
INSERT INTO Clients (NomEntreprise, ContactEmail, Telephone) VALUES
('BuildCorp', 'contact@buildcorp.com', '+33 1 23 45 67 89'),
('AgriPlus', 'info@agriplus.fr', '+33 1 98 76 54 32');

-- Documents
INSERT INTO Documents (Type, NomFichier, UrlFichier, UtilisateurId) VALUES
('Facture', 'facture_001.pdf', '/docs/factures/facture_001.pdf', 5),
('Certificat', 'certificat_iso.pdf', '/docs/certificats/iso.pdf', 2),
('BL', 'bon_livraison_003.pdf', '/docs/bl/bl003.pdf', 4);

-- Appels d'offres
INSERT INTO AppelsOffres (Titre, Description, Criteres, ClientId) VALUES
('Transport Marchandises Paris - Marseille', 'Demande de transport express avec conditions spécifiques', 'Réfrigération, ADR', 1),
('Fourniture de pièces mécaniques', 'Pièces pour maintenance machines agricoles', 'Délai < 7 jours, ISO', 2);

-- Soumissions
INSERT INTO Soumissions (AppelId, FournisseurId, Prix, DelaiLivraison, NoteQualite) VALUES
(1, 1, 1500.00, 2, 4.5),
(2, 2, 980.00, 5, 4.8);

-- Tracking
INSERT INTO Tracking (ConteneurId, Latitude, Longitude, DateHeure, Statut) VALUES
('CONT123456', 48.8566, 2.3522, NOW(), 'En transit - Paris'),
('CONT789012', 43.2965, 5.3698, NOW(), 'Arrivé - Marseille');
