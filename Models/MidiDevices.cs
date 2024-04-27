using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Melanchall.DryWetMidi.Multimedia;

namespace MidiFlowy.Models;

public class MidiDevices
{
    private List<InputDevice> _inputDevices;
    private List<OutputDevice> _outputDevices;

    public MidiDevices()
    {
        _inputDevices = new List<InputDevice>();
        _outputDevices = new List<OutputDevice>();
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
}