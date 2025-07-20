This repository contains my solution for the DataPatrol Full‑Stack Developer technical assignment.  
It includes:

- ASP.NET Core Web API (with EF Core, Repository/UoW, seed data, background worker)  
- Blazor Server UI (Blazor + Bootstrap components)  
- Random Number API for Task 2

#Apply EF Migrations & Seed Data

The API will listen on http://localhost:5116/

The Blazor UI will listen on http://localhost:5191/

RESTful API Endpoints


#Users

POST /api/User/reg

GET /api/User

GET /api/User/{userId}

PUT /api/User/{userId}

DELETE /api/User/{userId}

PUT /api/User/{userId}/toggle

POST /api/User/{userId}/groups

#User Requests

POST /api/Request/create

POST /api/Request/summary

GET /api/Request

GET /api/Request/{requestID}

PUT /api/Request/{requestID}

DELETE /api/Request/{requestID}


#User Groups

GET /api/Group

GET /api/Group/{groupId}

POST /api/Group

PUT /api/Group/{groupId}

DELETE /api/Group/{groupId}

POST /api/Group/{groupId}/users

POST /api/Group/{groupId}/policies


#Policies

GET /api/Policy

GET /api/Policy/{policyId}

POST /api/Policy

PUT /api/Policy/{policyId}

DELETE /api/Policy/{policyId}

POST /api/Policy/{policyId}/groups


#Random Number

GET /api/Random



Key Features
Data Model & Multi‑Tenancy Ready
EF Core entities with many‑to‑many mappings and cascade‑delete rules.

Repository & Unit‑of‑Work Pattern
Clean OOP abstraction for all data access.

Memory Management

Scoped DbContext + optional pooling

.AsNoTracking() on read queries

Blazor Server UI

MudBlazor + Bootstrap for responsive, accessible components

Modal dialogs, tables, and client‑side routing

Background Worker
Processes UserRequest records every 10 seconds according to business rules.

DTOs & Services
Task 2’s RandomService and generic ResponseDto<T> to demonstrate DI and layering.

Feel free to browse the code and run the solution locally. If you have any questions or run into issues, let me know!
Qais

**Notes on how I added the Random API:
- Under **RESTful API Endpoints**, I created a new **Random Number (Task 2)** section.  
- I listed `GET /api/Random` and showed its sample response shape.  

You can adjust the port URLs, project folder names, or phrasing to match your final structure, but this template should give you a polished, professional README that covers **everything**.
