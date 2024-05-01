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
        
    }
}