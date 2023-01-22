# Step 1: Specify your base image
FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build-env
WORKDIR /app
EXPOSE 80
EXPOSE 443

WORKDIR /app
COPY /Bibs.API/Bibs.API.csproj Bibs.API/
COPY /Domain/Domain.csproj Domain/
COPY /Infrastructure/Infrastructure.csproj Infrastructure/
COPY /Application/Application.csproj Application/

# Step 2: Copy project file to the ./ container folder
# COPY *.csproj ./
# Step 3: Run a restore to download dependencies
RUN dotnet restore Bibs.API/Bibs.API.csproj

# Step 4: Copy app code to the container
COPY . .
# Step 5: Build the app in Release mode
# Step 6: Publish the application
#RUN dotnet publish -c Release -r linux-musl-x64 --self-contained true /p:PublishTrimmed=true -o out
RUN dotnet publish Bibs.API/Bibs.API.csproj -c Release -o out

# Step 7: Expose port 80 in the container - Moved

# Build runtime image
# Step 8: Move the /app folder and run the compiled app
FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine-amd64
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Bibs.API.dll"]