# ======================
# Base
# ======================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# ======================
# Build
# ======================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj (đúng cấu trúc thư mục)
COPY AuthService/AuthService.Presentation/AuthService.Presentation.csproj \
    AuthService/AuthService.Presentation/
COPY AuthService/AuthService.Application/AuthService.Application.csproj \
    AuthService/AuthService.Application/
COPY AuthService/AuthService.Infrastructure/AuthService.Infrastructure.csproj \
    AuthService/AuthService.Infrastructure/
COPY AuthService/AuthService.Domain/AuthService.Domain.csproj \
    AuthService/AuthService.Domain/
COPY Shared.Kernel/Shared.Kernel.csproj \
    Shared.Kernel/
COPY Contracts/Contracts.csproj \
    Contracts/
    
# Restore
RUN dotnet restore AuthService/AuthService.Presentation/AuthService.Presentation.csproj

# Copy toàn bộ source
COPY AuthService/ AuthService/
COPY Shared.Kernel/ Shared.Kernel/
COPY Contracts/ Contracts/
# Build
WORKDIR /src/AuthService/AuthService.Presentation
RUN dotnet build AuthService.Presentation.csproj -c Release -o /app/build

# ======================
# Publish
# ======================
FROM build AS publish
RUN dotnet publish AuthService.Presentation.csproj -c Release -o /app/publish

# ======================
# Final
# ======================
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuthService.Presentation.dll"]
