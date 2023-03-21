# Btc
Bitcoin instruction simulation

## Run
Create and start containers

`docker compose up`

### Debug
To debug the application, first run the `docker compose -f docker-compose-debug.yml up` command. Then the **Btc.Instructure.Api** and **Btc.Notification.Consumer** projects are run together.

## Notes
- You can test the API by importing the following Postman collection:  [Source](https://api.postman.com/collections/3752724-63051831-aa9b-4ade-9b29-58a7ba920e2b?access_key=PMAT-01GW10E6QW1E8PDMXANY9BD5AB)
- When the Docker command is run, Instruction Api, PostgreSQL, RabbitMQ, Notification Consumer, MongoDB instances start.
- Since the database first approach is used, the sql script in init.sql is automatically executed. Thus, tables are created on PostgreSQL and one User record is inserted.
- On the MongoDB side, the database and the collection to be used are automatically created in the same way.
- Data will be lost when containers are downed. No docker volumes have been added to simplify the review.

### Technologies And Approaches
- .NET 7
- Entity Framework Core
- CQRS
- MediatR
- Mapster
- Fluent Validation
- PostgreSQL
- RabbitMQ
- MongoDB
- Layered Architecture
- Chain Of Responsibility Pattern
- Dependency Injection
- SOLID
- OOP
- Design Patterns
- Clean Code
- Database First

### Solution Structure
```
.
├── src
│   ├── Btc.Instructions.Api
│   ├── Btc.Instructions.Application
│   ├── Btc.Instructions.Data
│   ├── Btc.Instructions.Domain
│   ├── Btc.Notification.Application
│   ├── Btc.Notification.Consumer
│   ├── Btc.Notification.Data
│   ├── Btc.Notification.Domain
├── docker-compose.yml
├── docker-compose-debug.yml
├── init.sql
├── mongo-init.js
└── README.md
```

### Project Structure
![Btc](https://user-images.githubusercontent.com/21276521/226559327-9b0def08-6d63-4ac4-8ca8-0c6b9afe7123.png)

### Database Design
![db_design](https://user-images.githubusercontent.com/21276521/226558702-d1809dfd-6cf9-478c-8295-ee75a5d70ddd.png)

