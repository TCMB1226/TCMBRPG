using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Master : MonoBehaviour {

    float optionSpacing = 10;
    public GameObject CurrentStage;
    public GameObject Story;
    public GameObject Option0;
    public List<GameObject> options = new List<GameObject>();
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
            clone.GetComponent<Button>().interactable = true;
            var btn = clone.GetComponent<Button>().onClick;
            switch (i)
            {
                case 1:
                    btn.AddListener(delegate { change(1); });
                    break;
                case 2:
                    btn.AddListener(delegate { change(2); });
                    break;
                case 3:
                    btn.AddListener(delegate { change(3); });
                    break;
                case 4:
                    btn.AddListener(delegate { change(4); });
                    break;
                default:
                    btn.AddListener(delegate { change(); });
                    break;
            }
            clone.GetComponent<Button>().onClick.AddListener(delegate { change(i); });
            options.Add(clone);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Updated)
            change();
	}

    public void change(int Dest = 0)
    {
        Debug.Log("Option " + Dest);
        Updated = false;
        var Stage = CurrentStage.GetComponent<Control>();
        CurrentStage = Stage.options[Dest].Destination;
        Stage = CurrentStage.GetComponent<Control>();

        while (options.Count > 0)
        {
            var obj = options[0];
            options.Remove(obj);
            Destroy(obj);
        }

        Story.GetComponent<Text>().text = Stage.Story.ToString();
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
            clone.GetComponent<Button>().interactable = true;
            var btn = clone.GetComponent<Button>().onClick;
            switch (i)
            {
                case 1:
                    btn.AddListener(delegate { change(1); });
                    break;
                case 2:
                    btn.AddListener(delegate { change(2); });
                    break;
                case 3:
                    btn.AddListener(delegate { change(3); });
                    break;
                case 4:
                    btn.AddListener(delegate { change(4); });
                    break;
                default:
                    btn.AddListener(delegate { change(); });
                    break;
            }
            options.Add(clone);
        }

        Debug.Log("Complete");
    }

}
