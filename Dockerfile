# Build Stage
FROM microsoft/dotnet:2.2-sdk AS build-env

ARG APP_VER="0"

COPY src /build/src
COPY test /build/test
COPY CarPark.sln /build/CarPark.sln
COPY nuget.config /build/nuget.config
WORKDIR /build

RUN dotnet restore

WORKDIR /build/src/CarPark.WebServer

RUN echo ${APP_VER}
RUN dotnet publish -o /app -c Release -f netcoreapp2.2 -r debian.9-x64 --version-suffix $APP_VER


# Runtime Image Stage
FROM microsoft/dotnet:2.2-aspnetcore-runtime

ENV INFLUXDB_BASEURI="http://127.0.0.1:8086"
ENV INFLUXDB_DATABASE="metricsdatabase"
ENV INFLUXDB_CONSISTENCY="consistency"
ENV INFLUXDB_USERNAME="admin"
ENV INFLUXDB_PASSWORD="password"
ENV INFLUXDB_RETENTIONPOLICY="rp"

ENV REDIS_URL=""

WORKDIR /app
COPY --from=build-env /app .

EXPOSE 80

ENTRYPOINT ["dotnet", "CarPark.WebServer.dll"]