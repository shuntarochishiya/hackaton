using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Inventory
{
    private static Inventory instance;
    private Inventory()
    { }
 
    public static Inventory getInstance()
    {
        instance ??= new Inventory();
        
        return instance;
    }

    public List<KeyColor> keys = new();
    public bool hasRevolver = false;
}
