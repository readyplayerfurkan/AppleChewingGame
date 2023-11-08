using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingState : AppleState
{
    private AppleContext _context;

    public GrowingState(AppleContext context)
        => _context = context;
    
    public override void ChewApple()
    {
        throw new System.NotImplementedException();
    }

    public override void ClickToApple()
    {
        throw new System.NotImplementedException();
    }

    public override void GrowApple()
    {
        StartCoroutine(AppleGrowingSequance());
    }

    public override void FallApple()
    {
        throw new System.NotImplementedException();
    }
    
    private IEnumerator AppleGrowingSequance()
    {
        while (true)
        {
            transform.localScale += _context.dataContainer.appleGrowPercent;
            yield return new WaitForSeconds(1f);

            if (transform.localScale == Vector3.one)
                break;
        }
        _context.SetWholeState();
    }
}
