
CREATE or ALTER  PROCEDURE [DBO].[GET_TOTAL_BOOK_PRICE]
AS
BEGIN

    SELECT 
	COUNT(1) AS 'BOOKCOUNT',
	SUM(PRICE) AS 'TOTALPRICE'
	FROM BOOKS;

END;


