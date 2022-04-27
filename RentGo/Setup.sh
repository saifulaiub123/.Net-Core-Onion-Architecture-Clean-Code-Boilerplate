#!/bin/bash

set -e
sleep 30

until dotnet-ef database update --no-build; do
>&2 echo "SQL Server is starting up"
sleep 1
done

>&2 echo "SQL Server is up - executing command"

dotnet-ef database update