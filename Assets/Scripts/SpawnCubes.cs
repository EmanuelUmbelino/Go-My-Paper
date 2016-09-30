using UnityEngine;
using System.Collections;

public class SpawnCubes : MonoBehaviour {

    // distancia do spawn
    private int ds;
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private Transform player;

    // Use this for initialization
    void Start () {
        ds = 40;
        Invoke("Spawn", 1);
	}
	void Update()
    {
        this.transform.position = new Vector3(player.position.x, player.position.y, 90);
    }
	// Update is called once per frame
	void Spawn () {
        Vector3 posEnemy = new Vector3(this.transform.position.x + Random.Range(-ds, ds), this.transform.position.y + Random.Range(-ds, ds), this.transform.position.z);
        GameObject enemy = (GameObject) GameObject.Instantiate(enemyPrefab, posEnemy, enemyPrefab.transform.rotation);
        Invoke("Spawn", Random.Range(1, 200)/100);
    }
}
