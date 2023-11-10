using TMPro;
using UnityEngine;

[CreateAssetMenu]
public class DataContainer : ScriptableObject
{
    public float playerHealth = 1f;
    public float groundBorder = -3f;
    public Vector3 appleFallPercent = new Vector3(0, -0.05f, 0);
    public Vector3 appleGrowPercent = new Vector3(0.1f, 0.1f, 0.1f);
    public Vector3 appleWholeValue = new Vector3(0.5f, 0.5f, 0.5f);
}
