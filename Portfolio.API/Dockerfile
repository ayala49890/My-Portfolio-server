# ��� 1: ���� �����
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# ��� 2: ���� ������
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# ���� �� �� ������
COPY . .

# ��� Restore
RUN dotnet restore "Portfolio.API/Portfolio.API.csproj"

# ��� Publish
RUN dotnet publish "Portfolio.API/Portfolio.API.csproj" -c Release -o /app/publish

# ��� 3: ���� �����
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Portfolio.API.dll"]
