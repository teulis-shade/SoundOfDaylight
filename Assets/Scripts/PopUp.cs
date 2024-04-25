using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PopUp : Interactable
{
    [SerializeField] GameObject bigThing;
    bool justTurned;

    private void Start()
    {
        bigThing.GetComponent<SpriteRenderer>().sortingLayerName = "Popup";
        bigThing.SetActive(false);
    }
    protected override void Interact()
    {
        bigThing.SetActive(true);
        anim.SetBool("interacted", true);
        GetComponent<Collider2D>().enabled = false;
        StartCoroutine(cooldown(.5f));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !justTurned)
        {
            if (bigThing.activeSelf)
            {
                bigThing.SetActive(false);
                GetComponent<Collider2D>().enabled = true;
            }
        }
    }

    IEnumerator cooldown(float time)
    {
        justTurned = true;
        yield return new WaitForSeconds(time);
        justTurned = false;
    }
}
