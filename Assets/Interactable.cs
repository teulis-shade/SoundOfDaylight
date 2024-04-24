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
    [SerializeField] private Texture2D hoverCursorTexture;
    [SerializeField] private Sprite hoverSprite;

    [SerializeField] private List<Interactable> prereqs;
    Animator anim;

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

        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    private void OnMouseEnter()
    {
        hovering = true;
        
        if (!interacted && CheckInteraction())
        {
            sr.sprite = hoverSprite;
            Cursor.SetCursor(hoverCursorTexture, Vector2.zero, CursorMode.Auto); // Set custom cursor
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

    private void Interact()
    {
        interacted = true;

        anim.SetBool("interact", true);

        sr.sprite = normalSprite;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    private void FailInteract()
    {
        anim.SetBool("fail", true);
        anim.SetBool("fail", false);
    }

    public bool Check()
    {
        return interacted;
    }
}
