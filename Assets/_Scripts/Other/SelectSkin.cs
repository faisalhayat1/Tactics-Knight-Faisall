using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSkin : MonoBehaviour
{
    private float timer;
    public GameObject whiteBg;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      RaycastHit hit;
      if (Input.GetMouseButtonDown(0)){
        if (Physics.Raycast(ray, out hit, 100)){
            if (hit.collider.tag == "Button"){
                PlayerPrefs.SetInt("curSkin", int.Parse(hit.collider.gameObject.name));
                timer = 0.01f;
            }
        }
      }


      if (timer > 0){
          timer += Time.deltaTime;

          whiteBg.GetComponent<SpriteRenderer>().color = new Color(0.18f,0.56f,0.79f, timer);
          if (timer > 1){
              Application.LoadLevel(PlayerPrefs.GetInt("level")+"");
          }
      }
    }
}
