#!/bin/bash

# creating dir in mail folder
cd ./PublicTransportClient/public-transport-client/
ng build --prod --output-path ../../build/
cp -r ./nginx ../../build/front/nginx
cp ./prod.Dockerfile ../../../build/front/Dockerfile



