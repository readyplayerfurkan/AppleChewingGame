using UnityEngine;

public class ChewedState : AppleState
{
    private AppleContext _context;

    public ChewedState(AppleContext context)
        => _context = context;

    public override void ApplyStateChangingOptions()
    {
        _context.GetComponent<SpriteRenderer>().color = new Color(150f / 255f, 204f / 255f, 32f / 255f);
    }

    public override void ChewApple()
        => Debug.Log("Apple is already chewed.");
    
    public override void GrowApple()
        => Debug.Log("Apple cannot grow while it is chewed.");
    
    public override void FallApple()
        => Debug.Log("Apple cannot fall while it is chewed.");
}
