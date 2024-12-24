using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyframeLabubu : MonoBehaviour
{
    public static KeyframeLabubu Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    [SerializeField] public GameObject LeftArm;
    [SerializeField] public GameObject RightArm;
    [SerializeField] public GameObject Head;
    [SerializeField] public GameObject LeftLeg;
    [SerializeField] public GameObject RightLeg;

    public Vector3 LeftArmPos { get; set; }
    public Vector3 RightArmPos { get; set; }
    public Vector3 HeadPos { get; set; }
    public Vector3 LeftLegPos { get; set; }
    public Vector3 RightLegPos { get; set; }
    public float AnimationTime { get; set; }

/*    public KeyframeLabubu(Vector3 leftArmPos, Vector3 rightArmPos, Vector3 headPos, Vector3 leftLegPos, Vector3 rightLegPos)
    {
        LeftArmPos = leftArmPos;
        RightArmPos = rightArmPos;
        HeadPos = headPos;
        LeftLegPos = leftLegPos;
        RightLegPos = rightLegPos;
    }*/
    public void Snapshot()
    {
        if (LeftArm != null)
            LeftArmPos = LeftArm.transform.position;

        if (RightArm != null)
            RightArmPos = RightArm.transform.position;

        if (Head != null)
            HeadPos = Head.transform.position;

        if (LeftLeg != null)
            LeftLegPos = LeftLeg.transform.position;

        if (RightLeg != null)
            RightLegPos = RightLeg.transform.position;

        Debug.Log("Snapshot captured for all objects.");
        Debug.Log(LeftArmPos);
        Debug.Log(RightArmPos);
        Debug.Log(HeadPos);

    }


}
