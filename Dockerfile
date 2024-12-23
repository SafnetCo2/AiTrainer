# Use the official .NET SDK image for .NET 8.0
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory
WORKDIR /app

# Copy project files into the container
COPY . .

# Restore dependencies
RUN dotnet restore "HotelChatbotBackend.csproj"

# Build the application
RUN dotnet build "HotelChatbotBackend.csproj" -c Release -o /app/build

# Publish the application
RUN dotnet publish "HotelChatbotBackend.csproj" -c Release -o /app/publish

# Use the official .NET runtime image for .NET 8.0
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Set the working directory for the runtime
WORKDIR /app

# Copy published output from the build stage
COPY --from=build /app/publish .

# Expose the application's port
EXPOSE 80

# Set the entry point for the application
ENTRYPOINT ["dotnet", "HotelChatbotBackend.dll"]
