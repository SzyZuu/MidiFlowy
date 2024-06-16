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
    private ObservableCollection<InputDevice> _inputDevices;

    public MainWindowViewModel()
    {
        _inputDevices = new ObservableCollection<InputDevice>();
        var midiDeviceRefresher = new MidiDeviceRefresherService(MidiDevicesModel);
        midiDeviceRefresher.RefreshAll();
     
        LoadInputDevices();
        SelectedDevice = MidiDevicesModel.GetSelectedInput();
    }

    public ObservableCollection<InputDevice> InputDevices
    {
        get => _inputDevices;
        set => this.RaiseAndSetIfChanged(ref _inputDevices, value);
    }

    private void LoadInputDevices()
    {
        foreach (var device in MidiDevicesModel.FindAllInputDevices())
        {
            InputDevices.Add(device);
        }
    }
}
