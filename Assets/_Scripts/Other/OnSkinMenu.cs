using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSkinMenu : MonoBehaviour
{

    public GameObject circle;
    public GameObject text;
    public int scoreUnlock;

    // Start is called before the first frame update
    void Start()
    {

        if (scoreUnlock <= PlayerPrefs.GetInt("score")){
          Destroy(text);
          circle.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.5f);
          gameObject.tag = "Button";
        }else{
          text.GetComponent<TextMesh>().text = scoreUnlock+"";
          circle.GetComponent<SpriteRenderer>().color = new Color(1,0,0,0.5f);
        }

        if (gameObject.name == "1"){
            Destroy(text);
            circle.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.5f);
            gameObject.tag = "Button";
        }

        if (PlayerPrefs.GetInt("curSkin") == int.Parse(gameObject.name)){
            circle.GetComponent<SpriteRenderer>().color = new Color(0,1,0,0.5f);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
