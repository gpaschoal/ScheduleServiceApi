#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Src/ScheduleService.Presentation.Api/ScheduleService.Presentation.Api.csproj", "Src/ScheduleService.Presentation.Api/"]
RUN dotnet restore "Src/ScheduleService.Presentation.Api/ScheduleService.Presentation.Api.csproj"
COPY . .
WORKDIR "/src/Src/ScheduleService.Presentation.Api"
RUN dotnet build "ScheduleService.Presentation.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ScheduleService.Presentation.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ScheduleService.Presentation.Api.dll"]