FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine as build
WORKDIR /src

RUN dotnet --version

COPY . ./

RUN dotnet restore 

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine
WORKDIR /App

ENV DOTNET_EnableDiagnostics=0
ENV ASPNETCORE_HTTP_PORT=https://+:5001
ENV ASPNETCORE_URLS=http://+:5000

EXPOSE 5001 5000

RUN apk add --no-cache tzdata
ENV TZ America/Sao_Paulo

COPY --from=build /src/out .

RUN date

ENTRYPOINT [ "dotnet", "Alfa.Filmes.Api.dll" ]