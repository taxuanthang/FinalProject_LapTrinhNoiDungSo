using UnityEngine;

public class ShowerController : MonoBehaviour
{
    public GameObject puppet; // Reference to the puppet (Labubu)
    public Transform tubPosition; // Position in the tub
    public ParticleSystem waterEffect; // Water effect (shower)
    public GameObject pedestal; // Reference to pedestal
    public Camera mainCamera; // The default main camera
    public Camera showerCamera; // The new camera for the shower scene
    public ChuckSubInstance chuckInstance; // Reference to Chunity's ChuckSubInstance

    // Method called when the button is clicked
    public void TakeShower()
    {
        if (puppet != null && tubPosition != null)
        {
            // Move the puppet to the tub
            puppet.transform.position = tubPosition.position;

            // Enable the shower camera and disable the main camera
            if (showerCamera != null && mainCamera != null)
            {
                mainCamera.enabled = false; // Disable the main camera
                showerCamera.enabled = true; // Enable the shower camera
            }
            else
            {
                Debug.LogWarning("Cameras are not assigned in the ShowerController!");
            }
        }
        else
        {
            Debug.LogWarning("References are missing in the ShowerController!");
        }
    }

    public void WaterStart()
    {
        // Enable the water effect
        if (waterEffect != null)
        {
            waterEffect.Play(); // Play the particle effect
        }

        // Play the water sound using ChucK
        if (chuckInstance != null)
        {
            Debug.Log("Running water sound...");
            chuckInstance.RunCode(@"
                // Load and play a .wav file
                SndBuf sound => dac;
                ""water_drip.wav"" => sound.read; // Load the water drip sound
                1.0 => sound.gain;

                // Play the sound in a loop
                while (true)
                {
                    0 => sound.pos; // Reset sound to the beginning
                    sound.play();
                    sound.duration()::ms => now; // Wait for the duration of the sound
                }
            ");
        }
        else
        {
            Debug.LogWarning("ChuckSubInstance is not assigned in ShowerController!");
        }
    }

    public void WaterStop()
    {
        if (waterEffect != null)
        {
            waterEffect.Stop(); // Stop the water particle effect
        }

        // Stop the water sound (optional implementation for stopping ChucK)
        if (chuckInstance != null)
        {
            chuckInstance.BroadcastEvent("stopWaterSound");
        }
    }

    public void BackToPosition()
    {
        if (puppet != null)
        {
            // Assign a new Vector3 to position
            puppet.transform.position = new Vector3(-1.62f, -0.4f, 5.65f);

            // Switch back to the main camera
            if (mainCamera != null && showerCamera != null)
            {
                showerCamera.enabled = false; // Disable the shower camera
                mainCamera.enabled = true; // Enable the main camera
            }
        }
        else
        {
            Debug.LogWarning("Puppet reference is missing in the ShowerController!");
        }
    }
}
