using System.Collections;
using UnityEngine;

public class WholeState : AppleState
{
    private AppleContext _context;

    public WholeState(AppleContext context)
        => _context = context;

    public void OnSet()
    {
        _context.StartCoroutine(AppleFallingSequence());
    }

    public void OnUnSet()
    {
        
    }

    public void ChewApple()
    {
        _context.DataContainer.PlayerHealth += 0.25f;
        _context.SwitchState(_context.ChewedState);
    }

    private IEnumerator AppleFallingSequence()
    {
        while (!_context.IsAppleOnTheGround)
        {
            _context.transform.Translate(_context.DataContainer.appleFallPercent);

            yield return new WaitForSeconds(0.1f);

            if (_context.transform.position.y <= _context.DataContainer.groundBorder)
                _context.IsAppleOnTheGround = true;
        }

        yield return new WaitForSeconds(10f);
        _context.SwitchState(_context.RottenState);
    }
}
