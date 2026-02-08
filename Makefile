# ---------------------------------------------
# WalkMyDog Docker management
# ---------------------------------------------

# By default, run containers in detached mode (-d)
DOCKER_COMPOSE=docker compose

# ---------------------------------------------
# Start containers (detached by default)
# ---------------------------------------------
up:
	$(DOCKER_COMPOSE) up -d

# Start containers in foreground (logs visible)
up-logs:
	$(DOCKER_COMPOSE) up

# Stop containers (keep volumes)
stop:
	$(DOCKER_COMPOSE) stop

# Shutdown containers and remove networks (volumes remain)
down:
	$(DOCKER_COMPOSE) down

# Rebuild containers and start fresh
rebuild:
	$(DOCKER_COMPOSE) up --build -d

# Initialize database (example: run migrations)
init:
	@echo "Run EF Core migrations or other init tasks here"
	# Example:
	# $(DOCKER_COMPOSE) exec api dotnet ef database update
