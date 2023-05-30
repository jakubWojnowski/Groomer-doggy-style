FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

COPY *sln .
COPY src/Groomer-doggy-style/GroomerDoggyStyle/*.csproj ./src/Groomer-doggy-style/GroomerDoggyStyle/
COPY src/Groomer-doggy-style/GroomerDoggyStyle.Application/*.csproj ./src/Groomer-doggy-style/GroomerDoggyStyle.Application/
COPY src/Groomer-doggy-style/GroomerDoggyStyle.Application.Address/*.csproj ./src/Groomer-doggy-style/GroomerDoggyStyle.Application.Address/
COPY src/Groomer-doggy-style/GroomerDoggyStyle.Application.Dogs/*.csproj ./src/Groomer-doggy-style/GroomerDoggyStyle.Application.Dogs/
COPY src/Groomer-doggy-style/GroomerDoggyStyle.Application.Employee/*.csproj ./src/Groomer-doggy-style/GroomerDoggyStyle.Application.Employee/
COPY src/Groomer-doggy-style/GroomerDoggyStyle.Application.GroomerShops/*.csproj ./src/Groomer-doggy-style/GroomerDoggyStyle.Application.GroomerShops/
COPY src/Groomer-doggy-style/GroomerDoggyStyle.Application.Offers/*.csproj ./src/Groomer-doggy-style/GroomerDoggyStyle.Application.Offers/
COPY src/Groomer-doggy-style/GroomerDoggyStyle.Application.Owners/*.csproj ./src/Groomer-doggy-style/GroomerDoggyStyle.Application.Owners/
COPY src/Groomer-doggy-style/GroomerDoggyStyle.Application.Visits/*.csproj ./src/Groomer-doggy-style/GroomerDoggyStyle.Application.Visits/
COPY src/Groomer-doggy-style/GroomerDoggyStyle.Domain/*.csproj ./src/Groomer-doggy-style/GroomerDoggyStyle.Domain/
COPY src/Groomer-doggy-style/GroomerDoggyStyle.Infrastructure/*.csproj ./src/Groomer-doggy-style/GroomerDoggyStyle.Infrastructure/
RUN dotnet restore

COPY . .
RUN dotnet build

FROM build AS publish
WORKDIR /app/src/Groomer-doggy-style/GroomerDoggyStyle
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=publish /app/src/Groomer-doggy-style/GroomerDoggyStyle/out ./
EXPOSE 80
EXPOSE 433
ENTRYPOINT [ "dotnet", "GroomerDoggyStyle.dll" ]