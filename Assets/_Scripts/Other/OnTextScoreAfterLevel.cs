using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTextScoreAfterLevel : MonoBehaviour
{
    private float timer;
        private int score;
    // Start is called before the first frame update
    public void SetScore( int scor)
    {
        score = scor;
        PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score")+score);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < score){
          timer += Time.deltaTime *1000;
        }else{
          timer = score;
        }
        GameObject.Find("t_curScore").GetComponent<TextMesh>().text = (PlayerPrefs.GetInt("score")-score )+(int)timer+"";
        GetComponent<TextMesh>().text = (int)timer + "";
    }
}
