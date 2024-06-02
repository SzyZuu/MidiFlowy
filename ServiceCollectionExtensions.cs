using Microsoft.Extensions.DependencyInjection;
using MidiFlowy.Models;
using MidiFlowy.Services;
using MidiFlowy.ViewModels;

namespace MidiFlowy;

public static class ServiceCollectionExtensions
{
    public static void AddCommonServices(this IServiceCollection collection)
    {
        collection.AddTransient<MainWindowViewModel>();
    }
}