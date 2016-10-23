using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {
   
    public InputField input;
    public Button button;
    public Text answer;
    public Text reward;

	// Use this for initialization
	void Start () {
        button.onClick.AddListener(() => { handler(); });

	}
	
    //When the button is clicked, compare the text in the input field to the text in the answer text box. If they are equal, change the text in the reward text box to "you got it!"
    void handler()
    {
        if (input.text.Equals(answer.text))
            {
                reward.text = "You got it!";
				SceneManager SM = GameObject.Find ("SceneManager").GetComponent<SceneManager>();
				SM.MoveToScene (0);
            }
            else
            {
                reward.text = "Not quite. Make sure to not capitalize.";
            }
        
    }


	// Update is called once per frame
	void Update ()
    {
	    
	}
}
