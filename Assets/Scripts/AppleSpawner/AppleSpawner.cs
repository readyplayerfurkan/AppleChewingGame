using System.Collections;
using UnityEngine;

public class AppleSpawner : ObjectPooling<GameObject>
{
    [SerializeField] private const float MinRangeForXAxis = -1.5f;
    [SerializeField] private const float MaxRangeForXAxis = 2.4f;
    [SerializeField] private const float MinRangeForYAxis = 0f;
    [SerializeField] private const float MaxRangeForYAxis = 3f;
    
    void Start()
    {
        ObjectPool();
        StartCoroutine(SpawnApple());
    }

    private IEnumerator SpawnApple()
    {
        while (true)
        {
            itemInstantiate = GetItem();
            GetRandomPositionForApple(itemInstantiate.transform);
            yield return new WaitForSeconds(5f);
        }
    }

    private void GetRandomPositionForApple(Transform appleTransform)
    {
        float randomXCoordinate = Random.Range(MinRangeForXAxis, MaxRangeForXAxis);
        float randomYCoordinate = Random.Range(MinRangeForYAxis, MaxRangeForYAxis);

        appleTransform.position = new Vector3(randomXCoordinate, randomYCoordinate);
    }
}
