using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControlManager : SingletonPersistant<GameControlManager> {

    //public GameObject spriteImage;
    protected override void Awake()
    {
        //base.Awake();
        //PersistentManagerScript.Instance.autoPlayInterval = 6;
        //spriteImage = GameObject.FindGameObjectWithTag("ScreenDisplay");
    }

    private void Start()
    {

    }

}