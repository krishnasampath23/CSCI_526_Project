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
    // public string URL = @"https://docs.google.com/forms/u/2/d/e/1FAIpQLSeINTJed3u0J9RmvZs3GItAditDUFW4MR9yRh5YwCEBvafDnQ/formResponse";
    public string URL=@"https://docs.google.com/forms/u/2/d/e/1FAIpQLSf1G-1mTRCavEjK6v0fQzWC1BYzN3gl6kmGmNa8JBkZs-V0dw/formResponse";
    private long _sessionID;
    private int _poopsUsed=StaticScript._poopsUsed;
    private int _score=(StaticScript.enemies_killed*100)+((StaticScript.no_of_poops-StaticScript._poopsUsed)*100);
    private float _timePlayed=StaticScript.timeElapsed-StaticScript.timePrevious;
    private int poops_left=StaticScript.no_of_poops-StaticScript._poopsUsed;
    private int success_or_fail=StaticScript.success_or_fail;
    private int level=StaticScript.level;
    private int enemies_killed=StaticScript.enemies_killed;
    private int lines_drawn=StaticScript.lines_drawn;
    private int health=StaticScript.health;
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

 
        StartCoroutine(Post(_sessionID.ToString(),_timePlayed.ToString(),_score.ToString(), poops_left.ToString(),success_or_fail.ToString(),level.ToString(),enemies_killed.ToString(),health.ToString(),lines_drawn.ToString()));
    }
    private IEnumerator Post(string _sessionID, string _timePlayed,string _score, string poops_left, string success_or_fail, string level, string enemies_killed, string health, string lines_drawn )
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.1506871634", _sessionID);
        form.AddField("entry.147453066", _timePlayed);
        form.AddField("entry.664090624",_score);
        form.AddField("entry.850702427",poops_left);
        form.AddField("entry.228402792",success_or_fail);
        form.AddField("entry.1118317293",level);
        form.AddField("entry.303544330",enemies_killed);
        form.AddField("entry.1754955229",health);
        form.AddField("entry.2114550311",lines_drawn);



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