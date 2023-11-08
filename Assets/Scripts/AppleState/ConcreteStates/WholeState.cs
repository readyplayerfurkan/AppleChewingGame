using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WholeState : AppleState
{
    private AppleContext _context;

    public WholeState(AppleContext context)
        => _context = context;

    public override void ChewApple()
    {
        _context.dataContainer.playerHealth += 0.2f;
        _context.SetChewedState();
    }

    public override void ClickToApple()
    {
        throw new System.NotImplementedException();
    }

    public override void GrowApple()
    {
        throw new System.NotImplementedException();
    }

    public override void FallApple()
    {
        throw new System.NotImplementedException();
    }
}
