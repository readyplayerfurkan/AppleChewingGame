using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RottenState : AppleState
{
    private AppleContext _context;

    public RottenState(AppleContext context)
        => _context = context;
    
    public override void ChewApple()
    {
        throw new System.NotImplementedException();
    }

    public override void ClickToApple(AppleContext currentClickedApple)
    {
        _context.dataContainer.ClickedApple = currentClickedApple;
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
