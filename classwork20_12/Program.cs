var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddRazorPages();
builder.Services.AddControllers();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.MapControllers();

app.MapGet("/random", (HttpContext context) => 
{
    Random random = new();
    context.Response.WriteAsync("<h1>Welcome to random letter!</h1>");
    context.Response.WriteAsync($"<p>Your random letter is {(char) random.Next(1,100)}</p>");
}).WithName("random");

app.MapGet("/", (LinkGenerator links) =>
    new[]
    {
        links.GetPathByName("persons", options: new LinkOptions { AppendTrailingSlash = false}),
        links.GetPathByName("random"),
        links.GetPathByName("get_person"),
        links.GetPathByName("write_person")
    }
);

app.Run();
