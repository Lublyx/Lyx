using Lyx.CLI;
using Microsoft.Extensions.DependencyInjection;

namespace Lyx.CLI;

public static class Program
{
    public static void Main(string[] args)
    {
        try
        {

            ServiceCollection services = new ServiceCollection();
            SetIoC(services);
            ServiceProvider provider = services.BuildServiceProvider();

            App app = provider.GetRequiredService<App>();
            app.Run(args);
        
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    public static void SetIoC(ServiceCollection services)
    {
        IoC.IoC.Init(services);
        services.AddSingleton<App>();
    }
}

