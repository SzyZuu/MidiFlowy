using System;
using System.Collections.Generic;

namespace MidiFlowy.Services;

public class TeVirtualMidiService
{
    private Dictionary<string, TeVirtualMIDI> _ports = new();

    public void CreatePort(string name)
    {
        if (_ports.ContainsKey(name))
            throw new Exception("Port with this name already exists");
        _ports.Add(name, new TeVirtualMIDI(name));
    }

    public void RemovePort(string name)
    {
        if (!_ports.ContainsKey(name))
            throw new Exception("Couldn't remove port: " + name + ". No port was found with the name");
        
        _ports[name].shutdown();
        _ports.Remove(name);
    }

    public TeVirtualMIDI GetPortByName(string name)
    {
        if (_ports.ContainsKey(name))
        {
            return _ports[name];
        }

        throw new Exception("Couldn't get port: " + name);
    }
}