using LibraryManagement.Configuration;
using LibraryManagement.ConfigurationService;

var builder = WebApplication.CreateBuilder(args);

#region ConfigureServices
var configuration = ConfigurationHelper.GetConfiguration();
builder.Services.AddSingleton(configuration);

LibraryManagementBootstrapper.Configure(builder.Services, configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

#region Configure
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
#endregion


app.Run();
