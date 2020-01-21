using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptedEncounter : MonoBehaviour
{
    bool hasHitGround;
    bool interactionComplete;
    float distanceToPlayer = 0f;
    float interactionDistance = 3f;
    public float speed = 3.0f;
    GameObject player;

    public CameraShake shaker;
    public Dialogue dialogue;

    // Start is called before the first frame update
    void Start()
    {
        hasHitGround = false;
        interactionComplete = false;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (hasHitGround && !interactionComplete)
        {
            if (distanceToPlayer > interactionDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
            else
            {
                if (distanceToPlayer <= interactionDistance)
                {
                    // trigger the dialogue
                    // when the dialogue is over add something to the player's inventory
                    // interactionComplete is true;
                    // if interaction is complete, move back until a suitable distance away from player, then dissolve
                }
            }
            
        }
        
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Ground")
        {
            ShakeCamera();
            StartCoroutine(DelayMoving(1f));
        }
    }

    IEnumerator DelayMoving(float delayTime) {
        float elapsed = 0.0f;
        while (elapsed < delayTime)
        {
            elapsed += Time.deltaTime;

            yield return null;
        }

        hasHitGround = true;
        yield return null;
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void ShakeCamera()
    {
        StartCoroutine(shaker.Shake(0.15f, 1.0f));
    }
}
