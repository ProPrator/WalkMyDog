# DogWalk API 🐾

DogWalk is a backend service for dog walking.  
It works like Bolt Food, but for walking dogs.

This project is **API only**. There is no frontend.

## Idea
A dog owner creates a walk order.  
A dog walker accepts the order and walks the dog.

The API manages users, dogs, and walk orders.

## Tech Stack
- .NET (ASP.NET Core Web API)
- PostgreSQL
- Entity Framework Core
- REST API

## Main Entities
- User (owner or walker)
- Dog
- WalkOrder
- WalkStatus

## API Features
- User registration and login
- Create a dog walk order
- Accept a walk order
- Finish a walk
- Get active and finished walks

## Architecture
- Simple layered architecture
- Controllers and DTOs
- PostgreSQL database

## How to Run
1. Install PostgreSQL
2. Set `ConnectionString`
3. Run database migrations
4. Start the API

```bash
dotnet run
