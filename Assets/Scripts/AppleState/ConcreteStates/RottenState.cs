using UnityEngine;

public class RottenState : AppleState
{
    private AppleContext _context;

    public RottenState(AppleContext context)
        => _context = context;

    public void ApplyStateChangingOptions()
    {
        _context.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f);
    }

    public void ChewApple()
    {
        _context.dataContainer.PlayerHealth -= 0.2f;
        _context.SetChewedState();
    }

    public void GrowApple()
        => Debug.Log("Apple is rotten, sorry. :/");

    public void FallApple()
        => Debug.Log("Apple is rotten, sorry. :/");
}
