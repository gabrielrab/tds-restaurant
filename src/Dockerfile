## Build Stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /source
ENV PATH="${PATH}:/root/.dotnet/tools"
COPY ./Restaurant.Api ./Restaurant.Api
COPY ./Restaurant.Data ./Restaurant.Data
RUN dotnet restore "./Restaurant.Api/Restaurant.Api.csproj" --disable-parallel
RUN dotnet publish "./Restaurant.Api/Restaurant.Api.csproj" -c release -o /app --no-restore
RUN dotnet tool install --global dotnet-ef 
RUN cd "./Restaurant.Api/" && dotnet ef database update -s "../Restaurant.Api"

## Serve Stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app ./
ENV ASPNETCORE_URLS http://*:5001
ENV ASPNETCORE_ENVIRONMENT=Development
ENTRYPOINT [ "dotnet", "Restaurant.Api.dll" ]
