using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAttentionIcon : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("level") > 3 && PlayerPrefs.GetInt("att") == 0){

        }else{
          Destroy(gameObject);
        }

        if (PlayerPrefs.GetInt("level") >20  && PlayerPrefs.GetInt("att") == 0){
          Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
