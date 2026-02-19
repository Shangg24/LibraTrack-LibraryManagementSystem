/**SELECT**/

SELECT * FROM users


SELECT * FROM books


SELECT * FROM issues;


SELECT * FROM ActivityLog;


SELECT * FROM BookCopies;

SELECT * FROM GradeSections;

SELECT * FROM issue_books;

SELECT * FROM book_requests;

SELECT DISTINCT status FROM books;

SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'issue_books';


SELECT DISTINCT status FROM issues
WHERE status = 'Not Return'
AND date_delete IS NULL

SELECT DISTINCT status FROM books
WHERE status = 'Not Available'
AND date_delete IS NULL

SELECT DISTINCT status FROM issues;


USE [C:\USERS\ADMINISTRATOR\DOCUMENTS\LIBRATRACK.MDF];
SELECT DISTINCT status FROM issues;


SELECT @ConstraintName = dc.name
FROM sys.default_constraints dc
JOIN sys.columns c 
    ON c.default_object_id = dc.object_id
WHERE c.object_id = OBJECT_ID('users') 
  AND c.name = 'status';


  SELECT @ConstraintName2 = dc.name
FROM sys.default_constraints dc
JOIN sys.columns c 
    ON c.default_object_id = dc.object_id
WHERE c.object_id = OBJECT_ID('users') 
  AND c.name = 'role';


SELECT COLUMN_NAME
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'BookCopies';

SELECT COLUMN_NAME
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'issues';

SELECT name 
FROM sys.key_constraints 
WHERE parent_object_id = OBJECT_ID('issues');


SELECT TOP 10 * FROM books;


SELECT TOP 10 * FROM BookCopies;

SELECT DISTINCT status FROM issues;

SELECT COUNT(id) FROM issues WHERE status = 'Return' AND date_delete IS NULL;

SELECT COUNT(*) FROM issues WHERE status = 'Return';

SELECT COLUMN_NAME 
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'issues';



SELECT TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_NAME LIKE '%Issue%';


SELECT COLUMN_NAME
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'issues';


SELECT TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES
WHERE COLUMN_NAME = 'issue_id';

SELECT TABLE_NAME
FROM INFORMATION_SCHEMA.COLUMNS
WHERE COLUMN_NAME = 'issue_id';

SELECT * FROM IssueBookDetails;

SELECT issue_id, COUNT(*) AS cnt
FROM issues
GROUP BY issue_id
HAVING COUNT(*) > 1;

SELECT 
    COLUMN_NAME,
    DATA_TYPE,
    CHARACTER_MAXIMUM_LENGTH
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'issues'
  AND COLUMN_NAME = 'issue_id';

  EXEC sp_help 'issues';


  SELECT 
    COLUMN_NAME,
    DATA_TYPE,
    CHARACTER_MAXIMUM_LENGTH,
    IS_NULLABLE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'issues'
  AND COLUMN_NAME = 'issue_id';

  SELECT TOP 5 * FROM issues;


SELECT
    i.issue_id,
    i.full_name,
    b.book_title,
    ib.status,
    i.issue_date
FROM issue_books ib
JOIN issues i ON ib.issue_id = i.id
JOIN books b ON ib.book_id = b.id
ORDER BY i.issue_date DESC;

SELECT id, Copies
FROM Books
WHERE ISNUMERIC(Copies) = 0
   OR Copies IS NULL;

   EXEC sp_help issues;


SELECT COLUMN_NAME
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'books';

   SELECT Copies FROM Books
WHERE ISNUMERIC(Copies) = 0 OR Copies IS NULL

SELECT issue_id, book_id
FROM issue_books
WHERE issue_id = 1045;

SELECT issue_id FROM issue_books;

SELECT id, issue_id FROM issues;

SELECT * FROM issue_books;

SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'issues';


SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'issue_books';

SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'books';


SELECT TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE';


SELECT name
FROM sys.foreign_keys
WHERE parent_object_id = OBJECT_ID('issue_books');

EXEC sp_help 'issue_books';

EXEC sp_help 'issues';

SELECT 
    TABLE_NAME, COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, COLLATION_NAME
FROM INFORMATION_SCHEMA.COLUMNS
WHERE COLUMN_NAME = 'issue_id'
AND TABLE_NAME IN ('issues', 'issue_books');

SELECT issue_id, issue_date, return_date
FROM issues
ORDER BY date_insert DESC;

SELECT id, status
FROM issue_books
WHERE issue_id = 'YOUR_ISSUE_ID';

SELECT issue_id, date_delete FROM issues;

SELECT name
FROM sys.key_constraints
WHERE type = 'PK'
AND parent_object_id = OBJECT_ID('books');

SELECT name 
FROM sys.foreign_keys
WHERE parent_object_id = OBJECT_ID('BookCopies');

SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'books'

SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'books'
AND COLUMN_NAME = 'id';

EXEC sp_help 'books';


/**----------------------------------------------------------------------**/
/**CREATE**/

  CREATE TABLE ActivityLog (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ActivityDescription NVARCHAR(500),
    ActivityDate DATETIME DEFAULT GETDATE()
);


CREATE TABLE BookCopies (
    CopyID INT IDENTITY(1,1) PRIMARY KEY,
    BookID INT NOT NULL,
    CopyNumber INT NOT NULL,
    Status VARCHAR(20) DEFAULT 'Available',

    FOREIGN KEY (BookID) REFERENCES Books(id)
);


CREATE TABLE GradeSections (
    id INT IDENTITY PRIMARY KEY,
    department NVARCHAR(50),
    grade_level NVARCHAR(50),
    section NVARCHAR(50),
    is_active BIT DEFAULT 1
);


CREATE TABLE IssueBookDetails (
    id INT IDENTITY(1,1) PRIMARY KEY,

    issue_id NVARCHAR(20) NOT NULL, -- MUST MATCH EXACTLY
    book_title NVARCHAR(255) NOT NULL,
    author NVARCHAR(255),
    copy_id INT NULL,
    status VARCHAR(50) DEFAULT 'Not Return',

    CONSTRAINT FK_IssueBookDetails_Issue
        FOREIGN KEY (issue_id)
        REFERENCES issues(issue_id)
        ON DELETE CASCADE
);


CREATE TABLE issue_books (
    id INT IDENTITY(1,1) PRIMARY KEY,
    issue_id INT NOT NULL,
    book_id INT NOT NULL,
    status VARCHAR(20) DEFAULT 'Borrowed',
    date_insert DATETIME DEFAULT GETDATE(),

    CONSTRAINT FK_issue_books_issue
        FOREIGN KEY (issue_id) REFERENCES issues(id)
);

/**----------------------------------------------------------------------**/
/**TRUNCATE**/

TRUNCATE TABLE issues


TRUNCATE TABLE books;


/**----------------------------------------------------------------------**/
/**UPDATE**/

UPDATE issues SET status = 'Not Return' WHERE status = 'Not Return';


UPDATE BookCopies SET Status = 'Returned' WHERE CopyID = @copyId

UPDATE Books SET status = 'Returned' WHERE id = @id;


/**----------------------------------------------------------------------**/
/**ALTER**/

ALTER DATABASE LibraTrack SET ENABLE_BROKER WITH ROLLBACK IMMEDIATE;


ALTER TABLE users ADD status NVARCHAR(50) DEFAULT 'Pending';
ALTER TABLE users ADD role NVARCHAR(50) DEFAULT 'User';


ALTER TABLE users
ADD CONSTRAINT DF_users_status DEFAULT 'Pending' FOR status;


    -- 3. Add new default constraint
ALTER TABLE users
ADD CONSTRAINT DF_users_status DEFAULT 'Pending' FOR status;


ALTER TABLE users
ADD CONSTRAINT DF_users_role DEFAULT 'Librarian' FOR role;


ALTER TABLE books
ADD category NVARCHAR(100),
    ISBN NVARCHAR(50),
    shelf NVARCHAR(50);


ALTER TABLE issues
ADD copy_id NVARCHAR(20) NULL; -- new column


ALTER TABLE BookCopies
ADD CONSTRAINT FK_BookCopies_Books
FOREIGN KEY (BookID) REFERENCES Books(id);


ALTER TABLE books ADD BookID nvarchar(20);

ALTER TABLE books ADD Copies nvarchar(20);

ALTER TABLE BookCopies ALTER COLUMN CopyID VARCHAR(20);

ALTER TABLE BookCopies 
ALTER COLUMN CopyID VARCHAR(20);

--Drop the primary key constraint
ALTER TABLE BookCopies
DROP CONSTRAINT PK__BookCopi__C26CCCE5FA6A4F65;

--Add a new temporary column
ALTER TABLE BookCopies
ADD CopyID_New VARCHAR(20);

UPDATE BookCopies SET CopyID_New = CAST(CopyID AS VARCHAR(20));


--Copy existing integer data into the new varchar column
UPDATE BookCopies
SET CopyID_New = CAST(CopyID AS VARCHAR(20));


ALTER TABLE Books ADD available INT NOT NULL DEFAULT 0;

UPDATE Books SET available = copies;

ALTER TABLE books DROP CONSTRAINT PK_books;

--Drop the old INT column
ALTER TABLE BookCopies
DROP COLUMN CopyID;


ALTER TABLE Books
ADD available INT NOT NULL DEFAULT 0;


--Rename the new column to CopyID
EXEC sp_rename 'BookCopies.[CopyID_New]', 'CopyID', 'COLUMN';


--Recreate the primary key constraint
ALTER TABLE BookCopies
ADD CONSTRAINT PK_BookCopies PRIMARY KEY (CopyID);

ALTER TABLE issues
ADD temp_id INT IDENTITY(1,1);

ALTER TABLE issues
DROP COLUMN id;

ALTER TABLE issues
DROP CONSTRAINT PK_issues;   -- replace with the actual constraint name

EXEC sp_help 'issues';

EXEC sp_help 'books';

ALTER TABLE books
DROP CONSTRAINT PK__books__3213E83F8E491261;

EXEC sp_rename 'issues.temp_id', 'id', 'COLUMN';

ALTER TABLE issues
ADD CONSTRAINT PK_issues PRIMARY KEY (id);

ALTER TABLE issues ADD new_id INT IDENTITY(1,1);

ALTER TABLE issues
ADD student_id VARCHAR(50),
    grade_section VARCHAR(100);

ALTER TABLE issues
ADD id INT IDENTITY(1,1) PRIMARY KEY;

EXEC sp_rename 'issues.student_id', 'ID_no', 'COLUMN'; --RENAME COLUMN

ALTER TABLE Users
ADD id_number VARCHAR(50) NULL;

ALTER TABLE Users
ADD CONSTRAINT UQ_users_id_number UNIQUE (id_number);


ALTER TABLE issues
ADD CONSTRAINT UQ_issues_issue_id UNIQUE (issue_id);

ALTER TABLE issues
ALTER COLUMN issue_id NVARCHAR(20) NOT NULL;

ALTER TABLE issues
ADD CONSTRAINT UQ_issues_issue_id UNIQUE (issue_id);


ALTER TABLE issues
DROP COLUMN book_title;

ALTER TABLE issues
DROP COLUMN author;

ALTER TABLE issues
DROP COLUMN book_id;

ALTER TABLE issues
DROP COLUMN status;

ALTER TABLE issues
ALTER COLUMN issue_id VARCHAR(10);

ALTER TABLE issues
ADD status NVARCHAR(20) DEFAULT 'Not Return';

ALTER TABLE issue_books
DROP CONSTRAINT FK_issue_books_issue;

ALTER TABLE issue_books
ALTER COLUMN issue_id NVARCHAR(20) NOT NULL;

ALTER TABLE issue_books
ADD CONSTRAINT FK_issue_books_issue
FOREIGN KEY (issue_id) REFERENCES issues(issue_id);

ALTER TABLE issue_books
DROP CONSTRAINT FK_issue_books_issue;

ALTER TABLE issue_books
ALTER COLUMN issue_id NVARCHAR(20) NOT NULL;

ALTER TABLE issue_books
ALTER COLUMN issue_id VARCHAR(10) COLLATE SQL_Latin1_General_CP1_CI_AS;

ALTER TABLE issue_books
ALTER COLUMN issue_id VARCHAR(10) NOT NULL;


ALTER TABLE issue_books
ADD CONSTRAINT FK_issue_books_issue
FOREIGN KEY (issue_id)
REFERENCES issues(issue_id);

ALTER TABLE BookCopies DROP CONSTRAINT FK__BookCopie__BookI__46B27FE2;
ALTER TABLE BookCopies DROP CONSTRAINT FK_BookCopies_Books;

ALTER TABLE BookCopies
ADD BookPK INT;

UPDATE bc
SET bc.BookPK = b.BookPK
FROM BookCopies bc
JOIN books b ON bc.BookID = b.id;

ALTER TABLE BookCopies
ALTER COLUMN BookPK INT NOT NULL;

ALTER TABLE BookCopies
ADD CONSTRAINT FK_BookCopies_Books_New
FOREIGN KEY (BookPK)
REFERENCES books(BookPK);

ALTER TABLE books
ADD CONSTRAINT PK_books_BookPK PRIMARY KEY (BookPK);


ALTER TABLE BookCopies
DROP CONSTRAINT FK_BookCopies_Books;



/**----------------------------------------------------------------------**/
/**DECLARE**/

-- 1. Find the default constraint name for "status"
DECLARE @ConstraintName NVARCHAR(200);


DECLARE @ConstraintName2 NVARCHAR(200);


/**----------------------------------------------------------------------**/
/**IF**/

  -- 2. Drop the constraint
IF @ConstraintName IS NOT NULL
    EXEC('ALTER TABLE users DROP CONSTRAINT ' + @ConstraintName);


IF @ConstraintName2 IS NOT NULL
    EXEC('ALTER TABLE users DROP CONSTRAINT ' + @ConstraintName2);


/**----------------------------------------------------------------------**/
/**INSERT**/

-- Insert a default IT Staff account
INSERT INTO users (email, username, password, date_register, status, role)
VALUES ('itstaff@example.com', 'itstaff', 'it123', GETDATE(), 'Approved', 'IT');


UPDATE books SET BookID = 'B-' + RIGHT('0000' + CAST(id AS varchar(4)), 4)

EXEC sp_help 'BookCopies';


UPDATE Books
SET available = Copies
WHERE available IS NULL;


/**----------------------------------------------------------------------**/
/**DELETE**/

DELETE FROM books;

DELETE FROM BookCopies;

DELETE FROM issues;

DELETE FROM issue_books;

DELETE FROM BookCopies
WHERE CopyID LIKE '%Replace%';


DELETE FROM ActivityLog;



IF COL_LENGTH('dbo.issues','copy_id') IS NULL
BEGIN
    ALTER TABLE issues ADD copy_id NVARCHAR(50) NULL;
END;


/**----------------------------------------------------------------------**/
DROP TABLE IF EXISTS IssueBookDetails;
