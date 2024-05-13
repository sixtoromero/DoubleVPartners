# DoubleVPartners Prueba técnica
**Nota importante:** Leer hasta el final donde está la descripción para la base de datos.

![alt text](https://github.com/sixtoromero/DoubleVPartners/blob/main/DoubleVPartners.Services.WebAPIRest/wwwroot/img/backend-main.png "Arrquitectura DDD")

## Descripción del Proyecto
Es una solución desarrollada en .NET 6 que implementa la arquitectura de diseño dirigido por el dominio (DDD). Este enfoque se centra en la complejidad del dominio/negocio para facilitar la creación de soluciones de software complejas pero escalables.

## Arquitectura
La solución está dividida en varias capas siguiendo los principios DDD, lo que permite un desarrollo independiente y escalable de cada parte:

## Presentación
Capa responsable de interactuar con el usuario. Contiene los controladores necesarios para la gestión de los registros de Personas y Usuarios, para la gestión de la interfaz de usuario que lo consuma.

## Aplicación
Esta capa coordina las actividades de la aplicación. Implementa la lógica del flujo de trabajo y depende directamente del dominio.

## Dominio
Núcleo de la solución, donde se definen todas las entidades, enums, excepciones, interfaces, tipos y lógica específicos del dominio.

## Infraestructura
Capa que implementa y soporta la persistencia de los datos y otras operaciones que están fuera del núcleo del dominio como la comunicación con bases de datos y sistemas externos.

## Transversal
Contiene código que es común a todas las capas, como configuraciones y utilidades.

## Configuración Inicial
El archivo appsettings.json contiene configuraciones esenciales para el funcionamiento del proyecto, incluyendo cadenas de conexión a bases de datos y configuraciones específicas para CORS y otros parámetros relevantes.

Para gestionar el cambio de la base de datos deben dirigirse al appsettings.json en la capa de presentación en el proyecto DoubleVPartners.Services.WebAPIRest
```json
"ConnectionStrings": {
  "DoubleVPartnersConnection": "Data Source=DESKTOP-IEOP1NV\\SQLEXPRESS; Initial Catalog=DoubleVPartnersDB; Trusted_Connection=True; Min Pool Size=0; Max Pool Size=500; Pooling=true; Encrypt=False; TrustServerCertificate=True; MultipleActiveResultSets=True; Persist Security Info=True;"
}
```

# Base de datos

![alt text](https://github.com/sixtoromero/DoubleVPartners/blob/main/DoubleVPartners.Services.WebAPIRest/wwwroot/img/backend-main-bd.png "Backup y Scripts")

En la solución existe una carpeta llamada Base_de_Datos, como se muestra en la imagen se evidencia un backup y un script para la creación de la base de datos.

