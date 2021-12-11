FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Xpymb.TestExercises.RPG.ASP/Xpymb.TestExercises.RPG.ASP.csproj", "Xpymb.TestExercises.RPG.ASP/"]
RUN dotnet restore "src/Xpymb.TestExercises.RPG.ASP/Xpymb.TestExercises.RPG.ASP.csproj"
COPY . .
WORKDIR "/src/Xpymb.TestExercises.RPG.ASP"
RUN dotnet build "Xpymb.TestExercises.RPG.ASP.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Xpymb.TestExercises.RPG.ASP.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Xpymb.TestExercises.RPG.ASP.dll"]
