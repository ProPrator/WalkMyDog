# -----------------------------
# Stage 1: Build the application
# -----------------------------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution and project files first (for faster restore caching)
COPY *.sln ./
COPY WalkMyDog.Api/*.csproj WalkMyDog.Api/
COPY WalkMyDog.Application/*.csproj WalkMyDog.Application/

# Restore dependencies
RUN dotnet restore

# Copy all source code
COPY . .

# Publish the API project to a folder
RUN dotnet publish WalkMyDog.Api/WalkMyDog.Api.csproj -c Release -o /app/publish

# -----------------------------
# Stage 2: Runtime image
# -----------------------------
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copy the published output from the build stage
COPY --from=build /app/publish .

# Tell ASP.NET Core to listen on port 8080
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

# Entry point for the container
ENTRYPOINT ["dotnet", "WalkMyDog.Api.dll"]
