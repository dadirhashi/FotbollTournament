# TournaPRO – Tournament Registration App

A fullstack tournament management application built with a .NET Web API backend and a vanilla HTML/CSS/JavaScript frontend.

---

## What the application does

TournaPRO lets you manage a sports tournament from end to end:

- Create and manage **Tournaments**
- Register **Teams** and assign them to tournaments
- Add **Players** and assign them to teams
- Schedule **Games** between teams, including scores

---

## How to run the project

### Backend (.NET API)

```bash
cd TournamentApi
dotnet restore
dotnet ef database update   # applies migrations
dotnet run
```

The API will start on `http://localhost:5000` by default.

### Frontend

No build step needed. Just open `index.html` in your browser, or serve it with any static server:

```bash
# Example with VS Code Live Server, or:
npx serve .
```

> ⚠️ Make sure the API URL in `index.html` matches your backend port.  
> Look for this line near the bottom of the `<script>` tag:
> ```js
> const API = 'http://localhost:5000/api';
> ```

---

## API Endpoints

### Tournaments
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/tournament` | Get all tournaments |
| GET | `/api/tournament/id?id={id}` | Get tournament by ID |
| POST | `/api/tournament` | Create tournament |
| PUT | `/api/tournament/id?id={id}` | Update tournament |
| DELETE | `/api/tournament/id?id={id}` | Delete tournament |

### Teams
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/team` | Get all teams |
| GET | `/api/team/id?id={id}` | Get team by ID |
| POST | `/api/team` | Create team |
| PUT | `/api/team/id?id={id}` | Update team |
| DELETE | `/api/team/id?id={id}` | Delete team |

### Players
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/player` | Get all players |
| GET | `/api/player/id?id={id}` | Get player by ID |
| POST | `/api/player` | Create player |
| PUT | `/api/player/id?id={id}` | Update player |
| DELETE | `/api/player/id?id={id}` | Delete player |

### Games
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/game` | Get all games |
| GET | `/api/game/id?id={id}` | Get game by ID |
| POST | `/api/game` | Create game |
| PUT | `/api/game/id?id={id}` | Update game |
| DELETE | `/api/game/id?id={id}` | Delete game |

---

## How the frontend communicates with the API

The frontend uses the browser's native `fetch` API to make HTTP requests to the .NET backend.

- **GET** requests load data on page load and after every change
- **POST** requests send JSON from form inputs to create new records
- **PUT** requests send updated JSON to edit existing records
- **DELETE** requests remove records by ID via query parameter

All responses are parsed as JSON and rendered into the DOM dynamically — no page reloads needed. Error messages and success confirmations are shown via a toast notification system.

Example fetch call:
```js
const res = await fetch('http://localhost:5000/api/tournament', {
  method: 'POST',
  headers: { 'Content-Type': 'application/json' },
  body: JSON.stringify({ name: 'Spring Cup', startDate: '2025-03-01', endDate: '2025-03-15' })
});
```

---

## Reflection

### What went well
- The backend structure with Controllers → Services → Repository is clean and easy to extend. AutoMapper kept the controllers thin and the DTOs clearly separated from the domain models.
- The frontend came together quickly without a framework — vanilla JS with `fetch` and DOM manipulation is more than enough for an app at this scale.
- The relational model (Tournament → Team → Player, Tournament → Game) maps naturally to the UI flow.

### What was challenging
- The routing pattern `[HttpGet("id")]` with `[FromQuery] int id` is unconventional — normally REST APIs use route parameters like `/api/tournament/{id}`. This meant the frontend had to use query strings (`?id=`) instead of path segments, which required attention.
- Keeping the frontend state in sync after mutations (create/update/delete) required reloading all related data, since entities reference each other by ID.
- CORS needs to be configured in `Program.cs` to allow the frontend to communicate with the API from a different origin.

### Possible improvements
- Add authentication (e.g. JWT) so only authorized users can modify data
- Add pagination for large datasets
- Switch to standard route parameters (`/{id}`) in the API for cleaner REST conventions
- Add a bracket/standings view to visualize tournament progress
