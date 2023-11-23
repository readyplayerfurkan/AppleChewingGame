using UnityEngine;

public class ChewedState : AppleState
{
    private AppleContext _context;

    public ChewedState(AppleContext context)
        => _context = context;

    public void ApplyStateChangingOptions()
    {
        _context.GetComponent<SpriteRenderer>().color = new Color(150f / 255f, 204f / 255f, 32f / 255f);
    }

    public void ChewApple()
        => Debug.Log("Apple is already chewed.");
    
    public void GrowApple()
        => Debug.Log("Apple cannot grow while it is chewed.");
    
    public void FallApple()
        => Debug.Log("Apple cannot fall while it is chewed.");
}
