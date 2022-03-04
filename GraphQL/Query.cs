using CommanderGQL.Models;
using CommanderGQL.Data;

namespace CommanderGQL.GraphQL;

public class Query
{
    [UseDbContext(typeof(AppDbContext))]
    [UseProjection]
    public IQueryable<Platform> GetPlatforms([ScopedService] AppDbContext context)
    {
        return context.Platforms;
    }

    [UseDbContext(typeof(AppDbContext))]
    [UseProjection]
    public IQueryable<Command> GetCommands([ScopedService] AppDbContext context)
    {
        return context.Commands;
    }
}