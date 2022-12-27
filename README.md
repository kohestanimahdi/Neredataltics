# Neredataltics - Weather Condition and History

The goal of this project is to implement a weather service that depends on the country and city, returns the temprature and air condition.

## Development notes
This project consist two projects, `SmartModel` and `SmartFeatures`:

SmartModel: is a gRPC server, that returns the current weather of specific location (Country and City)
SmartFeatures: is a REST api sevice, that connects to the `SmartModel` as a client and get the data that user demand. This service, also, save the information
of the weather for each location in Database and has an endpoint to get the data from the database by some filters.
The services relation is drawed below:

![alt text](https://kohestanimahdi.ir/images/photo_2022-12-26_22-20-44.jpg)


## Delpoy notes
To deploy this project, I use `kubernetes` and `docker`. First of all, you have to build the project and push both of the on `DockerHub`. 
First of all, go to the solution folder and run these commands:

```console
$ docker build . -f Neredataltics.SmartFeatures\Dockerfile -t <yourUserName>/smart-feature
$ docker build . -f Neredataltics.SmartModel\Dockerfile -t <yourUserName>/smart-model
```

Replace the <yourUserName/tag> with your own `DockerHub` username. For instance, I run these commands:

```console
$ docker build . -f Neredataltics.SmartFeatures\Dockerfile -t kohestanimahdi/smart-feature:1.6
$ docker build . -f Neredataltics.SmartModel\Dockerfile -t kohestanimahdi/smart-model:1.0
```

after creating the images, you have to push them to the `DockerHub` by below commands:

```console
$ docker push <yourUserName>/smart-feature
$ docker push <yourUserName>/smart-model
```

Example:
```console
$ docker push kohestanimahdi/smart-feature
$ docker push kohestanimahdi/smart-model
```

after pushing the images. you can run these commands to create pods on kubernetes
```console
$ kubectl apply -f sql-server-deploy.yml
$ kubectl apply -f smart-model-deploy.yml
$ kubectl apply -f smart-feature-deploy.yml
```
If everything is done well, you can see the documentation of the smart-feature service in this url:
[localhost/swagger](http://localhost/swagger/index.html)