using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonPersistant<T> : MonoBehaviour where T : Component {

	// <T> indicates Generic
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    var obj = new GameObject();
                    obj.hideFlags = HideFlags.HideAndDontSave;
                    instance = obj.AddComponent<T>();
                    //obj.AddComponent<T>();
                }

            }
            return instance;
        }
        set
        {
            instance = value;
        }

    }
    protected virtual void Awake()
    {
        //This makes the instance persistent from scene to scene
        DontDestroyOnLoad(this);
        if(instance == null){
            instance = this as T;
        } else {
            Destroy(gameObject);
        }
    }

}


