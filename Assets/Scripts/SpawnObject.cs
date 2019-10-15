using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public float maxHeight;
    public float minHeight;

    public float rateSpawn;
    private float currentSpawn;
    public int maxBloco;

    public GameObject prefab;
    private float randomPosition;
    public List<GameObject> bloco;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxBloco; i++) {
            GameObject tempBloco = Instantiate(prefab) as GameObject; 
            bloco.Add(tempBloco);
            tempBloco.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentSpawn += Time.deltaTime;
        
        if(currentSpawn > rateSpawn) {
            currentSpawn = 0;
            SpawnBlocos();
            
        }
    }
    private void SpawnBlocos () {
        int randPosition = Random.Range (0, 11);
        if (randPosition <= 5) {
            randomPosition = minHeight;
        } else {
            randomPosition = maxHeight;
        }
        GameObject tempBloco = null;

        for (int i = 0; i < maxBloco; i++) {
            if (bloco[i].activeSelf == false) {
                tempBloco = bloco[i];
                break;
            }
        }
        if (tempBloco != null) {
            tempBloco.transform.position = new Vector3(transform.position.x, randomPosition, transform.position.z);
            tempBloco.SetActive(true);
        }


    }
}
