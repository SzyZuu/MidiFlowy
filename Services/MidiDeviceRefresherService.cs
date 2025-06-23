using System;
using System.Threading.Tasks;
using Melanchall.DryWetMidi.Multimedia;
using MidiFlowy.Models;

namespace MidiFlowy.Services;

public class MidiDeviceRefresherService
{
    private MidiDevicesModel _midiDevicesModel;

    public MidiDeviceRefresherService(MidiDevicesModel midiDevicesModel)
    {
        _midiDevicesModel = midiDevicesModel;

        DevicesWatcher.Instance.DeviceRemoved += OnDeviceRemoved;
        DevicesWatcher.Instance.DeviceAdded += OnDeviceAdded;
    }

    public async void RefreshAll()
    {
        await _midiDevicesModel.ClearDevices();
        
        _midiDevicesModel.AddInput(InputDevice.GetAll());

        foreach (var device in OutputDevice.GetAll())
        {
            Console.WriteLine(device.Name);
        }
        _midiDevicesModel.AddOutput(OutputDevice.GetAll());
    }
    
    private static void OnDeviceRemoved(object sender, DeviceAddedRemovedEventArgs e)
    {
        Console.WriteLine($"Device removed.");
    }
    
    private static void OnDeviceAdded(object sender, DeviceAddedRemovedEventArgs e)
    {
        Console.WriteLine($"Device added.");
    }
}