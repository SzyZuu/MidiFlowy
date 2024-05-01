using Melanchall.DryWetMidi.Multimedia;
using MidiFlowy.Models;

namespace MidiFlowy.Services;

public interface IMidiDeviceRefresher
{
    void RefreshAll();
}

public class MidiDeviceRefresherService(MidiDevices midiDevices) : IMidiDeviceRefresher
{
    public void RefreshAll()
    {
        midiDevices.AddInput(InputDevice.GetAll());
        midiDevices.AddOutput(OutputDevice.GetAll());
    }
}