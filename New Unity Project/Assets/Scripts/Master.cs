using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Master : MonoBehaviour {

    float optionSpacing = 10;
    public GameObject CurrentStage;
    public GameObject Story;
    public GameObject Option0;
    private List<GameObject> options = new List<GameObject>();
    public bool Updated;
    

	// Use this for initialization
	void Start () {
        var Stage = CurrentStage.GetComponent<Control>();
        Story.GetComponent<Text>().text = Stage.Story;
        optionSpacing += Option0.GetComponent<RectTransform>().rect.height;
        for (int i = 0; i < Stage.options.Capacity ; i++)
        {
            GameObject clone;
            clone = Instantiate(Option0, Option0.transform.parent) as GameObject;
            clone.transform.position = Option0.transform.position;
            clone.name = "Option" + i;
            var clonepos = clone.GetComponent<RectTransform>().anchoredPosition;
            clone.GetComponent<RectTransform>().anchoredPosition = new Vector2(clonepos.x, clonepos.y - optionSpacing * i);
            clone.GetComponent<Text>().text = Stage.options[i].text;
            options.Add(clone);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Updated)
            changed();
	}

    public void changed()
    {
        Updated = false;
        while (options.Count > 0)
        {
            var obj = options[0];
            options.Remove(obj);
            
        }

        var Stage = CurrentStage.GetComponent<Control>();
        Story.GetComponent<Text>().text = Stage.Story;
        for (int i = 0; i < Stage.options.Capacity; i++)
        {
            GameObject clone;
            clone = Instantiate(Option0) as GameObject;
            clone.transform.SetParent(Option0.transform.parent);
            clone.transform.position = Option0.transform.position;
            clone.name = "Option" + i;
            var clonepos = clone.GetComponent<RectTransform>().anchoredPosition;
            clone.GetComponent<RectTransform>().anchoredPosition = new Vector2(clonepos.x, clonepos.y - optionSpacing * i);
            clone.GetComponent<Text>().text = Stage.options[i].text;
        }
    }

}
