# Address Book v2

This is a second iteration of a Spring Boot-based address book service that exposes a REST API for managing contacts. It's a more feature-rich version of the earlier `addressbookv1` project, demonstrating use of Spring Data JPA, validation, DTO mapping, paging, exception handling, and automated tests.

## Key Features

- Spring Boot application with sensible defaults
- REST endpoints under `/api/v1/contacts` for creating and listing contacts
- Data persistence via Spring Data JPA (MySQL)
- DTOs for request/response (`ContactModel`, `AddressModel`, etc.)
- Custom exceptions and global handler for business rules (e.g. duplicate email)
- Support for tags attached to contacts (many-to-many relationship)
- Pagination of contact listing using `Pageable`
- Configuration via `application.yml` with development defaults
- Unit and controller tests using Spring's testing support
- Support email endpoint `/api/v1/contacts/help` drawing from config
- Swagger/OpenAPI documentation enabled (via `springdoc`)

## Project Structure

```
addressbookv2/
├── pom.xml
├── src/
│   ├── main/
│   │   ├── java/com/cloudthat/addressbookv2/
│   │   │   ├── config/AppConfig.java
│   │   │   ├── controllers/ContactController.java
│   │   │   ├── dtos/         # Data transfer objects
│   │   │   ├── exceptions/   # Custom business exceptions / handler
│   │   │   ├── mappers/      # DTO-to-entity mappers
│   │   │   ├── models/       # JPA entities and converters
│   │   │   ├── repositories/ # Spring Data JPA repositories
│   │   │   ├── services/     # Business logic
│   │   │   └── Addressbookv2Application.java
│   │   └── resources/application.yml
│   └── test/                # Unit and controller tests
└── data/                      # placeholder for DB files
```

## Requirements

- Java 17+
- Maven 3.6+
- MySQL server with a database named `contactmanagerdb`

## Setup & Running

1. **Database** – create the schema if it does not exist. The app uses `create-drop` mode by default:

   ```sql
   CREATE DATABASE contactmanagerdb;
   ```

2. **Configuration** – verify or adjust connection settings in `src/main/resources/application.yml`.

3. **Build**:

   ```bash
   cd springapps/addressbookv2
   ./mvnw clean package
   ```

4. **Run**:

   ```bash
   ./mvnw spring-boot:run
   ```

   The service will start on port `8086`.

5. **API endpoints**
   - `GET /api/v1/contacts?page=0&size=20` – list contacts (paged)
   - `POST /api/v1/contacts` – create a new contact (JSON body matching `ContactModel`)
   - `GET /api/v1/contacts/help` – support email message

6. **Swagger/OpenAPI** – access docs at `http://localhost:8086/swagger-ui.html` once the app is running.

## Testing

Run all tests with:

```bash
./mvnw test
```

Example unit tests cover the service and controller layers.

## Notes

- The project uses Lombok for loggers and model convenience. Ensure your IDE has Lombok support enabled.
- The `AppConfig` class exposes a `supportEmail` property read from YAML.
- JPA entities include converters for enums (e.g. `GenderConverter`).

## Extending

Future enhancements could include full CRUD endpoints, search/filter capabilities, security, or moving to a microservice architecture.

## License

Provided as-is for learning and demonstration purposes.