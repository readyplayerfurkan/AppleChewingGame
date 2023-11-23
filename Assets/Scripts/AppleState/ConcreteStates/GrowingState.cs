using System.Collections;
using UnityEngine;

public class GrowingState : AppleState
{
    private AppleContext _context;
    private IEnumerator _appleSpawnCoroutine;

    public GrowingState(AppleContext context)
        => _context = context;

    public void OnSet()
    {
        _context.IsAppleWhole = false;
        _context.IsAppleOnTheGround = false;
        _context.transform.localScale = _context.DataContainer.appleFirstScale;
        _context.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
        _appleSpawnCoroutine = AppleGrowingSequence();
        _context.StartCoroutine(_appleSpawnCoroutine);
    }

    public void OnUnSet()
    {
        _context.StopCoroutine(_appleSpawnCoroutine);
    }

    private IEnumerator AppleGrowingSequence()
    {
        while (!_context.IsAppleWhole)
        {
            _context.transform.localScale += _context.DataContainer.appleGrowPercent;
            
            if (_context.transform.localScale == _context.DataContainer.appleWholeValue) 
                _context.IsAppleWhole = true;

            yield return new WaitForSeconds(1f);
        }
        _context.SwitchState(_context.WholeState);
    }
    
    public void ChewApple()
    {
        _context.DataContainer.PlayerHealth += 0.1f;
        _context.SwitchState(_context.ChewedState);
    }
}
