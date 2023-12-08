using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Serial : MonoBehaviour
{
    SerialPort arduinoPort = new SerialPort("COM8");


    //Awake is called before Game Starts
    void Awake()
    {

        arduinoPort.BaudRate = 9600;
        arduinoPort.Parity = Parity.None;
        arduinoPort.StopBits = StopBits.One;
        arduinoPort.DataBits = 8;
        arduinoPort.Handshake = Handshake.None;

    }
    // Start is called before the first frame update
    void Start()
    {
        arduinoPort.Open();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendMessageToArduino(string msg)
    {
        arduinoPort.WriteLine(msg);
    }

    public void ClosePort()
    {
        arduinoPort.Close();
    }


}
