# BibsServer

Server-side backend logic for Bibs App

# Tools & Installation

.net 6 is the current deployed version

## GitHub

Github is used for the following:

-   Source Control and access management
-   Issue and project tracking
-   CI/CD processes via actions

## Docker Commands

Run default build: `docker build -t bibsapp .`

Run image: `docker run --name bisapp -p 8081:80 -d bibsapp`

Review logs: `docker logs <containerid>`

## Scripts
contains basic script execution files to spin up external services.

1. Create a empty postgres server and DB - clubsDb
```
create_postgres_db.sh
```