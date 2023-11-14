using UnityEngine;

public class EntryController : MonoBehaviour
{
    [SerializeField] private GameObject informationPanel;
    [SerializeField] private GameObject gameStarterButton;
    
    public void OnClickToScreen()
    {
        informationPanel.SetActive(false);
        gameStarterButton.SetActive(false);
    }
}
