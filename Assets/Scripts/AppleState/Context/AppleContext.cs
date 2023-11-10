using UnityEngine;

public class AppleContext : MonoBehaviour
{
    [Header("States")]
    private AppleState growingState;
    private AppleState wholeState;
    private AppleState chewedState;
    private AppleState rottenState;

    [Header("Local Variables")]
    private AppleState currentState;
    public DataContainer dataContainer;
    private bool isAppleWhole;
    private bool isAppleOnTheGround;

    public AppleState CurrentState => currentState;

    public bool IsAppleWhole
    {
        get => isAppleWhole;
        set => isAppleWhole = value;
    }

    public bool IsAppleOnTheGround
    {
        get => isAppleOnTheGround;
        set => isAppleOnTheGround = value;
    }

    private void Awake()
    {
        growingState = new GrowingState(this);
        wholeState = new WholeState(this);
        chewedState = new ChewedState(this);
        rottenState = new RottenState(this);

        currentState = growingState;
    }

    private void OnEnable()
    {
        GrowApple();
    }

    #region StateChangeMethods

    public void SetGrowingState()
        => currentState = growingState;

    public void SetWholeState()
    {
        currentState = wholeState;
        FallApple();
    }
    
    public void SetChewedState()
        => currentState = chewedState;
    
    public void SetRottenState()
        => currentState = rottenState;

    #endregion

    #region StateMethods

    public void ChewApple()
        => currentState.ChewApple();

    public void GrowApple()
        => currentState.GrowApple();

    public void FallApple()
        => currentState.FallApple();

    #endregion
}
