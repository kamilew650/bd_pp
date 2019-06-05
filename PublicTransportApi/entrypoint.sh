#!/bin/bash

set -e
run_cmd="dotnet run --server.urls http://*:80 --project PublicTransportApi"

until dotnet ef database update -p PublicTransportApi.Core -s PublicTransportApi; do
>&2 echo "SQL Server is starting up"
sleep 1
done

>&2 echo "SQL Server is up - executing command"
exec $run_cmd
