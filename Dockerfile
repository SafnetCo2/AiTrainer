# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Build the app from source code
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the .csproj file (use the correct path here)
COPY HotelChatbotBackend.csproj ./ 

# Restore dependencies
RUN dotnet restore "HotelChatbotBackend.csproj"

# Copy the rest of the source code
COPY . .

# Set the working directory
WORKDIR "/src/HotelChatbotBackend"

# Build the app
RUN dotnet build "HotelChatbotBackend.csproj" -c Release -o /app/build

# Publish the app
FROM build AS publish
RUN dotnet publish "HotelChatbotBackend.csproj" -c Release -o /app/publish

# Final stage - copy published files and set the entry point
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HotelChatbotBackend.dll"]
