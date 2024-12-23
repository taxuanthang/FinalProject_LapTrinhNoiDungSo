using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class TouchingManagement : MonoBehaviour
{

    [SerializeField] GameObject AccessoriesTrigger;
    [SerializeField] GameObject SkinTrigger;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ClickedObject = getClickedObject(out RaycastHit hit);
            if (AccessoriesTrigger == ClickedObject)
            {
                AccessoriesTrigger.SetActive(false);
                print("accessories");
            }
            if (SkinTrigger == ClickedObject)
            {
                print("skin");
                OpenPickerManager.Instance.OpenColorPicker();
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            //print("Remove");
        }
    }


    GameObject getClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            if (!isPointerOverUIObject())
            {
                target = hit.collider.gameObject;
            }
        }
        return target;
    }
    private bool isPointerOverUIObject()
    {
        PointerEventData ped = new PointerEventData(EventSystem.current);
        ped.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        //print(ped);
        List<RaycastResult> results = new List<RaycastResult>();
        //print(results);
        EventSystem.current.RaycastAll(ped, results);
        //print(results);
        return results.Count > 0;
    }
}
