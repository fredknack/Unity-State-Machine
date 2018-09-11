using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControlManager : SingletonPersistant<GameControlManager> {

    //public GameObject spriteImage;

    public void advanceScreen()
    {
        
    }

    protected override void Awake()
    {
        //base.Awake();
        //PersistentManagerScript.Instance.autoPlayInterval = 6;
        //spriteImage = GameObject.FindGameObjectWithTag("ScreenDisplay");

    }
}
