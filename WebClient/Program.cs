using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebClient;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.Components;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Add SignalR connection as a singleton service
builder.Services.AddSingleton(sp =>
{
    return new HubConnectionBuilder()
        .WithUrl("https://localhost:7157/chatHub") // Backend SignalR hub URL
        .WithAutomaticReconnect() // Automatically reconnect on disconnection
        .Build();
});

// Add HttpClient
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
