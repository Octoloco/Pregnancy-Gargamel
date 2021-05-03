using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShakeGame : MonoBehaviour
{
    public float shakeThreshold;
    public float minShakeInterval;
    private bool shaking;
    private bool shaked;

    private float sqrShakeThreshold;
    private float timeSinceLastShake;

    public Animator shakeAnim;

    public AudioClip[] audios;
    public AudioSource audioSource;
    private int audioIndex;

    public Image secondText; 

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("TransitionCanvas").GetComponentInChildren<Animator>().SetBool("cover", false);
        audioIndex = 0;
        sqrShakeThreshold = Mathf.Pow(shakeThreshold, 2);   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.acceleration.sqrMagnitude >= sqrShakeThreshold && Time.unscaledTime >= timeSinceLastShake + minShakeInterval)
        {
            secondText.enabled = true;
            shaking = true;
            timeSinceLastShake = Time.unscaledTime;
        }
        else if (Input.acceleration.sqrMagnitude < sqrShakeThreshold && Time.unscaledTime < timeSinceLastShake + minShakeInterval)
        {
            shaked = false;
        }
        else
        {
            shaking = false;
        }

        if (shaking)
        {
            shakeAnim.SetBool("shaking", true);

            if (!audioSource.isPlaying && !shaked)
            {
                audioIndex++;
                if (audioIndex > audios.Length - 1)
                {
                    audioIndex = 0;
                }
                audioSource.clip = audios[audioIndex];
                audioSource.Play();
            }
            shaked = true;
        }
        else
        {
            shakeAnim.SetBool("shaking", false);
        }

    }
}
