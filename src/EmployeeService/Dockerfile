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
COPY EmployeeService/EmployeeService.Presentation/EmployeeService.Presentation.csproj \
    EmployeeService/EmployeeService.Presentation/
COPY EmployeeService/EmployeeService.Application/EmployeeService.Application.csproj \
    EmployeeService/EmployeeService.Application/
COPY EmployeeService/EmployeeService.Infrastructure/EmployeeService.Infrastructure.csproj \
    EmployeeService/EmployeeService.Infrastructure/
COPY EmployeeService/EmployeeService.Domain/EmployeeService.Domain.csproj \
    EmployeeService/EmployeeService.Domain/
COPY Shared.Kernel/Shared.Kernel.csproj \
    Shared.Kernel/

# Restore
RUN dotnet restore EmployeeService/EmployeeService.Presentation/EmployeeService.Presentation.csproj

# Copy toàn bộ source
COPY EmployeeService/ EmployeeService/
COPY Shared.Kernel/ Shared.Kernel/

# Build
WORKDIR /src/EmployeeService/EmployeeService.Presentation
RUN dotnet build EmployeeService.Presentation.csproj -c Release -o /app/build

# ======================
# Publish
# ======================
FROM build AS publish
RUN dotnet publish EmployeeService.Presentation.csproj -c Release -o /app/publish

# ======================
# Final
# ======================
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmployeeService.Presentation.dll"]
