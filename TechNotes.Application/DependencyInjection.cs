using System;
using Microsoft.Extensions.DependencyInjection;
using TechNotes.Application.Notes;

namespace TechNotes.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Register application services here
        services.AddScoped<INoteService, NotesService>();

        return services;
    }
}


