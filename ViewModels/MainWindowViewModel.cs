using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Multimedia;
using MidiFlowy.Models;
using MidiFlowy.Services;
using ReactiveUI;

namespace MidiFlowy.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public string Greeting => "MidiFlowy";
    private string? _deviceNameText;
    public MidiDevicesModel MidiDevicesModel = new();
    public InputDevice SelectedDevice { get; set; }
    public OutputDevice[] SelectedOutputDevices { get; set; }
    private ObservableCollection<InputDevice> _inputDevices;
    private ObservableCollection<OutputDevice> _outputDevices;
    
    private DryWetMidiService _midiService;
    private TeVirtualMidiService _virtualMidiService;
    private MidiDeviceRefresherService _deviceRefresherService;
    
    public ICommand AddVirtualDeviceCommand { get; }
    public ICommand RemoveVirtualDeviceCommand { get; }

    public MainWindowViewModel()
    {
        _virtualMidiService = new TeVirtualMidiService();
        _midiService = new DryWetMidiService(MidiDevicesModel);
        _inputDevices = new ObservableCollection<InputDevice>();
        _outputDevices = new ObservableCollection<OutputDevice>();
        
        _deviceRefresherService = new MidiDeviceRefresherService(MidiDevicesModel);
        _deviceRefresherService.RefreshAll();
     
        LoadMidiDevices();
        SelectedDevice = MidiDevicesModel.GetSelectedInput();

        AddVirtualDeviceCommand = ReactiveCommand.Create(AddVirtualDevice);
        RemoveVirtualDeviceCommand = ReactiveCommand.Create(RemoveVirtualDevice);
    }

    private void RefreshDevices()
    {
        _inputDevices.Clear();
        _outputDevices.Clear();
        _deviceRefresherService.RefreshAll();
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

    public string? DeviceNameText
    {
        get => _deviceNameText;
        set => this.RaiseAndSetIfChanged(ref _deviceNameText, value);
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
        
        _midiService.Reload();
    }

    public void NewOutputDeviceSelected(OutputDevice newSelected)
    {
        Console.WriteLine("New Output Device Selected in ListBox: " + newSelected.Name);
        MidiDevicesModel.AddSelectedOutput(newSelected);
        
        _midiService.Reload();
    }

    public void OutputDeviceRemoved(OutputDevice removedDevice)
    {
        Console.WriteLine("Removing device: " + removedDevice.Name);
        MidiDevicesModel.RemoveOutput(removedDevice);
        
        _midiService.Reload();
    }

    private void AddVirtualDevice()
    {
        if(DeviceNameText is not null && DeviceNameText.Length > 1)
        {
            _virtualMidiService.CreatePort(DeviceNameText);
            RefreshDevices();
        }
    }
    
    private void RemoveVirtualDevice()
    {
        if(DeviceNameText is not null && DeviceNameText.Length > 1)
        {
            _virtualMidiService.RemovePort(DeviceNameText);
            RefreshDevices();
        }
    }
}
