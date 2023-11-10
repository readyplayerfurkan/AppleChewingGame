using TMPro;
using UnityEngine;

[CreateAssetMenu]
public class DataContainer : ScriptableObject
{
    public float playerHealth = 1f;
    public float groundBorder = -3f;
    private AppleContext clickedApple;
    public Vector3 appleFallPercent = new Vector3(0, -0.05f, 0);
    public Vector3 appleGrowPercent = new Vector3(0.1f, 0.1f, 0.1f);
    public Vector3 appleWholeValue = new Vector3(0.5f, 0.5f, 0.5f);

    [SerializeField] private TextMeshProUGUI currentStateText;
    public AppleContext ClickedApple
    {
        get => clickedApple;
        set
        {
            clickedApple = value;
            currentStateText.text = value.CurrentState.ToString();

            currentStateText.color = value.CurrentState.ToString() switch
            {
                "GrowingState" => new Color(236, 144, 144),
                "WholeState" => new Color(197, 31, 31),
                "ChewedState" => new Color(150, 204, 32),
                "RottenState" => new Color(0, 0, 0),
                _ => currentStateText.color
            };
        }
    }
}
