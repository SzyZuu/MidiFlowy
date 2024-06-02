using System.Collections.Generic;
using Avalonia.Controls;
using Melanchall.DryWetMidi.Multimedia;

namespace MidiFlowy.Views;

public partial class MainWindow : Window
{
    private List<InputDevice> _inputDevices;
    
    public MainWindow()
    {
        InitializeComponent();
    }
}