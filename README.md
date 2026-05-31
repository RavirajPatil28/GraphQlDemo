# GraphQL Demo API

A sample GraphQL application built using ASP.NET Core and Hot Chocolate to demonstrate GraphQL fundamentals and advanced concepts such as nested queries, mutations, filtering, sorting, resolvers, and DataLoaders.

## Architecture

The solution is organized into three projects:

```text
GraphQLDemo
│
├── GraphQLDemo.Api
│   ├── Program.cs
│   ├── Query.cs
│   └── Mutation.cs
│
├── GraphQLDemo.Business
│   ├── Resolvers
│   └── DataLoaders
│
└── GraphQLDemo.Data
    ├── Entities
    ├── InputTypes
    ├── Models
    └── Data
```

### Project Responsibilities

#### GraphQLDemo.Api

Contains:

* GraphQL endpoint configuration
* Query definitions
* Mutation definitions
* Application startup configuration

#### GraphQLDemo.Business

Contains:

* GraphQL Resolvers
* DataLoaders
* Business logic

#### GraphQLDemo.Data

Contains:

* Domain entities
* Input models
* Mock data store
* Shared models

---

## Domain Model

The application represents a simple Order Management System.

### Customer

```text
Customer
 ├── Id
 ├── Name
 └── Email
```

### Order

```text
Order
 ├── Id
 ├── OrderNumber
 ├── OrderDate
 └── CustomerId
```

### Item

```text
Item
 ├── Id
 ├── ItemCode
 ├── Description
 └── Price
```

### OrderItem

```text
OrderItem
 ├── OrderId
 ├── ItemId
 └── Quantity
```

Relationships:

```text
Customer
   │
   └── Orders
          │
          └── OrderItems
                    │
                    └── Item
```

---

## Features

### Queries

Retrieve customers, orders, and items.

Example:

```graphql
query {
  customers {
    id
    name
    email
  }
}
```

### Nested Queries

Fetch related data in a single request.

```graphql
query {
  orders {
    orderNumber

    customer {
      name
    }

    orderItems {
      quantity

      item {
        itemCode
        description
      }
    }
  }
}
```

### Mutations

Create customers, items, orders, and order items.

Example:

```graphql
mutation {
  createCustomer(
    input: {
      name: "Raviraj Patil"
      email: "raviraj@example.com"
    }
  ) {
    id
    name
  }
}
```

### Filtering

```graphql
query {
  orders(
    where: {
      customerId: {
        eq: 1
      }
    }
  ) {
    orderNumber
  }
}
```

### Sorting

```graphql
query {
  orders(
    order: {
      orderDate: DESC
    }
  ) {
    orderNumber
    orderDate
  }
}
```

---

## DataLoaders

The project demonstrates solving the GraphQL N+1 problem using DataLoaders.

Implemented DataLoaders:

* CustomerDataLoader
* ItemDataLoader
* OrderDataLoader

### Without DataLoader

```text
1 query to load Orders

100 queries to load Customers
```

### With DataLoader

```text
1 query to load Orders

1 batched query to load Customers
```

Benefits:

* Request batching
* Reduced database calls
* Improved performance
* Built-in caching

---

## GraphQL Concepts Demonstrated

* Schema Design
* Queries
* Mutations
* Object Relationships
* Resolvers
* Filtering
* Sorting
* DataLoaders
* N+1 Problem

---

## Running the Application

### Prerequisites

* .NET 8 SDK
* Visual Studio 2022 or VS Code

### Run

```bash
dotnet restore
dotnet build
dotnet run
```

Open:

```text
https://localhost:<port>/graphql
```

Use Banana Cake Pop to execute GraphQL queries and mutations.

---

## Future Enhancements

* Subscriptions
* Authorization
* Pagination
* Custom Scalars
* Validation
* File-based Persistence
* Entity Framework Core Integration

---

## Purpose

This project was created as a learning and demonstration project to explore GraphQL concepts using Hot Chocolate and ASP.NET Core.

It is intended for knowledge-sharing sessions, technical presentations, and portfolio purposes.

---

## Author

Raviraj Patil

.NET Full Stack Developer

Technologies:

* C#
* ASP.NET Core
* GraphQL (Hot Chocolate)
* SQL Server
* Angular
