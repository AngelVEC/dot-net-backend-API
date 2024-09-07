using dot_net_backend_api.Data;
using dot_net_backend_api.mutation;
using dot_net_backend_api.Query;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// make connection to the database
builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("postgressConnection")));

//Graphql
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

var app = builder.Build();

//To make /graphql accessable
app.MapGraphQL();

app.Run();
