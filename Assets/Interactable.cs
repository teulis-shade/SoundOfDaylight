using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Interactable : MonoBehaviour
{
    private bool hovering;
    private bool interacted;
    private SpriteRenderer sr;
    private Sprite normalSprite;
    [SerializeField] private Sprite hoverSprite;
    [SerializeField] private List<Interactable> prereqs;
    protected Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        normalSprite = sr.sprite;
    }
    private void OnMouseExit()
    {
        hovering = false;
        sr.sprite = normalSprite;
    }

    private void OnMouseEnter()
    {
        hovering = true;
        if (!interacted)
        {
            sr.sprite = hoverSprite;
        }
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

    protected virtual void Interact()
    {
        interacted = true;

        anim.SetBool("interact", true);

        sr.sprite = normalSprite;
    }

    protected void FailInteract()
    {
        anim.SetBool("fail", true);
        anim.SetBool("fail", false);
    }

    public bool Check()
    {
        return interacted;
    }
}
