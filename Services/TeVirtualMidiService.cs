using System;
using System.Collections.Generic;

namespace MidiFlowy.Services;

public class TeVirtualMidiService
{
    private Dictionary<string, TeVirtualMIDI> _ports = new();

    public void CreatePort(string name)
    {
        Console.WriteLine("Attempting port creation");
        
        if (_ports.ContainsKey(name))
        {
            //throw new Exception("Port with this name already exists");
            Console.WriteLine("Port with name exists");
            return;
        }        
        
        _ports.Add(name, new TeVirtualMIDI(name));
        Console.WriteLine("Port added");
    }

    public void RemovePort(string name)
    {
        Console.WriteLine("Attempting port removal");

        if (!_ports.ContainsKey(name))
        {
            //throw new Exception("Couldn't remove port: " + name + ". No port was found with the name");
            Console.WriteLine("Couldn't remove port: " + name + ". No port was found with the name");
            return;
        }      
        
        _ports[name].shutdown();
        _ports.Remove(name);
        Console.WriteLine("Port removed");
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