using System;
using UnityEngine;

public class EntryController : MonoBehaviour
{
    [SerializeField] private GameObject informationPanel;
    [SerializeField] private GameObject gameStarterButton;
    [SerializeField] private DataContainer dataContainer;

    private void Awake()
    {
        dataContainer.ResetAllValues();
    }
    
    public void OnClickToScreen()
    {
        informationPanel.SetActive(false);
        gameStarterButton.SetActive(false);
    }
}
