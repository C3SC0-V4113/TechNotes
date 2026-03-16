using Microsoft.Extensions.DependencyInjection;
using TechNotes.Application.Notes;

namespace TechNotes.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediator(typeof(DependencyInjection).Assembly);
        services.AddScoped<INotesOverviewService, NotesOverviewService>();
        return services;
    }
}


