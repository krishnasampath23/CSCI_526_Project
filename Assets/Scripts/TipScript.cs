using System.Collections;
using TMPro;
using UnityEngine;

public class TipScript:MonoBehaviour
{
    public GameObject player;
    public Arrow arrow;
    private TextMeshPro tipText;
    private GameObject tip1;
    private GameObject tip2;
    public static TipScript _ins;

    public static TipScript Ins
    {
        get
        {
            if(_ins == null)
            {
                _ins = new TipScript();
            }
            return _ins;
        }
    }

    string[][] tips = {
        new string[]{ "<color=#058923><size=20>Kill all the enemy to win this game!</size></color>", "Move:A&D",  "Press Spacebar to shoot & kill the tank." },
        new string[]{ "Touch the green platform to change color.","Shoot green bullets on the green tank to kill it." },
        new string[]{ "Drop an eraser (press X) on the line to remove it.","Enemy`s bullets can change platform`s color.","Change your color to green and kill the green tank." ,"Left click and hold to draw a line to reflect the bullet and kill the purple tank.","Shoot a bullet onto the line to kill the purple tank", "Kill the second purple tank by trapping its movement ","Now kill it" }
    };
    Vector3[][] poses = { 
        new Vector3[]{new Vector3(12.6f, 122f, 0), new Vector3(30.6f, 80.6f, 0), new Vector3(30.6f, 80.6f, 0) },
        new Vector3[]{new Vector3(6.9f, 148.8f, 0), new Vector3(30.6f, 70.6f, 0) },
        new Vector3[]{new Vector3(-145.8f, 92, 0), new Vector3(0.8f, 131, 0), new Vector3(0.8f, 131, 0) , new Vector3(45, 72.9f, 0)  , new Vector3(45, 72.9f, 0), new Vector3(45, 72.9f, 0), new Vector3(45, 72.9f, 0) }
    };
    int tipIndex = -1;
    int sceneIndex = 0;

    private void Awake()
    {
        _ins = this;
        tipText = GetComponent<TextMeshPro>();
        tip1 = transform.Find("tip1").gameObject;
        tip2 = transform.Find("tip2").gameObject;
    }

    public void ChangeScene(int sceneIndex)
    {
        this.sceneIndex = sceneIndex;
        tipIndex = 0;
        ShowTip();
        if(sceneIndex == 0)
        {
            Invoke("ShowNextTip", 5);
        }
    }

    private void ShowTip()
    {
        var isShowChild = sceneIndex == 0 && tipIndex == 1;
        arrow.ShowArrow(sceneIndex,tipIndex);
        tip1.SetActive(isShowChild);
        tip2.SetActive(isShowChild);
        if (tipIndex < tips[sceneIndex].Length)
        {
            tipText.text = tips[sceneIndex][tipIndex];
            ChangePos();
        }
        else
        {
            tipText.text = "";
            EventHandle.CallEventChangeScene();
        }
    }

    private void ChangePos()
    {
        tipText.transform.position = poses[sceneIndex][tipIndex];
        //if (tipIndex == 1)
        //{
        //    tipText.horizontalAlignment = HorizontalAlignmentOptions.Center;
        //}else
        //{
        //    tipText.horizontalAlignment = HorizontalAlignmentOptions.Left;
        //}
        //var w = tipText.preferredWidth * transform.localScale.x;
        //var h = tipText.preferredHeight * transform.localScale.y;
        //var playerPos = player.transform.position;
        //var posX = playerPos.x - w - 40;
        //var posY = playerPos.y;
        //if (posX < -146)
        //{
        //    posX = playerPos.x + 40;
        //}
        //if (posY > 162)
        //{
        //    posY = playerPos.y - h / 2 - 10;
        //}
        //tipText.transform.position = new Vector3(posX, posY, 0);
    }

    /// <summary>
    /// pressed W or S or D or A
    /// </summary>
    public void DirStepOk()
    {
        if(sceneIndex == 0 && tipIndex == 1)
        {
            tipIndex = 2;
            ShowTip();
        }
    }

    public void ShowNextTip()
    {
        tipIndex = 1;
        ShowTip();
    }

    public void KillBlackEnemy()
    {
        if(sceneIndex == 0 && tipIndex == 2)
        {
            tipIndex = 3;
            ShowTip();
        }else if(sceneIndex == 2 && tipIndex == 4)
        {
            tipIndex = 5;
            EventHandle.CallEventShowLineTip(1);
            ShowTip();
        }
        else if (sceneIndex == 2 && tipIndex == 6)
        {
            tipIndex = 7;
            ShowTip();
        }
    }

    /// <summary>
    /// jumped to another platform
    /// </summary>
    public void ToGreenPlatformOK()
    {
        if(sceneIndex == 1 && (tipIndex == 0 || tipIndex == 2) )
        {
            tipIndex = 1;
            ShowTip();
        }
    }

    public void KillGreenEnemy()
    {
        if (sceneIndex == 1 && tipIndex == 1)
        {
            tipIndex = 2;
            ShowTip();
        }else if(sceneIndex == 2 && tipIndex == 2)
        {
            tipIndex = 3;
            EventHandle.CallEventShowLineTip(0);
            ShowTip();
        }
    }

    public void BlackBulletTouchGreenEnemy()
    {
        if(sceneIndex == 1 && tipIndex == 1)
        {
            tipIndex = 0;
            ShowTip();
        }
    }

    public void EraserLineOK()
    {
        if(sceneIndex == 2 && tipIndex == 0)
        {
            tipIndex = 1;
            ShowTip();
        }
    }

    public void PlatformChangeGreen(Color value)
    {
        if (sceneIndex == 2 && tipIndex == 1 && value != Color.black)
        {
            tipIndex = 2;
            ShowTip();
        }
    }
    private int drawLine = 0;
    /// <summary>
    /// drawed lines
    /// </summary>
    public void DrawLinesOK()
    {
        if (sceneIndex == 2 && tipIndex == 3)
        {
            tipIndex = 4;
            EventHandle.CallEventHideLineTip(0);
            ShowTip();
        }else if(sceneIndex == 2 && tipIndex == 5)
        {
            drawLine += 1;
            if(drawLine == 2)
            {
                drawLine = 0;
                tipIndex = 6;
                EventHandle.CallEventHideLineTip(1);
                ShowTip();
            }
        }
    }

    public void EraserOK()
    {
        if (tipIndex == 4)
        {
            tipIndex = 5;
            ShowTip();
        }
    }
}