using BinhTypingApp.Application.Domain.Repository;
using BinhTypingApp.Web;
using BinhTypingApp.Web.HttpRepository;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetValue<String>("BASEAPIURL")) });
builder.Services.AddScoped<ITypingNotesHttpRepository, TypingNotesHttpRepository>();
var baseURL = builder.Configuration.GetValue<String>("BASEAPIURL");
await builder.Build().RunAsync();
