using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PopUp : Interactable
{
    GameObject bigThing;

    private void Start()
    {
        bigThing.SetActive(false);
    }
    protected override void Interact()
    {
        anim.SetBool("interacted", true);
        bigThing.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (bigThing.activeSelf)
            {
                bigThing.SetActive(false);
            }
        }
    }
}
