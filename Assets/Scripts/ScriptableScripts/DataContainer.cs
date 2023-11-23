using UnityEngine;

[CreateAssetMenu]
public class DataContainer : ScriptableObject
{
    private float _playerHealth = 1f;
    public float groundBorder = -3f;
    
    public Vector3 appleFallPercent = new Vector3(0, -0.05f, 0);
    public Vector3 appleGrowPercent = new Vector3(0.1f, 0.1f, 0.1f);
    public Vector3 appleWholeValue = new Vector3(0.5f, 0.5f, 0.5f);
    public Vector3 appleFirstScale = new Vector3(0.1f, 0.1f, 0.1f);
    public bool isAnAppleSelectedNow = false;

    private AppleContext _clickedApple;

    public AppleContext ClickedApple
    {
        get => _clickedApple;
        set
        {
            if (isAnAppleSelectedNow)
            {
                _clickedApple.AppleCursor.SetActive(false);
                _clickedApple = value;
                _clickedApple.AppleCursor.SetActive(true);
            }
            else
            {
                _clickedApple = value;
                isAnAppleSelectedNow = true;
                _clickedApple.AppleCursor.SetActive(true);
            }
        }
    }

    public float PlayerHealth
    {
        get => _playerHealth;
        set
        {
            if (_playerHealth > 1)
            {
                _playerHealth = 1;
                return;
            }
            
            _playerHealth = value;
        }
    }
}
