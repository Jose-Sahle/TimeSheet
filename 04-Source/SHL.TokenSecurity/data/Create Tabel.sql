CREATE TABLE TOKEN
(
	ID_TOKEN INTEGER PRIMARY KEY AUTOINCREMENT,
	KEY CHAR(512),
	URL CHAR(1024),
	CREDENCIAL CHAR(50),
	NOW CHAR(20)
);

