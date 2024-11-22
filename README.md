# TODO Application

A simple TODO list application built with .NET backend and React frontend.

## Tech Stack

Frontend:
- React (Vite)
- Tailwind CSS
- Redux
- TanStack React Query

Backend:
- .NET
- Entity Framework Core (In-memory database)


## Features

- Create, read, update, and delete TODO items
- Search and filter functionality

## Configuration

The project includes all necessary Docker configuration files and environment variables. Example of environment variable (included in repository):

```
VITE_API_BASE_URL=http://localhost:7100
```

## Running the Application

### Prerequisites

- Docker
- Docker Compose

### Steps to Run

1. Clone the repository:
```bash
git clone [repository-url]
```

2. Navigate to the project directory:
```bash
cd [project-directory]
```

3. Run the application using Docker Compose:
```bash
docker compose up --build
```

The application will be available at:
- Frontend: http://localhost:3100
- Backend API: http://localhost:7100
