using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCheck : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] GameObject canvas;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Cursor.visible = false;
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            Cursor.visible = true;
            canvas.SetActive(false);
        }
    }

}
