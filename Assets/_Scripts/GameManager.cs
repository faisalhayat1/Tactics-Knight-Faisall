using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float delayWin;
    public int numEnemy;

    public int level;

    public GameObject Canvass;
    public GameObject whiteBg;


    private GameObject t_levelText;
    private GameObject t_levelNum;
        private float timer;
        private float timer2;
        private float timer3;
        private float gameTimer;
    private bool win;


    void Awake()
    {
        PlayerPrefs.SetInt("numLvlPlayer", PlayerPrefs.GetInt("numLvlPlayer")+1);
        Canvass.active = true;
        whiteBg.active = true;
        win = true;

        t_levelNum = GameObject.Find("t_levelNum");
        t_levelText = GameObject.Find("t_levelText");

        t_levelNum.GetComponent<TextMesh>().color = new Color(0.6f,0.78f,0.9f, 0);
        t_levelText.GetComponent<TextMesh>().color = new Color(0.6f,0.78f,0.9f, 0);
        level = PlayerPrefs.GetInt("level");

        GameObject.Find("b_skipLevel").tag = "Button";


        Dictionary<string, object> parameters = new Dictionary<string, object>();
        parameters.Add("level_number", level );
        parameters.Add("level_count", PlayerPrefs.GetInt("numLvlPlayer") );
        //AppMetrica.Instance.ReportEvent ("level_start", parameters);
        //AppMetrica.Instance.SendEventsBuffer();
    }

    void Start(){
        if (level == 4 && PlayerPrefs.GetInt("score") < 1500) PlayerPrefs.SetInt("score", 1624);

        GameObject.Find("forLevelTimer").SendMessage("SetNewLevel", level);
        GameObject.Find("t_curScore").GetComponent<TextMesh>().text = PlayerPrefs.GetInt("score")+"";

        if (delayWin == -1.5f) delayWin = -1.65F;

        if (level > 5) GameObject.Find("ADS").GetComponent<ads_go>().ShowInterstitial();
    }


    public void Update()
    {
      gameTimer+= Time.deltaTime;

      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      RaycastHit hit;
      if (Input.GetMouseButtonDown(0)){

        if (level == 1){
          if (GameObject.Find("tutorial")) Destroy(GameObject.Find("tutorial"), 0.5f);
        }
        if (Physics.Raycast(ray, out hit, 100)){
            var nam = hit.collider.gameObject.name;
            if (hit.collider.tag == "Button"){
                if (nam == "b_menu"){
                    GameObject.Find("SystemObject").GetComponent<OnSystemObject>().ShowMenu(8);
                    if (GameObject.Find("attention"))  GameObject.Find("attention").transform.localPosition = new Vector3(2,12,0);

                }
                if (nam == "b_exitMenu"){
                    Destroy(hit.collider.gameObject.transform.parent.gameObject);
                    if (GameObject.Find("Hero")) GameObject.Find("Hero").GetComponent<Controll>().enabled = true;
                    if (GameObject.Find("attention")) Destroy(GameObject.Find("attention"));
                }

                if (nam == "b_restart"){
                    numEnemy = 9999;
                }

                if (nam == "b_info"){
                    if (GameObject.Find("Hero")) GameObject.Find("Hero").GetComponent<Controll>().enabled = false;
                    GameObject.Find("SystemObject").GetComponent<OnSystemObject>().ShowMenu(9);
                }

                if (nam == "b_skin"){
                    if (level > 3 && PlayerPrefs.GetInt("att") == 0) PlayerPrefs.SetInt("att", 1);
                    Application.LoadLevel("skinSelect");
                }

                if (nam == "b_noads" || nam == "b_donate"){
                    GameObject.Find("IAP").SendMessage ("BuyProductID", "gp_no_ads");
                }

                if (nam == "b_skipLevel"){
                      hit.collider.gameObject.AddComponent<ButtonClickEffect>();
                      GameObject.Find("ADS").SendMessage("ShowRewarded", "1");
                }






                if (nam == "star1"){
                    GameObject.Find("star1").GetComponent<SpriteRenderer>().color =Color.white;
                    Destroy(GameObject.Find("RateIt"), 0.2f);
                    numEnemy = 7777;
                                            Dictionary<string, object> parameters = new Dictionary<string, object>();
                                            parameters.Add("star", 1 );
                                            //AppMetrica.Instance.ReportEvent ("RateIt", parameters);
                                            //AppMetrica.Instance.SendEventsBuffer();
                }
                if (nam == "star2"){
                    GameObject.Find("star2").GetComponent<SpriteRenderer>().color =Color.white;
                    GameObject.Find("star1").GetComponent<SpriteRenderer>().color =Color.white;
                    Destroy(GameObject.Find("RateIt"), 0.2f);
                    numEnemy = 7777;
                                            Dictionary<string, object> parameters = new Dictionary<string, object>();
                                            parameters.Add("star", 2 );
                                            //AppMetrica.Instance.ReportEvent ("RateIt", parameters);
                                            //AppMetrica.Instance.SendEventsBuffer();
                }
                if (nam == "star3"){
                    GameObject.Find("star1").GetComponent<SpriteRenderer>().color =Color.white;
                    GameObject.Find("star2").GetComponent<SpriteRenderer>().color =Color.white;
                    GameObject.Find("star3").GetComponent<SpriteRenderer>().color =Color.white;
                    Application.OpenURL("https://play.google.com/store/apps/details?id=com.SG.tactic.knight");
                    Destroy(GameObject.Find("RateIt"), 0.4f);
                    numEnemy = 7777;
                                            Dictionary<string, object> parameters = new Dictionary<string, object>();
                                            parameters.Add("star", 3 );
                                            //AppMetrica.Instance.ReportEvent ("RateIt", parameters);
                                            //AppMetrica.Instance.SendEventsBuffer();
                }
                if (nam == "star4"){
                    GameObject.Find("star1").GetComponent<SpriteRenderer>().color =Color.white;
                    GameObject.Find("star2").GetComponent<SpriteRenderer>().color =Color.white;
                    GameObject.Find("star3").GetComponent<SpriteRenderer>().color =Color.white;
                    GameObject.Find("star4").GetComponent<SpriteRenderer>().color =Color.white;
                    Application.OpenURL("https://play.google.com/store/apps/details?id=com.SG.tactic.knight");
                    Destroy(GameObject.Find("RateIt"), 0.4f);
                    numEnemy = 7777;
                                            Dictionary<string, object> parameters = new Dictionary<string, object>();
                                            parameters.Add("star", 4 );
                                            //AppMetrica.Instance.ReportEvent ("RateIt", parameters);
                                            //AppMetrica.Instance.SendEventsBuffer();
                }
                if (nam == "star5"){
                    GameObject.Find("star1").GetComponent<SpriteRenderer>().color =Color.white;
                    GameObject.Find("star2").GetComponent<SpriteRenderer>().color =Color.white;
                    GameObject.Find("star3").GetComponent<SpriteRenderer>().color =Color.white;
                    GameObject.Find("star4").GetComponent<SpriteRenderer>().color =Color.white;
                    GameObject.Find("star5").GetComponent<SpriteRenderer>().color =Color.white;
                    Application.OpenURL("https://play.google.com/store/apps/details?id=com.SG.tactic.knight");
                    Destroy(GameObject.Find("RateIt"), 0.4f);
                    numEnemy = 7777;


                                            Dictionary<string, object> parameters = new Dictionary<string, object>();
                                            parameters.Add("star", 5 );
                                            //AppMetrica.Instance.ReportEvent ("RateIt", parameters);
                                            //AppMetrica.Instance.SendEventsBuffer();
                }


                if (nam == "b_tutorAxies"){
                  Destroy(GameObject.Find("tutor_axies"));
                  numEnemy = 7777;
                }
                if (nam == "b_tutorSword"){
                  Destroy(GameObject.Find("tutor_sword"));
                  numEnemy = 7777;
                }




            }
        }
      }

        if (timer < 1){
            timer += Time.deltaTime*2;
          //  whiteBg.GetComponent<SpriteRenderer>().color = new Color(1,1,1, 1-timer);
            whiteBg.GetComponent<SpriteRenderer>().color = new Color(0.18f,0.56f,0.79f, 1-timer);
          }


        if (numEnemy < 1){
            Destroy(GameObject.Find("b_skipLevel"));
                Destroy(GameObject.Find("b_menu"));
            numEnemy = 9999;
            timer2 = delayWin;
            if (GameObject.Find("Hero")) GameObject.Find("Hero").GetComponent<Controll>().enabled = false;
            GameObject.Find("Canvas").active = false;

                        Dictionary<string, object> parameters = new Dictionary<string, object>();
                        parameters.Add("level_number", level );
                        parameters.Add("level_time (sec)", (int)gameTimer );
                        parameters.Add("level_count", PlayerPrefs.GetInt("numLvlPlayer") );
                        //AppMetrica.Instance.ReportEvent ("level_finish", parameters);
                        //AppMetrica.Instance.SendEventsBuffer();
        }

        if (numEnemy == 9999){
            EndLEvel();
        }

        if (numEnemy == 7777){
            timer3 += Time.deltaTime*2;
          if (timer3 < 1){
                  t_levelNum.GetComponent<TextMesh>().color = new Color(1,1,1, timer3);
                  t_levelText.GetComponent<TextMesh>().color = new Color(1,1,1, timer3);
          }else{
              if (timer3 > 1.3f){
                numEnemy = 7778;
                timer3 = 1;
              }
          }
        }


        if (numEnemy == 7778){
          if (timer3 > 0){
              timer3 -= Time.deltaTime*2;
                  t_levelNum.GetComponent<TextMesh>().color = new Color(1,1,1, timer3);
                  t_levelText.GetComponent<TextMesh>().color = new Color(1,1,1, timer3);
          }else{
              Application.LoadLevel(PlayerPrefs.GetInt("level")+"");
          }
        }
    }


    public void Defeat()
    {
      Destroy(GameObject.Find("Hero"));
      numEnemy = -999;
          win = false;
      //Application.LoadLevel(Application.loadedLevel);
    }



    public void EndLEvel(){
        if (win){
            if (timer2 == delayWin){
                GameObject.Find("s_victory").GetComponent<AudioSource>().Play();
                //GameObject.Find("SystemObject").GetComponent<OnSystemObject>().DoEffect(3, GameObject.Find("endlevelEffect").transform.position);
                PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level")+1);
                if (GameObject.Find("TEXT")) Destroy(GameObject.Find("TEXT"));
                GameObject.Find("SystemObject").GetComponent<OnSystemObject>().EndLevelEffect();
                GameObject.Find("forLevelTimer").SendMessage("EndLevel");
            }
        }else{
            if (timer2 == delayWin){
                GameObject.Find("s_defeat").GetComponent<AudioSource>().Play();
                GameObject.Find("SystemObject").GetComponent<OnSystemObject>().DoEffect(4, GameObject.Find("endlevelEffect").transform.position);
            }
        }



        if (timer2 < 1){
            timer2 += Time.deltaTime;
            whiteBg.GetComponent<SpriteRenderer>().color = new Color(0.18f,0.56f,0.79f, timer2);
          //  whiteBg.GetComponent<SpriteRenderer>().color = new Color(1,1,1, timer2);
          }else{
            if (!win){
               Application.LoadLevel(Application.loadedLevel);
             }else{
                if (level == 5){
                 GameObject.Find("RateIt").transform.localPosition = Vector3.zero;
                }else if (level == 1){
                 GameObject.Find("tutor_axies").transform.localPosition = Vector3.zero;
                }else if(level == 4){
                 GameObject.Find("tutor_sword").transform.localPosition = Vector3.zero;
                }else{
                   numEnemy = 7777;
                }
                t_levelNum.GetComponent<TextMesh>().text = PlayerPrefs.GetInt("level")+"";
             }
          }
    }
}
