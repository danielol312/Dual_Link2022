using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueQueueHabilities : MonoBehaviour
{
    GameObject ItemSlow;
    ItemScore itemScore;
    ItemVelocity itemVelocity;
    [SerializeField] int scoreUp;

    public PlayerMovement playerMovement;
    public Score score;

    Queue<int> abilities = new Queue<int>();

   // int itemType = 0; // 1= velocidad 2= slow 3= score 


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(abilities.Count);
        /*if(ItemSlow == null || ItemSlow.GetComponent<itemSlow> == null)
        {
            ItemSlow = GameObject.FindGameObjectWithTag("itemSlow");

           // itemSlowScript = ItemSlow.GetComponent<itemSlow>;
        }*/

           if (Input.GetKeyUp(KeyCode.RightControl))
           {
               Debug.Log("q");
               if (abilities.Peek() == 1)
               {
                   Velocity();
                   abilities.Dequeue();

               }
               if (abilities.Peek() == 2)
               {
                   Slow();
                   abilities.Dequeue();
               }
               if (abilities.Peek() == 3)
               {
                   ScoreUp();
                   abilities.Dequeue();
                  // Debug.Log("Scoree!");
               }
           }

/*
           if (abilities.Count < 3)
           {
               if (itemVelocity.getVelocity == true)
               {
                   abilities.Enqueue(itemType);
                   Debug.Log("getvelocity");
               }
               else if (ItemSlow.GetComponent(typeof(bool)).getSlow == true )
               {
                   abilities.Enqueue(2);
                   Debug.Log("getslow");
               }
               else if (itemScore.getScore == true)
               {
                   abilities.Enqueue(3);
                   Debug.Log("getscore");
               }
           }
           */





    }
    
    public void EnqueueAbilitie(int itemType)
    {
        if (abilities.Count < 3)
        {
            abilities.Enqueue(itemType);
        }
    }


    void Velocity()
    {
        playerMovement.movementSpeed = playerMovement.movementSpeed * 4;
        Debug.Log("Speeed!!");
    }
    void Slow()
    {
        playerMovement.movementSpeed = playerMovement.movementSpeed / 4;
        Debug.Log("Slooow");
    }
    void ScoreUp()
    {
        score.score += scoreUp;
        Debug.Log(scoreUp + " More  Points !!!");
    }
}
