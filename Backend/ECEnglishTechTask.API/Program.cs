using System;
using AutoMapper;
using ECEnglishTechTask.Application.Extensions;
using ECEnglishTechTask.Application.Services;
using ECEnglishTechTask.Application.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterDALDependencies(builder.Configuration);
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ICourseService, CourseService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var config = new MapperConfiguration(cfg => cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies()));
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
