using System.Collections;
using UnityEngine;

public class GrowingState : AppleState
{
    private AppleContext _context;

    public GrowingState(AppleContext context)
        => _context = context;

    public void ApplyStateChangingOptions()
    {
        _context.IsAppleWhole = false;
        _context.IsAppleOnTheGround = false;
        _context.transform.localScale = _context.dataContainer.appleFirstScale;
        _context.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
        GrowApple();
    }

    public void ChewApple()
    {
        _context.dataContainer.PlayerHealth += 0.1f;
        _context.SetChewedState();
    }

    public void GrowApple()
    {
        _context.StartCoroutine(AppleGrowingSequence());
    }

    public void FallApple()
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
