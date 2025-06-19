using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnvironments : MonoBehaviour
{
    public int numDecor;

        public Material[] decor1;
        public Material[] decor2;
        public Material[] decor3;
        public Material[] decor4;
    // Start is called before the first frame update
    void Start()
    {
        if (numDecor != 0){
          Transform blocks = transform;

          foreach (Transform tr in transform){
            if (tr.name == "Blocks") blocks = tr;
          }

          foreach (Transform tr in blocks.transform){
              tr.eulerAngles = new Vector3(-90, 90 * Random.Range(0,4), 0);
              int rnd = Random.Range(0,2);
              if (rnd == 1) rnd = Random.Range(0,2);
              if (rnd == 1) rnd = Random.Range(0,3);

              if (numDecor == 1) tr.GetComponent<MeshRenderer>().material = decor1[rnd];
              if (numDecor == 2) tr.GetComponent<MeshRenderer>().material = decor2[rnd];
              if (numDecor == 3) tr.GetComponent<MeshRenderer>().material = decor3[rnd];
              if (numDecor == 4) tr.GetComponent<MeshRenderer>().material = decor4[rnd];
          }
        }
    }

}
