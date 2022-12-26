# Neredataltics - Weather Forcast and History

The goal of this project is to implement a weather service that depends on the country and city, returns the temprature and air condition.

## Development notes
This project consist two projects, `SmartModel` and `SmartFeatures`:

SmartModel: is a gRPC server, that returns the current weather of specific location (Country and City)
SmartFeatures: is a REST api sevice, that connects to the `SmartModel` as a client and get the data that user demand. This ser