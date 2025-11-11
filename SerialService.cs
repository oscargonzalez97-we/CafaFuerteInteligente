using System;
using System.IO.Ports;
using System.Threading;

public class SerialService : IDisposable
{
    private SerialPort _port;
    private readonly object _lock = new object();

    public event Action<string> LineReceived; // para la UI si desea suscribirse

    public SerialService(string portName, int baudRate = 9600)
    {
        _port = new SerialPort(portName, baudRate) { NewLine = "\n", ReadTimeout = 500 };
        _port.DataReceived += Port_DataReceived;
        try { if (!_port.IsOpen) _port.Open(); }
        catch (Exception) { /* manejar en UI */ }
    }

    private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        try
        {
            string s = _port.ReadLine()?.Trim();
            if (!string.IsNullOrEmpty(s)) LineReceived?.Invoke(s);
        }
        catch { /* ignore read errors */ }
    }

    public void SendCommand(string cmd)
    {
        try
        {
            lock (_lock)
            {
                if (_port != null && _port.IsOpen)
                {
                    _port.WriteLine(cmd);
                }
            }
        }
        catch { /* manejar/log */ }
    }

    public bool IsOpen => _port != null && _port.IsOpen;

    public void Dispose()
    {
        try
        {
            if (_port != null)
            {
                _port.DataReceived -= Port_DataReceived;
                if (_port.IsOpen) _port.Close();
                _port.Dispose();
            }
        }
        catch { }
    }
}
