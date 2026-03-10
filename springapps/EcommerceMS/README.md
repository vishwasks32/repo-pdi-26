# EcommerceMS

This repository contains a simple microservice-based e-commerce system built with Spring Boot. Each service is a standalone Maven project, providing a focused piece of functionality. The overall architecture consists of:

- **Service Registry** (`serviceregistry`): A Eureka server for service discovery.
- **API Gateway** (`apigateway`): A Zuul or Spring Cloud Gateway-based edge service handling routing and security.
- **Products Service** (`productsapp`): Manages product catalog and information.
- **Orders Service** (`ordersapp`): Handles order creation and tracking.
- **Payments Service** (`paymentsapp`): Processes payment transactions.

## Requirements

- Java 17 or later
- Maven 3.6+
- Docker (optional, if you containerize services)

## Getting Started

Each service can be started independently. The typical development workflow is:

1. Start the **Service Registry** first:
   ```bash
   cd springapps/EcommerceMS/serviceregistry
   ./mvnw spring-boot:run
   ```
   The registry listens on `http://localhost:8761` by default.

2. Start the **API Gateway**:
   ```bash
   cd ../apigateway
   ./mvnw spring-boot:run
   ```
   The gateway runs on `http://localhost:8080` and routes to downstream services.

3. Start backend services (products, orders, payments) in any order:
   ```bash
   cd ./productsapp && ./mvnw spring-boot:run
   cd ./ordersapp && ./mvnw spring-boot:run
   cd ./paymentsapp && ./mvnw spring-boot:run
   ```

4. Access the system via the gateway. Example endpoints:
   - `GET http://localhost:8080/products` for product catalog
   - `POST http://localhost:8080/orders` to create an order
   - `POST http://localhost:8080/payments` to submit a payment

## Project Structure

Each subfolder is a standard Spring Boot application with:

```
src/main/java/...         # application source code
src/main/resources/       # configuration (application.yml)
src/test/java/...         # unit and integration tests
pom.xml                   # Maven configuration
```

## Configuration

Default configuration for each service is stored in `src/main/resources/application.yml`. Ports, database connections, and other properties can be overridden via command-line arguments or environment variables.

## Testing

Run `./mvnw test` inside any service directory to execute its tests.

## Docker (optional)

Each service includes a Dockerfile (if applicable) and can be built with:

```bash
cd service-folder
./mvnw spring-boot:build-image -Dspring-boot.build-image.imageName=company/service-name
```

Then run using `docker run` or compose together with a `docker-compose.yml` you create.

## License

This project is provided as-is for learning purposes.