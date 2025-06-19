using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class Controll : MonoBehaviour
{
    public int level;
    public bool deadStep;
    private GameObject OnHeroArrow;
    private GameObject Canvass;
    public Vector3 movePos;
    private bool doArrow;
    private bool doArrow2;

    private float moveTimer;
    private float oldRotY;

    public GameObject targetWay;

    private Vector3 startMarker;
    private Vector3 endMarker;
    private float speed = 90.0F;
    private float startTime;
    private float journeyLength;

    public GameObject[] skins;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(GameObject.Find("previewSkin"));

        var skn = Instantiate(skins[PlayerPrefs.GetInt("curSkin")-1], transform.position, transform.rotation);
        skn.transform.parent = transform;
        skn.transform.localScale = new Vector3(3,3,3);
        skn.name = "skinHero";

        OnHeroArrow = GameObject.Find("OnHeroArrow");
            Canvass = GameObject.Find("Canvas");

        GameObject.Find("SystemObject").GetComponent<OnSystemObject>().SetStarsOnPlayer(gameObject, level);
    }

    // Update is called once per frame
    void Update()
    {
      moveTimer += Time.deltaTime;


      if (Input.GetMouseButton(0) && moveTimer > 0){
          doArrow = false;
          OnHeroArrow.transform.position = Vector3.up*999;
          float rotY = 0;

          if (CnInputManager.GetAxis("Vertical") > 0.5f)
          {
              doArrow = true;
              rotY = 0;
          }
          if (CnInputManager.GetAxis("Vertical") < -0.5f)
          {
              doArrow = true;
              rotY = 180;
          }

          if (CnInputManager.GetAxis("Horizontal") > 0.5f)
          {
              doArrow = true;
              rotY = 90;
          }
          if (CnInputManager.GetAxis("Horizontal") < -0.5f)
          {
              doArrow = true;
              rotY = 270;
          }


          if (oldRotY != rotY)  doArrow2 = false;

          if (doArrow){
              doArrow2 = true;
              oldRotY = rotY;
              OnHeroArrow.transform.position = transform.position;
              OnHeroArrow.transform.eulerAngles = new Vector3(0,rotY,0);
              transform.eulerAngles = OnHeroArrow.transform.eulerAngles;
              OnHeroArrow.GetComponent<OnHeroArrow>().BuildPlanes();
          }else{
            doArrow2 = false;

          }
          moveTimer = 0.01f;
      }


            if (Input.GetMouseButtonUp(0) && moveTimer > 0){
                OnHeroArrow.transform.position = Vector3.up*999;
                startTime = Time.time;

                journeyLength = Vector3.Distance(transform.position, movePos);
                startMarker = transform.position;
                if (doArrow2){
                    GameObject.Find("s_slide").GetComponent<AudioSource>().Play();
                    transform.eulerAngles = new Vector3(0,oldRotY,0);
                    moveTimer = -10.3f;
                    Canvass.active = false;
                }
            }


      ////////================   END CONTROLL =================================

      if (moveTimer < 0){
          //transform.position = Vector3.Lerp(transform.position, movePos, Time.deltaTime * 10);
          float distCovered = (Time.time - startTime) * speed;
          float fractionOfJourney = distCovered / journeyLength;
          if (journeyLength > 0.01f) transform.position = Vector3.Lerp(startMarker, movePos, fractionOfJourney);

          if (fractionOfJourney > 0.9f){
              moveTimer = 0.3f;
          }
      }

      if (moveTimer > 0.2f && Canvass.active == false){
              transform.position = movePos;
              doArrow2 = false;
              Canvass.active = true;
              DoAfterSteps();
      }

    }

    void DoAfterSteps(){


      if (targetWay != null){
          if (targetWay.tag == "Enemy"){
             GameObject.Find("SystemObject").GetComponent<OnSystemObject>().DoEffect(1, targetWay.transform.position);
             GameObject.Find("SystemObject").GetComponent<OnSystemObject>().DoEffect(2, targetWay.transform.position);
              if (!deadStep){
                GameObject.Find("s_hit").GetComponent<AudioSource>().Play();
                targetWay.SendMessage("Kill");
               }
          }else if (targetWay.tag == "Weapon"){
              level++;
              Destroy(targetWay);
                  GameObject.Find("s_weapon").GetComponent<AudioSource>().Play();
              GameObject.Find("SystemObject").GetComponent<OnSystemObject>().SetStarsOnPlayer(gameObject, level);
              GameObject.Find("SystemObject").GetComponent<OnSystemObject>().DoEffect(7, transform.position);
          }else if (targetWay.tag == "Lever"){
              GameObject.Find("s_lever").GetComponent<AudioSource>().Play();
              targetWay.GetComponent<OnLever>().DoLever();
          }
      }else{
          GameObject.Find("s_splash").GetComponent<AudioSource>().Play();
          if (deadStep) GameObject.Find("SystemObject").GetComponent<OnSystemObject>().DoEffect(5, transform.position - (Vector3.up*5));
      }


      if (deadStep) Defeat();

    }

    void Defeat(){
      GameObject.Find("GameManager").SendMessage("Defeat");
    }
}
