using UnityEngine;

public class AppleContext : MonoBehaviour
{
    private AppleState growingState;
    private AppleState wholeState;
    private AppleState chewedState;
    private AppleState rottenState;

    private AppleState currentState;
    public DataContainer dataContainer;

    public AppleContext()
    {
        growingState = new GrowingState(this);
        wholeState = new WholeState(this);
        chewedState = new ChewedState();
        rottenState = new RottenState();

        currentState = growingState;
    }

    private void OnEnable()
    {
        currentState.GrowApple();
    }

    #region StateChangeMethods

    public void SetGrowingState()
        => currentState = growingState;
    
    public void SetWholeState()
        => currentState = wholeState;
    
    public void SetChewedState()
        => currentState = chewedState;
    
    public void SetRottenState()
        => currentState = rottenState;

    #endregion

    #region StateMethods

    public void ChewApple()
        => currentState.ChewApple();

    public void ClickToApple()
        => currentState.ClickToApple();

    public void GrowApple()
        => currentState.GrowApple();

    public void FallApple()
        => currentState.FallApple();

    #endregion
}
