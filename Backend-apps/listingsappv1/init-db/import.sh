#!/bin/bash

# Import the JSON file into the products collection
# --jsonArray tells Mongo the file contains a list [{}, {}]
mongoimport --host localhost \
  --db homelistingsdb \
  --collection listings \
  --type json \
  --file /docker-entrypoint-initdb.d/listings.json \
  --jsonArray \
  --username admin \
  --password password \
  --authenticationDatabase admin