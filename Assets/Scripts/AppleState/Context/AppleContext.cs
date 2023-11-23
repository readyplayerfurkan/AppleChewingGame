using UnityEngine;

public class AppleContext : MonoBehaviour
{
    [Header("States")]
    private AppleState _growingState;
    private AppleState _wholeState;
    private AppleState _chewedState;
    private AppleState _rottenState;

    [Header("Game Events")] 
    [SerializeField] private GameObjectGenericGameEvent onAppleRotten;
    [SerializeField] private GameObjectGenericGameEvent onAppleChewed;

    [SerializeField] private DataContainer dataContainer;
    [SerializeField] private GameObject appleCursor;

    public DataContainer DataContainer => dataContainer;
    public GameObject AppleCursor => appleCursor;
    public AppleState CurrentState { get; private set; }
    public bool IsAppleWhole { get; set; }
    public bool IsAppleOnTheGround { get; set; }

    private void Awake()
    {
        _growingState = new GrowingState(this);
        _wholeState = new WholeState(this);
        _chewedState = new ChewedState(this);
        _rottenState = new RottenState(this);

        CurrentState = _growingState;
    }

    private void OnEnable()
    {
        SetGrowingState();
    }

    #region StateChangeMethods

    public void SetGrowingState()
    {
        CurrentState = _growingState;
        ApplyStateChangingOptions();
    }

    public void SetWholeState()
    {
        CurrentState = _wholeState;
        ApplyStateChangingOptions();
    }

    public void SetChewedState()
    {
        CurrentState = _chewedState;
        ApplyStateChangingOptions();
        onAppleChewed.Raise(gameObject);
    }

    public void SetRottenState()
    {
        CurrentState = _rottenState;
        ApplyStateChangingOptions();
        onAppleRotten.Raise(gameObject);
    }

    #endregion

    #region StateMethods

    public void ApplyStateChangingOptions()
        => CurrentState.ApplyStateChangingOptions();

    public void ChewApple()
        => CurrentState.ChewApple();

    public void GrowApple()
        => CurrentState.GrowApple();

    public void FallApple()
        => CurrentState.FallApple();

    #endregion
}
