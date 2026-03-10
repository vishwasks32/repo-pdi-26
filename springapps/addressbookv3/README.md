# Address Book v3

This is the third evolution of the Spring-based address book service. Building on `addressbookv2`, this version adds user registration and JSON Web Token (JWT)‑based authentication so that only authenticated clients can access contact management endpoints.

## Highlights

- Full Spring Boot application with REST API
- User registration and login endpoints (`/register`, `/login`)
- JWT authentication and authorization via a `JwtFilter` and `WebSecurityConfig`
- Password hashing with `BCryptPasswordEncoder`
- Role support (`ROLE_USER`, etc.) stored in `User` entity
- Continued support for contact CRUD operations under `/api/v1/contacts`
- Swagger/OpenAPI docs and global exception handling
- JPA entities, DTO mappers, validation, and paging from v2
- Unit tests included for core functionality

## Project Layout

```
addressbookv3/
├── pom.xml
├── src/
│   ├── main/java/com/cloudthat/addressbookv2/
│   │   ├── config/
│   │   │   ├── AppConfig.java          # property beans
│   │   │   └── WebSecurityConfig.java  # Spring Security setup
│   │   ├── controllers/
│   │   │   ├── AuthController.java     # register & login
│   │   │   └── ContactController.java  # contact endpoints
│   │   ├── dtos/                       # API request/response models
│   │   ├── entities/                   # JPA entities
│   │   ├── exceptions/                 # business errors & handler
│   │   ├── filters/                    # JWT filter implementation
│   │   ├── mappers/                    # DTO ↔ entity converters
│   │   ├── repositories/               # Spring Data JPA repos
│   │   ├── services/                   # business logic (including UserService)
│   │   ├── utility/                    # JWT utility class
│   │   └── Addressbookv2Application.java
│   └── resources/application.yml       # configuration
└── test/                               # basic integration/unit tests
```

## Requirements

- Java 17+
- Maven 3.6+
- MySQL database named `contactmanagerdb` (or adjust config)

## Setup & Configuration

1. **Database** – ensure (`ddl-auto: validate`) schema exists. You may reuse the schema from v2.

2. **Configuration** – update `src/main/resources/application.yml` for credentials, port, and other settings.

3. **Build**:

```bash
cd springapps/addressbookv3
./mvnw clean package
```

4. **Run**:

```bash
./mvnw spring-boot:run
```

   Server listens on port `8086` by default.

## API Endpoints

### Authentication

| Method | Path      | Description                               |
|--------|-----------|-------------------------------------------|
| POST   | /register | Create a new user (body `UserModel`).     |
| POST   | /login    | Authenticate, returns JWT token.          |

### Contacts (protected)

All `/api/v1/contacts` requests require an `Authorization: Bearer <token>` header obtained from login.

| Method | Path                        | Description                             |
|--------|-----------------------------|-----------------------------------------|
| GET    | /api/v1/contacts            | List contacts, supports paging.         |
| POST   | /api/v1/contacts            | Create new contact                      |
| GET    | /api/v1/contacts/help       | Return support email from config        |

Other endpoints may exist for addressing or search (check controller comments).

### Documentation

Swagger UI is available at `http://localhost:8086/swagger-ui.html` and API docs at `/api/v1/api-docs`.

## Testing

Run the test suite:

```bash
./mvnw test
```

The tests exercise the authentication flow and basic contact service.

## Security Notes

- `WebSecurityConfig` marks `/register` and `/login` as public and secures all other paths.
- `JwtFilter` validates tokens on each request.
- Passwords are stored with BCrypt hashing.

## Extending & Deployment

Possible enhancements include role-based access control, refresh tokens, endpoint expansion (update/delete contacts), and Dockerization.

## License

This project is provided as-is for educational/demo purposes.