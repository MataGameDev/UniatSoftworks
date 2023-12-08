
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        REBOOTBluetoothPlugin.WhenConnectedCall += ChangeScene;
    }

    // Update is called once per frame
    void ChangeScene()
    {
        SceneManager.LoadScene("Scene2", LoadSceneMode.Single);
    }
}
