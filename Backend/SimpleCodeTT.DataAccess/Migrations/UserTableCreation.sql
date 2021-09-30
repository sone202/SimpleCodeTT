CREATE TABLE SimpleCodeTT_db.dbo.users (
	id int IDENTITY(1,1) NOT NULL,
	username ntext NOT NULL,
	password ntext NOT NULL,
	CONSTRAINT users_PK PRIMARY KEY (id)
);