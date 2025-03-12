using GraphQL;
using GraphQL.Types;

var builder = WebApplication.CreateBuilder(args);

/* Register repositories */

builder.Services.AddSingleton<IRepository<Author>, AuthorRepository>();
builder.Services.AddSingleton<IRepository<Book>, BookRepository>();

/* Register GraphQL queries and mutations */

builder.Services.AddSingleton<AuthorQuery>();
builder.Services.AddSingleton<BookQuery>();
builder.Services.AddSingleton<Query>();

builder.Services.AddSingleton<AuthorMutation>();
builder.Services.AddSingleton<BookMutation>();
builder.Services.AddSingleton<Mutation>();

/* Register GraphQL schemas */

builder.Services.AddSingleton<ISchema, AuthorSchema>();
builder.Services.AddSingleton<ISchema, BookSchema>();
builder.Services.AddSingleton<ISchema, AppSchema>();

/*Register GraphQL services*/

builder.Services.AddGraphQL(options =>
{
    options.AddSystemTextJson(); 
    options.AddErrorInfoProvider(opt => opt.ExposeExceptionDetails = true);
    options.AddSchema<AppSchema>();
    options.AddSchema<BookSchema>();
    options.AddSchema<AuthorSchema>();
    options.AddGraphTypes(typeof(AppSchema).Assembly);
    options.AddGraphTypes(typeof(BookSchema).Assembly);
    options.AddGraphTypes(typeof(AuthorSchema).Assembly);
});

var app = builder.Build();

app.UseRouting();

/* Export schemas after building the app using the built service provider. */
await ExportSchema<BookSchema>(app.Services, "Book.graphql");
await ExportSchema<AuthorSchema>(app.Services, "Author.graphql");

/* Configure GraphQL endpoints for each schema.*/
app.UseGraphQL<BookSchema>("/graphql/book");
app.UseGraphQL<AuthorSchema>("/graphql/author");
app.UseGraphQL<AppSchema>("/graphql/app");

/* GraphQL Altair UI (for testing)*/
app.MapGraphQLAltair("/graphQL");

await app.RunAsync();

static async Task ExportSchema<TSchema>(IServiceProvider provider, string fileName) where TSchema : ISchema
{
    var schema = provider.GetRequiredService<TSchema>();
    var sdl = schema.Print();
    await File.WriteAllTextAsync(fileName, sdl);
}