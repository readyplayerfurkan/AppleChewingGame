using UnityEngine;

[CreateAssetMenu]
public class DataContainer : ScriptableObject
{
    public float playerHealth = 1f;
    public Vector3 appleGrowPercent = new Vector3(0.1f, 0.1f, 0.1f);
}
