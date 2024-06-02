using System.Collections.Generic;
using System.Linq;
using Melanchall.DryWetMidi.Multimedia;
using MidiFlowy.Models;
using MidiFlowy.Services;

namespace MidiFlowy.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public string Greeting => "MidiFlowy";
    private MidiDevices _midiDevices = new();

    public MainWindowViewModel()
    {
        var midiDeviceRefresher = new MidiDeviceRefresherService(_midiDevices);
        midiDeviceRefresher.RefreshAll();
    }

    public List<InputDevice> InputDevices()
    {
        return _midiDevices.FindAllInputDevices().ToList();
    }
}
