# Use the .NET 7 runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# Use the .NET 7 SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ParcelDeliveryService.csproj", "./"]
RUN dotnet restore "./ParcelDeliveryService.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "ParcelDeliveryService.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "ParcelDeliveryService.csproj" -c Release -o /app/publish

# Use the base image and copy the published application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ParcelDeliveryService.dll"]

### build the Docker container: ###
#docker build -t parceldeliveryservice .

### After building the Docker container -> run it: ###
#docker run -d -p 8080:80 --name parceldeliveryservice parceldeliveryservice
