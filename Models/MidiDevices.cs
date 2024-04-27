using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Melanchall.DryWetMidi.Multimedia;

namespace MidiFlowy.Models;

public class MidiDevices
{
    private List<InputDevice> InputDevices;
    private List<OutputDevice> OutputDevices;

    public MidiDevices()
    {
        InputDevices = new List<InputDevice>();
        OutputDevices = new List<OutputDevice>();
    }
    
    public IEnumerable<InputDevice> FindAllInputDevices()
    {
        return (IEnumerable<InputDevice>)InputDevices.ToArray();
    }
    
    public IEnumerable<OutputDevice> FindAllOutputDevices()
    {
        return (IEnumerable<OutputDevice>)OutputDevices.ToArray();
    }
    
    public void AddInput(IEnumerable<InputDevice> inputDevice)
    {
        InputDevices = inputDevice.ToList();
    }

    public void AddOutput(IEnumerable<OutputDevice> outputDevice)
    {
        OutputDevices = outputDevice.ToList();
    }
}