using CommanderGQL.Models;
using CommanderGQL.Data;
using HotChocolate.Types;
using HotChocolate;

namespace CommanderGQL.GraphQL.Platforms;

public class PlatformType : ObjectType<Platform>
{
    protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
    {
        descriptor.Description("Represents any s/w or service that has command line interface");

        descriptor.Field(p => p.LicenseKey).Ignore();

        descriptor.Field(p => p.Commands)
                    .ResolveWith<Resolvers>(p => p.GetCommands(default!, default!))
                    .UseDbContext<AppDbContext>()
                    .Description("This is the list of the commands available in the platform");

        //base.Configure(descriptor);
    }

    private class Resolvers
    {
        public IQueryable<Command> GetCommands([Parent] Platform platform, [ScopedService] AppDbContext context)
        {
            return context.Commands.Where(p => p.PlatformId == platform.Id);
        }
    }
}