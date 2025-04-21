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
        if (_vm is null)
        {
            Console.WriteLine("ViewModel not initialized");
            return;
        }

        if (e.AddedItems.Count > 0)
        {
            _vm.NewDeviceSelected((InputDevice)e.AddedItems[0]);
            Console.WriteLine("Changed to: " + _vm.SelectedDevice.Name);
        }
    }

    private void OutputSelection_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (_vm is null)
        {
            Console.WriteLine("ViewModel not initialized");
            return;
        }
        
        if (e.AddedItems.Count > 0)
        {            
            Console.WriteLine("Items added");
            _vm.NewOutputDeviceSelected((OutputDevice)e.AddedItems[0]);
        }else if (e.RemovedItems.Count > 0)
        {
            Console.WriteLine("Items removed");
            _vm.OutputDeviceRemoved((OutputDevice)e.RemovedItems[0]);
        }
    }
}