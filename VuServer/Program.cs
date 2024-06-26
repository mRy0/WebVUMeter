using VuServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddControllers();
builder.Services.AddSignalR();

builder.Services.AddSingleton<CoreAudioService>();
builder.Services.AddHostedService(sp => sp.GetRequiredService<CoreAudioService>());

builder.Services.AddHostedService<VuService>();
builder.Services.AddRazorPages();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.MapHub<VuHub>("/vuhub");

app.UseStaticFiles();
app.UseDefaultFiles();
app.MapRazorPages();
app.UseBlazorFrameworkFiles();
app.MapFallbackToFile("index.html");





app.Run();
