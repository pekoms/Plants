using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Plants.WA;
using Plants.WA.Services;
using MudBlazor.Services;



var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddTransient<IPlantService, PlantService>();
builder.Services.AddTransient<IPlantRecordService, PlantRecordService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddSingleton<SharedStateService>();


builder.Services.AddMudServices();

    



await builder.Build().RunAsync();
