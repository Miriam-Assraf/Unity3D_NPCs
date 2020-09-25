using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;
public enum Type
{
    Energy,
    Hunger,
    Hygiene,
    Social,
    Fun
}


public class Need : ScriptableObject
{

    public Type type;
    public int stat = 0;
    public int decreasebl;
    private const int _top = 100;
    private const int _buttom = 0;
    private const int _tier1 = 20;
    private const int _tier2 = 40;
    private const int _tier3 = 60;
    private const int _tier4 = 80;
    private const int _tier1_add = 80;
    private const int _tier2_add = 40;
    private const int _tier3_add = 20;
    private const int _tier4_add = 10;
    private const float _dist_weight1 = 0.001f;
    private const float _dist_weight2 = 0.005f;
    private const float _dist_weight3 = 0.01f;
    private const float _dist_weight4 = 0.05f;

    public void SetNeed(int new_stat)
    {
        if (new_stat <= _top & new_stat >= _buttom)
        {
            this.stat = new_stat;
        }
        else if (new_stat <= _buttom)
        {
            this.stat = _buttom;
        }
        else if (new_stat > _top)
        {
            this.stat = _top;
        }
    }

    public void increase(int amount)
    {
        if (this.stat + amount < _top)
        {
            this.stat += amount;
        }
        else
        {
            this.stat = _top;
        }

    }
    // decrese the need by 1-2.
    public void decrease()
    {
        if (this.stat > _buttom)
        {
            this.stat -= decreasebl;
        }
    }
    // this function is used for adding more Weight to important Need's
/*    public void weightEditer()
    {
       // Debug.Log("current in weight editer " + this.stat);
        if (this.stat <= _tier1)
        {
            this.stat = this.stat + _tier1_add;
        }
        else if (this.stat <= _tier2)
        {
            this.stat = this.stat + _tier2_add;

        }
        else if (this.stat <= _tier3)
        {
            this.stat = this.stat + _tier3_add;

        }
        else if (this.stat <= _tier4)
        {
            this.stat = this.stat + _tier4_add;
        }
    }*/

    public float getWeight(float distance)
    {
        float weight;
        //UnityEngine.Debug.Log("distance " + distance);
        //UnityEngine.Debug.Log("for " + this.stat);
        // Debug.Log("current in weight editer " + this.stat);
        if (this.stat <= _tier1)
        {
            weight = _tier1_add - _dist_weight1 * distance;
            //UnityEngine.Debug.Log("weight1 " + weight);
        }
        else if (this.stat <= _tier2)
        {
            weight = _tier2_add - _dist_weight2 * distance;
            //UnityEngine.Debug.Log("weight2 " + weight);

        }
        else if (this.stat <= _tier3)
        {
            weight = _tier3_add - _dist_weight3 * distance;
           // UnityEngine.Debug.Log("weight3 " + weight);

        }
        else if (this.stat <= _tier4)
        {
            weight = _tier4_add - _dist_weight4 * distance;
           // UnityEngine.Debug.Log("weight4 " + weight);
        }
        else
        {
            weight = - distance;
        }
        
        return weight;
    }

    public void String()
    {
        Debug.Log("activity: " + this.type + " stat:" + stat);

    }
}
