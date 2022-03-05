using CommanderGQL.Models;
using CommanderGQL.Data;
using HotChocolate.Types;
using HotChocolate;


namespace CommanderGQL.GraphQL.Commands;

public class CommandType : ObjectType<Command>
{
    protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
    {
        descriptor.Description("Represents any executable command");

        descriptor.Field(c => c.Platform).ResolveWith<Resolvers>(c => c.GetPlatform(default!, default!))
        .UseDbContext<AppDbContext>()
        .Description("This is the platform where command belongs");

        //base.Configure(descriptor);
    }

    private class Resolvers
    {
        public Platform GetPlatform(Command command, [ScopedService] AppDbContext context)
        {
            return context.Platforms.First(p => p.Id == command.PlatformId);
        }
    }
}