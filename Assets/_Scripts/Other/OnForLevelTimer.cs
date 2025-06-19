using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnForLevelTimer : MonoBehaviour
{
    public int level;

    private float timer;
    public float speed;

    private GameObject t_levelTimer;
    // Start is called before the first frame update

  	void Start () {

  		DontDestroyOnLoad(this.gameObject);

    }


    public void EndLevel(){
      GameObject.Find("scoreLevel").SendMessage("SetScore", 200+timer*7);
      speed = 80;
    }

    public void SetNewLevel(int lvl)
    {
    t_levelTimer = GameObject.Find("levelTimer");
        if (level != lvl){
            timer = 40 + (level*4.2f);
            speed = 1;
            level = lvl;
        }
    }

    // Update is called once per frame
    void Update()
    {
      if (t_levelTimer){
        timer -= Time.deltaTime * speed;
        if (timer < 0){
          timer = 0;
          Destroy(t_levelTimer);
        }

          t_levelTimer.GetComponent<TextMesh>().text = (int)timer + "";

      }



    }
}
