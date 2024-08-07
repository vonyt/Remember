using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOneSpawn : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] AlienPlayerTwo player;
    bool called = false;
    public Transform enemySpawn;

    Rigidbody2D rb2;
    void Update(){
        if((PointsAccessor.points == 5 && called == false) || (PointsAccessor.points > 5 && called == false)) {
            StartCoroutine(EnemyLines());
            called = true;
        }
    }

    public IEnumerator EnemyLines(){
        int i = 0;
        List<GameObject> lineEnemies = new List<GameObject>();
        while(i < 10){
            GameObject enemyInstance = Instantiate(enemyPrefab, enemySpawn.position, enemySpawn.rotation);
            lineEnemies.Add(enemyInstance);
            StartCoroutine(MoveEnemy(enemyInstance));
            yield return new WaitForSeconds(2.0f);
            i++;
        }
        yield return null;
    }


    private IEnumerator MoveEnemy(GameObject enemy){
        float move = 0f;
        Rigidbody2D rb2 = enemy.GetComponent<Rigidbody2D>();
        if(rb2 == null) yield break;
        while (move < 10.0f){
            if(enemy == null) yield break;
            rb2.velocity = Vector2.right * 2.0f;
            move += Time.deltaTime;
            yield return null;
        }
        
    }
}
