# Use the official .NET Core SDK image as the base image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Install Node.js and npm
RUN apt-get update && apt-get install -y nodejs npm
RUN npm install mermaid
RUN npm audit fix --force

# Copy the project file and restore any dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the entire project and build it
COPY . ./
RUN dotnet publish -c Release -o out

# Use the official ASP.NET Core runtime image as the base image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app

# Copy the published output from the build environment
COPY --from=build-env /app/out ./

# Set the ASP.NET Core environment
ENV ASPNETCORE_ENVIRONMENT Development

# Expose the port that the application will listen on
EXPOSE 80

# Start the application
ENTRYPOINT ["dotnet", "bitfit.dll"]
