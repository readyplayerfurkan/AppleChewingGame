using System.Collections;
using UnityEngine;

public class GrowingState : AppleState
{
    private AppleContext _context;

    public GrowingState(AppleContext context)
        => _context = context;
    
    public override void ChewApple()
    {
        _context.dataContainer.playerHealth += 0.1f;
        _context.SetChewedState();
    }

    public override void ClickToApple(AppleContext currentClickedApple)
    {
        _context.dataContainer.ClickedApple = currentClickedApple;
    }

    public override void GrowApple()
    {
        _context.StartCoroutine(AppleGrowingSequence());
    }

    public override void FallApple()
        => Debug.Log("Apple is not whole.");
    
    private IEnumerator AppleGrowingSequence()
    {
        while (!_context.IsAppleWhole)
        {
            _context.transform.localScale += _context.dataContainer.appleGrowPercent;
            
            if (_context.transform.localScale == _context.dataContainer.appleWholeValue) 
                _context.IsAppleWhole = true;

            yield return new WaitForSeconds(1f);
        }
        _context.SetWholeState();
    }
}
