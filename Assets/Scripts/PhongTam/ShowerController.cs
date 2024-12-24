using UnityEngine;

public class ShowerController : MonoBehaviour
{
    public GameObject puppet; // Reference to the puppet (Labubu)
    public Transform tubPosition; // Position in the tub
    public ParticleSystem waterEffect; // Water effect (shower)
    public GameObject pedestal; // Reference to pedestal
    public Camera mainCamera; // The default main camera
    public Camera showerCamera; // The new camera for the shower scene
    public AudioSource waterSound; // Reference to the AudioSource for water sound

    private Vector3 customPosition = new Vector3(-0.08f, -0.57f, -1.79f); // Custom position for the puppet

    // Method called when the button is clicked
    public void TakeShower()
    {
        if (puppet != null && tubPosition != null)
        {
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
        else
        {
            Debug.LogWarning("Water effect is not assigned in the ShowerController!");
        }

        // Play the water sound
        if (waterSound != null)
        {
            waterSound.Play(); // Play the water sound
        }
        else
        {
            Debug.LogWarning("Water sound is not assigned in the ShowerController!");
        }
    }

    public void WaterStop()
    {
        if (waterEffect != null)
        {
            waterEffect.Stop(); // Stop the water particle effect
        }
        else
        {
            Debug.LogWarning("Water effect is not assigned in the ShowerController!");
        }

        // Stop the water sound
        if (waterSound != null)
        {
            waterSound.Stop();
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
            else
            {
                Debug.LogWarning("Cameras are not assigned in the ShowerController!");
            }
        }
        else
        {
            Debug.LogWarning("Puppet reference is missing in the ShowerController!");
        }
    }
}
