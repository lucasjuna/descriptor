FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY Descriptor.API/Descriptor.API.csproj Descriptor.API/
RUN dotnet restore Descriptor.API/Descriptor.API.csproj
COPY . .
WORKDIR /src/Descriptor.API
RUN dotnet build Descriptor.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Descriptor.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Descriptor.API.dll"]
