FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MediatR.Demo.EndPoint/MediatR.Demo.EndPoint.csproj", "MediatR.Demo.EndPoint/"]
COPY ["MediatR.Demo.Bll/MediatR.Demo.Bll.csproj", "MediatR.Demo.Bll/"]
COPY ["MediatR.Demo.Dal/MediatR.Demo.Dal.csproj", "MediatR.Demo.Dal/"]
COPY ["MediatR.Demo.Framework/MediatR.Demo.Framework.csproj", "MediatR.Demo.Framework/"]
RUN dotnet restore "MediatR.Demo.EndPoint/MediatR.Demo.EndPoint.csproj"
COPY . .
WORKDIR "/src/MediatR.Demo.EndPoint"
RUN dotnet build "MediatR.Demo.EndPoint.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MediatR.Demo.EndPoint.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MediatR.Demo.EndPoint.dll"]
