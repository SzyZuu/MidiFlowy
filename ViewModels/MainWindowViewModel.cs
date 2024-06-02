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
    private MidiDevices _midiDevices = new();
    private ObservableCollection<InputDevice> _inputDevices;

    public MainWindowViewModel()
    {
        _inputDevices = new ObservableCollection<InputDevice>();
        var midiDeviceRefresher = new MidiDeviceRefresherService(_midiDevices);
        midiDeviceRefresher.RefreshAll();
        LoadInputDevices();

        SelectedDevice = _midiDevices.GetSelectedInput();
    }

    public ObservableCollection<InputDevice> InputDevices
    {
        get => _inputDevices;
        set => this.RaiseAndSetIfChanged(ref _inputDevices, value);
    }

    private void LoadInputDevices()
    {
        foreach (var device in _midiDevices.FindAllInputDevices())
        {
            InputDevices.Add(device);
        }
    }
}
