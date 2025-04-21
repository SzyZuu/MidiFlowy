using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Melanchall.DryWetMidi.Multimedia;
using MidiFlowy.Models;
using MidiFlowy.Services;
using ReactiveUI;

namespace MidiFlowy.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public string Greeting => "MidiFlowy";
    public MidiDevicesModel MidiDevicesModel = new();
    public InputDevice SelectedDevice { get; set; }
    public OutputDevice[] SelectedOutputDevices { get; set; }
    private ObservableCollection<InputDevice> _inputDevices;
    private ObservableCollection<OutputDevice> _outputDevices;

    public MainWindowViewModel()
    {
        _inputDevices = new ObservableCollection<InputDevice>();
        _outputDevices = new ObservableCollection<OutputDevice>();
        
        var midiDeviceRefresher = new MidiDeviceRefresherService(MidiDevicesModel);
        midiDeviceRefresher.RefreshAll();
     
        LoadMidiDevices();
        SelectedDevice = MidiDevicesModel.GetSelectedInput();
    }

    public ObservableCollection<InputDevice> InputDevices
    {
        get => _inputDevices;
        set => this.RaiseAndSetIfChanged(ref _inputDevices, value);
    }
    
    public ObservableCollection<OutputDevice> OutputDevices
    {
        get => _outputDevices;
        set => this.RaiseAndSetIfChanged(ref _outputDevices, value);
    }

    private void LoadMidiDevices()
    {
        foreach (var device in MidiDevicesModel.FindAllInputDevices())
        {
            InputDevices.Add(device);
        }

        foreach (var device in MidiDevicesModel.FindAllOutputDevices())
        {
            OutputDevices.Add(device);
        }
    }

    public void NewDeviceSelected(InputDevice newSelected)
    {
        Console.WriteLine("New Selected Device in ComboBox: " + newSelected.Name);
        MidiDevicesModel.SetInput(newSelected);
        SelectedDevice = MidiDevicesModel.GetSelectedInput();
    }

    public void NewOutputDeviceSelected(OutputDevice newSelected)
    {
        Console.WriteLine("New Output Device Selected in ListBox: " + newSelected.Name);
        MidiDevicesModel.AddSelectedOutput(newSelected);
    }

    public void OutputDeviceRemoved(OutputDevice removedDevice)
    {
        Console.WriteLine("Removing device: " + removedDevice.Name);
        MidiDevicesModel.RemoveOutput(removedDevice);
    }
}
