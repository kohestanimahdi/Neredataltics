# Neredataltics - Weather Condition and History

The goal of this project is to implement a weather service that depends on the country and city, returns the temprature and air condition.

## Development notes
This project consist two projects, `SmartModel` and `SmartFeatures`:

SmartModel: is a gRPC server, that returns the current weather of specific location (Country and City)
SmartFeatures: is a REST api sevice, that connects to the `SmartModel` as a client and get the data that user demand. This service, also, save the information
of the weather for each location in Database and has an endpoint to get the data from the database by some filters.
The services relation is drawed below:

![alt text](https://kohestanimahdi.ir/images/photo_2022-12-26_22-20-44.jpg)