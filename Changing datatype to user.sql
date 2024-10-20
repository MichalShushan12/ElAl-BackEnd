USE ElalDB;
ALTER TABLE Users
ALTER COLUMN CreatedAt DATETIME;

select * from Users