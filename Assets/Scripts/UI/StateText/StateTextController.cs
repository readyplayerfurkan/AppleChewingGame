using TMPro;
using UnityEngine;

public class StateTextController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentStateText;
    private AppleContext clickedApple;

    public void OnAppleClicked(GameObject apple)
    {
        clickedApple = apple.GetComponent<AppleContext>();
        Debug.Log(clickedApple.CurrentState);
        
        currentStateText.color = clickedApple.CurrentState.ToString() switch
        {
            "GrowingState" => new Color(236, 144, 144),
            "WholeState" => new Color(197, 31, 31),
            "ChewedState" => new Color(150, 204, 32),
            "RottenState" => new Color(0, 0, 0),
            _ => currentStateText.color
        };
    }
}
