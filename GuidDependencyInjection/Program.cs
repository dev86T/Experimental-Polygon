using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddSingleton<IGuidService, GuidDependencyInjection>(); //AddTransient, AddScoped

var serviceProvider = services.BuildServiceProvider();

using (var scope = serviceProvider.CreateScope())
{
    var service1 = scope.ServiceProvider.GetRequiredService<IGuidService>();
    var service2 = scope.ServiceProvider.GetRequiredService<IGuidService>();

    service1.PrintGuid();
    service2.PrintGuid();

    Console.WriteLine(ReferenceEquals(service1, service2));
}


class GuidDependencyInjection : IGuidService
{
    private readonly Guid _guid;

    public GuidDependencyInjection()
    {
        _guid = Guid.NewGuid();
    }

    public void PrintGuid()
    {
        Console.WriteLine(_guid);
    }
}


interface IGuidService
{
    void PrintGuid();
}