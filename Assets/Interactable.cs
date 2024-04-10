using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


[RequireComponent(typeof(Animator))]
public class Interactable : MonoBehaviour
{
    private bool hovering;
    private bool interacted;
    [SerializeField] private List<Interactable> prereqs;
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnMouseExit()
    {
        hovering = false;
    }

    private void OnMouseEnter()
    {
        hovering = true;
    }

    private void OnMouseDown()
    {
        if (hovering && !interacted)
        {
            if (CheckInteraction())
            {
                Interact();
            }
            else
            {
                FailInteract();
            }
        }
    }

    private bool CheckInteraction()
    {
        foreach (Interactable act in prereqs)
        {
            if (!act.interacted)
            {
                return false;
            }
        }
        return true;
    }

    private void Interact()
    {
        interacted = true;

        anim.SetBool("interact", true);
    }

    private void FailInteract()
    {
        anim.SetBool("fail", true);
        anim.SetBool("fail", false);
    }
}
