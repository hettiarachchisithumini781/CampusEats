
var builder = WebApplication.CreateBuilder(args);

// Allow the deployed React frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend", policy =>
    {
        policy.WithOrigins(
            "https://campus-eats-jade.vercel.app"
        )
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("Frontend");

// Test endpoint
app.MapGet("/", () =>
{
    return Results.Ok(new
    {
        message = "CampusEats API is running successfully!"
    });
});

// Sample menu endpoint
app.MapGet("/api/menu", () =>
{
    var menu = new[]
    {
        new
        {
            id = 1,
            name = "Rice and Curry",
            price = 450
        },
        new
        {
            id = 2,
            name = "Chicken Fried Rice",
            price = 850
        },
        new
        {
            id = 3,
            name = "Kottu",
            price = 750
        }
    };

    return Results.Ok(menu);
});

app.Run();
