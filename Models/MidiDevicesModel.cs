using System;
using System.Collections.Generic;
using System.Linq;
using Melanchall.DryWetMidi.Multimedia;

namespace MidiFlowy.Models;

public class MidiDevicesModel
{
    private List<InputDevice> _inputDevices = new();
    private List<OutputDevice> _outputDevices = new();

    public bool NoMidiDevices;

    private InputDevice? _selectedDevice;

    public MidiDevicesModel()
    {
        NoMidiDevices = !_inputDevices.Any();
    }

    public IEnumerable<InputDevice> FindAllInputDevices()
    {
        return (IEnumerable<InputDevice>)_inputDevices.ToArray();
    }
    
    public IEnumerable<OutputDevice> FindAllOutputDevices()
    {
        return (IEnumerable<OutputDevice>)_outputDevices.ToArray();
    }
    
    public void AddInput(IEnumerable<InputDevice> inputDevice)
    {
        _inputDevices = inputDevice.ToList();
    }

    public void AddOutput(IEnumerable<OutputDevice> outputDevice)
    {
        _outputDevices = outputDevice.ToList();
    }

    public InputDevice GetSelectedInput()
    {
        if (_selectedDevice is null && !NoMidiDevices)
        {
            _selectedDevice = _inputDevices[0];
            return _selectedDevice;
        } 
        
        return _selectedDevice = null;
    }

    public void SetInput(InputDevice input)
    {
        if(!_inputDevices.Contains(input))
            throw new ModelException();
        _selectedDevice = input;
    }
}