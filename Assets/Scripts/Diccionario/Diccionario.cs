using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diccionario : PlayerMovement
{
  Dictionary<string,int> myInventory=new Dictionary<string,int>();

    public Text inventoryDisplay;
    void Start()
    {
        DisplayInventory();
    }
    public void DisplayInventory()
    {
        inventoryDisplay.text = "";
        foreach (var item in myInventory)
        {
            inventoryDisplay.text += "Item: " + item.Key + "Character: " + item.Value;
        }
    }
    public void addStar()
    {
        if(myInventory.ContainsKey("Star"))
        {
            myInventory["Star"]++;
        }
        else
        {
            myInventory.Add("Star", 1);
        }
        DisplayInventory();
    }
    public void addHeart()
    {
        if (myInventory.ContainsKey("Heart"))
        {
            myInventory["Heart"]++;
        }
        else
        {
            myInventory.Add("Heart", 1);
        }
        DisplayInventory();
    }
    public void addDiamond()
    {
        if (myInventory.ContainsKey("Diamond"))
        {
            myInventory["Diamond"]++;
        }
        else
        {
            myInventory.Add("Diamond", 1);
        }
        DisplayInventory();
    }
}
