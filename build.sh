#!/bin/bash

# creating dir in mail folder
cd ./PublicTransportClient/public-transport-client/
mkdir ../../build/dist/
ng build --prod --aot=false --build-optimizer=false --output-path ../../build/dist/
cp -r ./nginx ../../build/
cp ./prod.Dockerfile ../../build/Dockerfile



