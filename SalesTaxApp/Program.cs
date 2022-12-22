using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SalesTaxApp;
using SalesTaxApp.Builder;
using SalesTaxApp.Db;
using SalesTaxApp.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IShoppingTripCalculator, ShoppingTripCalculator>();
builder.Services.AddSingleton<IShopStoreDB, ShopStoreDB>();
builder.Services.AddSingleton<IProductFactory, ProductFactory>();
builder.Services.AddSingleton<IPriceCalculatorService, PriceCalculatorService>();
await builder.Build().RunAsync();
