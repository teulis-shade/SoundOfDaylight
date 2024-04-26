using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCheck : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject block;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Cursor.visible = false;
        block.SetActive(true);
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            Cursor.visible = true;
            block.SetActive(false);
            canvas.SetActive(false);
        }
    }

}
