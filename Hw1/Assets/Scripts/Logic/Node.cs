using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Node : ScriptableObject
{
    public Vector3 parentPosition;
    public float average;
    public List<Need> needlist;
    private int count;

    public void initializeNode(List<Need> list)
    {
        this.needlist = list;
        this.average = 0;
        //this.average = Average();

    }

    public void Average(float weight)
    {
        count = 0;

        foreach (Need n in needlist)
        {
            //Debug.Log("for " + n.type +" we got " + n.stat);
            count++;
            average += n.stat;
        }
        //Debug.Log(average);
        //Debug.Log("");
        average = average / count;
        //Debug.Log("avg before distance " + average);
        average += weight;
        //Debug.Log("avg after distance " + average);
    }

    public void UpdateNode(Object o)    // per sec
    {
        if (o != null)
        {
            //Debug.Log("obj " + o.name);
            foreach (Need n in needlist)
            {
                if (n.type != o.type)
                {
                    n.decrease();
                }
                else
                {
                    n.increase(o.increasePerSec);
                }
            }
        }

        else
        {
            foreach (Need n in needlist)
            {
                n.decrease();
            }
        }
    }

    public void String()
    {
        foreach (Need n in needlist)
        {
            n.String();
        }
    }

    public void CalculateNewStat(Object o)
    {
        foreach (Need n in needlist)
        {
            if (n.type == o.type)
            {
               // UnityEngine.Debug.Log("before " + n.stat);

                //Debug.Log("before "+n.stat);
                //n.weightEditer();   // update current need weight
                //Debug.Log("after weight "+n.stat);
                n.stat += (o.increasePerSec * o.time);    // increase need
                if (n.stat > 100)    // dont increase more than 100
                    n.stat = 100;
                //Debug.Log("after calc " +n.stat);
                //UnityEngine.Debug.Log("after " + n.stat);


            }
        }

        foreach (Need n in needlist)
        {
            if (n.type != o.type) // dicrease all other needs by executing time of operation

            {
                //UnityEngine.Debug.Log("before " + n.stat);

                n.stat = n.stat - (n.decreasebl * o.time);
                //UnityEngine.Debug.Log("after " + n.stat);

            }
        }
    }

    /*    public void effectStat(Type type, int time, int updateStat)
        {

            int effectOfTime = 0;
            foreach (Need n in this.needlist)
            {
                if (n.type != type)
                {
                    effectOfTime = n.stat - (n.decreasebl * time);
                    n.SetNeed(effectOfTime);
                }
                else
                {
                    n.SetNeed(n.stat + updateStat);
                }

            }
        }*/

    public Node clone()
    {
        List<Need> tempList = new List<Need>();
        foreach (Need n in this.needlist)
        {
            Need newNeed = (Need)ScriptableObject.CreateInstance(typeof(Need));
            newNeed.type = n.type;
            newNeed.decreasebl = n.decreasebl;
            tempList.Add(newNeed);
            newNeed.SetNeed(n.stat);
        }

        Node tempNode = (Node)ScriptableObject.CreateInstance(typeof(Node));
        tempNode.initializeNode(tempList);

        return tempNode;
    }


}
