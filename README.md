# 🚀 Mi Proyecto Orders

###--Manual de Usuario--###

1.Primero que todo. Borrar la carpeta "Migrations"

2.Crear la imagen en Docker con: docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=TuClaveSegura@123" -p 1433:1433 --name sql_server_orders -d mcr.microsoft.com/mssql/server:2022-latest" -p 1433:1433 --name sql_server_orders -d mcr.microsoft.com/mssql/server:2022-latest

!IMPORTANTE!
Cambiar la contraseña "TuClaveSegura@123" Por la tuya.

3.Abrir la consola de Nuget y colocar primero el comando: 

Add-Migration InitialDb

Seguido del comando:

Update-Database

4.Click derecho en la solucion principal "Orders" e ir a "Configurar Proyectos de Inicio"

5.Elegir la opcion Varios proyectos de inicio, y en un nuevo perfil colocar solo el orders.backend y orders.frontend en ACCION: "Inicio", los otros 2 en "Ninguno"

6.Aplicar cambios e Iniciar el aplicativo.





###--Documentacion--###

https://docs.google.com/document/d/1uSdEkdmtbF0K7cpjYUtn1sUCK6Qu9R4ZXMdxMSUmfU4/edit?tab=t.0


###--Verciones--###
Vercion actual: 0.0.4 
