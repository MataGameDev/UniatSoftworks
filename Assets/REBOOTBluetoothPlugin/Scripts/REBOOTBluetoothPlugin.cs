using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class REBOOTBluetoothPlugin : MonoBehaviour 
{
	public bool landScape;
	public bool applicationNeverSleep;
	public bool disableCanvasOnNewSceneLoad;
	public string messageWhenConnecting;
	public string messageWhenConectionFails;

	private Dropdown devicesDropDownList;
	private Text statusText;
	private Button connectButton;
	private Button quitButton;
	private Canvas connectionCanvas;

	public delegate void BluetoothConnection ();
	public delegate void BluetoothReceiver (string incomingString);
	public static event BluetoothConnection WhenConnectedCall;
	public static event BluetoothConnection WhenDisconnectedCall;
	public static event BluetoothReceiver WhenReceiveDataCall;

    private List<string> devicesList = new List<string> ();
	private static string incomingString;

	private void Start()
	{
		GameObject eventSystem = new GameObject ("EventSystem");
		eventSystem.AddComponent<EventSystem>();
		eventSystem.AddComponent<StandaloneInputModule>();
		devicesDropDownList = GameObject.FindWithTag ("DeviceList").GetComponent<Dropdown>();
		statusText = GameObject.FindWithTag ("StatusText").GetComponent<Text>();
		connectButton = GameObject.FindWithTag ("ConnectButton").GetComponent<Button>();
		quitButton = GameObject.FindWithTag ("QuitButton").GetComponent<Button>();;
		connectionCanvas = GameObject.FindWithTag ("ConnectionCanvas").GetComponent<Canvas>();
		Debug.Log ("Here");
		connectButton.interactable = false;
		AndroidJavaObject plugin = new AndroidJavaObject ("com.bluetooth.re_boot.bluetoothlibrary.BluetoothClass");
		plugin.Call("EnableBluetooth");
		DontDestroyOnLoad (connectionCanvas);
		DontDestroyOnLoad (gameObject);
		connectButton.GetComponent<Button>().onClick.AddListener (Connect);
		quitButton.GetComponent<Button> ().onClick.AddListener (Quit);
        
		if(landScape)
		{
			Screen.orientation = ScreenOrientation.LandscapeLeft;
		}

		if(applicationNeverSleep)
		{
			Screen.sleepTimeout = SleepTimeout.NeverSleep;
		}

        BondedDevices();
	}

    public void BondedDevices()
	{
        AndroidJavaObject plugin = new AndroidJavaObject ("com.bluetooth.re_boot.bluetoothlibrary.BluetoothClass");
		plugin.Call ("DiscoverDevices");
        devicesList.Clear ();		
	}

	public void GetDiscoveredDevices(string message)
	{
        devicesList.Add (message);
		devicesDropDownList.ClearOptions();
		devicesDropDownList.AddOptions (devicesList);
        if(devicesDropDownList.options.Count > 0)
        {
            connectButton.interactable = true;
        }
	}

	public void Connect( )
	{
		string deviceToConnect = devicesDropDownList.GetComponentInChildren<Text> ().text;
		string[] information = deviceToConnect.Split (new char[] {','});
		string macAdress = information[1];
		statusText.text = messageWhenConnecting;
		AndroidJavaObject plugin = new AndroidJavaObject ("com.bluetooth.re_boot.bluetoothlibrary.BluetoothClass");
		plugin.Call ("Connect", macAdress);
	}

    public void OnConnected()
	{
        statusText.text = "Conectado";
        if (disableCanvasOnNewSceneLoad)
		{
			connectionCanvas.gameObject.SetActive (false);
		}

		if(WhenConnectedCall != null)
		{
			WhenConnectedCall();
		}
	}

    public void OnFailedConnection()
	{
		statusText.text = messageWhenConectionFails;
	}

    public void OnDisconnected()
	{
        statusText.text = "Se ha desconectado";

        if (WhenDisconnectedCall != null)
		{
			WhenDisconnectedCall();
		}

		if(disableCanvasOnNewSceneLoad)
		{
			connectionCanvas.gameObject.SetActive (true);
		}
	}

    public void GetString(string incomingMessage)
	{
		if(WhenReceiveDataCall != null)
		{
			WhenReceiveDataCall(incomingMessage);
		}
	}

    public static void Send(string dataToSend)
	{
		AndroidJavaObject plugin = new AndroidJavaObject ("com.bluetooth.re_boot.bluetoothlibrary.BluetoothClass");
		plugin.CallStatic ("Send", dataToSend);		
	}

	void Quit()
	{
		Application.Quit ();
	}
}
