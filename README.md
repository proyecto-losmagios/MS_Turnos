# Micro servicio de Turnos

Levantar servicio

    dotnet run -p API

URL: http://localhost:4320

Crear Migration y aplicar migration

    cd AccessData
    dotnet ef migrations add NOMBRE_MIGRACION -s ../API/
    dotnet ef database update -s ../API/


Comandos de dotnet-ef:

    dotnet ef migrations add
    dotnet ef migrations list
    dotnet ef migrations script
    dotnet ef dbcontext info
    dotnet ef dbcontext scaffold
    dotnet ef database drop
    dotnet ef database update



Levantar Docker de PostgreSQL

    docker-compose up -d
