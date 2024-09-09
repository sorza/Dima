using Dima.Api.Common.Api;
using Dima.Api.Endpoints;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.AddConfiguration();
        builder.AddSecurity();
        builder.AddDataContexts();
        builder.AddCrossOrigin();
        builder.AddDocumentation();
        builder.AddServices();

        var app = builder.Build();

        if(app.Environment.IsDevelopment())
            app.ConfigureDevEnvironment();

        app.UseSecurity();        
        app.MapEndpoints();

        app.Run();
    }
}