using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : CharacterController2D
{

    private Dictionary<Item, string> miInventario;
    public Inventario()
    {
        miInventario= new Dictionary<Item, string>();
    }


    public void addItem(Item item)
    {
        //if ()
        //{
        //    miInventario.TryAdd(item, "blue");
        //}
        //else ()
        //{
        //    miInventario.TryAdd(item, "red");
        //}

    }





    //void Start()
    //{
    //    miInventario.Add("Heart", 1);
    //    miInventario.Add("Diamond", 1);
    //    miInventario.Add("Star", 1);

    //    miInventario.Add("Blue Heart", 2);
    //    miInventario.Add("Blue Diamond", 2);
    //    miInventario.Add("Blue Star", 2);

    //    foreach (var item in miInventario)
    //    {
    //       // inventoryDisplay.text=item.ToString();
    //    }
    //}

   
}
