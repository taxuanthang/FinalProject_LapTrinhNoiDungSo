using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPickerManager : MonoBehaviour
{
    #region Singleton
    public static OpenPickerManager OpenPickerManagerInstance;
    public static OpenPickerManager Instance
    {   // Single Instance assurity
        get
        {
            if (OpenPickerManagerInstance == null)
            {
                OpenPickerManagerInstance = FindObjectOfType<OpenPickerManager>();
                if (OpenPickerManagerInstance == null)
                {
                    GameObject obj = new GameObject();
                    OpenPickerManagerInstance = obj.AddComponent<OpenPickerManager>();
                }
            }
            return OpenPickerManagerInstance;
        }
    }
    void Awake()
    {
        GameObject.DontDestroyOnLoad(gameObject);

    }
    #endregion

    [SerializeField] private GameObject colorPicker;
    [SerializeField] private LeanTweenType easeType;
    [SerializeField] private GameObject skinTrigger;

    public void OpenColorPicker()
    {
        skinTrigger.SetActive(false);
        LeanTween.scale(colorPicker, new Vector3(1f,1f,1f), 0.5f).setEase(easeType);
    }
    public void CloseColorPicker()  
    {
        skinTrigger.SetActive(true);
        LeanTween.scale(colorPicker, new Vector3(0,0f,0f), 0.5f).setEase(easeType);
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
