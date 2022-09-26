using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject pane_Init;
    public GameObject pane_Instruction;
    public GameObject pane_OperateInstruction;
    public GameObject btn_start;
    public GameObject btn_restart;
    public EnemyScript[] enemys;
    public PlayerScript player;
    public bool fromInit = false;
    // Start is called before the first frame update
    void Start()
    {
        EventHandle.EventOver += OnEventOver;
        pane_Init.SetActive(true);
        btn_restart.SetActive(false);
        pane_OperateInstruction.SetActive(false);
        pane_Instruction.SetActive(false);
        ObjectsActive(false);
    }

    private void OnEventOver()
    {
        pane_Init.SetActive(true);
        btn_start.SetActive(false);
        btn_restart.SetActive(true);
        int num = enemys.Length;
        for(int i = 0; i < num;i++)
        {
            enemys[i].ResetState();
        }
        player.ResetState();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ClickStart()
    {
        pane_Init.SetActive(false);
        pane_OperateInstruction.SetActive(true);
    }

    private void ObjectsActive(bool value)
    {
        int num = enemys.Length;
        for (int i = 0; i < num; i++)
        {
            enemys[i].gameObject.SetActive(value);
        }
        player.gameObject.SetActive(value);
    }

    public void ClickInstructionFromInit()
    {
        fromInit = true;
        pane_Init.SetActive(false);
        pane_Instruction.SetActive(true);
    }

    public void ClickInstructionFromGame()
    {
        fromInit = false;
        pane_Instruction.SetActive(true);
    }

    public void ClickRestart()
    {
        pane_Init.SetActive(false);
        ObjectsActive(true);
    }

    public void CloseInitPane()
    {
        if (fromInit)
        {
            pane_Init.SetActive(true);
        }

        pane_Instruction.SetActive(false);
    }

    public void CloseOperateInstruction()
    {
        pane_OperateInstruction.SetActive(false);
        ObjectsActive(true);
    }

}
