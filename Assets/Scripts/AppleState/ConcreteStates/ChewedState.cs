using UnityEngine;

public class ChewedState : AppleState
{
    private AppleContext _context;

    public ChewedState(AppleContext context)
        => _context = context;

    public void OnUnSet()
    {
        
    }

    public void ChewApple()
        => Debug.Log("Apple is already chewed.");

    public void OnSet()
    {
        _context.GetComponent<SpriteRenderer>().color = new Color(150f / 255f, 204f / 255f, 32f / 255f);
        _context.onAppleChewed.Raise(_context.gameObject);
    }
}
