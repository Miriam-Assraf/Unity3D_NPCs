using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Object : ScriptableObject
{
    public Type type;
    public int time;
    public int increasePerSec;
    public string name;
    public string op;
    public string animation;
    public int y_rotation;
    public int hight_offset;
    public GameObject item;

    public void initializeObject(string op, Type type, int time, int increasePerSec, string name, string animation, int y_rotation, int hight_offset)
    {
        this.op = op;
        this.type = type;
        this.time = time;
        this.increasePerSec = increasePerSec;
        this.name = name;
        this.animation = animation;
        this.y_rotation = y_rotation;
        this.hight_offset = hight_offset;
        this.item = GameObject.Find(name);

    }
    public void String()
    {
        Debug.Log("Object: " + this.type + "Name:" + name);

    }
}
