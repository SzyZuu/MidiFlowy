using System;
using System.Collections.Generic;
using System.Linq;
using Melanchall.DryWetMidi.Multimedia;

namespace MidiFlowy.Models;

public class MidiDevicesModel
{
    private List<InputDevice> _inputDevices = new();
    private List<OutputDevice> _outputDevices = new();

    private InputDevice? _selectedDevice;
    private List<OutputDevice> _selectedOutputDevices = new();

    private bool NoMidiDevices()
    { 
        return !_inputDevices.Any();
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
        if (_selectedDevice is null)
        {
            if (!NoMidiDevices())
            {
                _selectedDevice = _inputDevices[0];
                return _selectedDevice;
            }
            return _selectedDevice = null;
        }

        return _selectedDevice;
    }

    public void SetInput(InputDevice input)
    {
        _selectedDevice = input;
    }

    public void AddSelectedOutput(OutputDevice output)
    {
        if (!_selectedOutputDevices.Contains(output))
        {
            _selectedOutputDevices.Add(output);
        }
    }

    public void RemoveOutput(OutputDevice outputToRemove)
    {
        if (_selectedOutputDevices.Contains(outputToRemove))
        {
            _selectedOutputDevices.Remove(outputToRemove);
            Console.WriteLine("Removed device");
        }
    }
}