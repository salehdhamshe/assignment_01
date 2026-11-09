using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject[] coinPrefabs;
    public int coinsPerBatch = 5;

    public Vector2 minPosition = new Vector2(-8f, -4f);
    public Vector2 maxPosition = new Vector2(8f, 4f);

    private int coinsLeft = 0;                 

    void Start()
    {
        SpawnBatch();
    }

    public void CoinCollected()                
    {
        coinsLeft--;

        if (coinsLeft == 0)
        {
            SpawnBatch();
        }
    }

    private void SpawnBatch()
    {
        for (int i = 0; i < coinsPerBatch; i++)
        {
            int typeIndex = Random.Range(0, coinPrefabs.Length);

            float x = Random.Range(minPosition.x, maxPosition.x);
            float y = Random.Range(minPosition.y, maxPosition.y);

            Instantiate(coinPrefabs[typeIndex], new Vector3(x, y, 0), Quaternion.identity);
        }

        coinsLeft = coinsPerBatch;            
    }
}