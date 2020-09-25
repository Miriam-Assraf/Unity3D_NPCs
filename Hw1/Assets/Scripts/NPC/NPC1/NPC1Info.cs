using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC1Info : MonoBehaviour
{
    public NPC1 npc;
    public TextMeshPro textmeshPro;
    public string name;
    public Type type;
    public bool isOp;

    // Start is called before the first frame update
    void Start()
    {
        npc = GameObject.Find("NPC1").GetComponent<NPC1>();
        TextMeshPro textmeshPro = GetComponent<TextMeshPro>();
        name = gameObject.name;
        isOp = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch (name)
        {
            case "Energy":
                type = Type.Energy;
                break;
            case "Hunger":
                type = Type.Hunger;
                break;
            case "Hygiene":
                type = Type.Hygiene;
                break;
            case "Social":
                type = Type.Social;
                break;
            case "Fun":
                type = Type.Fun;
                break;
            case "Op":
                isOp = true;
                break;
        }
        /* Vector3 energyPos = Camera.main.WorldToScreenPoint(this.transform.position);
         socialTxt.transform.position = energyPos;*/
        if (!isOp)
        {
            foreach (Need n in npc.NeedNode.needlist)
            {
                if (n.type == type)
                {
                    textmeshPro.text = name + ": " + n.stat;
                    /* if (n.stat >= 80)
                     {
                    GetComponent<Renderer>().material.color = new Color(41 / 255.0f, 238 / 255.0f, 18 / 255.0f);

                    }
                    else if (80 > n.stat >= 40) 
                    {
                        GetComponent<Renderer>().material.color = new Color(255 / 255.0f, 130 / 255.0f, 0 / 255.0f);
                    }
                    else if (0 < n.stat < 40)
                    {
                        GetComponent<Renderer>().material.color = new Color(255 / 255.0f, 20 / 255.0f, 20 / 255.0f);
                    }*/
                }
            }
        }
        else
        {
            if (npc.new_target != null)
            {
                textmeshPro.text = "Operation chosen: " + npc.new_target.op;
            }
        }
    }
}
