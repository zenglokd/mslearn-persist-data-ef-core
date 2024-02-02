using ContosoPizza.Services;
using ContosoPizza.Data;
// Additional using declarations

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<PizzaService>();
builder.Services.AddScoped<CouponService>();

// Add the PizzaContext
builder.Services.AddSqlite<PizzaContext>("Data Source=ContosoPizza.db");

// Add the PromotionsContext
builder.Services.AddSqlite<PromotionsContext>("Data Source=Promotions/Promotions.db");





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

// Add the CreateDbIfNotExists method call
app.CreateDbIfNotExists();

app.MapGet("/", () => @"Contoso Pizza management API. Navigate to /swagger to open the Swagger test UI.");

app.Run();



