using UnityEngine;

public class ChewButtonController : MonoBehaviour
{
    private AppleContext context;
    
    public void OnAppleSelected(GameObject selectedApple)
    {
        context = selectedApple.GetComponent<AppleContext>();
    }

    public void ChewApple()
    {
        if (context == null) return;
        
        context.ChewApple();
    }
}
