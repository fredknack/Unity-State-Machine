using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : SingletonPersistant<GameStateManager> {

    private StateMachine stateMachine = new StateMachine();

    public void switchToDefaultMode()
    {
        this.stateMachine.ChangeState(new DefaultState(false, this.gameObject, "default"));
    }
    public void switchToScreenOne()
    {
        this.stateMachine.ChangeState(new ScreenOneState(false, this.gameObject, "screen one"));
    }
    public void switchToScreenTwo()
    {
        this.stateMachine.ChangeState(new ScreenTwoState(false, this.gameObject, "screen two"));
    }
    public void switchToScreenThree()
    {
        this.stateMachine.ChangeState(new ScreenThreeState(false, this.gameObject, "screen three"));
    }
    public void switchToScreenFour()
    {
        this.stateMachine.ChangeState(new ScreenFourState(false, this.gameObject, "screen four"));
    }
    public void switchToScreenFive()
    {
        this.stateMachine.ChangeState(new ScreenFiveState(false, this.gameObject, "screen five"));
    }
    protected override void Awake()
    {
        //base.Awake();
    }
}
