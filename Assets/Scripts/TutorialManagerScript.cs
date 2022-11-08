using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class TutorialManagerScript : MonoBehaviour
    {
        public GameObject scene1;
        public GameObject scene2;
        public GameObject scene3;

        public GameObject lineTip;
        public LineRenderer lineRender;

        public Transform goodjob;

        public Rigidbody2D player;

        private Vector3 playerOriPos;
        [SerializeField] private Line _linePrefab;
        private bool gameOver;

        void Start()
        {
            playerOriPos = player.transform.localPosition;
            EventHandle.EventChangeScene += ShowGoodJob;
            EventHandle.EventShowLineTip += ShowLine;
            EventHandle.EventHideLineTip += HideLine;

            ShowStepScene();
        }

        private void ShowStepScene()
        {
            int sceneIndex = StaticScript.tutorialStep;
            switch (sceneIndex)
            {
                case 0:
                    scene1.SetActive(true);
                    player.transform.localPosition = playerOriPos;
                    TipScript.Ins.ChangeScene(sceneIndex);
                    break;
                case 1:
                    scene1.SetActive(false);
                    scene2.SetActive(true);
                    player.transform.localPosition = playerOriPos;
                    TipScript.Ins.ChangeScene(sceneIndex);
                    break;
                case 2:
                    scene1.SetActive(false);
                    scene3.SetActive(true);
                    DrawLine();
                    player.transform.localPosition = playerOriPos;
                    TipScript.Ins.ChangeScene(sceneIndex);
                    break;
            }
        }

        private void DrawLine()
        {
            var posX = -110;
            var mousePos = new Vector2(posX, 10);
            var line = Instantiate(_linePrefab, mousePos, Quaternion.identity);
            for (int i = 0; i < 51; i++)
            {
                posX += 1;
                line.SetPosition(new Vector2(posX, 10));
            }
        }

        private void ShowLine()
        {
            lineTip.SetActive(true);
            FadeOut();
        }

        private void HideLine()
        {
            lineTip.SetActive(false);
        }

        private void FadeIn()
        {
            if (lineRender) {
                lineRender.material.DOFade(0.6f, 0.5f).onComplete += FadeOut;
            }
        }

        private void FadeOut()
        {
            if (lineRender) {
                lineRender.material.DOFade(0, 0.5f).onComplete += FadeIn;
            }
        }

        private void ChangeScene()
        {
            StaticScript.tutorialStep += 1;
            if(StaticScript.tutorialStep <= 2)
            {
                SceneManager.LoadScene("Tutorial");
            }
            
            
            //goodjob.gameObject.SetActive(false);
            //sceneIndex += 1;
            //ShowStepScene();
        }
        private Vector3 overPos;
        private void ShowGoodJob()
        {
            gameOver = true;
            overPos = player.transform.localPosition;
            player.angularVelocity = 0;
            goodjob.gameObject.SetActive(true);
            goodjob.DOScale(new Vector3(3, 3, 3), 0.5f);
            Invoke("ChangeScene",2f);
        }


        // Update is called once per frame
        void Update()
        {
            if(gameOver)
            {
                player.transform.localPosition = overPos;
            }
        }

        private void OnDestroy()
        {
            EventHandle.EventChangeScene -= ShowGoodJob;
            EventHandle.EventShowLineTip -= ShowLine;
            EventHandle.EventHideLineTip -= HideLine;
        }
    }
}