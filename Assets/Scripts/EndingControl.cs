using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingControl : MonoBehaviour
{
    Image image;
    [SerializeField] List<Sprite> frames;
    int currFrame;

    private void Start()
    {
        image = GetComponent<Image>();
        currFrame = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currFrame++;
            if (frames.Count == currFrame)
            {
                SceneManager.LoadScene(0);
            }

            image.sprite = frames[currFrame];
        }
    }
}
