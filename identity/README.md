# Construxiv Identity Service 

### Require 
- [Install MySQL]


### Run

- Config to run build project.
    + Open Identity.sln by Visual Studio.
    + Rebuild Identity.sln.
    + Run debug.
    
    ![StartupProject](StartupProject.PNG)


### Run by docker-compose
- Require: [install docker](https://docs.docker.com/get-docker/)
- Run debug with docker-compose
![docker-compose](docker-compose.PNG)

### Build image
- DOCKER_REGISTRY=<docker_registry_location> docker-compose build
- #eg: DOCKER_REGISTRY=dockerhub.registry.vn docker-compose build
- #=> then image will be create with name "dockerhub.registry.vn/identity"

### Parameter
- Run command: ``docker run identity --<parameter name> <value>``
- Parameter:
    + ``ConnectionStrings__Connection``: connection string of database.
 
