using System.Collections.ObjectModel;
using Melanchall.DryWetMidi.Multimedia;
using MidiFlowy.Models;
using MidiFlowy.Services;

namespace MidiFlowy.ViewModels;

public class MidiViewModel : ViewModelBase
{
    public MidiDevices MidiDevices = new();
    public ObservableCollection<InputDevice> InputDevices;

    public MidiViewModel()
    {
        InputDevices = new ObservableCollection<InputDevice>();
        var midiDeviceRefresher = new MidiDeviceRefresherService(MidiDevices);
        midiDeviceRefresher.RefreshAll();
    }
}