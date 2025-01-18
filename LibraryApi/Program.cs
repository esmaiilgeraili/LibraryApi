using LibraryManagement.Configuration;

var builder = WebApplication.CreateBuilder(args);

#region ConfigureServices
var configuration = ConfigurationHelper.GetConfiguration();
builder.Services.AddSingleton(configuration);

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
