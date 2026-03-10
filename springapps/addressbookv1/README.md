# Address Book v1

This is a simple Spring-based address book application demonstrating basic JDBC operations with `JdbcTemplate`. The project includes a `User` entity and a corresponding DAO that interacts with a MySQL database.

## Features

- Minimal Spring configuration using Java-based annotations
- `JdbcTemplate` for database access
- Ability to save and fetch `User` records

## Project Structure

```
addressbookv1/
├── pom.xml                 # Maven project descriptor
└── src/main/java/com/cloudthat/
    ├── BeanConfig.java     # Spring configuration (DataSource, JdbcTemplate)
    ├── Main.java           # Simple main to bootstrap Spring context
    ├── User.java           # POJO representing a user
    ├── PhoneNumber.java    # POJO for phone number (unused by DAO)
    └── UserDao.java        # Repository handling CRUD operations
```

## Requirements

- Java 17 (or later)
- Maven 3.6+
- MySQL database running with a schema named `demodb`

## Setup

1. Ensure MySQL is running and create the database and table:

    ```sql
    CREATE DATABASE demodb;
    USE demodb;
    
    CREATE TABLE User (
        id INT AUTO_INCREMENT PRIMARY KEY,
        username VARCHAR(100),
        emailId VARCHAR(150),
        phoneNumber VARCHAR(50)
    );
    ```

2. Update `BeanConfig` if your database connection details differ.

3. Build the project with Maven:

    ```bash
    cd springapps/addressbookv1
    mvn clean package
    ```

4. Run the application:

    ```bash
    mvn exec:java -Dexec.mainClass=com.cloudthat.Main
    ```

    The sample `Main` class will insert a user and print a user retrieved by ID.

## Notes

- This example uses `DriverManagerDataSource` without pooling; it's intended for learning/demo only.
- The `PhoneNumber` class is included for potential extension but isn't persisted in this version.

## License

Provided as-is for educational purposes.