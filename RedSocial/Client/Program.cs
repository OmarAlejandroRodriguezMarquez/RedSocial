using Blazorise;
using Blazorise.Icons.Material;
using Blazorise.Material;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RedSocial.Client;
using RedSocial.Client.Auth;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddMaterialProviders()
    .AddMaterialIcons();

builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<Autenticacion>();
builder.Services.AddScoped<AuthenticationStateProvider, Autenticacion>(proveedor => 
proveedor.GetRequiredService<Autenticacion>());
builder.Services.AddScoped<ILoginService, Autenticacion>(proveedor =>
proveedor.GetRequiredService<Autenticacion>());

builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();

