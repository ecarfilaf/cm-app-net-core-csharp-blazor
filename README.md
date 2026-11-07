# CM App .Net-core C#
CM - Sys Admin .Net Core C# Blazor

# Sistema Fullstack (.NET 10)

Este repositorio contiene una solución desacoplada compuesta por una API REST segura en el backend y una interfaz web moderna en el frontend, ambas construidas bajo la plataforma **.NET 10**.

![.NET Version](https://shields.io)
![Frontend](https://shields.io)
![Backend](https://shields.io)
![Database](https://shields.io)

---

## 📂 Estructura de la Solución

```text
📁 tu-repositorio-root/
│
├── 📁 apibackend/               # PROYECTO BACKEND (API REST)
│   ├── apibackend.csproj
│   ├── Program.cs
│   ├── appsettings.json
│   └── ...
│
└── 📁 frontend/                 # PROYECTO FRONTEND (Blazor Web App)
    ├── frontend.csproj
    ├── Program.cs
    ├── appsettings.json
    └── ...
```

---

## 🛠️ Tecnologías y Librerías Utilizadas

### Backend (`apibackend`)
* **Framework:** ASP.NET Core Web API (.NET 10)
* **ORM:** Entity Framework Core con soporte relacional.
* **Motor de Base de Datos:** MySQL (`MySql.EntityFrameworkCore`).
* **Seguridad:** Autenticación mediante **JWT Bearer Tokens** y hashing de contraseñas con **BCrypt**.
* **Documentación:** OpenAPI / Swagger (`Swashbuckle`).

### Frontend (`frontend`)
* **Framework:** **Blazor Components** (.NET 10)
* **UI Componentes:** Implementación de grillas de datos optimizadas mediante `Microsoft.AspNetCore.Components.QuickGrid`.
* **Consumo de API:** `HttpClient` nativo para comunicación asíncrona con el backend JWT.

---

## ⚙️ Requisitos Previos

Antes de ejecutar los proyectos, asegúrate de tener instalado:
* **SDK de .NET 10** o superior.
* Servidor de Base de Datos **MySQL** activo.
* Un IDE compatible (VS Code con C# Dev Kit o Visual Studio 2022).

---

## 🚀 Instalación y Configuración paso a paso

### 1. Clonar el repositorio
```bash
git clone https://github.com
cd tu-repositorio
```

### 2. Configurar y lanzar el Backend
1. Navega a la carpeta del servidor:
   ```bash
   cd apibackend
   ```
2. Abre `appsettings.json` o `appsettings.Development.json` y configura tu cadena de conexión a MySQL y secretos JWT:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=nombre_bd;User=root;Password=tu_password;"
     },
     "Jwt": {
       "Key": "UnaClaveSecretaMuyLargaYSeguraDeAlMenos32Bytes",
       "Issuer": "tu-app.com",
       "Audience": "tu-app.com"
     }
   }
   ```
3. Restaura las dependencias e inicia el backend:
   ```bash
   dotnet restore
   dotnet run
   ```
   *Nota: La documentación de Swagger estará disponible en la URL local generada (ej. `http://localhost:5xxx/swagger`).*

### 3. Configurar y lanzar el Frontend
1. Abre una nueva terminal en la raíz y navega a la carpeta del cliente:
   ```bash
   cd frontend
   ```
2. Verifica la URL base configurada en su `appsettings.json` o en `Program.cs` para apuntar exactamente al puerto donde corre tu `apibackend`.
3. Restaura las dependencias e inicia la interfaz de Blazor:
   ```bash
   dotnet restore
   dotnet run
   ```

---

## 🔒 Flujo de Seguridad del Sistema

1. El usuario inicia sesión en la interfaz web de **Blazor**.
2. El cliente envía las credenciales de forma segura hacia la **Web API**.
3. El Backend verifica la contraseña (descifrando el hash con **BCrypt**) y devuelve un token firmado con **JWT**.
4. El Frontend almacena el token y lo adjunta automáticamente en las cabeceras HTTP de cada petición subsecuente para consumir datos y renderizar componentes dinámicos en las vistas de **QuickGrid**.
