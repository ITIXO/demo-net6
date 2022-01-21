using Microsoft.AspNetCore.Mvc;
using System.Xml.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<PersonService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "Hello World!");

app.MapGet("/person/{person}",
           (Person person, PersonService personService)
                => Results.Ok(personService.SayHello(person)))
    .Produces<string>(StatusCodes.Status200OK)
    .WithName("GET Person deserialized")
    .WithTags("Getters")
    .ExcludeFromDescription();

app.MapPost("/person",
           ([FromBody] Person person)
                => Results.Ok($"Hello, {person.FirstName}!"));


app.MapGet("/person/xml/{person}",
   (Person person)
        => new XmlResult<Person>(person));

app.Run();

public class PersonService
{
    public string SayHello(Person person)
        => $"Hello, {person.FirstName}!";
}


public record Person(string FirstName, string LastName)
{
    public Person() : this(string.Empty, string.Empty)
    {
    }

    public static bool TryParse(string input, out Person? person)
    {
        var parts = input.Split('_');

        person = new(parts[0], parts[1]);
        return true;
    }

    public override string ToString()
        => $"{FirstName} {LastName}";
}


public class XmlResult<T> : IResult
{
    private static readonly XmlSerializer xmlSerializer = new(typeof(T));
    private readonly T result;

    public XmlResult(T result)
    {
        this.result = result;
    }

    public Task ExecuteAsync(HttpContext httpContext)
    {
        using var ms = new MemoryStream();
        xmlSerializer.Serialize(ms, result);

        httpContext.Response.ContentType = "application/xml";

        ms.Position = 0;
        return ms.CopyToAsync(httpContext.Response.Body);
    }
}
