using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPickerManager : MonoBehaviour
{
    [SerializeField] private GameObject colorPicker;
    [SerializeField] private LeanTweenType easeType;

    public void OpenColorPicker()
    {
        LeanTween.scale(colorPicker, new Vector3(3f,3f,3f), 0.5f).setEase(easeType);
    }
    public void CloseColorPicker()  
    {
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
