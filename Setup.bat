@echo off

REM === Configuracion, ajuste estos valores para la base de datos que necesite ===

set MYSQL_USER=root
set MYSQL_PASSWORD=247755ca80

REM === Obtener el directorio del batch del script
set SCRIPT_RUN_DIR=%~dp0
set PROJECT_DIRECTORY=%SCRIPT_RUN_DIR%IMEDICALAPP
set SQL_FILE_PATH=%PROJECT_DIRECTORY%\crear_base_de_datos.sql

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

pause

REM === Crear archivo start.bat en el mismo directorio Setup.bat ===
echo @echo off > "%~dp0start.bat"
echo REM === Iniciar Interfaz web === >> "%~dp0start.bat"
echo cd /d %PROJECT_DIRECTORY%\app >> "%~dp0start.bat"
echo start cmd /k "npm start" >> "%~dp0start.bat"
echo. >> "%~dp0start.bat" 
echo REM === Iniciar .NET === >> "%~dp0start.bat"
echo cd /d "%PROJECT_DIRECTORY%" >> "%~dp0start.bat"
echo start cmd /k dotnet run >> "%~dp0start.bat"
echo. >> "%~dp0start.bat" 
echo REM === Espere unos segundos antes de ejecutar el siguiente comando === >> "%~dp0start.bat"
echo timeout /t 5 /nobreak ^> nul >> "%~dp0start.bat"
echo. >> "%~dp0start.bat" 
echo pause >> "%~dp0start.bat"

echo "start.bat creado en %~dp0"

echo "Iniciando IMEDICALAPP...."

cd /d "%PROJECT_DIRECTORY%\app"

REM === Instalar dependencias de Node.js solo si no existe ===
IF NOT EXIST "package-lock.json" {
    npm install
    if %errorlevel% neq 0 (
        echo "Error durante la instalacion de npm..."
        pause
        exit /b 1
    )
}

