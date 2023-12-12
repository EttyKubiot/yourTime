using UnityEngine;
using UnityEngine.InputSystem;

public class XboxDeviceChecker : MonoBehaviour
{
    public GameObject[] players; // Array of player objects to activate

    void Start()
    {
      
        CheckConnectedDevices();
    }

    void CheckConnectedDevices()
    {
        var allDevices = InputSystem.devices;

        Debug.Log("Total Connected Devices: " + allDevices.Count);

        int xboxDeviceCount = 0;

        foreach (var device in allDevices)
        {
            Debug.Log("Device Name: " + device.name);
            Debug.Log("Device Layout: " + device.layout);

            if (IsXboxController(device))
            {
                xboxDeviceCount++;
            }
        }

        Debug.Log("Xbox Devices Found: " + xboxDeviceCount);

        ActivatePlayers(xboxDeviceCount);
    }

    bool IsXboxController(InputDevice device)
    {
        string productName = device.name;
        return productName.Contains("XInputControllerWindows", System.StringComparison.OrdinalIgnoreCase);
    }

    void ActivatePlayers(int count)
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].SetActive(i < count);
        }
    }
}
