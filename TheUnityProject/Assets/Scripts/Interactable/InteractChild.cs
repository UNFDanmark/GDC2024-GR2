using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractChild : MonoBehaviour
{
    private bool isInside = false;

    
    private float interactCooldownLeft = 0;

    private Interactable parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject.GetComponent<Interactable>();
        parent.InteractableInit();
    }

    // Update is called once per frame
    void Update()
    {
        interactCooldownLeft -= Time.deltaTime;
        if (isInside)
        {
            if (Input.GetAxis("Interact") == 1 && interactCooldownLeft <= 0)
            {
                interactCooldownLeft = parent.interactCooldown;
                parent.OnInteract();
            }
        }
        parent.InteractableUpdate();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInside = true;
            parent.InteractableStart();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInside = false;
            parent.InteractableEnd();
        }
    }
}
