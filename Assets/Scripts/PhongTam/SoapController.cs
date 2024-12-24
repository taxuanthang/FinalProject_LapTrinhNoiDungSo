using UnityEngine;

public class SoapBarController : MonoBehaviour
{
    public GameObject labubu; // Reference to Labubu
    public ParticleSystem soapEffect; // Soap bubbles particle effect
    public Material soapyMaterial; // Soapy material for Labubu
    public Material originalMaterial; // Original material of Labubu
    public ParticleSystem waterEffect; // Water particle system

    private bool isSoapy = false; // Whether Labubu has soap on it
    private bool isDragging = false; // Whether the soap bar is being dragged

    void Update()
    {
        // Check if the soap is being dragged
        if (isDragging)
        {
            // Detect if the soap is over Labubu using a Raycast
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Raycast hit: " + hit.collider.gameObject.name);

                if (hit.collider.gameObject == labubu)
                {
                    // Apply soap to Labubu
                    ApplySoap();
                }
            }
        }

        // Check if water is active to remove soap
        if (isSoapy && waterEffect != null && waterEffect.isPlaying)
        {
            Debug.Log("Water is active. Removing soap.");
            RemoveSoap();
        }
    }

    void OnMouseDrag()
    {
        // Set isDragging to true
        isDragging = true;
        Debug.Log("Dragging soap...");

        // Move the soap bar to follow the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            transform.position = hit.point;
           
        }
    }

    void OnMouseUp()
    {
        // Stop dragging the soap
        isDragging = false;
  
    }

    void ApplySoap()
    {
        if (!isSoapy)
        {
            isSoapy = true;
          

            // Change Labubu's material to soapy material
            Renderer labubuRenderer = labubu.GetComponent<Renderer>();
            if (labubuRenderer != null)
            {
                labubuRenderer.material = soapyMaterial;
                Debug.Log("Labubu material changed to soapy.");
            }
            else
            {
                
            }

            // Enable soap particle effect
            if (soapEffect != null)
            {
                soapEffect.Play();
                Debug.Log("Soap effect started.");
            }
            else
            {
                
            }
        }
    }


    void RemoveSoap()
    {
        isSoapy = false;

        // Restore Labubu's original material
        Renderer labubuRenderer = labubu.GetComponent<Renderer>();
        if (labubuRenderer != null)
        {
            labubuRenderer.material = originalMaterial;
            
        }
        else
        {
            
        }

        // Stop soap particle effect
        if (soapEffect != null)
        {
            soapEffect.Stop();
            Debug.Log("Soap effect stopped.");
        }
    }
}
