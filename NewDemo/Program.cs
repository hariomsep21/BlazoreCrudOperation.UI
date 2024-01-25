using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NewDemo.Services.Interface;
using NewDemo.Services.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using NewDemo;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";





builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7276") });
builder.Services.AddScoped<IStudentInterface, StudentService>();

await builder.Build().RunAsync();