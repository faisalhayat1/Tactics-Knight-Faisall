using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLever : MonoBehaviour
{
    public GameObject targetLever;
    // Start is called before the first frame update
    public void DoLever()
    {
        Destroy(this);
        if (targetLever) targetLever.GetComponent<OnLeverTarget>().numLever -= 1;
        transform.eulerAngles = new Vector3(0,0,-90);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
