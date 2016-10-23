using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public float spawnRange = 5;
    public float waveCooldown = 3f;
    public Monster furnace, ghost;

    [HideInInspector]
    public int monstersLeft = 0;

    private GameObject player;
    private Monster[][] waves;
    private int wave = 0;
    private float waveTimer = 0f;


    // Use this for initialization
    void Start() {
        player = GameObject.Find("Player");
        waves = new Monster[][]
        {
            new Monster[] {ghost, ghost, ghost},
            new Monster[] {furnace, ghost, furnace},
            new Monster[] {furnace, furnace, furnace, ghost, ghost, ghost},
            new Monster[] {ghost, ghost, ghost, ghost, ghost, ghost, ghost, ghost},
        };
    }

    // Update is called once per frame
    void Update() {
        if (waveTimer == 0)
        {
            print("Wave " + wave);
            waveTimer = -1;
            foreach (Monster monster in waves[wave])
            {
                Spawn(monster);
            }
            monstersLeft = waves[wave].Length;
            wave++;
            if (wave == waves.Length)
            {
                print("You win!!1");
            }
        }
        else if (waveTimer == -1 && monstersLeft == 0 && wave < waves.Length)
        {
            print("Start Countdown");
            waveTimer = waveCooldown;
        }
        else if (waveTimer > 0)
        {
            waveTimer = Mathf.Max(waveTimer - Time.deltaTime, 0);
        }
    }

    void Spawn(Monster monster)
    {
        Vector2 pos = Random.insideUnitCircle * spawnRange + (Vector2) player.transform.position;
        Instantiate(monster, pos, new Quaternion());
    }
}
