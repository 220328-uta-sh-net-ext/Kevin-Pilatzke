-- SQL statements are divided informally into a few categories/sublanguages.
-- Data Manipulation Language (DML)
--   SELECT, INSERT, UPDATE, DELETE
--  these statements all operate on rows of tables.

-- Data Definition Language
--   CREATE, ALTER, DROP, TRUNCATE TABLE
--  these statements operate on other objects, like entire tables, or functions, views, etc.

-- Transaction Control Language (TCL) manages transactions, whereby
--  multiple statements can be encapsulated as one operation that
--  either entirely succeeds or takes no effect at all.
--   BEGIN TRANSACTION, COMMIT, ROLLBACK, SAVE TRANSACTION

-- Data Control Language (DCL) manages permissions/users/auth
--   GRANT, REVOKE

-- some other statements we'll see that aren't usually categorized:
--   SET, EXECUTE

-- caveats
--  these categories are not standardized - they don't appear in the ANSI SQL
--    standard, and the T-SQL documentation only mentions DML and DDL in passing.
--    other SQL variants may put more emphasis on these categories.
--  there is some disagreement on whether TRUNCATE TABLE is DML or DDL.
--  sometimes SELECT is considered as Data Query Language (DQL) rather than DML.

-- rest of DML besides SELECT is for adding/changing/removing rows.

-- INSERT

SELECT * FROM Genre;

INSERT INTO Genre VALUES (100, 'Miscellaneous');

INSERT INTO Genre (GenreId) VALUES (101);

INSERT INTO Genre (GenreId, Name) VALUES (102, 'Misc 2');

SELECT * FROM Genre WHERE GenreId >= 100;

INSERT INTO Genre (GenreId, Name) VALUES
	(103, 'Misc 3'),
	(104, 'Misc 4');

INSERT INTO Genre (GenreId, Name)
	SELECT GenreId + 10, Name + '!'
	FROM Genre
	WHERE GenreId = 104;

-- INSERT can also do things like read CSV files etc

-- UPDATE

-- without a WHERE, would modify every row
UPDATE Genre
SET Name = 'Misc 1'  -- , otherthing = value
WHERE GenreId = 101;

-- could make more complex
-- UPDATE Genre
-- SET Name = Name + '!', Name = 'asdf'  -- , otherthing = value
-- WHERE GenreId = 101;

-- without a WHERE, would delete every row (one by one)
DELETE FROM Genre
WHERE GenreId = 100;

-- this command deletes all rows all at once,
-- more quickly than an unconditional DELETE does.
--TRUNCATE TABLE Genre;

-- it's sometimes said that TRUNCATE TABLE cannot be rolled back
-- because it doesn't log enough info about the deleted data.
-- this may be true for some other SQL variants, but in
-- SQL Server, TRUNCATE can be rolled back.

-- exercises

-- 1. insert two new records into the employee table.
Select * from Employee
insert into Employee (EmployeeID, LastName, FirstName, Title, ReportsTO) VALUES (9, 'Doe', 'John', 'Sales Support Agent', 2)
insert into Employee (EmployeeID, LastName, FirstName, Title, ReportsTO) VALUES (10, 'Dee', 'Joanna', 'IT Staff', 6)

-- 2. insert two new records into the tracks table.
Select * from Track
INSERT INTO Track (TrackID, Name, AlbumID, Composer, MediaTypeID, Milliseconds, UnitPrice) VALUES (3504, 'Why am I Here Doing this', 666, 'E I O', 1, 10000, 999.99)
INSERT INTO Track (TrackID, Name, AlbumID, Composer, MediaTypeID, Milliseconds, UnitPrice) VALUES (3505, 'Copy Pasta', 999, 'Rofl', 1, 98989898, 999.99)
-- 3. update customer Aaron Mitchell's name to Robert Walter

-- 4. delete one of the employees you inserted.

-- 5. delete customer Robert Walter.