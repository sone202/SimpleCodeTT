CREATE TABLE SimpleCodeTT_db.dbo.employees (
	id int IDENTITY(1,1) NOT NULL,
	name ntext NOT NULL,
	email ntext NULL,
	birthday date NULL,
	salary money NULL,
	last_modified_date datetime2 NULL,
	CONSTRAINT employees_PK PRIMARY KEY (id)
);