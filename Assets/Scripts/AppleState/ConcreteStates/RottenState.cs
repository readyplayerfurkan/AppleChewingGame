using UnityEngine;

public class RottenState : AppleState
{
    private AppleContext _context;

    public RottenState(AppleContext context)
        => _context = context;

    public void OnSet()
    {
        _context.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f);
        _context.onAppleRotten.Raise(_context.gameObject);
    }

    public void OnUnSet()
    {
        
    }

    public void ChewApple()
    {
        _context.DataContainer.PlayerHealth -= 0.2f;
        _context.SwitchState(_context.ChewedState);
    }
}
