using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHeroArrow : MonoBehaviour
{

    private int numPlane;

    private GameObject sky;
    private GameObject notkill;
    private GameObject kill;
    private GameObject Hero;
    // Start is called before the first frame update
    void Start()
    {
        numPlane = 1;
        sky = GameObject.Find("sky");
        notkill = GameObject.Find("notkill");
        kill = GameObject.Find("kill");
        Hero = GameObject.Find("Hero");

        transform.position = Vector3.up*999;

    }

    void Update(){

    }

    // Update is called once per frame
    public void BuildPlanes()
    {
        GameObject temp;
        bool none = false;

        sky.transform.Translate(Vector3.up*999);
        notkill.transform.Translate(Vector3.up*999);
        kill.transform.Translate(Vector3.up*999);

        Hero.GetComponent<Controll>().targetWay = null;
        Hero.GetComponent<Controll>().deadStep = false;

        for(int i = 1; i < 16; i++)
        {
          temp = GameObject.Find(""+i);
            temp.transform.localPosition = new Vector3(0, 0.1f, i*5);

          Vector3 down = temp.transform.TransformDirection(Vector3.forward);
          RaycastHit hit;
          if (!none){
              if (Physics.Raycast(temp.transform.position + (Vector3.up*10), down, out hit)){
                  if (hit.collider.tag == "Enemy"){
                    CheckKill(hit.collider.gameObject, temp.transform.localPosition);
                    none = true;

                    Hero.GetComponent<Controll>().movePos = new Vector3(temp.transform.position.x, 0 , temp.transform.position.z);
                    temp.transform.localPosition = new Vector3(0, 0.1f, 999);
                  }else if (hit.collider.tag == "Wall") {
                    none = true;

                    Hero.GetComponent<Controll>().movePos = new Vector3(GameObject.Find(""+(i-1)).transform.position.x, 0 , GameObject.Find(""+(i-1)).transform.position.z);
                    temp.transform.localPosition = new Vector3(0, 0.1f, 999);

                    Hero.GetComponent<Controll>().deadStep = false;
                    Hero.GetComponent<Controll>().targetWay = hit.collider.gameObject;


                  }else if (hit.collider.tag == "Weapon"){
                    none = true;
                    Hero.GetComponent<Controll>().targetWay = hit.collider.gameObject;
                    kill.transform.localPosition = temp.transform.localPosition;

                    Hero.GetComponent<Controll>().movePos = new Vector3(temp.transform.position.x, 0 , temp.transform.position.z);
                    temp.transform.localPosition = new Vector3(0, 0.1f, 999);

                  }else if (hit.collider.tag == "Lever"){
                    none = true;
                    Hero.GetComponent<Controll>().targetWay = hit.collider.gameObject;
                    kill.transform.localPosition = temp.transform.localPosition;

                    Hero.GetComponent<Controll>().movePos = new Vector3(temp.transform.position.x, 0 , temp.transform.position.z);
                    temp.transform.localPosition = new Vector3(0, 0.1f, 999);
                  }

              }else{
                  Hero.GetComponent<Controll>().movePos = new Vector3(temp.transform.position.x, 0 , temp.transform.position.z);
                  sky.transform.position = temp.transform.position;
                  none = true;
                  temp.transform.localPosition = new Vector3(0, 0.1f, 999);

                  Hero.GetComponent<Controll>().deadStep = true;
                  Hero.GetComponent<Controll>().targetWay = null;
              }
          }else{
              temp.transform.localPosition = new Vector3(0, 0.1f, 999);
          }

        }
    }

    void CheckKill(GameObject hit, Vector3 Pos){
        Hero.GetComponent<Controll>().targetWay = hit;

        if (hit.GetComponent<OnEnemy>().level <= Hero.GetComponent<Controll>().level ){
            kill.transform.localPosition = Pos;
        }else{
            Hero.GetComponent<Controll>().deadStep = true;
            notkill.transform.localPosition = Pos;
        }
    }
}
