using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    
    public GameObject pane_OperateInstruction;
    public GameObject pane_GameUI;
    public GameObject player;
    public bool fromInit = false;
    // Start is called before the first frame update
    
    void Awake()
    {
        if (StaticScript.showOperateInfo)
        {
            ObjectsActive(false);
            pane_OperateInstruction.SetActive(true);
        }
        else
        {
            pane_OperateInstruction.SetActive(false);
            StartGame();
        }

    }

    
    // Update is called once per frame
    void Update()
    {

    }

    private void ObjectsActive(bool value)
    {
        //enemy.gameObject.SetActive(value);
        player.SetActive(value);
    }



    public void CloseOperateInstruction()
    {
        pane_OperateInstruction.SetActive(false);
        StartGame();
    }

    private void StartGame()
    {
        ObjectsActive(true);
        StaticScript.showOperateInfo = false;
        EventHandle.CallEventStart();
        StaticScript.timerOn = true;
        //enemy.StartGame();
    }

}
