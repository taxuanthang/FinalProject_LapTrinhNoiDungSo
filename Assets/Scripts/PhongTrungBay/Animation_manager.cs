using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] public GameObject LeftArm;
    [SerializeField] public GameObject RightArm;
    [SerializeField] public GameObject Head;
    [SerializeField] public GameObject LeftLeg;
    [SerializeField] public GameObject RightLeg;
    public static AnimationManager Instance { get; private set; }
    private List<KeyframeLabubu> keyframeBuffer = new List<KeyframeLabubu>();
    public bool isPlaying = false;
    private float keyframeSpeed = 500f; // Adjust speed as needed for smoother animation
    private Coroutine playbackCoroutine;

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

    public void startPlayBackClicked()
    {
        if (isPlaying)
        {
            StopPlayback();
        }
        else
        {
            StartPlayback();
        }
    }

    public void AppendKeyframe(KeyframeLabubu keyframe)
    {
        keyframeBuffer.Add(keyframe);
        print(keyframe.LeftArmPos);
        for (int i = 0; i < keyframeBuffer.Count; i++)
        {
            print(keyframeBuffer[i].LeftArmPos);
        }
        Debug.Log("Added Keyframe");
    }

    public void StartPlayback()
    {
        ////print(keyframeBuffer.Count);
        //for (int i =0;i< keyframeBuffer.Count; i++)
        //{
        //    print(keyframeBuffer[i].LeftArmPos);
        //}
        if (keyframeBuffer.Count == 0)
        {
            Debug.LogWarning("No keyframes to play");
            return;
        }

        if (playbackCoroutine != null) // Stop any ongoing playback
        {
            StopCoroutine(playbackCoroutine);
        }

        isPlaying = true;
        
        playbackCoroutine = StartCoroutine(AnimateObjectsCoroutine());
        
        
        Debug.Log("Playback Started");
    }

    public void StopPlayback()
    {
        isPlaying = false;

        if (playbackCoroutine != null)
        {
            StopCoroutine(playbackCoroutine);
        }

        Debug.Log("Playback Stopped");
    }

    private IEnumerator AnimateObjectsCoroutine()
    {
    while (isPlaying)
    {
        for (int i = 0; i < keyframeBuffer.Count - 1; i++)
        {
            KeyframeLabubu start = keyframeBuffer[i];
            KeyframeLabubu end = keyframeBuffer[i + 1];

            Debug.Log($"Animating keyframe {i} from {start.LeftArmPos} to {end.LeftArmPos}");

            float elapsedTime = 0f;
            float duration = Vector3.Distance(start.LeftArmPos, end.LeftArmPos) / keyframeSpeed;

            if (duration <= 0f) duration = 0.1f; // Avoid zero-duration animations

            while (elapsedTime < duration)
            {
                float t = elapsedTime / duration; // Normalized time
                LeftArm.transform.position = Vector3.Lerp(start.LeftArmPos, end.LeftArmPos, t);
                RightArm.transform.position = Vector3.Lerp(start.RightArmPos, end.RightArmPos, t);
                Head.transform.position = Vector3.Lerp(start.HeadPos, end.HeadPos, t);
                LeftLeg.transform.position = Vector3.Lerp(start.LeftLegPos, end.LeftLegPos, t);
                RightLeg.transform.position = Vector3.Lerp(start.RightLegPos, end.RightLegPos, t);

                elapsedTime += Time.deltaTime;
                Debug.Log($"Elapsed Time: {elapsedTime}, Normalized Time: {t}");
                    yield return new WaitForSeconds(0.1f);
            }

            // Ensure the final position matches the end keyframe
            LeftArm.transform.position = end.LeftArmPos;
            RightArm.transform.position = end.RightArmPos;
            Head.transform.position = end.HeadPos;
            LeftLeg.transform.position = end.LeftLegPos;
            RightLeg.transform.position = end.RightLegPos;
        }

        //isPlaying = false;
        //Debug.Log("Playback Completed");
    }
    }

}
