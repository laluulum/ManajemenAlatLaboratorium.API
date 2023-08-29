using ManajemenAlatLaboratorium.API.Data;
using ManajemenAlatLaboratorium.API.Services;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers()
        .AddJsonOptions(configure => {
            configure.JsonSerializerOptions.AllowTrailingCommas = true;
        });

    builder.Services.AddSqlite<LaboratoriumContext>("Data Source=Laboratorium.db");
    
    builder.Services.AddScoped<IAlatService, AlatService>();
    builder.Services.AddScoped<IPeminjamService, PeminjamService>();
    builder.Services.AddScoped<IPeminjamanAlatService, PeminjamanAlatService>();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    //app.UseAuthorization();
    app.MapControllers();
    app.Run();
}