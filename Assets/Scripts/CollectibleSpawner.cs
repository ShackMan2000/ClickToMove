using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    /// <summary>
    /// Spawn collectibles at start
    /// save in pool on pick up
    /// </summary>
    /// 

    [SerializeField] Collectible collectiblePrefab;
    [SerializeField] List<CollectibleStack> collectiblesToSpawn;

    [SerializeField] float spawnRange;
    [SerializeField] float spawnHeight;

    static Dictionary<CollectibleInfo, List<Collectible>> inactiveCollectibles;




    private void Awake()
    {
        CreateCollectiblePools();
        SpawnCollectibles();
    }

    private void OnEnable()
    {
        Collectible.OnCollected += ReturnToPool;
    }


    void CreateCollectiblePools()
    {
        inactiveCollectibles = new Dictionary<CollectibleInfo, List<Collectible>>();

        foreach (var stack in collectiblesToSpawn)
        {
            inactiveCollectibles.Add(stack.Info, new List<Collectible>());
        }
    }


    private void SpawnCollectibles()
    {
        foreach (var stack in collectiblesToSpawn)
        {
            List<Collectible> pool = inactiveCollectibles[stack.Info];

            for (int i = 0; i < stack.Amount; i++)
            {
                Collectible newCollectible = null;

                if (pool.Count > 0)
                {
                    newCollectible = pool[0];
                    pool.Remove(newCollectible);
                }
                else
                {
                    newCollectible = Instantiate(collectiblePrefab, transform);
                    newCollectible.InjectInfo(stack.Info);
                }


                newCollectible.transform.position = GetRandomSpawnPosition();
            }
        }


        Vector3 GetRandomSpawnPosition()
        {
            float spawnX = UnityEngine.Random.Range(-spawnRange, spawnRange);
            float spawnZ = UnityEngine.Random.Range(-spawnRange, spawnRange);
            return new Vector3(spawnX, spawnHeight, spawnZ);
        }
    }



    private void ReturnToPool(Collectible c)
    {
        c.gameObject.SetActive(false);

        inactiveCollectibles[c.Info].Add(c);
    }


    private void OnDisable()
    {
        Collectible.OnCollected -= ReturnToPool;
    }

}
