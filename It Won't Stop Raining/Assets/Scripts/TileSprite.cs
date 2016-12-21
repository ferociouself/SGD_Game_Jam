using UnityEngine;
using System.Collections;

// @NOTE the attached sprite's position should be "top left" or the children will not align properly
// Strech out the image as you need in the sprite render, the following script will auto-correct it when rendered in the game
[RequireComponent(typeof(SpriteRenderer))]

// Generates a nice set of repeated sprites inside a streched sprite renderer
// @NOTE Vertical only, you can easily expand this to horizontal with a little tweaking
public class TileSprite : MonoBehaviour {
    public Axis direction = Axis.Horizontal;

    public enum Axis { Horizontal, Vertical, Both }

    private Vector2 scale, spriteSize;
    private SpriteRenderer sr;

    void Awake() {
        // Get the current sprite with an unscaled size
        sr = GetComponent<SpriteRenderer>();
        scale = transform.localScale;
        spriteSize = new Vector2(sr.bounds.size.x / transform.localScale.x,
            sr.bounds.size.y / transform.localScale.y);
        transform.localScale = new Vector3(1, 1, 1);

        // Generate a child prefab of the sprite renderer
        GameObject childPrefab = new GameObject();
        SpriteRenderer childSprite = childPrefab.AddComponent<SpriteRenderer>();
        childPrefab.transform.position = transform.position;
        childSprite.sprite = sr.sprite;
        childPrefab.transform.localScale = new Vector3(1, 1, 1);
        childPrefab.name = gameObject.name + "_Tiled ";
        childSprite.sortingOrder = -2;
        
        // Loop through and spit out repeated tiles
        GameObject child;
        if (direction != Axis.Horizontal) {
            for (int i = 1, l = (int)Mathf.Round(scale.y); i < l; i++) {
                child = Instantiate(childPrefab) as GameObject;
                child.transform.position = transform.position - (new Vector3(0, spriteSize.y * i, 0));
                child.transform.parent = transform;
            }
        } if( direction != Axis.Vertical) { 
            for (int i = 1, l = (int)Mathf.Round(scale.x); i < l; i++) {
                child = Instantiate(childPrefab) as GameObject;
                child.transform.position = transform.position - (new Vector3(spriteSize.x * i, 0, 0));
                child.transform.parent = transform;
            }
        }

        // Set the parent last on the prefab to prevent transform displacement
        childPrefab.transform.parent = transform;

        // Disable the currently existing sprite component since its now a repeated image
        sr.enabled = false;
    }
}