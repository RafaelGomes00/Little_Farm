using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{

    public float value { get; private set; }
    public bool canEquip { get; private set; }
    public Sprite sprite { get; private set; }
    public string name { get; private set; }

    public Item(float value, bool canEquip, Sprite sprite, string name)
    {
        this.value = value;
        this.canEquip = canEquip;
        this.sprite = sprite;
        this.name = name;
    }
}
