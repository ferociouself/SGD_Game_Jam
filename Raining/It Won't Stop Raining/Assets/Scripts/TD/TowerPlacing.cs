using UnityEngine;
using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;

public class TowerPlacing : MonoBehaviour
{
    public Button[] towerSlots;
    public Toggle[] towerSelect;
    public int onID;
    //BoxCollider2D[] towerSlots;
    //BoxCollider2D[] buttons;
    GameObject towerIDTracker;
    //int towerID;
    ////int goldCount;
	// Use this for initialization

	float timer;

	void Start ()
    {
        onID = -1;
        //towerSlots = new Button[24];
        //towerSelect = new Toggle[3];
        towerSelect[0].name = "Lego";
        towerSelect[1].name = "Care Bear";
        towerSelect[2].name = "Play Doh";
        for (int i = 0; i < towerSelect.Length; i++)
        {
            //towerSelect[i].onValueChanged.AddListener(() => { towerPick(); });
        }
        for (int i = 0; i < towerSlots.Length; i++)
        {
            towerSlots[i].onClick.AddListener(() => { towerAppear(); });
        }
        //towerSlots = new BoxCollider2D[24];
        //buttons = new BoxCollider2D[3];
        towerIDTracker = new GameObject();
        onID = Int32.Parse(towerIDTracker.GetComponent<TextMesh>().text);

		timer = 0.00f;
	}

    public void setSprite(GameObject tower, Sprite img)
    {
        tower.GetComponent<Image>().sprite = img;
    }

    void towerPick()
    {
        if(name.Equals("Lego"))
        {
            onID = 0;
        }
        else if (name.Equals("Care Bear"))
        {
            onID = 1;
        }
        else if (name.Equals("Play Doh"))
        {
            onID = 2;
        }
    }

    void towerAppear()
    {
        //if (onID == 0)
        //{
        //    towerSlots.Sprite = Resources.Load("Sprites/TD/Lego", typeof(Sprite));
        //}
        //else if (onID == 1)
        //{
        //    Sprite = Resources.Load("Sprites/TD/e6vv");
        //}
        //else if (onID == 2)
        //{
        //    Sprite = Resources.Load("Sprites/TD/Play Doh");
        //}
    }

    //void OnMouseDown()
    //{

    //    GameObject tested = this.gameObject;
    //    if (tested.GetComponent<SpriteRenderer>().sprite.name.Equals(("Lego")))
    //    {
    //        //if (goldCount >= 5)
    //        {
    //            towerID = 1;
    //        }
    //    }
    //    else if (tested.GetComponent<SpriteRenderer>().sprite.name.Equals("e6vv"))
    //    {
    //        //if (goldCount >= 10)
    //        {
    //            towerID = 2;
    //        }
    //    }
    //    else if (tested.GetComponent<SpriteRenderer>().sprite.name.Equals(("Lego")))
    //    {
    //        //if (goldCount >= 7)
    //        {
    //            towerID = 3;
    //        }
    //    }
    //    else
    //    {
    //        if (towerID > 0)
    //        {
    //            if (towerID == 1)
    //            {
    //                Sprite newSprite = (Sprite)Resources.Load("Materials/Sprites/TD/Lego");
    //                tested.GetComponent<SpriteRenderer>().sprite = newSprite;
    //                //goldCount -= 5;
    //            }
    //            else if (towerID == 2)
    //            {
    //                Sprite newSprite = (Sprite)Resources.Load("Materials/Sprites/TD/e6vv");
    //                tested.GetComponent<SpriteRenderer>().sprite = newSprite;
    //                //goldCount -= 10;
    //            }
    //            else if (towerID == 3)
    //            {
    //                Sprite newSprite = (Sprite)Resources.Load("Materials/Sprites/TD/Play Doh");
    //                tested.GetComponent<SpriteRenderer>().sprite = newSprite;
    //                //goldCount -= 7;
    //            }
    //            towerID = 0;
    //        }
    //    }
    //}


	// Update is called once per frame
	void Update ()
    {
		timer += Time.deltaTime;

		if (timer >= 60.00f) {
			SceneManager SM = GameObject.Find ("SceneManager").GetComponent<SceneManager>();
			SM.MoveToScene (0);
		}
	}
}
