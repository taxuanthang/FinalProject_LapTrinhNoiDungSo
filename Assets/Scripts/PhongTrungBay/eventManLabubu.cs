using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventManLabubu : MonoBehaviour
{
   
    public void addKeyframeButtonClicked()
    {
        KeyframeLabubu.Instance.Snapshot();
        AnimationManager.Instance.AppendKeyframe(KeyframeLabubu.Instance);
    }
    public void startPlayBackClicked()
    {
        if (AnimationManager.Instance.isPlaying)
        {
            AnimationManager.Instance.StopPlayback();
        }
        else
        {
            AnimationManager.Instance.StartPlayback();
        }
    }
}
