using System.Collections;
using UnityEngine;
using DG.Tweening;
public class Arrow : MonoBehaviour
{
    private float posX;
    private float posY;
    // Use this for initialization
    void Start()
    {
        posX = transform.localPosition.x;
    }

    private void MoveX()
    {
        transform.DOLocalMoveX(posX + 5, 0.5f).onComplete += BackX;
    }

    private void BackX()
    {
        transform.DOLocalMoveX(posX, 0.5f).onComplete += MoveX;
    }

    private void MoveY()
    {
        transform.DOLocalMoveY(posY - 5, 0.5f).onComplete += BackY;
    }

    private void BackY()
    {
        transform.DOLocalMoveY(posY, 0.5f).onComplete += MoveY;
    }

    private void HideArrow()
    {
        gameObject.SetActive(false);
    }

    public void ShowArrow(int sceneIndex,int stepIndex)
    {
        
        if(sceneIndex == 1)
        {
            if(stepIndex == 0)
            {
                DOTween.Clear();
                transform.localPosition = new Vector3(86.5f,122.5f,0);
                transform.localEulerAngles = new Vector3(0, 0, 0);
                gameObject.SetActive(true);
                posX = 86.5f;
                MoveX();
            }
            else if(stepIndex == 1)
            {
                DOTween.Clear();
                gameObject.SetActive(true);
                transform.localPosition = new Vector3(89.8f,29.4f,0);
                transform.localEulerAngles = new Vector3(0, 0, -90);
                posY = 29.4f;
                MoveY();
            }
            else
            {
                gameObject.SetActive(false);
            }
        }else if(sceneIndex == 2)
        {
            if(stepIndex == 0)
            {
                DOTween.Clear();
                gameObject.SetActive(true);
                transform.localPosition = new Vector3(-86.6f, 53.6f, 0);
                transform.localEulerAngles = new Vector3(0, 0, -90);
                posY = 53.6f;
                MoveY();
            }else
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}