using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
//using System.Diagnostics;
//using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;
/*
public enum State
{
    doingOp,
    notDoingOp
}
*/
public class NPCMotion : MonoBehaviour
{

    public GameInitializer GIReference;
    int time;
    int interval = 2;
    float nextTime = 0;
    private Node NeedNode;
    private Node tempNode;
    public GameObject target;
    public Object new_target;
    public Object old_target;
    public List<Object> ObjectList = new List<Object>();
    [SerializeField] float destinationReachedTreshold;
    NavMeshAgent agent;
    private const int statsNumber = 5;
    private State _currentState;

    void Awake()
    {
        SetUp();
        SetUpObjects();
    }
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.transform.position);
        destinationReachedTreshold = 10f;
        _currentState = State.notDoingOp;
        time = 0;
        //Object target;
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentState == State.doingOp)
        {
            //new_target.String();
            float distanceToTarget = Vector3.Distance(transform.position, new_target.item.transform.position);
            //Debug.Log();
            if (distanceToTarget < destinationReachedTreshold)
            {
                if (new_target.y_rotation != 0)
                {
                    Vector3 v = transform.rotation.eulerAngles;
                    transform.rotation = Quaternion.Euler(v.x, new_target.y_rotation, v.z);
                }
                if (new_target.hight_offset != 0)
                {
                    transform.position -= new Vector3(0, new_target.hight_offset, 0);
                }
                GetComponent<Animation>().Play(new_target.animation);

                if (Time.time >= nextTime)
                {
                    if (time <= new_target.time)
                    {
                        NeedNode.UpdateNode(new_target);
                        if (stopOp(NeedNode, new_target))
                        {
                            GameObject.Find(new_target.name).GetComponent<ObjStatus>().unuse();
                            //UnityEngine.Debug.Log("hereee " + GameObject.Find(new_target.name).GetComponent<ObjStatus>().isUsed);
                            _currentState = State.notDoingOp;
                        }
                        //new_target.String();
                        //UnityEngine.Debug.Log(time + " <= " + new_target.time);
                        time += 1;
                        //NeedNode.String();

                        nextTime += interval;

                    }
                    else
                    {
                        //old_target = new_target;
                        GameObject.Find(new_target.name).GetComponent<ObjStatus>().unuse();
                        //UnityEngine.Debug.Log("hereee " + old_target.name);
                        _currentState = State.notDoingOp;
                    }
                }

            }
            else
            {
                if (Time.time >= nextTime)
                {

                    NeedNode.UpdateNode(null);  // not doing nothing yet
                    //NeedNode.String();

                    nextTime += interval;

                }
                GetComponent<Animation>().Play("Walking");
            }
        }

        else
        {
            time = 0;
            getDecision();
            GameObject.Find(new_target.name).GetComponent<ObjStatus>().use();
            //UnityEngine.Debug.Log("for " + new_target.name + " " + GameObject.Find(new_target.name).GetComponent<ObjStatus>().isUsed);

            agent.SetDestination(new_target.item.transform.position);
            _currentState = State.doingOp;

            if (Time.time >= nextTime)
            {

                NeedNode.UpdateNode(null);
                //NeedNode.String();

                nextTime += interval;

            }
        }

        //if (State = active) ;
        //dont do Decision
        //if (state = idle) ;
        // Do Decision.

    }

    void getDecision()
    {
        float average = 0;
        foreach (Object o in ObjectList)
        {
            if (GameObject.Find(o.name) != null)
            {
                tempNode = NeedNode.clone();
                float weight = 0;
                foreach (Need n in tempNode.needlist)
                {
                    if (n.type == o.type)
                    {
                        weight = n.getWeight((transform.position - o.item.transform.position).magnitude);
                    }
                }
                // get new stat
                tempNode.CalculateNewStat(o);
                // get average depending on weight
                tempNode.Average(weight);
                // tempNode.effectStat(o.type, o.time, o.updateValue);
                UnityEngine.Debug.Log("average for " + o.name + " is " + tempNode.average);

                if (GameObject.Find(o.name) != null)
                {
                    if (average < tempNode.average)
                    {
                        //Debug.Log("yes");
                        if (!GameObject.Find(o.name).GetComponent<ObjStatus>().isUsed)
                        {
                            average = tempNode.average;
                            target = o.item;
                            new_target = o;
                        }
                    }
                }
            }
        }
    }

    /* void UpdateStat()
     {
         int effectOfTime = 0;
         foreach (Need n in NeedNode.needlist)
         {
             if (new_target.type == n.type)
             {
                 print(n.type);
                 n.stat+= new_target.increasePerSec*new_target.time;
             }
             else
             {
                 print(n.type + "Not type");
                 effectOfTime = n.stat - (n.decreasebl * new_target.time);
                 n.stat=effectOfTime;
             }
             NeedNode.String();
         }
     }*/

    void SetUp()
    {
        Need EnergeryNeed = (Need)ScriptableObject.CreateInstance(typeof(Need));
        initializeNeed(EnergeryNeed, Type.Energy);
        Need HungerNeed = (Need)ScriptableObject.CreateInstance(typeof(Need));
        initializeNeed(HungerNeed, Type.Hunger);
        Need HygienNeed = (Need)ScriptableObject.CreateInstance(typeof(Need));
        initializeNeed(HygienNeed, Type.Hygiene);
        Need SocialNeed = (Need)ScriptableObject.CreateInstance(typeof(Need));
        initializeNeed(SocialNeed, Type.Social);
        Need FunNeed = (Need)ScriptableObject.CreateInstance(typeof(Need));
        initializeNeed(FunNeed, Type.Fun);

        /* Need EnergeryNeed = new Need(Type.Energy, Random.Range(1, 3));
         Need HungerNeed = new Need(Type.Hunger, Random.Range(1, 3));
         Need HyginNeed = new Need(Type.Hygine, Random.Range(1, 3));
         Need SocialNeed = new Need(Type.Social, Random.Range(1, 3));
         Need FunNeed = new Need(Type.Fun, Random.Range(1, 3));*/

        List<Need> needlist = new List<Need>();
        needlist.Add(EnergeryNeed);
        needlist.Add(HungerNeed);
        needlist.Add(HygienNeed);
        needlist.Add(SocialNeed);
        needlist.Add(FunNeed);

        NeedNode = (Node)ScriptableObject.CreateInstance(typeof(Node));
        NeedNode.initializeNode(needlist);
        //NeedNode.String();

        foreach (Need n in needlist)
        {
            n.SetNeed(UnityEngine.Random.Range(70, 101));
            //n.String();
        }
    }


    void SetUpObjects()
    {

        GIReference = GameObject.Find("GameInitializer").GetComponent<GameInitializer>();
        ObjectList = GIReference.ObjectList;

    }

    void initializeNeed(Need n, Type type)
    {
        n.type = type;
        n.decreasebl = UnityEngine.Random.Range(1, 3);
    }

    bool stopOp(Node needs, Object o)
    {
        bool isCurrentLow = false;
        foreach (Need n in needs.needlist)
        {
            if (n.stat < 10) // if we have a need too low or reached to 100, we want to stop and look for other operation
            {
                if (n.type == o.type)
                {
                    isCurrentLow = true;
                }
            }
        }

        if (!isCurrentLow)
        {
            foreach (Need n in needs.needlist)
            {
                if ((n.type != o.type && n.stat < 10 && n.type != Type.Social) || n.stat >= 100)
                {
                    return true;
                }
            }
        }

        return false;
    }
}
