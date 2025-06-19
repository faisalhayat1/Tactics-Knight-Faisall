using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSystemObject : MonoBehaviour
{
    public GameObject[] effect;

    void Awake(){
      var go = GameObject.Find("levelTimerObject");
      go.transform.parent = GameObject.Find("GUI").transform;
      go.transform.localPosition = Vector3.zero;

    }
    // Start is called before the first frame update
    public void DoEffect(int num, Vector3 pos)
    {

        var ef = Instantiate(effect[num], pos, effect[num].transform.rotation);
    }

    // Update is called once per frame
    public void SetStarsOnPlayer( GameObject go, int level)
    {
        Destroy(GameObject.Find(go.name+"Stars"));
      var ef = Instantiate(effect[6], go.transform.position, effect[6].transform.rotation);
        ef.name = go.name+"Stars";
        //ef.transform.parent = go.transform;
        ef.GetComponent<OnPlayerStar>().SetStars(go, level);
    }


    public void ShowMenu(int num)
    {
        GameObject go = GameObject.Find("GUI");
        var ef = Instantiate(effect[num], go.transform.position, effect[num].transform.rotation);
        ef.transform.parent = go.transform;
        ef.transform.localPosition = Vector3.zero;
        ef.transform.localEulerAngles = Vector3.zero;
    }


        public void EndLevelEffect()
        {
            GameObject go = Camera.main.gameObject;
            var ef = Instantiate(effect[10], go.transform.position, effect[10].transform.rotation);
            ef.transform.parent = go.transform;
            ef.transform.localPosition = Vector3.zero;
            ef.transform.localEulerAngles = Vector3.zero;
        }
}
