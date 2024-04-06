using System.Collections;
using Unity.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARCameraManager))]
public class BibcamCameraConfigurator : MonoBehaviour
{
    IEnumerator Start()
    {
        // Wait for configurations to become available
        yield return new WaitForEndOfFrame();

        // Get available camera configurations
        var cameraManager = GetComponent<ARCameraManager>();
        using var configs = cameraManager.GetConfigurations(Allocator.Temp);

        // Switch to the first available 4k camera configuration
        var fourKResolution = new Vector2(3840, 2160);
        foreach (var c in configs)
        {
            if (c.resolution == fourKResolution)
            {
                Debug.Log($"Switching to 4k camera configuration:\n{c}");
                cameraManager.currentConfiguration = c;
                break;
            }
        }
    }
}