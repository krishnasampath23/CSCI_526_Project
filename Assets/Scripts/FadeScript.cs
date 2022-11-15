using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using DG.Tweening;

public class FadeScript:MonoBehaviour
{
    public LineRenderer lineRender;
    public void Show()
    {
        gameObject.SetActive(true);
        if (lineRender == null)
            lineRender = GetComponent<LineRenderer>();
        FadeOut();
    }

    public void Hide()
    {
        DOTween.KillAll();
        gameObject.SetActive(false);
    }

    public void FadeIn()
    {
        if (lineRender != null)
        {
            lineRender.material.DOFade(0.6f, 0.5f).onComplete += FadeOut;
        }

    }

    public void FadeOut()
    {
        if (lineRender != null)
        {
            lineRender.material.DOFade(0, 0.5f).onComplete += FadeIn;
        }
    }
    
}
