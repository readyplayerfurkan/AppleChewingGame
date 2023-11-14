using System.Collections;
using UnityEngine;

public class AppleSpawner : ObjectPooling<GameObject>
{
    private const float MinRangeForXAxis = -1.7f;
    private const float MaxRangeForXAxis = 2.7f;
    private const float MinRangeForYAxis = 0f;
    private const float MaxRangeForYAxis = 3f;

    private const float appleSpawnInterval = 7.5f;
    
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
            yield return new WaitForSeconds(appleSpawnInterval);
        }
    }

    private void GetRandomPositionForApple(Transform appleTransform)
    {
        float randomXCoordinate = Random.Range(MinRangeForXAxis, MaxRangeForXAxis);
        float randomYCoordinate = Random.Range(MinRangeForYAxis, MaxRangeForYAxis);

        appleTransform.position = new Vector3(randomXCoordinate, randomYCoordinate);
    }
    
    private IEnumerator ReleaseItemFromScene(GameObject chewedApple)
    {
        yield return new WaitForSeconds(10f);
        ReleaseItem(chewedApple);
    }

    public void OnAppleChewed(GameObject chewedApple)
    {
        StartCoroutine(ReleaseItemFromScene(chewedApple));
    }
    
    public void OnAppleRotten(GameObject rottenApple)
    {
        StartCoroutine(ReleaseItemFromScene(rottenApple));
    } }
