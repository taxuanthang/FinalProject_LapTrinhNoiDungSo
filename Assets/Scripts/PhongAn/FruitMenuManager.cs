using UnityEngine;

public class FruitMenuManager : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject bananaPrefab;
    public GameObject orangePrefab;

    public Transform handPosition; // Vị trí tay cầm hoa quả

    private GameObject currentFruit; // Hoa quả hiện tại nhân vật đang cầm

    public void SelectApple()
    {
        EquipFruit(applePrefab);
        Debug.Log("Apple selected!");
    }

    public void SelectBanana()
    {
        EquipFruit(bananaPrefab);
        Debug.Log("Banana selected!");
    }

    public void SelectOrange()
    {
        EquipFruit(orangePrefab);
        Debug.Log("Orange selected!");
    }

    public void EquipFruit(GameObject fruitPrefab)
    {
        if (fruitPrefab == null)
        {
            Debug.LogWarning("Fruit prefab is null! Cannot equip.");
            return;
        }
    
        // Xóa hoa quả cũ nếu có
        if (currentFruit != null)
        {
            Debug.Log("Destroying current fruit: " + currentFruit.name);
            Destroy(currentFruit);
        }
    
        // Kiểm tra handPosition
        if (handPosition == null)
        {
            Debug.LogError("HandPosition is not assigned in the Inspector!");
            return;
        }
    
        // Tạo hoa quả mới và gắn vào tay
        currentFruit = Instantiate(fruitPrefab, handPosition.position, handPosition.rotation);
        if (currentFruit == null)
        {
            Debug.LogError("Failed to instantiate fruit!");
            return;
        }
    
        Debug.Log("Equipped fruit: " + fruitPrefab.name);
    
        currentFruit.transform.SetParent(handPosition);
    }
}
