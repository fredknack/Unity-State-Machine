using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentManagerScript : MonoBehaviour {

	public static PersistentManagerScript Instance { get; private set; }

    public bool autoPlay = true;
    public int autoPlayInterval = 6;
    public int slideNum = 1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }
}
