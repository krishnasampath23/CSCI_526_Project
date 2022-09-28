using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine.Networking;


public class SendToGoogle : MonoBehaviour
{
    //[SerializeField]
    public string URL = @"https://docs.google.com/forms/u/2/d/e/1FAIpQLSeINTJed3u0J9RmvZs3GItAditDUFW4MR9yRh5YwCEBvafDnQ/formResponse";

    private long _sessionID;
    private int _poopsUsed=StaticScript._poopsUsed;
    private int _score=StaticScript.score;
    private float _timePlayed=StaticScript.timeElapsed-StaticScript.timePrevious;
    // Start is called before the first frame update
    private void Awake()
    {
        // Assign sessionID to identify playtests
        _sessionID = DateTime.Now.Ticks;
        Send();
    }
    public void Send()
    {
        // Assign variables
      
       // _testPlayers = UnityEngine.Random.Range(0, 101);

 
        StartCoroutine(Post(_sessionID.ToString(), _poopsUsed.ToString(),_score.ToString(),_timePlayed.ToString()));
    }
    private IEnumerator Post(string _sessionID, string _poopsUsed,string _score, string _timePlayed)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.1506871634", _sessionID);
        form.AddField("entry.147453066", _poopsUsed);
        form.AddField("entry.1850845775",_score);
        form.AddField("entry.1700182594",_timePlayed);


        // Send responses and verify result
        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }

    }
}