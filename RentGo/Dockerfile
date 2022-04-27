FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine as build
WORKDIR /app
COPY . .

#ENV ASPNETCORE_ENVIRONMENT=Development

# Install cultures (same approach as Alpine SDK image)
#RUN apk add --no-cache icu-libs
#RUN apt-get install libicu-dev
# Disable the invariant mode (set in base image)
#ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

RUN dotnet restore
RUN dotnet publish "RentGo.Api/RentGo.Api.csproj" -c Release -o /app/published-app

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine as runtime
WORKDIR /app

COPY --from=build /app/published-app /app


 ENV \
     DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false \
     LC_ALL=en_US.UTF-8 \
     LANG=en_US.UTF-8
 RUN apk add --no-cache icu-libs


ENTRYPOINT [ "dotnet", "/app/RentGo.Api.dll" ]