# =========================
# VARIABLES
# =========================
COMPOSE = docker compose
PROJECT_NAME = institution-management

# =========================
# DEFAULT
# =========================
.DEFAULT_GOAL := help

# =========================
# COMMANDS
# =========================

help:
	@echo "Available commands:"
	@echo " make up              - Build & start all services"
	@echo " make down            - Stop & remove all containers"
	@echo " make restart         - Restart all services"
	@echo " make logs            - View logs"
	@echo " make ps              - Show running containers"
	@echo " make build           - Build all images"
	@echo " make rebuild         - Rebuild without cache"
	@echo " make clean           - Remove containers, images, volumes"
	@echo " make gateway         - Build & run only API Gateway"
	@echo " make employee        - Build & run only Employee Service"

# =========================
# CORE
# =========================

up:
	$(COMPOSE) up -d --build

down:
	$(COMPOSE) down

restart:
	$(COMPOSE) down
	$(COMPOSE) up -d --build

logs:
	$(COMPOSE) logs -f

ps:
	$(COMPOSE) ps

build:
	$(COMPOSE) build

rebuild:
	$(COMPOSE) build --no-cache

clean:
	$(COMPOSE) down -v --rmi all --remove-orphans

# =========================
# SERVICE-SPECIFIC
# =========================

gateway:
	$(COMPOSE) up -d --build apigateway

employee:
	$(COMPOSE) up -d --build employee-service
	
auth:
	$(COMPOSE) up -d --build auth-service
