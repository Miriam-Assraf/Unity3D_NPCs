using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjStatus : MonoBehaviour
{
    public bool isUsed;

    void start()
    {
        isUsed = false;
    }

    public void use()
    {
        isUsed = true;
    }

    public void unuse()
    {
        isUsed = false;
    }


}
