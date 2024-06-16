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
        throw new System.NotImplementedException();
    }
}