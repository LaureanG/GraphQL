using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate;

namespace CommanderGQL.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        public IQueryable<Platform> GetPlatform([ScopedService] AppDbContext context)
        {
            return context.Platforms; 
        }
    }
}