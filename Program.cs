using CryptlexLicensingApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureServices();

var app = builder.Build();

Configure(app);

app.Run();

void ConfigureServices()
{
    builder.Services.AddRazorPages();
    builder.Services.AddSession(options =>
    {
        options.IdleTimeout = TimeSpan.FromMinutes(30);
        options.Cookie.HttpOnly = true;
        options.Cookie.IsEssential = true;
    });
    builder.Services.AddAuthentication("CookieAuthentication")
        .AddCookie("CookieAuthentication", config =>
        {
            config.Cookie.Name = "UserLoginCookie";
            config.LoginPath = "/Login";
        });
    builder.Services.AddScoped(sp => new HttpService(sp.GetRequiredService<IConfiguration>()));
}

void Configure(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }

    app.UseStaticFiles();
    app.UseRouting();
    app.UseHttpsRedirection();
    app.UseSession();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapRazorPages();
    app.UseMiddleware<BearerTokenMiddleware>();
}
