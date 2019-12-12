# Mini-Project-3-microservices

Christoffer Dunk
Jonas Pedersen

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
we have 2 different microservices in play in our system: 
1. is able to fetch all the differnet car there should be available to book
2. handle every operation that regards Review, creating the review and storing it in out database (at Azure) and also able to fetch all the created review from the database

Car rest: 
[Car rest service, click here.](https://github.com/JonasManley/SI_RestServiceCars)

Review rest:
The repo is private since there's a username and password that we don't want the be exposed, message me if you want access to it. 

## CI & CD 
We have used Azure pipelines for both Continous integration and deloyment.

* Continuous integratiom - everytime we commit the main repo (Mini-project-3-microservices) or the two rests. 
* Continuous Deloyment - consist of two things: 1. stating, is where we make the application ready for deloyment to azure. 2. deploy it. 

## Problems
* composition - we tried to set up both thing and managed to add a docker composition to your solution, but we couldn't manage to make it work with rabbitMQ, which were nersesarry for our application to work at all.  
orchestration - Tried to set it up, but we just ran into one problem and then the next up, and at the end time caught up to us..
