using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class CustomDeviceIdManager : MonoBehaviour
{
    private Dictionary<InputDevice, string> deviceUniqueIds = new Dictionary<InputDevice, string>();

    void Start()
    {
        GetConnectedDevicesUniqueIds();
    }

    void GetConnectedDevicesUniqueIds()
    {
        var allDevices = InputSystem.devices;

        foreach (var device in allDevices)
        {
            if (device is Gamepad) // Modify for different device types if needed
            {
                string uniqueId = GenerateUniqueDeviceId(device);
                deviceUniqueIds.Add(device, uniqueId);
                Debug.Log("Device Unique ID: " + uniqueId);
            }
        }
    }

    string GenerateUniqueDeviceId(InputDevice device)
    {
        // Example: Generate a unique ID based on device name and type
        string uniqueId = device.name + "_" + device.GetType().ToString();
        return uniqueId;
    }
}
