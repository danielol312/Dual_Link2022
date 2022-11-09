using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
  public enum ItemType
    {
        Heart,
        Diamons,
        Star,
    }

    public ItemType itemtype;
    public int amount;
    public string player;
    internal static string Value;
}
