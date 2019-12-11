# Mini-Project-3-microservices

The objective of this project is to support your learning of microservices integration, deployment, composition, and orchestration. It will be also a software support for a virtual company with a business in providing booking services.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites
Software needed for running this project

- Install RabbitMQ (https://www.rabbitmq.com/download.html)
- Install Visual studio 2019 (https://visualstudio.microsoft.com/downloads/)

### Setup Instructions
- Download this repository
- Open both the client and server with Visual studio 2019
- Change file paths to the direction your project is installed (There are 2 paths to adjust, both located in Receive.cs)
	- Mini-Project-3-microservices -> MiniProject2Server -> Receive.cs
- Start RabbitMQ
- Run Server and the Client afterwards
	
## Our Microservices
We have refactored mini project 2 and seperated Car as a microservice, so now the car objects are handled in our Car Rest. We have also created another Rest microservice called Review which handle everything about reviews.
