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
