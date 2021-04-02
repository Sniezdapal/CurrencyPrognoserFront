FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR src/
COPY CurrencyPrognoser.csproj .
RUN dotnet restore
COPY . .
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /app
COPY --from=publish /app/publish/wwwroot .
COPY nginx.conf /etc/nginx/nginx.conf