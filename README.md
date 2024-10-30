Este proyecto solicita a la api del clima la ciudad que se ingresa, y devuelve los solicitado siendo esto, el nombre de la ciudad, temperatura humedad y descripcion en español y unidades metricas.

En relacion a las noticias, solicita las noticias que hacen referencia a la peticion que se hizo en el clima, y devuelve las noticias en orden cronologico.

La seccion de busquedas recientes, el programa captura las peticiones que se hacen y las almacena en la base de datos, para despues desplegar solamente las ultimas 5 peticiones que se han realizado





Prerequisitos

.NET SDK ----- Descargarlo desde https://dotnet.microsoft.com/download
MySQL
Git   -------- Usado para clonar el repositorio

Para instalar y ejecutar use el archivo setup.bat este ejecutara todo lo necesario para la instalacion 





Instalación y uso manual
-------------------------------------------------------------------------------------------------
---------Instalacion

----En la terminal navegue al directorio deseado y escriba el siguiente comando para clonar el repositorio

git clone https://github.com/datecru/IMEDICALAPP.git

----Navegue al directorio del proyecto

CD IMEDICALAPP

----------Configuracion de la base de datos

----Abrir el Program.cs con el editor y editar la linea 47, replasar el nombre de la base de datos, usuario y contraseña
var connectionString = "Server=localhost;Port=3306;Database=imedical_database;User Id=root;Password=247755ca80;";

----------Iniciar la aplicacion
----Navegue al directorio IMEDICALAPP/app y ejecute el siguiente comando en la terminal
npm install
npm run start
----Desde el directorio IMEDICALAPP escriba el comando en la terminal
dotnet run




