using System.Collections.ObjectModel;
using Melanchall.DryWetMidi.Multimedia;
using MidiFlowy.Models;
using MidiFlowy.Services;

namespace MidiFlowy.ViewModels;

public class MidiViewModel : ViewModelBase
{
    public MidiDevicesModel MidiDevicesModel = new();
    public ObservableCollection<InputDevice> InputDevices;

    public MidiViewModel()
    {
        InputDevices = new ObservableCollection<InputDevice>();
        var midiDeviceRefresher = new MidiDeviceRefresherService(MidiDevicesModel);
        midiDeviceRefresher.RefreshAll();
    }
}