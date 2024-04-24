using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Animateable : MonoBehaviour
{
    [SerializeField] private List<Interactable> prereqs;
    [SerializeField] private string triggerName;
    private Dictionary<Interactable, bool> done;
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
        done = new Dictionary<Interactable, bool>();
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
                anim.SetTrigger(triggerName);
            }
        }
    }
}
