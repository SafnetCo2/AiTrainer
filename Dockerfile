# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Build the app from source code
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HotelChatbotBackend/HotelChatbotBackend.csproj", "HotelChatbotBackend/"]
RUN dotnet restore "HotelChatbotBackend/HotelChatbotBackend.csproj"
COPY . .
WORKDIR "/src/HotelChatbotBackend"
RUN dotnet build "HotelChatbotBackend.csproj" -c Release -o /app/build

# Publish the app
FROM build AS publish
RUN dotnet publish "HotelChatbotBackend.csproj" -c Release -o /app/publish

# Final stage - copy published files and set the entry point
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HotelChatbotBackend.dll"]
