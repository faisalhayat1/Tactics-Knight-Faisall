using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnemy : MonoBehaviour
{
    public int level;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().numEnemy += 1;
        GameObject.Find("SystemObject").GetComponent<OnSystemObject>().SetStarsOnPlayer(gameObject, level);
    }

    // Update is called once per frame
    public void Kill()
    {
      GameObject.Find("GameManager").GetComponent<GameManager>().numEnemy -= 1;
          Destroy(gameObject);
    }
}
