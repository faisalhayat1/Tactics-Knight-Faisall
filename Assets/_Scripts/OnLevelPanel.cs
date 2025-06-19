using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLevelPanel : MonoBehaviour
{
    public int level;

    public GameObject[] circle;
    public GameObject[] circleText;
    public GameObject line;
    public GameObject curLevel;
    // Start is called before the first frame update
    void Start()
    {
        level = GameObject.Find("GameManager").GetComponent<GameManager>().level;

        int lvlStart = ((int)(level/(5f+0.001f))*5)+1;

        circleText[0].GetComponent<TextMesh>().text =""+ lvlStart;
        circleText[1].GetComponent<TextMesh>().text =""+ (lvlStart +1);
        circleText[2].GetComponent<TextMesh>().text =""+ (lvlStart +2);
        circleText[3].GetComponent<TextMesh>().text =""+ (lvlStart +3);
        circleText[4].GetComponent<TextMesh>().text =""+ (lvlStart +4);

        int curLvl = level-lvlStart;

        circle[0].GetComponent<SpriteRenderer>().color = new Color(0.15f, 0.61f, 0.88f);
        circle[1].GetComponent<SpriteRenderer>().color = new Color(0.15f, 0.61f, 0.88f);
        circle[2].GetComponent<SpriteRenderer>().color = new Color(0.15f, 0.61f, 0.88f);
        circle[3].GetComponent<SpriteRenderer>().color = new Color(0.15f, 0.61f, 0.88f);
        circle[4].GetComponent<SpriteRenderer>().color = new Color(0.15f, 0.61f, 0.88f);

        line.transform.localScale = new Vector3(0.25f*(curLvl), 1,1);

        for(int i = 0; i < curLvl; i++)
        {
            circle[i].GetComponent<SpriteRenderer>().color = new Color(0.75f, 0.91f, 1f);
        }

        circle[curLvl].GetComponent<SpriteRenderer>().color = Color.white;

        curLevel.transform.position = circle[curLvl].transform.position;
    }

}
