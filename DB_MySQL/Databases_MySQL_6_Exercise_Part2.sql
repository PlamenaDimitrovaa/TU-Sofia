#SELECT * FROM customers;
#SELECT * FROM customer_accounts;
#DELETE FROM customers 
#WHERE id = 1;

BEGIN;
UPDATE customer_accounts
SET amount = amount - 50000
WHERE id = 3 AND amount >= 50000;

UPDATE customer_accounts
SET amount = amount + 50000
WHERE id = 1;
COMMIT; #ROLLBACK;