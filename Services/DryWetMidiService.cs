using System;
using Melanchall.DryWetMidi.Multimedia;
using MidiFlowy.Models;

namespace MidiFlowy.Services;

public class DryWetMidiService
{
    private MidiDevicesModel _midiDevicesModel;
    private DevicesConnector _devicesConnector;
    
    private InputDevice _selectedInput;
    private OutputDevice[] _selectedOutputs;
    
    public DryWetMidiService(MidiDevicesModel midiDevicesModel)
    {
        _midiDevicesModel = midiDevicesModel;
    }

    public void Reload()
    {
        UnsubscribeOutputEvent();
        
        _selectedInput = _midiDevicesModel.GetSelectedInput();
        _selectedOutputs = _midiDevicesModel.GetSelectedOutputs();

        if (_selectedInput is null || _selectedOutputs is null)
        {
            Console.WriteLine("In or out is null");
            if(_devicesConnector is not null)
                _devicesConnector.Disconnect();
            return;
        }

        foreach (var outputDevice in _selectedOutputs)
        {
            outputDevice.PrepareForEventsSending();
            outputDevice.EventSent += HandleOutputEvent;
        }

        if (_devicesConnector is not null)
        {
            _devicesConnector.Disconnect();
            Console.WriteLine("AREDEVICESCONNECTED: " + _devicesConnector.AreDevicesConnected);
        }

        _devicesConnector = new DevicesConnector(_selectedInput, _selectedOutputs);
        _devicesConnector.Connect();
        _selectedInput.StartEventsListening();
        
        // _selectedInput.EventReceived += (sender, e) =>
        // {
        //     Console.WriteLine($"Input from {_selectedInput.Name}: {e.Event}");
        // };
    }

    private void HandleOutputEvent(object? sender, MidiEventSentEventArgs e)
    {
        if(sender is OutputDevice outputDevice)
            Console.WriteLine($"Output from {outputDevice.Name}: {e.Event}");
    }

    private void UnsubscribeOutputEvent()
    {
        if(_selectedOutputs is null)
            return;

        foreach (var device in _selectedOutputs)
        {
            device.EventSent -= HandleOutputEvent;
        }
    }
}