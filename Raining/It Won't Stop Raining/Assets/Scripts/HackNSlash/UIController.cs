using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Sprite heart_full, heart_empty;

    private Player player;

    void Start () {
        player = GameObject.Find("Player").GetComponent<Player>();
	}
	
	void Update () {
        for (int i = 0; i < 8; i++)
        {
            Image heart = GameObject.Find("Heart_" + i).GetComponent<Image>();
            heart.sprite = player.health > i ? heart_full : heart_empty;
        }
    }
}
