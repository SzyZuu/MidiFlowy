using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Melanchall.DryWetMidi.Multimedia;
using MidiFlowy.Services;
using MidiFlowy.ViewModels;

namespace MidiFlowy.Views;

public partial class MainWindow : Window
{
    private MainWindowViewModel? _vm;
    
    public MainWindow()
    {
        InitializeComponent();
        GetViewModel();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void GetViewModel()
    {
        _vm = this.DataContext as MainWindowViewModel ?? new MainWindowViewModel();
    }

    private void InputDropdown_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (e.AddedItems.Count > 0)
        {
            if (_vm is not null)
            {
                _vm.NewDeviceSelected((InputDevice)e.AddedItems[0]);
                Console.WriteLine("Changed to: " + _vm.SelectedDevice.Name);
            }
            else
            {
                Console.WriteLine("ViewModel not initialized");
            }
        }else
            Console.WriteLine("No Items added");
    }

    private void OutputSelection_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (e.AddedItems.Count > 0)
        {
            if (_vm is not null)
            {
                _vm.NewOutputDeviceSelected((OutputDevice)e.AddedItems[0]);
            }
            else
            {
                Console.WriteLine("ViewModel not initialized");
            }
        }else
            Console.WriteLine("No Items added");
    }
}