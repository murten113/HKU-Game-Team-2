using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Required for UI elements

public class LoopingSoundController : MonoBehaviour
{
    public List<GameObject> targetUIElements;  // List of UI elements to check
    public AudioClip soundClip;                // Sound clip to play on loop
    public float soundVolume = 1f;             // Volume for the looping sound

    private AudioSource audioSource;           // AudioSource component to play the sound

    void Start()
    {
        // Initialize AudioSource component
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = soundClip;
        audioSource.loop = true;
        audioSource.volume = soundVolume;
    }

    void Update()
    {
        // Check if any of the target UI elements exist and are active
        bool anyElementActive = false;
        foreach (GameObject uiElement in targetUIElements)
        {
            if (uiElement != null && uiElement.activeInHierarchy)
            {
                anyElementActive = true;
                break; // Exit the loop as soon as we find an active element
            }
        }

        // Play or stop the sound based on whether any element is active
        if (anyElementActive)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
