using UnityEngine;

public class RottenState : AppleState
{
    private AppleContext _context;

    public RottenState(AppleContext context)
        => _context = context;

    public override void ApplyStateChangingOptions()
    {
        _context.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f);
    }

    public override void ChewApple()
    {
        _context.dataContainer.playerHealth -= 0.2f;
        _context.SetChewedState();
    }

    public override void GrowApple()
        => Debug.Log("Apple is rotten, sorry. :/");

    public override void FallApple()
        => Debug.Log("Apple is rotten, sorry. :/");
}
