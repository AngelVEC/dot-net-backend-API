using dot_net_backend_api.Data;
using dot_net_backend_api.mutation;
using dot_net_backend_api.Query;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// make connection to the database
builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("postgressConnection")));

//Cors for localhost react
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                            policy.AllowAnyHeader();
                            policy.AllowAnyMethod();
                            policy.WithOrigins("http://localhost:3000");
                      });
});

//Graphql
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

var app = builder.Build();

//To make /graphql accessable
app.MapGraphQL();

//To allow cors origin
app.UseCors(MyAllowSpecificOrigins);

app.Run();
