using Melanchall.DryWetMidi.Multimedia;
using MidiFlowy.Models;

namespace MidiFlowy.Services;

public class MidiDeviceRefresherService
{
    private MidiDevices _midiDevices;

    public MidiDeviceRefresherService(MidiDevices midiDevices)
    {
        _midiDevices = midiDevices;
    }

    public void RefreshAll()
    {
        _midiDevices.AddInput(InputDevice.GetAll());
        _midiDevices.AddOutput(OutputDevice.GetAll());
    }
}