using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLocalEuler : MonoBehaviour
{
    public float speed;
    public Vector3 Vector;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector = new Vector3(0,0, Vector.z+(Time.deltaTime * speed));
        transform.localEulerAngles =Vector;
    }
}
