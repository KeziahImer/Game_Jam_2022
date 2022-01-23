using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public Vector2 pos;
    public GameObject enemy;
    public int wave = 1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) {
            for (int i = 0; i < wave; i++) {
                SpawnMob();
            }
            wave += 1;
        }
    }

    public void SpawnMob()
    {
        GameObject tmp = Instantiate(enemy, pos, Quaternion.identity, transform);
        tmp.GetComponent<EnemyGFX>().SetSpeed(3f);
        Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();

        GameObject tmp2 = Instantiate(enemy, pos, Quaternion.identity, transform);
        tmp2.GetComponent<EnemyGFX>().SetSpeed(3f);
        Rigidbody2D rb2 = enemy.GetComponent<Rigidbody2D>();
    }
}
