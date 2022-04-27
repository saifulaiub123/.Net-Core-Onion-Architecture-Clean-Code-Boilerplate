# Wait to be sure that SQL Server came up
sleep 10s

# Run the setup script to create the DB and the schema in the DB
# Note: make sure that your password matches what is in the Dockerfile
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Pass@123 -d master -i create-database.sql
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Pass@123 -d RentGo -i create-schema.sql
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Pass@123 -d RentGo -i initial-db-value.sql