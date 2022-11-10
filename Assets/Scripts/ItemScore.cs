using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScore : MonoBehaviour
{
    public GameObject objectToFind;
    public RedQueueHabilities redQueueHabilities;
    public BlueQueueHabilities blueQueueHabilities;
    string tagName = "QueueManager";
    public int itemType = 3;
    // Start is called before the first frame update
    void Start()
    {
        objectToFind = GameObject.FindGameObjectWithTag(tagName);
        redQueueHabilities = objectToFind.GetComponent<RedQueueHabilities>();
        blueQueueHabilities = objectToFind.GetComponent<BlueQueueHabilities>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "RedPlayer")
        {
            redQueueHabilities.GetComponent<RedQueueHabilities>().EnqueueAbilitie(itemType);
            gameObject.SetActive(false);
        }
        if (collision.tag == "BluePlayer")
        {
            blueQueueHabilities.GetComponent<BlueQueueHabilities>().EnqueueAbilitie(itemType);
            gameObject.SetActive(false);
        }

    }
}
