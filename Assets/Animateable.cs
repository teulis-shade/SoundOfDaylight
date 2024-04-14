using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Animateable : MonoBehaviour
{
    [SerializeField] private List<Interactable> prereqs;
    private Dictionary<Interactable, bool> done;
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
        foreach (Interactable i in prereqs)
        {
            done.Add(i, false);
        }
    }

    private void Update()
    {
        foreach (Interactable i in done.Keys)
        {
            if (!done[i] && i.Check())
            {
                anim.SetTrigger("animate");
            }
        }
    }
}
