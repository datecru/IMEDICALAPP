@echo off

REM === Configuracion, ajuste estos valores para la base de datos que necesite ===

set MYSQL_USER = root
set MYSQL_PASSWORD = 247755ca80

REM === Obtener el directorio del batch del script
set SCRIPT_DIR = %~dp0
set PROJECT_DIRECTORY = %SCRIPT_DIR%..
set SQL_FILE_PATH = %PROJECT_DIRECTORY%\crear_base_de_datos.sql

REM === Clonar el Repositorio ===
IF NOT EXIST "%PROJECT_DIRECTORY%" (
    echo "Clonando el repositorio..."
    git clone https://github.com/datecru/IMEDICALAPP.git "%PROJECT_DIRECTORY%"

)

echo "Creando base de datos..."
mysql -u "%MYSQL_USER%" -p"%MYSQL_PASSWORD%" < "%SQL_FILE_PATH%"
if %errorlevel% neq 0 (
    echo "Error creando la base de datos, revise su configuracion de MySQL y el archivo SQL"
    pause
    exit /b 1
)

echo "Base de datos creada"

echo "Iniciando IMEDICALAPP...."

cd /d "%PROJECT_DIRECTORY%\app"

npm install
npm start



cd /d "%PROJECT_DIRECTORY%"
dotnet run

