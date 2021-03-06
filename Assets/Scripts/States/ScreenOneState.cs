﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenOneState : IState
{
    private bool autoPlay;
    private GameObject ownerGameObject;
    private string gameStyle;

    public ScreenOneState(bool autoPlay , GameObject ownerGameObject , string gameStyle){
        this.autoPlay = autoPlay;
        this.ownerGameObject = ownerGameObject;
        this.gameStyle = gameStyle;
    }

    public void Enter()
    {
        //Debug.Log("autoPlay active " + autoPlay);
        //Debug.Log("Parent of state is at x position: " + this.ownerGameObject.transform.position.x);
        Debug.Log("The style of the game is: " + this.gameStyle);

        SwapImage.Instance.SetImage1();
    }

    public void Execute()
    {
        
    }

    public void Exit()
    {
        
    }
}
