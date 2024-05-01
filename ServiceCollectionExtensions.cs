﻿using Microsoft.Extensions.DependencyInjection;
using MidiFlowy.Models;
using MidiFlowy.ViewModels;

namespace MidiFlowy;

public static class ServiceCollectionExtensions
{
    public static void AddCommonServices(this IServiceCollection collection)
    {
        collection.AddSingleton<MidiDevices>();
        collection.AddTransient<MainWindowViewModel>();
    }
}