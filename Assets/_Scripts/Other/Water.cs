using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 endPos;

        private int trigger;
        private float timer;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        endPos = startPos + Vector3.up;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (trigger == 0){
          transform.position = Vector3.Lerp(transform.position, endPos, Time.deltaTime);
        }else{
          transform.position = Vector3.Lerp(transform.position, startPos, Time.deltaTime);
        }

        if (timer> 2){
          timer = 0;
          trigger = 1 - trigger;
        }

    }
}
