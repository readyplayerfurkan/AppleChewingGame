using TMPro;
using UnityEngine;

public class StateTextController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentStateText;
    private AppleContext clickedApple;

    public void OnAppleClickedOrChewed(GameObject apple)
    {
        clickedApple = apple.GetComponent<AppleContext>();

        ChangedTextColor(clickedApple);
        ChangeTextContent(clickedApple);
    }

    private void ChangedTextColor(AppleContext clickedApple)
    {
        currentStateText.color = clickedApple.CurrentState.ToString() switch
        {
            "GrowingState" => new Color(236f / 255f, 144f / 255f, 144f / 255f),
            "WholeState" => new Color(197f / 255f, 31f / 255f, 31f / 255f),
            "ChewedState" => new Color(150f / 255f, 204f / 255f, 32f / 255f),
            "RottenState" => new Color(0f, 0f, 0f),
            _ => currentStateText.color
        };
    }

    private void ChangeTextContent(AppleContext clickedApple)
    {
        currentStateText.text = clickedApple.CurrentState.ToString() switch
        {
            "GrowingState" => "Growing State",
            "WholeState" => "Whole State",
            "ChewedState" => "Chewed State",
            "RottenState" => "Rotten State",
            _ => currentStateText.text
        };
    }
}
