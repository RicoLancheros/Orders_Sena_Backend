# Orders_Sena_Backend

Proyecto basado en: https://docs.google.com/document/d/1pTHvzrLzPjkA1ms-bdrTgYCc3bwPu8Ta2ftBL-_pryk/edit?tab=t.0

Para hacer referencia de Shared a Backend con el Datacontext, se inicio CMD en la carpeta contenedora del proyecto y se mando el comando: "dotnet add Orders\Orders.Backend\Orders.Backend.csproj reference Orders\Orders.Shared\Orders.Shared.csproj" por CMD

(Agregando esta linea: ProjectReference Include="..\Orders.Shared\Orders.Shared.csproj"


Migraciones:

1.1: INSTALAR PRIMERO: dotnet tool install --global dotnet-ef

Se inician las migracion parandonos en CMD en la carpeta de Orders.Backend

1. dotnet ef migrations add InitialDb

2. dotnet ef database update



