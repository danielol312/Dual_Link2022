using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{

    private Dictionary<string, int> miInventario=new Dictionary<string, int>();
    public Text inventoryDisplay;

    // Start is called before the first frame update
    void Start()
    {
        
        miInventario.Add("Heart", 1);
        miInventario.Add("Diamond", 1);
        miInventario.Add("Star", 1);

        miInventario.Add("Blue Heart", 2);
        miInventario.Add("Blue Diamond", 2);
        miInventario.Add("Blue Star", 2);

        foreach (var item in miInventario)
        {
            inventoryDisplay.text=item.ToString();
        }
    }

   
}
