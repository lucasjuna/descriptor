# Running

 1. Make sure Docker for Windows is installed 
 2. Go to solution root (where docker-compose.dcproj file is located)
 3. Run `docker-compose -f docker-compose.yml build` 
 4. Check docker-compose.override.yml and make sure listed ports are not in use (by default it's 8080, 8181 and 5433)
 5. Run `docker-compose -f docker-compose.yml -f docker-compose.override.yml up `
 6. Go to http://localhost:8080 in browser
