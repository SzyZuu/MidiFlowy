using Melanchall.DryWetMidi.Multimedia;
using MidiFlowy.Models;

namespace MidiFlowy.Services;

public class MidiDeviceRefresherService
{
    private MidiDevicesModel _midiDevicesModel;

    public MidiDeviceRefresherService(MidiDevicesModel midiDevicesModel)
    {
        _midiDevicesModel = midiDevicesModel;
    }

    public void RefreshAll()
    {
        _midiDevicesModel.AddInput(InputDevice.GetAll());
        _midiDevicesModel.AddOutput(OutputDevice.GetAll());
    }
}