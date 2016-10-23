using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToggleReactor : MonoBehaviour {
    public Toggle toggleBox;
    public int counter;
    // Use this for initialization
    void Start()
    {
        counter = 0;
        toggleBox.onValueChanged.AddListener((value) => { getOn(); });
    }

    public bool getOn() 
    {
        counter++;
        if (counter % 2 == 1)
        {
            return true;
        }
        return false;

    }

    

	// Update is called once per frame
	void Update () {
	
	}
}
