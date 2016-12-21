using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ActivateController : MonoBehaviour {

    public GameObject player;
    public GameObject interactableObject;

    public InteractableController.ActivateType type;
    PlayerInventoryController pIC;

    public float decayRange;

    private SceneManager SM;
    private List<Transition> transitions;

    void Start() {
        SM = GameObject.Find("SceneManager").GetComponent<SceneManager>();
        pIC = player.GetComponent<PlayerInventoryController>();
    }

    // Update is called once per frame
    void Update() {
        List<Transition> toRem = new List<Transition>();
        foreach (Transition t in transitions) {
            t.update();
            if (t.finished) {
                if (t.fading)
                    t.obj.SetActive(false);
                toRem.Add(t);
            }
        }
        transitions = transitions.Except(toRem).ToList();

        if (StaticMethods.Distance(
            (Vector2)interactableObject.transform.position, 
            (Vector2)player.transform.position) > decayRange) {
            //gameObject.SetActive(false);
            activate(interactableObject);
        } else {
            deactivate(interactableObject);
        }


        if (Input.GetButtonDown("Activate")) {
            gameObject.SetActive(false);
            Activate();
        } else if (Input.GetButtonDown("Deactivate")) {
            gameObject.SetActive(false);
        }
    }

    void activate(GameObject obj) {
        if (obj.activeInHierarchy) return;
        obj.SetActive(false);
        transitions.Add(new Transition(obj, 1));
    }

    void deactivate(GameObject obj) {
        if (!obj.activeInHierarchy) return;
        transitions.Add(new Transition(obj, -1));
    }

    void Activate() {
        switch (type) {
            case InteractableController.ActivateType.TowerDefense:
                if (pIC.isInInventory(InteractableController.ActivateType.ITEM_ARMYFIGURES)) {
                    //Do things to start Tower Defense!
                    SM.MoveToScene(10, pIC.getInventory(), player.transform.position);
                } else {
                    Invalid();
                }
                break;
            case InteractableController.ActivateType.HackAndSlash:
                if (pIC.isInInventory(InteractableController.ActivateType.ITEM_TOYSWORD)) {
                    //Do things to start Hack and Slash!
                    //Debug.Log("Hack and Slash Started!");
                    SM.MoveToScene(11, pIC.getInventory(), player.transform.position);
                } else {
                    Invalid();
                }
                break;
            case InteractableController.ActivateType.Riddle:
                if (pIC.isInInventory(InteractableController.ActivateType.ITEM_TOYSWORD)) {
                    //Do things to start Hack and Slash!
                    //Debug.Log("Hack and Slash Started!");
                    SM.MoveToScene(9, pIC.getInventory(), player.transform.position);
                } else {
                    Invalid();
                }
                break;
            case InteractableController.ActivateType.HideAndSeek:
                if (pIC.isInInventory(InteractableController.ActivateType.ITEM_TREAT)) {
                    //Do things to start Hide and Seek!
                    SM.MoveToScene(12, pIC.getInventory(), player.transform.position);
                } else {
                    Invalid();
                }
                break;
            case InteractableController.ActivateType.OperationMaze:
                if (pIC.isInInventory(InteractableController.ActivateType.ITEM_MASK)) {
                    //Do things to start Operation: Maze!
                    SM.MoveToScene(8, pIC.getInventory(), player.transform.position);
                } else {
                    Invalid();
                }
                break;
            case InteractableController.ActivateType.Racing:
                if (pIC.isInInventory(InteractableController.ActivateType.ITEM_MODELBOAT)) {
                    //Do things to start Racing!
                    SM.MoveToScene(3, pIC.getInventory(), player.transform.position);

                } else {
                    Invalid();
                }
                break;
            case InteractableController.ActivateType.Rhythm:
                if (pIC.isInInventory(InteractableController.ActivateType.ITEM_DRUMSTICKS)) {
                    //Do things to start Rhythm!
                    SM.MoveToScene(4, pIC.getInventory(), player.transform.position);
                } else {
                    Invalid();
                }
                break;
            case InteractableController.ActivateType.PuzzlePlatformer:
                if (pIC.isInInventory(InteractableController.ActivateType.ITEM_SHOES)) {
                    //Do things to start Puzzle Platformer!
                    SM.MoveToScene(2, pIC.getInventory(), player.transform.position);

                } else {
                    Invalid();
                }
                break;
            case InteractableController.ActivateType.Asteroids:
                if (pIC.isInInventory(InteractableController.ActivateType.ITEM_BUGSPRAY)) {
                    //START ASTEROIDS
                    SM.MoveToScene(7, pIC.getInventory(), player.transform.position);
                } else {
                    Invalid();
                }
                break;
            case InteractableController.ActivateType.BrickBreaker:
                if (pIC.isInInventory(InteractableController.ActivateType.ITEM_BATTERIES)) {
                    // START BRICK BREAKER
                    SM.MoveToScene(6, pIC.getInventory(), player.transform.position);
                } else {
                    Invalid();
                }
                break;
            case InteractableController.ActivateType.DuckHunt:
                if (pIC.isInInventory(InteractableController.ActivateType.ITEM_SLINGSHOT)) {
                    SM.MoveToScene(1, pIC.getInventory(), player.transform.position);
                } else {
                    Invalid();
                }
                break;
            case InteractableController.ActivateType.TicTacToe:
                if (pIC.isInInventory(InteractableController.ActivateType.ITEM_PEN)) {
                    SM.MoveToScene(5, pIC.getInventory(), player.transform.position);
                } else {
                    Invalid();
                }
                break;
            default:
                if ((int)type > InteractableController.ITEM_START - 1) {
                    pIC.setInventoryActive(type);
                    Debug.Log(interactableObject);
                    interactableObject.SetActive(false);
                }
                break;
        }
    }

    //Tell the player that they need an item.
    void Invalid() {

    }
}

public class Transition {

    public GameObject obj;
    float time, totTime = 1;
    int direction;

    private SpriteRenderer sr;
    private Color startColor;

    public bool finished { get { return time >= totTime; } }
    public bool fading { get { return direction < 0; } }

    public Transition(GameObject obj, int direction) {
        this.obj = obj;
        this.direction = direction;
        sr = obj.GetComponent<SpriteRenderer>();
    }

    public void update() {
        time += Time.deltaTime;

        Color finalColor;
        if (direction < 0) {
            finalColor = new Color(255, 255, 255, 0);
        } else {
            finalColor = new Color(255, 255, 255, 255);
        }
        sr.color = blendColors(time, 0, totTime, sr.color, finalColor);
    }

    
    /**
	 * linearly interpolates the RGB values of the two colors with relation to time
	 * @param t the current time; if outside the parameters start and end, the value is constained automatically
	 * @param start initial time
	 * @param end maximum time
	 * @param first the beginning color
	 * @param last the final color
	 * @return the mixed color; if either color is null, the resulting color is the instantiated one. 
	 * If both are null, the resulting color is Color.WHITE, with RGBA values of 255
	 */
    public static Color blendColors(float t, float start, float end, Color first, Color last) {
        if (first == null || last == null) {
            if (first == null && last == null)
                return Color.white;
            if (first == null)
                return last;
            return first;
        }

        //bounds validation
        if (t > end) t = end;
        if (t < start) t = start;

        //slope calculation
        float mr = (last.r - first.r) / (float)(end - start);
        float mg = (last.g - first.g) / (float)(end - start);
        float mb = (last.b - first.b) / (float)(end - start);
        float ma = (last.a - first.a) / (float)(end - start);

        //interpolation
        return new Color(
                mr * (t - start) + first.r,
                mg * (t - start) + first.g,
                mb * (t - start) + first.b,
                ma * (t - start) + first.a);
    }

}
