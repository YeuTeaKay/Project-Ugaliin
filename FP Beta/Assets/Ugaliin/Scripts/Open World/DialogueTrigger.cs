using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Dialogue Text")]
    [SerializeField] private TextAsset inkJSON;

    
    private bool playerInRange;

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (playerInRange && !VNManager.GetInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(true);

            if(InputManager.GetInstance().GetInteractPressed())
            {
                VNManager.GetInstance().EnterVNMode(inkJSON);
            }
        }
        else
        {
            visualCue.SetActive(false);
        }
    }

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
