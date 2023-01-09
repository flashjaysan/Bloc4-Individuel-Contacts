using Contacts.Business;
using Contacts.Common.Entities;
using Contacts.Common.Mappings;
using Contacts.Common.Resources;
using Contacts.DataAccess;
using Contacts.DataAccess.DbContext;
using Contacts.DataAccess.UnitOfWork;
using Contacts.DataAccess.UnitOfWork.Repositories;
using Contacts.Service;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// injection des services
builder.Services.AddScoped<IService<RoleResource>, RoleService>();
builder.Services.AddScoped<IService<UserResource>, UserService>();
builder.Services.AddScoped<IService<UserRoleResource>, UserRoleService>();
builder.Services.AddScoped<IService<PlaceResource>, PlaceService>();
builder.Services.AddScoped<IService<DepartmentResource>, DepartmentService>();

// injection des repositories
builder.Services.AddScoped<IRepository<RoleEntity>, RoleRepository>();
builder.Services.AddScoped<IRepository<UserEntity>, UserRepository>();
builder.Services.AddScoped<IRepository<UserRoleEntity>, UserRoleRepository>();
builder.Services.AddScoped<IRepository<PlaceEntity>, PlaceRepository>();
builder.Services.AddScoped<IRepository<DepartmentEntity>, DepartmentRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ContactsDbContext>();

builder.Services.AddMvc();
builder.Services.AddCors();
builder.Services.AddAutoMapper(typeof(UserMapping).Assembly);// le mapping n'est pas dans la couche API. Il faut référencer une des classes de la couche Common.
builder.Services.AddDbContext<ContactsDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("ContactsDb"));
});
//Put static data in database 
using var serviceScope = builder.Services.BuildServiceProvider();
var context = serviceScope.GetService<ContactsDbContext>();
new DbSeed().SeedAsync(context).Wait();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
