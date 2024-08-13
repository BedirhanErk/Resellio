# Resellio

Resellio is an e-commerce project for buying and selling second-hand goods. The project was developed using **Asp.Net Core MVC** and **Microservices** architecture. You can examine the microservices architecture used in the project in the diagram below. Additionally, you can access the project details and pictures provided.

## Diagram

![Resellio Diagram](https://i.ibb.co/N6tVj47/Resellio-Diagram.png)

## Asp.Net Core MVC Microservice

UI microservice is responsible for displaying the data obtained from the microservices to the user and facilitating interaction with the user.

- **HTML**
- **CSS**
- **JavaScript**
- **Bootstrap**
- **jQuery**
- **FluentValidation**

## API Gateway

- **Ocelot**

## Catalog Microservice

Microservice responsible for the storage and presentation of products and product categories.

 - **MongoDB**
 - **MongoDB.Driver**
 - **AutoMapper**
  
## Basket Microservice

Microservice responsible for basket operations.

- **RedisDB**
- **StackExchange.Redis**

## Order Microservice

Microservice responsible for order processing.

- **Sql Server**
- **Entity Framework Core**
- **Domain Driven Design** (DDD)
- **CQRS** (MediatR)

## Discount Microservice

Microservice is responsible for the discount coupons offered to users.

- **PostgreSQL**
- **Dapper**

## Photo Stock Microservice

Microservice responsible for keeping and presenting product photographs.

## Payment Microservice

Microservice is responsible for payment processing.

## IdentityServer Microservice

Microservice responsible for user data storage, token and refreshtoken generation.

- **Sql Server**
- **Entity Framework Core**

## Message Broker

- **RabbitMQ** 
- **MassTransit** 

## Docker

The databases used in the project have been set up as containers. At the end of the project, the microservices were dockerized and docker compose files were created

![Resellio Gif](https://i.ibb.co/SsWHwNQ/Resellio-Gif.gif)

---

I continue to develop the project if you have any suggestions or if you encounter any problems

Mail: erkilicbedirhan@gmail.com

---
