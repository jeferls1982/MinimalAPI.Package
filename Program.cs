var builder = WebApplication.CreateBuilder(args);
builder.AddDapper();
builder.AddServices();
builder.AddOpenAPI();

var app = builder.Build();
app.UseServices();
app.MapCarter();
app.UseOpenAPI(string.Empty);

app.Run();
