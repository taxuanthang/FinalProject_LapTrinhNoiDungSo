using UnityEngine;

public class ShowerController : MonoBehaviour
{
    public GameObject puppet;  // Reference to the puppet
    public Transform tubPosition; // Position in the tub
    public ParticleSystem waterEffect; // Water effect (shower)

    // Method called when the button is clicked
    public void TakeShower()
    {
        if (puppet != null && tubPosition != null)
        {
            // Move the puppet to the tub
            puppet.transform.position = tubPosition.position;
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
    }
    public void WaterStop()
    {
        if (waterEffect != null)
        {
            waterEffect.Stop();
        }
    }
}
