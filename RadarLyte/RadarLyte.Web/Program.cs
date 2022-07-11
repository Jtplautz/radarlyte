using RadarLyte.Extensions;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
//builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();

//app.MapRazorPages();
if (app.Environment.IsDevelopment())
{
    app.UseSpa(spa =>
    {
        // use 'build-dev' npm script
        spa.Options.StartupTimeout = TimeSpan.FromSeconds(10);
        spa.Options.SourcePath = "InteractiveClient";
        spa.UseViteDevelopmentServer();
    });

}

app.Run();
