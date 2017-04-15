using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class Control : MonoBehaviour {

    [System.Serializable]
    public class Options
    {
        public string text;
        public GameObject Destination;
    }

    public string Story;
    public List<Options> options = new List<Options>();

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update () {
	}
}
