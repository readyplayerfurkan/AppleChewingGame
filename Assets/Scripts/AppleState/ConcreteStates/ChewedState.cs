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
    {

    }

    public override void GrowApple()
    {

    }

    public override void FallApple()
    {

    }
}
