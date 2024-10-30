### **IMEDICALAPP**

Este proyecto interactúa con una API del clima para obtener información sobre una ciudad específica y muestra resultados en español con unidades métricas. Además, busca noticias relacionadas con la ciudad y muestra un historial de las últimas 5 búsquedas realizadas.

### **Prerrequisitos**

- **.NET SDK:** Descárgalo desde <https://dotnet.microsoft.com/download>

- **MySQL:** Necesario para gestionar la base de datos

- **Git:** Utilizado para clonar el repositorio

### **Instalación y Ejecución**

#### **Método Rápido:**

- Descarga solamente el archivo `Setup.bat` para una instalación automatica.
- Se creara un archivo `start.bat` este iniciara automaticamente la interfaz web junto con el .NET para el backend

#### **Método Manual:**

1. **Clonar el Repositorio:**

   Bash

   ```
   git clone https://github.com/datecru/IMEDICALAPP.git

   ```

  

2. **Acceder al Directorio:**

   Bash

   ```
   cd IMEDICALAPP

   ```

  

3. **Configurar la Base de Datos:**

   - Editar el archivo `Program.cs` y modificar la cadena de conexión en la línea 47:

     C#

     ```
     var connectionString = "Server=localhost;Port=3306;Database=imedical_database;User Id=root;Password=247755ca80;";

     ```

    

4. **Iniciar la Aplicación:**

   - Desde la terminal, dentro del directorio `IMEDICALAPP/app`:

     Bash

     ```
     npm install
     npm run start

     ```

    

   - O desde el directorio raíz del proyecto:

     Bash

     ```
     dotnet run

     ```

    

### **Funcionalidades**

- **Búsqueda de Clima:**

  - Ingresa el nombre de una ciudad.

  - Obtiene la temperatura, humedad y una descripción del clima.

  - Muestra los resultados en español y unidades métricas.

- **Búsqueda de Noticias:**

  - Encuentra noticias relacionadas con la ciudad buscada.

  - Ordena las noticias por fecha.

- **Historial de Búsquedas:**

  - Almacena las últimas 5 búsquedas en una base de datos.

  - Muestra el historial de búsquedas recientes.
