using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Singleton <T> where T :  class, new()
{
    protected static T instance;
    public UI_Singleton()
    {

    }
    public T Instance
    {
        get
        {
            if (instance == null)
                instance = new T();
            return instance;
        }
    }
}
