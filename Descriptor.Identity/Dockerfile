FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Descriptor.Identity/Descriptor.Identity.csproj", "Descriptor.Identity/"]
RUN dotnet restore "Descriptor.Identity/Descriptor.Identity.csproj"
COPY . .
WORKDIR "/src/Descriptor.Identity"
RUN dotnet build "Descriptor.Identity.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Descriptor.Identity.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Descriptor.Identity.dll"]