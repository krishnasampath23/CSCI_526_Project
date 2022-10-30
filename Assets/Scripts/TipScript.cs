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
            return _ins;
        }
    }
    string[] tips = { "Move:A&D", "Jump to another platform to change your color","Shoot:SPACE","DrawingLines:Mouse","Eraser:X" };
    int tipIndex = 0;

    private void Awake()
    {
        _ins = this;
        tipText = GetComponent<TextMeshPro>();
        tip1 = transform.Find("tip1").gameObject;
        tip2 = transform.Find("tip2").gameObject;
    }
    private void Start()
    {
        Invoke("ShowTip", 0.2f);
    }


    private void ShowTip()
    {
        var isShowChild = tipIndex == 0;
        tip1.SetActive(isShowChild);
        tip2.SetActive(isShowChild);
        if (tipIndex < tips.Length)
        {
            tipText.text = tips[tipIndex];
            ChangePos();
        }
        else
        {
            tipText.text = "";
        }
        
    }

    private void ChangePos()
    {
        var w = tipText.preferredWidth * transform.localScale.x;
        var h = tipText.preferredHeight * transform.localScale.y;
        var playerPos = player.transform.position;
        var posX = playerPos.x - w - 40;
        var posY = playerPos.y;
        if (posX < -146)
        {
            posX = playerPos.x + 40;
        }
        if (posY > 162)
        {
            posY = playerPos.y - h / 2 - 10;
        }
        tipText.transform.position = new Vector3(posX, posY, 0);
    }
    private string GetShowTip()
    {
        if (tipIndex == -1) return "";
        if ( tipIndex < tips.Length)
        {
            return tips[tipIndex];
        }
        return "";
    }

    /// <summary>
    /// pressed W or S or D or A
    /// </summary>
    public void DirStepOk()
    {
        if(tipIndex == 0)
        {
            tipIndex = 1;
            ShowTip();
        }
    }

    /// <summary>
    /// jumped to another platform
    /// </summary>
    public void ToGreenPlatformOK()
    {
        if(tipIndex == 1)
        {
            tipIndex = 2;
            ShowTip();
        }
    }

    /// <summary>
    /// pressed the space key
    /// </summary>
    public void PoopBulletOK()
    {
        if (tipIndex == 2)
        {
            tipIndex = 3;
            ShowTip();
        }
    }
    /// <summary>
    /// drawed lines
    /// </summary>
    public void DrawLinesOK()
    {
        if (tipIndex == 3)
        {
            tipIndex = 4;
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