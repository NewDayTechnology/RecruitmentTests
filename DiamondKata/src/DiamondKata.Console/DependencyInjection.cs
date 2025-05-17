using Microsoft.Extensions.DependencyInjection;
using DiamondKata.Application.Interfaces;
using DiamondKata.Application.Services;
using DiamondKata.Domain.Interfaces;
using DiamondKata.Infrastructure.Services;

namespace DiamondKata.Console;

public static class DependencyInjection
{
    public static IServiceCollection AddDiamondKataServices(this IServiceCollection services)
    {
        // Domain services
        services.AddSingleton<IDiamondPatternService, DiamondPatternService>();

        // Application services
        services.AddSingleton<IDiamondGeneratorService, DiamondGeneratorService>();

        // Console services
        services.AddSingleton<IInputHandler, ConsoleInputHandler>();

        return services;
    }
} 