using System;
using Melanchall.DryWetMidi.Multimedia;
using MidiFlowy.Models;

namespace MidiFlowy.Services;

public class DryWetMidiService
{
    private MidiDevicesModel _midiDevicesModel;
    private DevicesConnector _devicesConnector;
    
    public DryWetMidiService(MidiDevicesModel midiDevicesModel)
    {
        _midiDevicesModel = midiDevicesModel;
    }

    public void Reload()
    {
        InputDevice selectedInput = _midiDevicesModel.GetSelectedInput();
        OutputDevice[] selectedOutputs = _midiDevicesModel.GetSelectedOutputs();

        if (selectedInput is null || selectedOutputs is null)
        {
            Console.WriteLine("In or out is null");
            return;
        }

        foreach (var outputDevice in selectedOutputs)
        {
            outputDevice.PrepareForEventsSending();
            outputDevice.EventSent += (sender, e) =>
            {
                Console.WriteLine($"Output from {outputDevice.Name}: {e.Event}");
            };
        }

        if (_devicesConnector is not null)
            _devicesConnector.Disconnect();

        _devicesConnector = new DevicesConnector(selectedInput, selectedOutputs);
        _devicesConnector.Connect();
        selectedInput.StartEventsListening();
        
        selectedInput.EventReceived += (sender, e) =>
        {
            Console.WriteLine($"Input from {selectedInput.Name}: {e.Event}");
        };
    }
}