using dot_net_backend_api.Data;
using dot_net_backend_api.Query;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// make connection to the database
builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("postgressConnection")));

//Graphql
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();

var app = builder.Build();

app.MapGraphQL();

app.Run();
