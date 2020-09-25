using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    public List<Object> ObjectList = new List<Object>();
    // Start is called before the first frame update
    void Start()
    {
        String[] social_paths = { "NPC1", "NPC2" };
        // sleep
        Object sleep1 = (Object)ScriptableObject.CreateInstance(typeof(Object));
        sleep1.initializeObject("sleep", Type.Energy, 3, 30, "parents bed right", "Laying", -90, 4);
        ObjectList.Add(sleep1);

        Object sleep2 = (Object)ScriptableObject.CreateInstance(typeof(Object));
        sleep2.initializeObject("sleep", Type.Energy, 3, 30, "parents bed left", "Laying", -90, 4);
        ObjectList.Add(sleep2);

        Object sleep3 = (Object)ScriptableObject.CreateInstance(typeof(Object));
        sleep3.initializeObject("sleep", Type.Energy, 3, 30, "bedroom bed left", "Laying", -90, 7);
        ObjectList.Add(sleep3);

        Object coffee = (Object)ScriptableObject.CreateInstance(typeof(Object));
        coffee.initializeObject("drink coffee", Type.Energy, 2, 20, "coffee", "Idle", 0, 0);
        ObjectList.Add(coffee);

        Object watchTv1 = (Object)ScriptableObject.CreateInstance(typeof(Object));
        watchTv1.initializeObject("watch TV", Type.Fun, 3, 28, "couch right", "Sitting", 90, -2);
        ObjectList.Add(watchTv1);

        Object watchTv2 = (Object)ScriptableObject.CreateInstance(typeof(Object));
        watchTv2.initializeObject("watch TV", Type.Fun, 3, 28, "couch left", "Sitting", 90, -2);
        ObjectList.Add(watchTv2);

        Object computer1 = (Object)ScriptableObject.CreateInstance(typeof(Object));
        computer1.initializeObject("play on PC", Type.Fun, 2, 35, "parents computer", "Sitting", -30, -2);
        ObjectList.Add(computer1);

        Object computer2 = (Object)ScriptableObject.CreateInstance(typeof(Object));
        computer2.initializeObject("play on PC", Type.Fun, 2, 35, "bedroom computer", "Sitting", 30, -1);
        ObjectList.Add(computer2);

        Object meal = (Object)ScriptableObject.CreateInstance(typeof(Object));
        meal.initializeObject("eat cooked meal", Type.Hunger, 3, 30, "oven", "Idle", 0, 0);
        ObjectList.Add(meal);

        Object sandwich = (Object)ScriptableObject.CreateInstance(typeof(Object));
        sandwich.initializeObject("eat sandwich", Type.Hunger, 2, 30, "fridge", "Idle", 0, 0);
        ObjectList.Add(sandwich);

        Object snack = (Object)ScriptableObject.CreateInstance(typeof(Object));
        snack.initializeObject("eat snack", Type.Hunger, 1, 40, "snack", "Idle", 0, 0);
        ObjectList.Add(snack);

        Object toilet1 = (Object)ScriptableObject.CreateInstance(typeof(Object));
        toilet1.initializeObject("go to toilet", Type.Hygiene, 2, 40, "toilet", "Sitting", 1, -4);
        ObjectList.Add(toilet1);

        Object toilet2 = (Object)ScriptableObject.CreateInstance(typeof(Object));
        toilet2.initializeObject("go to toilet", Type.Hygiene, 2, 40, "bedroom toilet", "Sitting", 90, -4);
        ObjectList.Add(toilet2);

        Object toilet3 = (Object)ScriptableObject.CreateInstance(typeof(Object));
        toilet3.initializeObject("go to toilet", Type.Hygiene, 2, 40, "parents toilet", "Sitting", 1, -4);
        ObjectList.Add(toilet3);

        Object chat1 = (Object)ScriptableObject.CreateInstance(typeof(Object));
        computer1.initializeObject("chat online", Type.Social, 2, 40, "parents computer", "Sitting", -30, -2);
        ObjectList.Add(chat1);

        Object chat2 = (Object)ScriptableObject.CreateInstance(typeof(Object));
        computer2.initializeObject("chat online", Type.Social, 2, 40, "bedroom computer", "Sitting", 30, -1);
        ObjectList.Add(chat1);
    }


}
