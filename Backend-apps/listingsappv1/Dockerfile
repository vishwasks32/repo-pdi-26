FROM node:20-alpine
WORKDIR /usr/src/app
COPY package*.json ./
RUN npm install
COPY . .
ENV PORT=3000
ENV MONGO_URI
EXPOSE 3000
CMD ["node", "app.js"]