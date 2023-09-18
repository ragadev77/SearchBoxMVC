/*** DDL Area ***/
CREATE TABLE Bank (
	BankID int NOT NULL PRIMARY KEY,
	BankName varchar(50) NOT NULL,
	BankAlias varchar(10) NOT NULL,
	BankCode int NOT NULL,
);

CREATE TABLE Customer ( 
	CustomerID INT PRIMARY KEY, 
	CustomerName VARCHAR(50) NOT NULL, 
	Address VARCHAR(100) NOT NULL, 
	PhoneNumber VARCHAR(20) NOT NULL, 
	Email VARCHAR(50) NOT NULL, 
	CreditScore INT NOT NULL 
);

CREATE TABLE Account ( 
	AccountID INT PRIMARY KEY, 
	CustomerID INT NOT NULL, 
	AccountNumber VARCHAR(10) NOT NULL, 
	CardNumber VARCHAR(20) NOT NULL,
	BankID INT NOT NULL, 
	CreditLimit DECIMAL(10, 2) NOT NULL, 
	InterestRate DECIMAL(6, 2) NOT NULL, 
	Balance DECIMAL(10, 2) NOT NULL, 
	PaymentDueDate DATE NOT NULL,
	CONSTRAINT FKAccountBank FOREIGN KEY (BankID) REFERENCES Bank(BankID),
 	CONSTRAINT FKAccountCustomer FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID) 
 );

 CREATE TABLE CardTransaction ( 
	TransactionID INT PRIMARY KEY, 
	AccountID INT NOT NULL, 
	TransactionDate DATETIME NOT NULL, 
	TransactionAmount DECIMAL(10, 2) NOT NULL, 
	TransactionDescription VARCHAR(100) NOT NULL,
	CONSTRAINT FKTransactionAccount FOREIGN KEY (AccountID) REFERENCES Account(AccountID) 
);

/*** Generate Sample Data ***/

-- Insert sample data into Bank table 
	INSERT INTO Bank (BankID, BankName, BankAlias, BankCode)
	VALUES
	(1, 'Bank Central Asia', 'BCA', 100),
	(2, 'Bank Mandiri', 'Mandiri', 200),
	(3, 'Bank Rakyat Indonesia', 'BRI', 300);

-- Insert sample data into Customer table 
	INSERT INTO Customer (CustomerID, CustomerName, Address, PhoneNumber, Email, CreditScore) 
	VALUES 
	(1, 'John Doe', '123 Main St, Anytown, USA', '555-555-1234', 'john.doe@email.com', 750),
	(2, 'Jane Smith', '456 Oak St, Anytown, USA', '555-555-5678', 'jane.smith@email.com', 680);

-- Insert sample data into Account table 
	INSERT INTO Account (AccountID, CustomerID, AccountNumber, CardNumber, BankID, CreditLimit, InterestRate, Balance, PaymentDueDate) 
	VALUES 
	(1, 1, '1234500000', '1111-1111-1111-1111', 1, 5000, 18.5, 2500, '2022-05-01'),
	(2, 2, '0000012345', '2222-2222-2222-2222', 2, 10000, 13.75, 7500, '2022-05-05'),
	(3, 1, '9999911111', '3333-3333-3333-3333', 2, 12000, 11.75, 5000, '2022-11-22'),
	(4, 3, '0000099999', '4444-4444-4444-4444', 1, 8000, 13.75, 3000, '2022-09-23'),
	(5, 2, '1234599999', '5555-5555-5555-5555', 1, 18000, 18.5, 9000, '2022-07-12');


-- Insert sample data into Transaction table 
	INSERT INTO CardTransaction (TransactionID, AccountID, TransactionDate, TransactionAmount, TransactionDescription) 
	VALUES 
	(1, 1, '2022-04-23 09:45:00', 50, 'Gas station purchase'), 
	(2, 1, '2022-04-24 12:30:00', 75.99, 'Amazon purchase'), 
	(3, 2, '2022-05-01 19:15:00', 150, 'Grocery store purchase'), 
	(4, 2, '2022-05-02 07:30:00', 50.25, 'Coffee shop purchase')

/*** Base Query ***/
-- Base Query Bank
select BankID, BankName, BankAlias, BankCode  
from Bank b ;

-- Base Query Customer
select CustomerID, CustomerName, Address, PhoneNumber, Email, CreditScore  
from Customer c ;

-- Base Query Account
select AccountID, CustomerID, AccountNumber, CardNumber, BankID 
	, CreditLimit, InterestRate, Balance, PaymentDueDate  
from Account a ;

-- Base Query CardTransaction
select TransactionID, AccountID
	, TransactionDate, TransactionAmount, TransactionDescription 
from CardTransaction ct ;

