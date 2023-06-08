#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Groomer-doggy-style/GroomerDoggyStyle/GroomerDoggyStyle.Api.csproj", "src/Groomer-doggy-style/GroomerDoggyStyle/"]
COPY ["src/Groomer-doggy-style/GroomerDoggyStyle.Application.Address/GroomerDoggyStyle.Application.Address.csproj", "src/Groomer-doggy-style/GroomerDoggyStyle.Application.Address/"]
COPY ["src/Groomer-doggy-style/GroomerDoggyStyle.Application/GroomerDoggyStyle.Application.csproj", "src/Groomer-doggy-style/GroomerDoggyStyle.Application/"]
COPY ["src/Groomer-doggy-style/GroomerDoggyStyle.Domain/GroomerDoggyStyle.Domain.csproj", "src/Groomer-doggy-style/GroomerDoggyStyle.Domain/"]
COPY ["src/Groomer-doggy-style/GroomerDoggyStyle.Application.Dogs/GroomerDoggyStyle.Application.Dogs.csproj", "src/Groomer-doggy-style/GroomerDoggyStyle.Application.Dogs/"]
COPY ["src/Groomer-doggy-style/GroomerDoggyStyle.Application.Employee/GroomerDoggyStyle.Application.Employee.csproj", "src/Groomer-doggy-style/GroomerDoggyStyle.Application.Employee/"]
COPY ["src/Groomer-doggy-style/GroomerDoggyStyle.Application.GroomerShops/GroomerDoggyStyle.Application.GroomerShops.csproj", "src/Groomer-doggy-style/GroomerDoggyStyle.Application.GroomerShops/"]
COPY ["src/Groomer-doggy-style/GroomerDoggyStyle.Application.Offers/GroomerDoggyStyle.Application.Offers.csproj", "src/Groomer-doggy-style/GroomerDoggyStyle.Application.Offers/"]
COPY ["src/Groomer-doggy-style/GroomerDoggyStyle.Application.Owners/GroomerDoggyStyle.Application.Owners.csproj", "src/Groomer-doggy-style/GroomerDoggyStyle.Application.Owners/"]
COPY ["src/Groomer-doggy-style/GroomerDoggyStyle.Application.Visits/GroomerDoggyStyle.Application.Visits.csproj", "src/Groomer-doggy-style/GroomerDoggyStyle.Application.Visits/"]
COPY ["src/Groomer-doggy-style/GroomerDoggyStyle.Infrastructure/GroomerDoggyStyle.Infrastructure.csproj", "src/Groomer-doggy-style/GroomerDoggyStyle.Infrastructure/"]
RUN dotnet restore "src/Groomer-doggy-style/GroomerDoggyStyle/GroomerDoggyStyle.Api.csproj"
COPY . .
WORKDIR "/src/src/Groomer-doggy-style/GroomerDoggyStyle"
RUN dotnet build "GroomerDoggyStyle.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GroomerDoggyStyle.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GroomerDoggyStyle.Api.dll"]