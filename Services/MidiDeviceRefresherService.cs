using Melanchall.DryWetMidi.Multimedia;
using MidiFlowy.Models;

namespace MidiFlowy.Services;

public class MidiDeviceRefresherService(MidiDevices midiDevices)
{
    public void RefreshAll()
    {
        midiDevices.AddInput(InputDevice.GetAll());
        midiDevices.AddOutput(OutputDevice.GetAll());
    }
}