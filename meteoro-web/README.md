# MeteoroWeb

This project was generated using [Angular CLI](https://github.com/angular/angular-cli) version 21.2.9.

## Development server

To start a local development server, run:

```bash
ng serve
```

Once the server is running, open your browser and navigate to `http://localhost:4200/`. The application will automatically reload whenever you modify any of the source files.

## Code scaffolding

Angular CLI includes powerful code scaffolding tools. To generate a new component, run:

```bash
ng generate component component-name
```

For a complete list of available schematics (such as `components`, `directives`, or `pipes`), run:

```bash
ng generate --help
```

## Building

To build the project run:

```bash
ng build
```

This will compile your project and store the build artifacts in the `dist/` directory. By default, the production build optimizes your application for performance and speed.

## Running unit tests

To execute unit tests with the [Vitest](https://vitest.dev/) test runner, use the following command:

```bash
ng test
```

## Running end-to-end tests

For end-to-end (e2e) testing, run:

```bash
ng e2e
```

Angular CLI does not come with an end-to-end testing framework by default. You can choose one that suits your needs.

## Additional Resources

For more information on using the Angular CLI, including detailed command references, visit the [Angular CLI Overview and Command Reference](https://angular.dev/tools/cli) page.

1. INTRODUCCIÓN
El proyecto Meteoro surge como una solución tecnológica integral ante la necesidad de fortalecer la resiliencia urbana frente a eventos climáticos adversos. Mediante el uso de un stack moderno compuesto por .NET 10 y Angular 21, el sistema transforma datos meteorológicos complejos en información accionable para la ciudadanía y las autoridades.
1.1. Contexto General
La ciudad de La Paz, debido a su compleja topografía de cuencas y laderas, es altamente susceptible a desastres hidrometeorológicos como inundaciones repentinas y granizadas extremas. En este escenario, la gestión de riesgos no solo depende de la capacidad de respuesta de los equipos de emergencia, sino fundamentalmente de la velocidad con la que la información fluye hacia las áreas vulnerables. Meteoro se posiciona como el puente digital que conecta las APIs de monitoreo global con la realidad barrial paceña.
1.2. Problemática
El problema central radica en la latencia y falta de especificidad de los sistemas de alerta actuales. Los avisos climáticos suelen ser generales para toda la ciudad, ignorando que en La Paz puede haber una tormenta eléctrica en la zona Sur mientras el Centro permanece despejado. Esta desconexión impide que los vecinos de barrios específicos tomen medidas preventivas a tiempo, resultando en pérdidas materiales y riesgos humanos que podrían mitigarse con alertas tempranas geolocalizadas.
1.3. Antecedentes
A nivel local, los esfuerzos de monitoreo han dependido históricamente de estaciones manuales o boletines informativos emitidos con frecuencias de actualización lentas. Proyectos previos han intentado centralizar el monitoreo de ríos, pero carecían de una interfaz PWA (Progressive Web App) que permitiera al ciudadano común recibir notificaciones push en tiempo real sin depender de una infraestructura de hardware propietaria. Meteoro toma estos antecedentes y los evoluciona utilizando comunicación bidireccional mediante SignalR.
1.4. Justificación
Justificación Técnica: El uso de Clean Architecture permite que el sistema sea escalable y mantenible. La integración de servicios de terceros mediante Webhooks y el procesamiento de datos en PostgreSQL 18 aseguran una base sólida para el manejo de Big Data meteorológico.
Justificación Social: Al democratizar el acceso a las alertas tempranas, el sistema empodera a las juntas vecinales, permitiéndoles organizar evacuaciones preventivas de forma autónoma basándose en datos científicos reales y no en suposiciones.
Justificación Económica: La prevención es significativamente más barata que la reconstrucción. Un aviso oportuno de 15 minutos puede salvar activos críticos y vehículos, reduciendo el impacto económico de los desastres en las familias paceñas.
1.5. Alcance y Limitaciones
Alcance: El sistema cubrirá el monitoreo por distritos municipales, la emisión de alertas automáticas según umbrales de precipitación, la visualización de un mapa de calor de riesgos y la gestión de usuarios mediante Keycloak. Incluye la capacidad de funcionamiento offline básico para consulta de mapas previos.
Limitaciones: La precisión del sistema depende directamente de la disponibilidad y exactitud de las APIs externas (como OpenWeather). En esta fase inicial, el sistema no incluye la instalación física de sensores propios, sino que se nutre de la red de datos meteorológicos ya existente y de los reportes verificados de los usuarios.


2. OBJETIVOS
2.1. Objetivo General
Desarrollar un sistema web de monitoreo y alertas tempranas para riesgos hidrometeorológicos denominado Meteoro, empleando .NET Core 10 y Angular 21, para fortalecer la resiliencia barrial ante eventos climáticos en la ciudad de La Paz.
2.2. Objetivos Específicos
Integrar APIs meteorológicas externas y servicios de geolocalización para el monitoreo constante de variables críticas (precipitación, humedad, viento).
Implementar un motor de reglas en el backend que dispare alertas automáticas basadas en umbrales de riesgo predefinidos por distrito.
Desarrollar una interfaz PWA mobile-first que permita a los usuarios visualizar mapas de calor de riesgo y recibir notificaciones push inmediatas.
3. MARCO TEÓRICO
3.1. Arquitectura Limpia (Clean Architecture)
La Arquitectura Limpia es un patrón de diseño de software que prioriza la independencia de los marcos de trabajo (frameworks) y la separabilidad de las reglas de negocio. En Meteoro, esto se traduce en una estructura de capas concéntricas:
Capa de Dominio: Contiene la lógica central de evaluación de riesgos climáticos.
Capa de Aplicación: Define los casos de uso, como el envío de alertas mediante SignalR.
Capa de Infraestructura: Maneja la comunicación con la API de clima y la persistencia en base de datos.
Esta estructura garantiza que, si en el futuro se cambia la API de clima o el motor de base de datos, el núcleo del sistema permanezca intacto.
3.2. .NET Core (Versión 10)
.NET Core es una plataforma de código abierto y multiplataforma de alto rendimiento. La versión 10 proporciona mejoras significativas en el manejo de Minimal APIs y servicios en segundo plano (Background Services). Para este proyecto, .NET es el motor principal que procesa constantemente los datos meteorológicos en tiempo real, permitiendo una ejecución robusta y escalable para miles de usuarios simultáneos en los distritos de La Paz.
3.3. Angular 21 + PWA (Progressive Web Apps)
Angular es un framework de desarrollo para aplicaciones web SPA (Single Page Application). La integración con PWA dota al sistema de características de una aplicación nativa:
Service Workers: Permiten que el mapa de riesgos y las alertas previas sean accesibles sin conexión a internet.
Notificaciones Push: Crucial para que el vecino reciba una alerta de emergencia en su celular incluso con el navegador cerrado.
Manifiesto de Aplicación: Permite la instalación del sistema directamente en el escritorio del móvil.
3.4. Keycloak + OAuth2
Keycloak es una herramienta de código abierto para la gestión de identidad y accesos (IAM). Al implementar el protocolo OAuth2 y OpenID Connect, Meteoro garantiza que el acceso al panel de control de alertas esté estrictamente limitado a personal autorizado. Esto previene que usuarios malintencionados emitan alertas de emergencia falsas, asegurando la integridad y confiabilidad del sistema de seguridad ciudadana.
3.5. PostgreSQL + UUID v7
PostgreSQL es el sistema de gestión de bases de datos relacionales más avanzado. En este proyecto, se implementa el uso de UUID v7 para las llaves primarias de los registros de alerta. A diferencia de los UUID tradicionales, la versión 7 incluye un componente temporal (timestamp) que permite:
Ordenamiento Cronológico Natural: Las alertas se almacenan físicamente en el orden en que ocurren, optimizando las consultas de trazabilidad histórica.
Rendimiento en Inserción: Reduce la fragmentación de índices en tablas de gran volumen, ideal para el registro constante de datos climáticos.
4. ANÁLISIS DEL SISTEMA
4.1. Requerimientos Funcionales
RF1: Monitoreo en Tiempo Real: Dashboard con datos actualizados de lluvia y temperatura por zona.
RF2: Gestión de Alertas: Configuración de umbrales (ej. > 20mm de lluvia = Alerta Naranja).
RF3: Notificaciones Multi-canal: Envío de notificaciones push a dispositivos móviles y alertas visuales en el dashboard.
RF4: Mapa de Riesgos Barrial: Visualización geográfica de zonas seguras y puntos de riesgo.
4.2. Requerimientos No Funcionales
Estos requerimientos aseguran la calidad, el rendimiento y la seguridad de la plataforma:
RNF1: Alta Disponibilidad (PWA): La aplicación debe ser instalable y funcional incluso en condiciones de baja conectividad, permitiendo ver el último estado de alerta cacheado.
RNF2: Seguridad y Autenticación: Todo acceso administrativo debe ser validado por Keycloak mediante tokens JWT (JSON Web Tokens).
RNF3: Escalabilidad: El backend en .NET 10 debe ser capaz de manejar un incremento súbito de conexiones durante eventos de crisis climática.
RNF4: Diseño Responsivo: La interfaz debe seguir una filosofía mobile-first para asegurar que el vecino pueda usarla cómodamente desde su celular bajo la lluvia.
RNF5: Latencia Mínima: El tiempo entre la detección del riesgo en el servidor y la recepción de la alerta en el móvil no debe superar los 3 segundos.
4.3. Actores del Sistema
En Meteoro interactúan tres perfiles principales:
Administrador (Gestor de Riesgos): Personal técnico encargado de configurar los umbrales de lluvia, validar reportes vecinales y gestionar la comunicación oficial en situaciones de desastre.
Vecino (Usuario Final): Ciudadano que utiliza la PWA para monitorear su zona, recibir alertas preventivas y reportar incidentes en su barrio.
Sistema Meteorológico (Actor Externo): La API (OpenWeather) que provee la materia prima (datos climáticos) para el funcionamiento del motor de riesgos.
4.4. Casos de Uso
A continuación se detallan los procesos clave del sistema:
CU-01: Recepción Automática de Alerta
Actor: Vecino / Sistema.
Flujo: El backend detecta niveles críticos de lluvia -> El motor de reglas genera una alerta -> SignalR envía la notificación push -> El celular del vecino suena y muestra el nivel de riesgo y recomendaciones de evacuación.
CU-02: Reporte de Incidente Barrial
Actor: Vecino.
Flujo: El vecino detecta un muro con riesgo de caída -> Abre la PWA -> Toma una foto y añade una descripción -> El sistema geolocaliza el reporte y lo envía al dashboard del Administrador.
CU-03: Configuración de Umbrales de Riesgo
Actor: Administrador.
Flujo: El administrador ingresa al panel de control -> Selecciona un distrito -> Define que si la lluvia supera los 25mm en 1 hora el estado pase a "Alerta Naranja" -> Guarda los cambios y el motor de reglas se actualiza instantáneamente.
5. DISEÑO DEL SISTEMA
5.1. Arquitectura del Sistema (Meteoro)
Meteoro.Domain: Entidades como Alerta, Distrito, Sensor, ReporteClimatico.
Meteoro.Application: Lógica de evaluación de riesgos y servicios de notificación.
Meteoro.Infrastructure: Cliente para la API de Clima, persistencia en PostgreSQL y Hubs de SignalR.
Meteoro.API: Endpoints para la app móvil/web y recepción de reportes de campo.
5.2. Modelo de Base de Datos (Simplificado)
Distritos: Nombre, coordenadas poligonales, nivel de riesgo base.
Alertas: Tipo (Lluvia, Granizo, Inundación), nivel (Verde, Amarillo, Naranja, Rojo), marca de tiempo.
Suscripciones: Tokens de dispositivos para notificaciones push vinculados a un distrito.
6. IMPLEMENTACIÓN
6.1. Requisitos de Instalación
Para poner en marcha el ecosistema de Meteoro, se deben cumplir los siguientes requisitos técnicos en el entorno de servidor o desarrollo:
Runtime de .NET 10: Necesario para ejecutar la API y los servicios en segundo plano.
Node.js v20+ y Angular CLI 21: Para la compilación y despliegue del frontend PWA.
Docker y Docker Compose: Indispensables para orquestar los contenedores de PostgreSQL 18 y Keycloak de manera estandarizada.
Suscripción a API de Clima: Credenciales válidas (API Keys) de servicios como OpenWeatherMap para la ingesta de datos.
Certificado SSL/TLS: Obligatorio para el funcionamiento de Service Workers y notificaciones push en entornos de producción.
6.2. Estructura del Backend (Arquitectura Limpia)
El backend está organizado siguiendo los principios de separación de responsabilidades, lo que permite que la lógica de alertas climáticas no se contamine con detalles de la base de datos o la web:
Meteoro.Domain: Contiene las entidades base (Alerta, ZonaRiesgo), interfaces de repositorios y las especificaciones de los umbrales climáticos.
Meteoro.Application: Contiene los casos de uso (Lógica de negocio). Aquí reside el "Motor de Evaluación" que decide si una lluvia es peligrosa.
Meteoro.Infrastructure: Implementa el acceso a datos con Entity Framework Core, la integración con Keycloak y el cliente que consume las APIs de clima.
Meteoro.API: Expone los controladores REST y los Hubs de SignalR para la comunicación en tiempo real con los vecinos.
6.3. Estructura del Frontend
La aplicación Angular utiliza una arquitectura basada en módulos y características (feature-based) para optimizar la carga:
Core: Interceptores de tokens JWT, servicios de SignalR y el Service Worker para soporte offline.
Shared: Componentes reutilizables como el visor de mapas, indicadores de nivel de alerta y modales de emergencia.
Features/Monitoring: Dashboard principal que muestra el estado del tiempo por distrito en tiempo real.
Features/Alerts: Historial de alertas emitidas y configuración de notificaciones push.
6.4. Seguridad y Auditoría
La seguridad de Meteoro se apoya en dos pilares críticos para evitar falsas alarmas y garantizar la integridad:
Seguridad (Keycloak): Toda emisión de alerta manual o cambio de umbrales requiere un token JWT con rol de ADMIN_RIESGOS. Los interceptores de Angular aseguran que cada petición lleve la firma digital correspondiente.
Auditoría (UUID v7 & JSONB): Cada vez que se dispara una alerta, se registra un evento inmutable en PostgreSQL. El uso de UUID v7 permite que los registros de auditoría estén ordenados temporalmente de forma nativa, facilitando la reconstrucción de la línea de tiempo del desastre para análisis post-evento.
6.5. Endpoints Principales
La API de Meteoro expone los siguientes servicios clave:
GET /api/v1/monitoring/current: Obtiene el estado climático actual de todos los distritos.
POST /api/v1/alerts/manual: Permite a un administrador disparar una alerta de emergencia inmediata.
GET /api/v1/history/alerts/{distritoId}: Recupera el histórico cronológico de alertas de una zona específica.
POST /api/v1/reports/incident: Permite a los vecinos subir fotos y coordenadas de riesgos detectados (alcantarillas tapadas, grietas).
GET /api/v1/weather/forecast: Proyecta el riesgo hidrometeorológico para las próximas 24 horas.
7. PRUEBAS
ID	Caso de Prueba	Entrada	Resultado Esperado	Resultado
PR-01	Recepcion de Datos	Llamada programada a OpenWeather	Datos de lluvia transformados en entidades del dominio	OK
PR-02	Disparo de Alertas	Simulacion de lluvia>30mm en Distrito1	SignalR envia notificaciones push a usuarios suscritos	OK
PR-03	Modo PWA Offline	Desconexion de red en dispositivo movil	El usuario puede ver el ultimo mapa de riesgo cacheado	OK
PR-04	Seguridad de Roles	Intento de emitir alerta con rol Vecino	Bloqueo de acceso (403 Forbidden) por Keycloack.	 OK

8. CONCLUSIONES Y RECOMENDACIONES
8.1. Conclusiones
El desarrollo de Meteoro demuestra que la integración de tecnologías web modernas (.NET 10 y Angular 21) permite reducir drásticamente el tiempo de respuesta ante desastres naturales. La implementación de una arquitectura basada en eventos (WebSockets) soluciona el problema de la latencia en las alertas tradicionales, proporcionando a los ciudadanos de La Paz una herramienta vital para la prevención de riesgos barriales.
8.2. Recomendaciones
Integración IoT: Se recomienda para futuras fases instalar sensores de nivel de río de bajo costo conectados vía MQTT directamente a la API de Meteoro.
Capacitación Vecinal: Es fundamental socializar el uso de la PWA en juntas vecinales para asegurar que la población sepa interpretar los niveles de alerta (Verde a Rojo).
Backups: Mantener una política de respaldos georendundantes para la base de datos PostgreSQL debido a la criticidad de la información histórica para futuros estudios de riesgo.
9. BIBLIOGRAFÍA
Microsoft Learn (2025). Documentación oficial de .NET 10 y SignalR para tiempo real. Recuperado de https://learn.microsoft.com/dotnet/
Angular.dev (2026). Guía de Progressive Web Apps (PWA) y Service Workers. Recuperado de https://angular.dev/
Gobierno Autónomo Municipal de La Paz (2024). Plan de Contingencia ante Lluvias y Riesgos Geológicos.
OpenWeatherMap (2026). Weather API Reference and Weather Condition Codes. Recuperado de https://openweathermap.org/api
A.	Codigo Docker-compose.yml
services:
  # 1. BASE DE DATOS (PostgreSQL)
  # Almacenamiento centralizado de niveles de ríos y estado de sensores
  db-meteorov2:
    image: postgres:latest
    container_name: postgres_meteorov2
    environment:
      POSTGRES_DB: db_meteorov2
      POSTGRES_USER: postgres
      POSTGRES_PASSWORD: Lasin1234
    ports:
      - "5433:5432"
    volumes:
      - postgres_data:/var/lib/postgresql/data
    networks:
      - meteoro-network
    restart: always

  # 2. SEGURIDAD (Keycloak)
  # Gestión de acceso seguro para funcionarios de la Alcaldía de La Paz
  auth-meteoro:
    image: quay.io/keycloak/keycloak:latest
    container_name: keycloak_meteoro
    command: start-dev
    environment:
      KC_BOOTSTRAP_ADMIN_USERNAME: admin
      KC_BOOTSTRAP_ADMIN_PASSWORD: admin
    ports:
      - "8080:8080"
    depends_on:
      - db-meteorov2
    networks:
      - meteoro-network
    restart: always

  # 3. BACKEND (ASP.NET Core API)
  # Lógica de alertas preventivas y procesamiento de datos meteorológicos
  api-meteoro:
    build:
      context: ./Meteorov2.Api
      dockerfile: Dockerfile
    container_name: api_meteoro_v2
    ports:
      - "5000:8080"
    environment:
      - ConnectionStrings__DefaultConnection=Host=db-meteorov2;Port=5432;Database=db_meteorov2;Username=postgres;Password=Lasin1234
    depends_on:
      - db-meteorov2
    networks:
      - meteoro-network
    restart: always

  # 4. FRONTEND (Angular)
  # Dashboard interactivo de visualización de riesgos y gestión de estaciones
  web-meteoro:
    build:
      context: ./meteoro-web
      dockerfile: Dockerfile
    container_name: web_meteoro_v2
    ports:
      - "4200:80"
    depends_on:
      - api-meteoro
    networks:
      - meteoro-network
    restart: always

networks:
  meteoro-network:
    driver: bridge

volumes:
  postgres_data:

