FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["GroomerDoggyStyle/GroomerDoggyStyle.Api.csproj", "GroomerDoggyStyle/"]
COPY ["GroomerDoggyStyle.Application/GroomerDoggyStyle.Application.csproj", "GroomerDoggyStyle.Application/"]
COPY ["GroomerDoggyStyle.Domain/GroomerDoggyStyle.Domain.csproj", "GroomerDoggyStyle.Domain/"]
COPY ["GroomerDoggyStyle.Infrastructure/GroomerDoggyStyle.Infrastructure.csproj", "GroomerDoggyStyle.Infrastructure/"]
COPY ["GroomerDoggyStyle.Application.Address/GroomerDoggyStyle.Application.Address.csproj", "GroomerDoggyStyle.Application.Address/"]
COPY ["GroomerDoggyStyle.Application.Dogs/GroomerDoggyStyle.Application.Dogs.csproj", "GroomerDoggyStyle.Application.Dogs/"]
COPY ["GroomerDoggyStyle.Application.Employee/GroomerDoggyStyle.Application.Employee.csproj", "GroomerDoggyStyle.Application.Employee/"]
COPY ["GroomerDoggyStyle.Application.GroomerShops/GroomerDoggyStyle.Application.GroomerShops.csproj", "GroomerDoggyStyle.Application.GroomerShops/"]
COPY ["GroomerDoggyStyle.Application.Offers/GroomerDoggyStyle.Application.Offers.csproj", "GroomerDoggyStyle.Application.Offers/"]
COPY ["GroomerDoggyStyle.Application.Owners/GroomerDoggyStyle.Application.Owners.csproj", "GroomerDoggyStyle.Application.Owners/"]
COPY ["GroomerDoggyStyle.Application.Visits/GroomerDoggyStyle.Application.Visits.csproj", "GroomerDoggyStyle.Application.Visits/"]
RUN dotnet restore "GroomerDoggyStyle/GroomerDoggyStyle.Api.csproj"
COPY . .
WORKDIR "/src/GroomerDoggyStyle"
RUN dotnet build "GroomerDoggyStyle.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GroomerDoggyStyle.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GroomerDoggyStyle.Api.dll"]