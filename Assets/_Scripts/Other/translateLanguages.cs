using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class translateLanguages : MonoBehaviour
{
    public string rus;
    /*public string spain;
    public string thai;
    public string india;*/

    public bool canvass;
    // Start is called before the first frame update
    void Start()
    {
        var lang = Application.systemLanguage;
        string newtext = "";


        if (lang == SystemLanguage.Russian && rus != "") newtext = rus;


        if (newtext != "")
        {
            if (canvass == false)
            {
                GetComponent<TextMesh>().text = rus;

                var TextScript = gameObject.GetComponent<TextMesh>();
                var texts = TextScript.text.Replace("\\n","\n");
                texts = TextScript.text.Replace("*","\n");
                TextScript.text = texts;
            }
            else
            {
                GetComponent<Text>().text = rus;

                var TextScript = gameObject.GetComponent<Text>();
                var texts = TextScript.text.Replace("\\n","\n");
                texts = TextScript.text.Replace("*","\n");
                TextScript.text = texts;
            }
        }
    }
}
