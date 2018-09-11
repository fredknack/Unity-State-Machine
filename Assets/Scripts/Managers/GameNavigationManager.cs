using UnityEngine;
using UnityEngine.SceneManagement;

public class GameNavigationManager : SingletonPersistant<GameNavigationManager> {

    public void ScreenOne()
    {
        GameStateManager.Instance.switchToScreenOne(); 
    }
    public void ScreenTwo()
    {
        GameStateManager.Instance.switchToScreenTwo();
    }
    public void ScreenThree()
    {
        GameStateManager.Instance.switchToScreenThree();
    }
    public void ScreenFour()
    {
        GameStateManager.Instance.switchToScreenFour();
    }
    public void ScreenFive()
    {
        GameStateManager.Instance.switchToScreenFive();
    }

}