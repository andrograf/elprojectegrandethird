#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Use Node.js 14 as the base image
FROM node:14

# Create a working directory for the app
WORKDIR /app

# Copy package.json and package-lock.json into the container
COPY package*.json ./

# Install dependencies
RUN npm install

# Copy the app's source code into the container
COPY . .

# Expose port 3000 for the container
EXPOSE 44447

# Start the app by running the proxy.js file
CMD ["node", "proxy.js"]
