# Orders_Sena_Backend

Proyecto basado en: https://docs.google.com/document/d/1pTHvzrLzPjkA1ms-bdrTgYCc3bwPu8Ta2ftBL-_pryk/edit?tab=t.0

Para hacer referencia de Shared a Backend con el Datacontext, se inicio CMD en la carpeta contenedora del proyecto y se mando el comando: "dotnet add Orders\Orders.Backend\Orders.Backend.csproj reference Orders\Orders.Shared\Orders.Shared.csproj" por CMD

(Agregando esta linea:)

  <ItemGroup>
    <ProjectReference Include="..\Orders.Shared\Orders.Shared.csproj" /> 
  </ItemGroup>
