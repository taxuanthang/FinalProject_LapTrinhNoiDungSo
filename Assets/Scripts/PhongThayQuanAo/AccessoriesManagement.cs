using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TS.ColorPicker;

public class AccessoriesManagement : MonoBehaviour
{
    public List<GameObject> gameObjects; // List of 3D game objects
    public List<Sprite> previewSprites; // List of corresponding preview sprites
    public GameObject buttonPrefab; // Prefab for buttons
    public Transform gridParent; // Parent object with Grid Layout Group
    public Button nextPageButton; // Next page button
    public Button prevPageButton; // Previous page button
    public GameObject accessoriesTrigger;
    [SerializeField] private GameObject Accessories;
    [SerializeField] private LeanTweenType easeType;

    private int currentPage = 0;
    private const int itemsPerPage = 8; // 2x4 grid size
    private int totalPages;


    #region Singleton
    public static AccessoriesManagement AccessoriesManagementInstance;
    public static AccessoriesManagement Instance
    {   // Single Instance assurity
        get
        {
            if (AccessoriesManagementInstance == null)
            {
                AccessoriesManagementInstance = FindObjectOfType<AccessoriesManagement>();
                if (AccessoriesManagementInstance == null)
                {
                    GameObject obj = new GameObject();
                    AccessoriesManagementInstance = obj.AddComponent<AccessoriesManagement>();
                }
            }
            return AccessoriesManagementInstance;
        }
    }
    //void Awake()
    //{
    //    GameObject.DontDestroyOnLoad(gameObject);

    //}
    #endregion

    public void OpenAccessories()
    {
        accessoriesTrigger.SetActive(false);
        LeanTween.scale(Accessories, new Vector3(1f, 1f, 1f), 0.5f).setEase(easeType);
    }
    public void CloseAccessories()
    {
        accessoriesTrigger.SetActive(true);
        LeanTween.scale(Accessories, new Vector3(0, 0f, 0f), 0.5f).setEase(easeType);
    }

    void Start()
    {
        CloseAccessories();
        // Ensure the number of sprites matches the number of game objects
        if (previewSprites.Count != gameObjects.Count)
        {
            Debug.LogError("The number of preview sprites must match the number of game objects.");
            return;
        }

        totalPages = Mathf.CeilToInt((float)gameObjects.Count / itemsPerPage);

        nextPageButton.onClick.AddListener(NextPage);
        prevPageButton.onClick.AddListener(PreviousPage);

        UpdatePage();
    }

    void UpdatePage()
    {
        // Clear previous buttons
        foreach (Transform child in gridParent)
        {
            Destroy(child.gameObject);
        }

        // Determine range of items to display
        int startIndex = currentPage * itemsPerPage;
        int endIndex = Mathf.Min(startIndex + itemsPerPage, gameObjects.Count);

        for (int i = startIndex; i < endIndex; i++)
        {
            GameObject obj = gameObjects[i];
            Sprite previewSprite = previewSprites[i];

            GameObject button = Instantiate(buttonPrefab, gridParent);

            // Set button image
            Image buttonImage = button.GetComponent<Image>();
            if (previewSprite != null)
            {
                buttonImage.sprite = previewSprite;
            }

            // Set button onClick event
            Button btnComponent = button.GetComponent<Button>();
            btnComponent.onClick.AddListener(() => ActivateOnlyThisObject(obj));
        }

        // Update navigation buttons
        prevPageButton.interactable = currentPage > 0;
        nextPageButton.interactable = currentPage < totalPages - 1;
    }

    void ActivateOnlyThisObject(GameObject targetObject)
    {
        // Deactivate all objects
        foreach (GameObject obj in gameObjects)
        {
            obj.SetActive(false);
        }

        // Activate the selected object
        targetObject.SetActive(true);
        Debug.Log($"{targetObject.name} activated!");
    }

    void NextPage()
    {
        if (currentPage < totalPages - 1)
        {
            currentPage++;
            UpdatePage();
        }
    }

    void PreviousPage()
    {
        if (currentPage > 0)
        {
            currentPage--;
            UpdatePage();
        }
    }
}
