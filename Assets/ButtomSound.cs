using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtomSound : MonoBehaviour
{
    public AudioClip soundClip;
    private Button button;
    private AudioSource audioSource;

    private void Start()
    {
        button = GetComponent<Button>();
        audioSource = FindObjectOfType<AudioSource>();
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        if (soundClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(soundClip);
        }
    }
}
