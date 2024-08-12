/*------------------------------------------------------------
*        Script SQLSERVER 
------------------------------------------------------------*/


/*------------------------------------------------------------
-- Table: Recette
------------------------------------------------------------*/
CREATE TABLE Recette(
	ID     INT IDENTITY (1,1) NOT NULL ,
	Nom    VARCHAR(50)  NOT NULL ,
	Categorie VARCHAR(50) NOT NULL ,
	Prix   INT  NOT NULL  ,
	CONSTRAINT Recette_PK PRIMARY KEY (ID)
);
INSERT INTO Recette (Nom,Categorie, Prix) VALUES ('Endive aux Noix','Entree' ,6), ('Compote de Pomme','Dessert' ,6), ('Burger Vegan','Plat',26), ('Steack Frite', 'Plat', 21), ('Fondant Chocolat','Dessert',5), ('Planche de Charcuterie', 'Entree', 8);

/*------------------------------------------------------------
-- Table: StockIngredients
------------------------------------------------------------*/
CREATE TABLE StockIngredients(
	ID          INT IDENTITY (1,1) NOT NULL ,
	Nom         VARCHAR(50)  NOT NULL ,
	Stock       INT  NOT NULL ,
	Categorie   VARCHAR(50)  NOT NULL  ,
	CONSTRAINT StockIngredients_PK PRIMARY KEY (ID)
);

INSERT INTO StockIngredients (Nom, Stock, Categorie) VALUES ('Endive', 0, 'Legume'), ('Noix', 0, 'Legume'), ('Pomme', 0, 'Fruit'), 
('Pomme de Terre', 0, 'Legume'),('Steack', 0, 'Viande'), ('Saucisson',0,'Viande'), 
('Jambon',0,'Viande'), ('Pain', 0,'Pain'), ('Salade',0,'Legume'),
('Tomate',0,'Legume'), ('Cornichon',0,'Legume'),('Steack de Tofu',0,'Legume'),
('Fondant Chocolat',0,'Surgeler');

/*------------------------------------------------------------
-- Table: IngredientRecette
------------------------------------------------------------*/
CREATE TABLE IngredientRecette(
	ID             INT IDENTITY (1,1)  NOT NULL ,
	NomRecette     VARCHAR(50)  NOT NULL , 
	NomIngredient  VARCHAR(50)  NOT NULL ,
	Quantite       INT  NOT NULL ,
	CONSTRAINT IngredientRecette_PK PRIMARY KEY (ID)
);
INSERT INTO IngredientRecette (NomRecette, NomIngredient, Quantite) VALUES ('Endive aux Noix', 'Endive', 2), ('Endive aux Noix', 'Noix', 3), ('Compote de Pomme', 'Pomme', 3),
('Burger Vegan', 'Pain',2), ('Burger Vegan', 'Salade',1), ('Burger Vegan', 'Tomate',1), ('Burger Vegan','Steack de Tofu',1),('Burger Vegan','Cornichon',2),
('Steack Frite','Steack',2), ('Steack Frite','Pomme de Terre', 4), ('Steack Frite','Salade',1),
('Fondant Chocolat','Fondant Chocolat',1), ('Planche de Charcuterie','Jambo',1),('Planche de Charcuterie','Saucisson',1);


/*------------------------------------------------------------
-- Table: ReservationTable
------------------------------------------------------------*/
CREATE TABLE ReservationTable(
	ID               INT IDENTITY (1,1) NOT NULL ,
	NomReservation   VARCHAR(50)  NOT NULL ,
	NbPersonne       INT  NOT NULL ,
	Horaire          INT  NOT NULL  ,
	CONSTRAINT ReservationTable_PK PRIMARY KEY (ID)
);


/*------------------------------------------------------------
-- Table: Materiel
------------------------------------------------------------*/
CREATE TABLE Materiel(
	ID         INT IDENTITY (1,1) NOT NULL ,
	Nom        VARCHAR(50)  NOT NULL ,
	Quantite   INT  NOT NULL  ,
	CONSTRAINT Materiel_PK PRIMARY KEY (ID)
);


/*------------------------------------------------------------
-- Table: ComptaCommande
------------------------------------------------------------*/
CREATE TABLE ComptaCommande(
	ID                INT IDENTITY (1,1) NOT NULL ,
	IDRecette         INT  NOT NULL ,
	NomRecette        VARCHAR(50)  NOT NULL ,
	QuantiteRecette   INT  NOT NULL  ,
	CONSTRAINT ComptaCommande_PK PRIMARY KEY (ID)
);


CREATE TABLE EtapeRecette(
	ID 				INT IDENTITY (1,1) NOT NULL ,
	NomRecette      VARCHAR(50) NOT NULL ,
	NbEtape			INT NOT NULL ,
	Description   	VARCHAR(250) NOT NULL ,
	Action			VARCHAR(50) NOT NULL ,
	Temps				INT NOT NULL , 
	CONSTRAINT EtapeRecette_PK PRIMARY KEY (ID)
);

INSERT INTO EtapeRecette (NomRecette, NbEtape, Description, Action, Temps) 
VALUES ('Endive aux Noix', 1, 'Découpez les endives en tranche', 'Decoupe', 10),
 ('Endive aux Noix', 2, 'Cassez les noix en morceaux', 'Decoupe', 20), 
 ('Endive aux Noix', 3, 'Melangez les endives et les noix', 'Melange', 25),
 ('Compote de Pomme',1, 'Cuire les pommes a 280° pour en faire de la compote','Cuire', 100),
 ('Burger Vegan',1, 'Cuire le steack de tofu','Cuire',50),
 ('Burger Vegan', 2, 'Ajoutez le pain, la salade, les tomates et les cornichons','Preparation',30),
 ('Steack Frite', 1, 'Decoupe les pommes de terres en frites','Decoupe',30),
 ('Steack Frite', 2, 'Cuire les steack', 'Cuire', 50),
 ('Steack Frite', 3, 'Ajoutez la salade, les frites et les steack ensemble','Preparation',35),
 ('Fondant Chocolat', 1, 'Rechauffez le fondant au micro onde', 'Rechauffe',20),
 ('Planche de Charcuterie',1,'Decoupez le jambon en tranche', 'Decoupe', 30),
 ('Planche de Charcuterie', 2, 'Decoupez le Saucisson en tranche', 'Decoupe',30);