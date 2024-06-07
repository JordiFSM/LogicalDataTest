--- Aspectos generales
Tener instalado visual studio 2022 y .net core 6, así como sql server para la base de datos.

Para la generación de la base de datos es necesario: 
  - Abrir el archivo SqlQueryLogicalDataDB.sql que se encuentra en [src -> Core -> LogicalData.Data -> QueryDB]
  - Copiar el script y pegarlo en SSMS en un nuevo query.
  - Generar la base de dato cons sus tablas correspondientes y verificar que esta este creada.

Ahora es necesario cambiar el nombre del servidor "DESKTOP-3G95FA4\\SQLEXPRESS" en script de conexión del API que se encuentra en la carpeta src -> API ->  API -> appsettings.json por el servidor de del la instancia que almacena la DB:
    - "Server=DESKTOP-3G95FA4\\SQLEXPRESS; Database=LogicalDataDB; Trusted_Connection=True; TrustServerCertificate=True"
    
Por último correr el api y crearse un usuario con el endpoint "/api/Usuario/RegistrarUsuario" para poder utilizar la aplicación web.
