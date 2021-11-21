using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Types;
using System.Linq;

namespace CommanderGQL.GraphQL.Commands
{
    public class CommandType : ObjectType<Command>
    {
        protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
        {
            descriptor.Description("Reperesents any executable command");

            descriptor.Field(c => c.Platform)
                      .ResolveWith<Resolvers>(c => c.GetPlatform(default!, default!))
                      .UseDbContext<AppDbContext>()
                      .Description("This is the platform to which command belongs");
        }

        private class Resolvers
        {
            public Platform GetPlatform([Parent] Command command, [ScopedService] AppDbContext context)
            {
                return context.Platforms.FirstOrDefault(p => p.Id == command.PlatformId);
            }
        }
    }
}
