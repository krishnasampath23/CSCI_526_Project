using System.Collections;
using TMPro;
using UnityEngine;

public class TipScript:MonoBehaviour
{
    public GameObject player;
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
        new string[]{ "Move:A&D", "Press Spacebar to shoot & kill the enemy" },
        new string[]{ "Switch Color","Shoot Enemy" ,"Change Color"},
        new string[]{ "Drop Eraser on white line to erase","Kill Green Enemy" ,"Draw line","Kill black enemy ① with a rame", "Kill black enemy ② by trapping its movement " }
    };
    Vector3[] poses = { new Vector3(30.6f, 70.6f, 0), new Vector3(30.6f, 70.6f, 0), new Vector3(60f, 65.5f, 0)};
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
    }

    private void ShowTip()
    {
        var isShowChild = sceneIndex == 0 && tipIndex == 0;
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
        tipText.transform.position = poses[sceneIndex];
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
        if(sceneIndex == 0 && tipIndex == 0)
        {
            tipIndex = 1;
            ShowTip();
        }
    }

    public void KillBlackEnemy()
    {
        if(sceneIndex == 0 && tipIndex == 1)
        {
            tipIndex = 2;
            ShowTip();
        }else if(sceneIndex == 2 && tipIndex == 3)
        {
            tipIndex = 4;
            ShowTip();
        }
        else if (sceneIndex == 2 && tipIndex == 4)
        {
            tipIndex = 5;
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
            tipIndex = 3;
            ShowTip();
        }else if(sceneIndex == 2 && tipIndex == 1)
        {
            tipIndex = 2;
            EventHandle.CallEventShowLineTip();
            ShowTip();
        }
    }

    public void BlackBulletTouchGreenEnemy()
    {
        if(sceneIndex == 1 && tipIndex == 1)
        {
            tipIndex = 2;
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
    /// <summary>
    /// drawed lines
    /// </summary>
    public void DrawLinesOK()
    {
        if (sceneIndex == 2 && tipIndex == 2)
        {
            tipIndex = 3;
            EventHandle.CallEventHideLineTip();
            ShowTip();
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