using System;
using System.Collections.Generic;
using System.Linq;
using Melanchall.DryWetMidi.Multimedia;

namespace MidiFlowy.Models;

public class MidiDevices
{
    private List<InputDevice> _inputDevices = new();
    private List<OutputDevice> _outputDevices = new();

    private InputDevice? _selectedDevice;

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
        return _selectedDevice;
    }

    public void SetInput(InputDevice input)
    {
        if(!_inputDevices.Contains(input))
            throw new ModelException();
        _selectedDevice = input;
    }
}