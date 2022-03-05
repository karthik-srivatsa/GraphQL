using CommanderGQL.Data;
using CommanderGQL.GraphQL;
using CommanderGQL.GraphQL.Platforms;
using CommanderGQL.GraphQL.Commands;
using GraphQL.Server.Ui.Voyager;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddPooledDbContextFactory<AppDbContext>(opt => opt.UseSqlServer
                        (configuration.GetConnectionString("CommandDbConnection")));

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<PlatformType>()
    .AddType<CommandType>()
    .AddFiltering()
    .AddSorting();


var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.MapGraphQL();

//{url}/ui/voyager
app.UseGraphQLVoyager(new VoyagerOptions
{
    GraphQLEndPoint = "/graphql",
});

app.Run();
