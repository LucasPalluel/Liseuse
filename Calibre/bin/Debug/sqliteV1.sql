------------------------------------------------------------
--        Script SQLite  
------------------------------------------------------------


------------------------------------------------------------
-- Table: SAUVEGARDERECHERCHE
------------------------------------------------------------
CREATE TABLE SAUVEGARDERECHERCHE(
	id_fichier        INTEGER NOT NULL PRIMARY KEY  ,
	nom               TEXT NOT NULL ,
	chemin_fichier    TEXT NOT NULL
);


------------------------------------------------------------
-- Table: AUTEUR
------------------------------------------------------------
CREATE TABLE AUTEUR(
	id_auteur         INTEGER NOT NULL PRIMARY KEY,
	nom_auteur        TEXT,
	prenom_auteur     TEXT
);


------------------------------------------------------------
-- Table: SERIE
------------------------------------------------------------
CREATE TABLE SERIE(
	id_serie     INTEGER NOT NULL PRIMARY KEY  ,
	nom_serie    TEXT NOT NULL
);


------------------------------------------------------------
-- Table: MOTSCLEF
------------------------------------------------------------
CREATE TABLE MOTSCLEF(
	id_mots      INTEGER NOT NULL PRIMARY KEY  ,
	type_mots    TEXT NOT NULL
);


------------------------------------------------------------
-- Table: TOMES
------------------------------------------------------------
CREATE TABLE TOMES(
	id_tomes      INTEGER NOT NULL PRIMARY KEY  ,
	type_genre    TEXT NOT NULL
);


------------------------------------------------------------
-- Table: GENRE
------------------------------------------------------------
CREATE TABLE GENRE(
	id_genre      INTEGER NOT NULL PRIMARY KEY ,
	type_genre    TEXT NOT NULL
);


------------------------------------------------------------
-- Table: LIVRE
------------------------------------------------------------
CREATE TABLE LIVRE(
	id_livre        INTEGER NOT NULL PRIMARY KEY,
	titre           TEXT NOT NULL,
	nbpages         INTEGER NOT NULL,
	evaluation      INTEGER,
	datepubli       NUMERIC NOT NULL,
	chemin_livre    TEXT NOT NULL,
	description     TEXT DEFAULT NULL ,
	avancement      INTEGER NOT NULL,
	langue          TEXT NOT NULL ,
	hash			TEXT NOT NULL,
	id_genre        INTEGER NOT NULL,
	id_tomes        INTEGER,
	id_serie        INTEGER
	
	,CONSTRAINT LIVRE_GENRE_FK FOREIGN KEY (id_genre) REFERENCES GENRE(id_genre)
	,CONSTRAINT LIVRE_TOMES0_FK FOREIGN KEY (id_tomes) REFERENCES TOMES(id_tomes)
	,CONSTRAINT LIVRE_SERIE1_FK FOREIGN KEY (id_serie) REFERENCES SERIE(id_serie)
);


------------------------------------------------------------
-- Table: COLLECT
------------------------------------------------------------
CREATE TABLE COLLECT(
	id_collect     INTEGER NOT NULL PRIMARY KEY  ,
	nom_collect    TEXT NOT NULL
);


------------------------------------------------------------
-- Table: EDITEUR
------------------------------------------------------------
CREATE TABLE EDITEUR(
	id_editeur     INTEGER NOT NULL PRIMARY KEY  ,
	nom_editeur    TEXT NOT NULL
);


------------------------------------------------------------
-- Table: EDITER_LIVRE
------------------------------------------------------------
CREATE TABLE EDITER_LIVRE(
	id_editeur    INTEGER NOT NULL ,
	id_livre      INTEGER NOT NULL ,
	id_collect    INTEGER NOT NULL ,
	ISBN          TEXT NOT NULL ,
	pays          TEXT NOT NULL,
	CONSTRAINT EDITER_LIVRE_PK PRIMARY KEY (id_editeur,id_livre,id_collect)

	,CONSTRAINT EDITER_LIVRE_EDITEUR_FK FOREIGN KEY (id_editeur) REFERENCES EDITEUR(id_editeur)
	,CONSTRAINT EDITER_LIVRE_LIVRE0_FK FOREIGN KEY (id_livre) REFERENCES LIVRE(id_livre)
	,CONSTRAINT EDITER_LIVRE_COLLECT1_FK FOREIGN KEY (id_collect) REFERENCES COLLECT(id_collect)
);


------------------------------------------------------------
-- Table: APPARTIENT_COLLECT
------------------------------------------------------------
CREATE TABLE APPARTIENT_COLLECT(
	id_livre      INTEGER NOT NULL ,
	id_collect    INTEGER NOT NULL,
	CONSTRAINT APPARTIENT_COLLECT_PK PRIMARY KEY (id_livre,id_collect)

	,CONSTRAINT APPARTIENT_COLLECT_LIVRE_FK FOREIGN KEY (id_livre) REFERENCES LIVRE(id_livre)
	,CONSTRAINT APPARTIENT_COLLECT_COLLECT0_FK FOREIGN KEY (id_collect) REFERENCES COLLECT(id_collect)
);


------------------------------------------------------------
-- Table: ASSOCIER_MOTSCLEF
------------------------------------------------------------
CREATE TABLE ASSOCIER_MOTSCLEF(
	id_livre    INTEGER NOT NULL ,
	id_mots     INTEGER NOT NULL,
	CONSTRAINT ASSOCIER_MOTSCLEF_PK PRIMARY KEY (id_livre,id_mots)

	,CONSTRAINT ASSOCIER_MOTSCLEF_LIVRE_FK FOREIGN KEY (id_livre) REFERENCES LIVRE(id_livre)
	,CONSTRAINT ASSOCIER_MOTSCLEF_MOTSCLEF0_FK FOREIGN KEY (id_mots) REFERENCES MOTSCLEF(id_mots)
);


------------------------------------------------------------
-- Table: A_ECRIT
------------------------------------------------------------
CREATE TABLE A_ECRIT(
	id_livre     INTEGER NOT NULL ,
	id_auteur    INTEGER NOT NULL,
	CONSTRAINT A_ECRIT_PK PRIMARY KEY (id_livre,id_auteur)

	,CONSTRAINT A_ECRIT_LIVRE_FK FOREIGN KEY (id_livre) REFERENCES LIVRE(id_livre)
	,CONSTRAINT A_ECRIT_AUTEUR0_FK FOREIGN KEY (id_auteur) REFERENCES AUTEUR(id_auteur)
);


------------------------------------------------------------
-- Table: BIBLIOVIRT
------------------------------------------------------------
CREATE TABLE BIBLIOVIRT(
	id_livre      INTEGER NOT NULL ,
	id_fichier    INTEGER NOT NULL,
	CONSTRAINT BIBLIOVIRT_PK PRIMARY KEY (id_livre,id_fichier)

	,CONSTRAINT BIBLIOVIRT_LIVRE_FK FOREIGN KEY (id_livre) REFERENCES LIVRE(id_livre)
	,CONSTRAINT BIBLIOVIRT_SAUVEGARDERECHERCHE0_FK FOREIGN KEY (id_fichier) REFERENCES SAUVEGARDERECHERCHE(id_fichier)
);

------------------------------------------------------------
-- Table: GENRE DATA Livres
------------------------------------------------------------
INSERT INTO GENRE (id_genre, type_genre) VALUES (0, 'Catégories'); 
INSERT INTO GENRE (id_genre, type_genre) VALUES (1, 'Actualité');
INSERT INTO GENRE (id_genre, type_genre) VALUES (2, 'Adolescent'); 
INSERT INTO GENRE (id_genre, type_genre) VALUES (3, 'Amour');
INSERT INTO GENRE (id_genre, type_genre) VALUES (4, 'Aventure');
INSERT INTO GENRE (id_genre, type_genre) VALUES (5, 'Bien-être');
INSERT INTO GENRE (id_genre, type_genre) VALUES (6, 'Biographie');
INSERT INTO GENRE (id_genre, type_genre) VALUES (7, 'Bit-Lit');
INSERT INTO GENRE (id_genre, type_genre) VALUES (8, 'Classique');
INSERT INTO GENRE (id_genre, type_genre) VALUES (9, 'Cuisine et Vin');
INSERT INTO GENRE (id_genre, type_genre) VALUES (10, 'Développement personnel');
INSERT INTO GENRE (id_genre, type_genre) VALUES (11, 'Dictionnaires');
INSERT INTO GENRE (id_genre, type_genre) VALUES (12, 'Économie');
INSERT INTO GENRE (id_genre, type_genre) VALUES (13, 'Érotique');
INSERT INTO GENRE (id_genre, type_genre) VALUES (14, 'Ésotérisme');
INSERT INTO GENRE (id_genre, type_genre) VALUES (15, 'Essai');
INSERT INTO GENRE (id_genre, type_genre) VALUES (16, 'Fantastique');
INSERT INTO GENRE (id_genre, type_genre) VALUES (17, 'Guerre');
INSERT INTO GENRE (id_genre, type_genre) VALUES (18, 'Histoire');
INSERT INTO GENRE (id_genre, type_genre) VALUES (19, 'Horreur');
INSERT INTO GENRE (id_genre, type_genre) VALUES (20, 'Humour');
INSERT INTO GENRE (id_genre, type_genre) VALUES (21, 'Informatique');
INSERT INTO GENRE (id_genre, type_genre) VALUES (22, 'Journalisme');
INSERT INTO GENRE (id_genre, type_genre) VALUES (23, 'Littérature');
INSERT INTO GENRE (id_genre, type_genre) VALUES (24, 'Médecine');
INSERT INTO GENRE (id_genre, type_genre) VALUES (25, 'Nature et Animaux');
INSERT INTO GENRE (id_genre, type_genre) VALUES (26, 'Philosophie');
INSERT INTO GENRE (id_genre, type_genre) VALUES (27, 'Poésie');
INSERT INTO GENRE (id_genre, type_genre) VALUES (28, 'Policier');
INSERT INTO GENRE (id_genre, type_genre) VALUES (29, 'Politique');
INSERT INTO GENRE (id_genre, type_genre) VALUES (30, 'Psychologie');
INSERT INTO GENRE (id_genre, type_genre) VALUES (31, 'Religion');
INSERT INTO GENRE (id_genre, type_genre) VALUES (32, 'Romance');
INSERT INTO GENRE (id_genre, type_genre) VALUES (33, 'Romance Gay');
INSERT INTO GENRE (id_genre, type_genre) VALUES (34, 'Santé');
INSERT INTO GENRE (id_genre, type_genre) VALUES (35, 'Science');
INSERT INTO GENRE (id_genre, type_genre) VALUES (36, 'Science Fiction');
INSERT INTO GENRE (id_genre, type_genre) VALUES (37, 'Société');
INSERT INTO GENRE (id_genre, type_genre) VALUES (38, 'Sociologie');
INSERT INTO GENRE (id_genre, type_genre) VALUES (39, 'Spiritualité');
INSERT INTO GENRE (id_genre, type_genre) VALUES (40, 'Sport');
INSERT INTO GENRE (id_genre, type_genre) VALUES (41, 'Terreur');
INSERT INTO GENRE (id_genre, type_genre) VALUES (42, 'Thriller');
INSERT INTO GENRE (id_genre, type_genre) VALUES (43, 'Voyage/Tourisme');