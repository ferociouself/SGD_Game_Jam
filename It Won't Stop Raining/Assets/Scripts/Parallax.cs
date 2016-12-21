using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {

    public float smoothing = 1;
    public Transform[] bgs;

    private float[] parallaxScales;
    private Transform cam;
    private Vector3 prevCamPos;

    void Awake() {
        cam = Camera.main.transform;
    }
    
	void Start () {
        prevCamPos = cam.position;
        parallaxScales = new float[bgs.Length];
        for (int i = 0; i < bgs.Length; i++)
            parallaxScales[i] = bgs[i].position.z * -1;
    }
	
	void Update () {
        for (int i = 0; i < bgs.Length; i++) {
            Vector3 loc = bgs[i].position;
            Vector2 p = new Vector2((prevCamPos.x - cam.position.x) * parallaxScales[i],
                (prevCamPos.y - cam.position.y) * parallaxScales[i]);
            Vector3 pos = new Vector3(loc.x + p.x, loc.y + p.y, loc.z);
            bgs[i].position = Vector3.Lerp(bgs[i].position, pos, smoothing * Time.deltaTime);
        }
        prevCamPos = cam.position;
    }
}
