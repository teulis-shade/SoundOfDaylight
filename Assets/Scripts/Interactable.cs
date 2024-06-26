using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Rendering.Universal;


[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(AudioSource))]
public class Interactable : MonoBehaviour
{
    private bool hovering;
    private bool interacted;

    [SerializeField] private float waitTime = 0f;


    private SpriteRenderer sr;
    private Sprite normalSprite;
    [SerializeField] private List<Interactable> prereqs;
    [SerializeField] private AudioClip interactSound;
    [SerializeField] private bool repeatSound;
    protected Animator anim;
    private GameObject lighting;
    private CursorHolder cursor;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        normalSprite = sr.sprite;
        //lighting = transform.GetChild(0).gameObject;
        //lighting.SetActive(false);
        sr.sortingLayerName = "Interactable";
        cursor = FindObjectOfType<CursorHolder>();
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().loop = repeatSound;
        GetComponent<AudioSource>().clip = interactSound;

    }
    private void OnMouseExit()
    {
        hovering = false;
        //lighting.SetActive(false);
        Cursor.SetCursor(cursor.cursorNormal, Vector2.zero, CursorMode.Auto);
    }

    private void OnMouseEnter()
    {
        hovering = true;
        if (!interacted && CheckInteraction())
        {
            //lighting.SetActive(true);
            Cursor.SetCursor(cursor.cursorHighlight, Vector2.zero, CursorMode.Auto);
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
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

        GetComponent<AudioSource>().Play();

        if (waitTime != 0)
        {
            FindObjectOfType<TitleControl>().NextSceneOnDelay(waitTime);
        }
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
