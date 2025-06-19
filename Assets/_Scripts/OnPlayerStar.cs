using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerStar : MonoBehaviour
{
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    private GameObject target;
    // Start is called before the first frame update

    public void SetStars(GameObject targ, int num)
    {
      num++;
      target = targ;
      if (num == 1){
        Destroy(star2);
        Destroy(star3);
      }
      if (num == 2){
        Destroy(star1);
        Destroy(star3);
      }
      if (num == 3){
        Destroy(star2);
        Destroy(star1);
      }

    }

    void Update(){
        if (target){
            transform.position = target.transform.position;
        }else{
            Destroy(gameObject);
        }
    }
}
