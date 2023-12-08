
using UnityEngine;

public class SendAndRecieveInformationScript : MonoBehaviour
{
    public void TurnLedOn()
    {
        REBOOTBluetoothPlugin.Send("1");
    }

    public void TurnLedOff()
    {
        REBOOTBluetoothPlugin.Send("2");
    }

}
