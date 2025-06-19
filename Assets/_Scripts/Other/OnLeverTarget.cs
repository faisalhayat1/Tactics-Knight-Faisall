using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLeverTarget : MonoBehaviour
{

    public int numLever;

    public bool boomAndWather;

    public GameObject destroyToo;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (numLever <= 0){

          if (boomAndWather) GameObject.Find("SystemObject").GetComponent<OnSystemObject>().DoEffect(5, transform.position);
          if (destroyToo != null){
            if (destroyToo.tag == "Enemy"){
              destroyToo.SendMessage("Kill");
            }else{
              Destroy(destroyToo);
            }
          }

          Destroy(gameObject);
        }
    }
}
