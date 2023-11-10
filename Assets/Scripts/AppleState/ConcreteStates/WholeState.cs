using System.Collections;
using UnityEngine;

public class WholeState : AppleState
{
    private AppleContext _context;

    public WholeState(AppleContext context)
        => _context = context;

    public override void ChewApple()
    {
        _context.dataContainer.playerHealth += 0.25f;
        _context.SetChewedState();
    }

    public override void GrowApple()
        => Debug.Log("Apple is already whole.");

    public override void FallApple()
    {
        _context.StartCoroutine(AppleFallingSequence());
    }

    private IEnumerator AppleFallingSequence()
    {
        while (!_context.IsAppleOnTheGround)
        {
            _context.transform.Translate(_context.dataContainer.appleFallPercent);

            yield return new WaitForSeconds(0.1f);

            if (_context.transform.position.y <= _context.dataContainer.groundBorder)
                _context.IsAppleOnTheGround = true;
        }

        yield return new WaitForSeconds(10f);
        _context.SetRottenState();
    }
}
