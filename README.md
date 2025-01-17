# AristaProject
Proyecto de Arista .NET
Descripción: Este proyecto consiste en una aplicación frontend desarrollada en Blazor que se conecta a una API para manejar datos de clientes.

Requisitos:
- .NET 6 o superior.
- Visual Studio (recomendado).
- Conexión a la base de datos (SQL Server).

Pasos para correr localmente:
1. Clona este repositorio o descomprime el archivo ZIP.
2. Abre el archivo `.csproj` en Visual Studio.
3. Asegúrate de tener la base de datos configurada y accesible desde la API.
4. Ejecuta la API y la aplicación frontend localmente:
    - Abre la API en Visual Studio y presiona F5 para iniciar el servidor.
    - Luego, abre el frontend (`FrontendArista`) en Visual Studio y presiona F5 para iniciar la aplicación.
5. La API y la aplicación frontend se comunicarán localmente.

Cómo conectarse a la base de datos:
1. Configura la cadena de conexión a la base de datos en el archivo `appsettings.json` de la API.
2. Si la base de datos está en un servidor remoto, asegúrate de que la API tenga acceso adecuado.

Información adicional:
- La API utiliza el puerto 5000 por defecto para la comunicación.
- Para cambiar el puerto de la API, modifica la configuración en el archivo `launchSettings.json`.
- Si tienes problemas con la base de datos, revisa los logs de la API para más detalles.

Colaboradores:
- Puedes agregarme como colaborador: "sharepointarista" en el repositorio de GitHub.
