# שלב 1: בסיס להרצה
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# שלב 2: בסיס לבנייה
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# העתק את כל הקבצים
COPY . .

# בצע Restore
RUN dotnet restore "Portfolio.API/Portfolio.API.csproj"

# בצע Publish
RUN dotnet publish "Portfolio.API/Portfolio.API.csproj" -c Release -o /app/publish

# שלב 3: הרצה סופית
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Portfolio.API.dll"]
