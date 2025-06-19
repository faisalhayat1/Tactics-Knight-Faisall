using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSettings : MonoBehaviour
{

    public GameObject whiteBg;
    private float timer;
    // Start is called before the first frame update
    void Awake()
    {

      //PlayerPrefs.SetInt("firstStart", 0);
        timer = -0.7f;
        if (PlayerPrefs.GetInt("firstStart") == 0){
                    PlayerPrefs.SetInt("att", 0);
                    PlayerPrefs.SetInt("level", 1);
                    PlayerPrefs.SetInt("score", 0);
          PlayerPrefs.SetInt("curSkin", 1);

          PlayerPrefs.SetInt("firstStart", 1);
        }

        GameObject.Find("t_levelNum").GetComponent<TextMesh>().text = PlayerPrefs.GetInt("level")+"";
    }

    // Update is called once per frame
    void Start()
    {


    }

    void Update(){

            timer += Time.deltaTime;
            whiteBg.GetComponent<SpriteRenderer>().color = new Color(0.18f,0.56f,0.79f, timer);
            if (timer > 1){
                Application.LoadLevel(PlayerPrefs.GetInt("level")+"");
            }
    }
}
