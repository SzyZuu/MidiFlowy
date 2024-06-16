using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Melanchall.DryWetMidi.Multimedia;
using MidiFlowy.Models;
using MidiFlowy.Services;
using ReactiveUI;

namespace MidiFlowy.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public string Greeting => "MidiFlowy";
    public InputDevice SelectedDevice { get; set; }
    public MidiViewModel MidiViewModel { get; }

    public MainWindowViewModel()
    {
        MidiViewModel = new MidiViewModel();
        LoadInputDevices();
        SelectedDevice = MidiViewModel.MidiDevices.GetSelectedInput();
    }

    public ObservableCollection<InputDevice> InputDevices
    {
        get => MidiViewModel.InputDevices;
        set => this.RaiseAndSetIfChanged(ref MidiViewModel.InputDevices, value);
    }

    private void LoadInputDevices()
    {
        foreach (var device in MidiViewModel.MidiDevices.FindAllInputDevices())
        {
            InputDevices.Add(device);
        }
    }
}
