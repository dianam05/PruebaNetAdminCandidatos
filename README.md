# PruebaNetAdminCandidatos
Prueba tecnica .NET Computrabajo COL

#Desripción
aplicación web
utilizando arquitectura MVC que permite al reclutador realizar las siguientes acciones:
- Consultar una lista de candidatos inscritos.
- Inscribir nuevos candidatos y sus experiencias profesionales.
- Editar la inscripción de un candidato y sus experiencias profesionales.
- Eliminar un candidato.

#Estructura
Aplicación web ASP.NET Core MVC utilizando arquitectura en capas, Entity Framework con Code-First, 
base de datos en SQL Express o In-Memory, principios de DDD, SOLID, Clean Code, y el patrón CQRS.
#
AdminCandidatos.sln
-AdminCandidatos.Infrastructure       ← Acceso a datos (EF Core, Models, DbContext)

	Models                             ← Modelos EF (Candidate, CandidateExperience)
	Persistence                        ← DbContext (AdminCandidatosDBContext)

-AdminCandidatos.Application          ← Lógica de aplicación separada por CQRS

	Commands              ← Comandos para crear, editar, eliminar
		Candidates            ← Comandos de Candidate (Create, Update, Delete) CandidateExperiences         
		CandidateExperience   ← Comandos de CandidateExperience
	Interfaces                          Interfaces para Inyección de Dependencias
		Candidates             ← Interfaces de Candidate (Create, Update, Delete)
		CandidateExperiences   ← Interfaces de CandidateExperience
	Queries             ← Consultas (queries + handlers)
						← Queries como GetAll, GetById	
										  
-MiAppWeb               ← Proyecto web MVC (presentación)

	Controllers    ← Controladores MVC (CandidateController, CandidateExperienceController)
	Views                           ← Vistas Razor (Create.cshtml, Index.cshtml, etc.)
		Candidate
		CandidateExperience
	wwwroot                         ← Archivos estáticos (css, js)
	Program.cs / appsettings.json   ← Configuración general y punto de entrada


#Clonar y configurar
url para clonar el repositorio Git
https://github.com/dianam05/PruebaNetAdminCandidatos.git

-Actualizar cadena de conexion del archivo appsettings.json

-Ejecutar en el motor de base de datos, el archivo ScriptSQL.sql que se encuentra en la raiz del proyecto, para
crear la base de datos y tablas correspondientes.

#Tambien se puede utilizar SQL in-memory, descomentando en el archivo Program.cs:

// Configuración para SQL In-Memory
builder.Services.AddDbContext<YourDbContext>(options =>
    options.UseInMemoryDatabase("GestionCanditadosDb"));
	
Y comentando la sección para SQL Express (LocalDB):

// Configurar conexión a la base de datos
builder.Services.AddDbContext<AdminCandidatosDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));






