using DoctorWho.Db;
using DoctorWho.Db.Interfaces.IReporitories;
using DoctorWho.Db.Repositories;
using DoctorWho.Services;
using DoctorWho.Services.Interfaces;
using DoctorWho.Web.Filters;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options=>options.Filters.Add<ValidationFilter>())
.AddJsonOptions(opt =>
                opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); ;
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IEpisodeRepository, EpisodeRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IEnemyRepository, EnemyRepository>();
builder.Services.AddScoped<ICompanionRepository, CompanionRepository>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IEpisodeService, EpisodeService>();
builder.Services.AddScoped<IEnemyService, EnemyService>();
builder.Services.AddScoped<ICompanionService, CompanionService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddDbContext<DoctorWhoCoreDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DoctorWhoCoreDatabase")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters()
                .AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()); ;

var app = builder.Build();

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
