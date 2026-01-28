# Solution Document: Real Time - Inventory Dashboard Project

## 1. Project Overview

This project is a Real Time inventory management dashboard built using:

- **Frontend**: Angular 21
- **Backend**: .NET 8 Web API
- **Database**: (sqlite3)
- **Containerization**: Docker
- **Web Server**: Nginx (to serve Angular app)

The app allows Read and Update operations on inventory items and provides a responsive UI for managing inventory.

---

## 2. Architectural Decisions

### 2.1 Frontend

- **Framework**: Angular
- **Build & Deployment**:
  - Used Node 20 to build the Angular app.
  - Dist folder served via Nginx for static files.

### 2.2 Backend

- **Framework**: ASP.NET Core 8 Web API
- **Endpoints**: REST APIs for Read and Update operations on inventory.
- **Trade-off**: .NET chosen for strong typing, performance, and easy integration with SQL databases.

### 2.3 Containerization

- **Docker Compose**:
  - Multi-service setup: `frontend` + `backend` in the same network.
  - Network isolation via `inventory-net`.
- **Dockerfile Decisions**:
  - Frontend: Multi-stage build to reduce image size (`node:20` → `nginx:alpine`).
  - Backend: Multi-stage build using .NET SDK → Runtime image.

### 2.4 Nginx

- **Purpose**: Serve Angular static files and proxy API requests to backend.
- **Configuration**:
  - `/` → Angular app (`index.html`)
  - `/api/` → Backend API proxy
  - `/hubs/` → SignalR or WebSocket endpoints
- **Trade-off**: Avoids CORS issues by proxying all API calls.

---

## 4. How to Run

1. Clone the repo:

```bash
git clone <repo-link>
cd InventoryDashboard
```

2. Build and run container (Bonus Task Done: Dockerize the solution so it runs with a single docker-compose up.
   ):

```bash
docker compose up --build
```
