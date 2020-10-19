using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour //Singleton 
{
    //Singleton name T

   private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                //FindObeject by T
                instance = FindObjectOfType<T>();
            }

            return instance;
        }
    }


}
