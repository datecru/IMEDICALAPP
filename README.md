En la linea 17 del Program.cs se debe cambiar el usuario y contraseña de la base de datos 

var connectionString = "Server=localhost;Port=3306;Database=imedical_database;User Id=root;Password=247755ca80;";

la ejecucion del programa se hace en la terminal de visualcode con dotnet run y navegando ala carpeta weather-news-app y ejecutando el comando npm start en la terminal

este proyecto solicita a la api del clima la ciudad que se ingresa, y devuelve los solicitado siendo esto, el nombre de la ciudad, temperatura humedad y descripcion en español y unidades metricas

en relacion a las noticias, solicita las noticias que hacen referencia a la peticion que se hizo en el clima, y devuelve las noticias en orden cronologico

para la seccion de busquedas recientes, el programa captura las peticiones que se hacen y las almacena en la base de datos, para despues desplegar solamente las ultimas 5 peticiones que se han realizado
