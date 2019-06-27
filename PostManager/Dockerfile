FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["PostManager.csproj", ""]
RUN dotnet restore "PostManager.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "PostManager.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "PostManager.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PostManager.dll"]