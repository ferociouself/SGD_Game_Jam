using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClickTest : MonoBehaviour {
    
    public Button tower;
    public Toggle[] toggles;
    bool[] values = { true, false, false };
    public void Start()
    {
        toggles[0].onValueChanged.AddListener((value) => { setvalue1(value); });
        toggles[1].onValueChanged.AddListener((value) => { setvalue2(value); });
        toggles[2].onValueChanged.AddListener((value) => { setvalue3(value); });
    }

    public void setvalue1(bool value)
    {
        values[0] = value;
    }

    public void setvalue2(bool value)
    {
        values[1] = value;
    }

    public void setvalue3(bool value)
    {
        values[2] = value;
    }

	public void onClick(Sprite img)
    {
        if (values[0] == true)
        {
           
            tower.GetComponent<Image>().sprite = img;
        }
    }
    public void onClick2(Sprite img)
    {
        if (values[1] == true)
        {
            
            tower.GetComponent<Image>().sprite = img;
        }
    }
    public void onClick3(Sprite img)
    {
        if (values[2] == true)
        {
            
            tower.GetComponent<Image>().sprite = img;
        }
    }
}
