FROM eclipse-temurin:21.0.10_7-jdk-noble
WORKDIR /app
COPY target/addressbookv2-0.0.1-SNAPSHOT.jar /app/app.jar
EXPOSE 8086
ENTRYPOINT ["java","-jar","app.jar"]