using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPlay : MonoBehaviour {
    private Timer timer;
    private float startTime;
    public bool autoPlay = true; 
    public int autoTimerDuration = 5;
    private int screenIndex = 1;

	void Start () {
        timer = new GameObject().AddComponent<Timer>();
        timer.Duration = autoTimerDuration;
        timer.Run();

        startTime = Time.time;
	}
	
	void Update () {
        if(autoPlay){
            if(timer.Finished)
            {
                float elapsedTime = Time.time - startTime;

                switch (screenIndex)
                {
                    case 1:
                        GameNavigationManager.Instance.ScreenOne();
                        break;
                    case 2:
                        GameNavigationManager.Instance.ScreenTwo();
                        break;
                    case 3:
                        GameNavigationManager.Instance.ScreenThree();
                        break;
                    case 4:
                        GameNavigationManager.Instance.ScreenFour();
                        break;
                    case 5:
                        GameNavigationManager.Instance.ScreenFive();
                        break;
                }

                startTime = Time.time;
                if (screenIndex >= 5) {
                    screenIndex = 1;
                }else{
                    screenIndex = screenIndex + 1;
                }
                timer.Run();
            }
        }
	}
}