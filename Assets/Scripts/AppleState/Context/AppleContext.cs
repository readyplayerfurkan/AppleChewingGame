using UnityEngine;

public class AppleContext : MonoBehaviour
{
    [Header("States")]
    private AppleState _growingState;
    private AppleState _wholeState;
    private AppleState _chewedState;
    private AppleState _rottenState;

    [Header("Local Variables")]
    private AppleState _currentState;
    public DataContainer dataContainer;
    public GameObject appleCursor;

    [Header("Game Events")] 
    [SerializeField] private GameObjectGenericGameEvent onAppleRotten;
    [SerializeField] private GameObjectGenericGameEvent onAppleChewed;

    public AppleState CurrentState => _currentState;

    public bool IsAppleWhole { get; set; }
    public bool IsAppleOnTheGround { get; set; }

    private void Awake()
    {
        _growingState = new GrowingState(this);
        _wholeState = new WholeState(this);
        _chewedState = new ChewedState(this);
        _rottenState = new RottenState(this);

        _currentState = _growingState;
    }

    private void OnEnable()
    {
        SetGrowingState();
    }

    #region StateChangeMethods

    public void SetGrowingState()
    {
        _currentState = _growingState;
        ApplyStateChangingOptions();
    }

    public void SetWholeState()
    {
        _currentState = _wholeState;
        ApplyStateChangingOptions();
    }

    public void SetChewedState()
    {
        _currentState = _chewedState;
        ApplyStateChangingOptions();
        onAppleChewed.Raise(gameObject);
    }

    public void SetRottenState()
    {
        _currentState = _rottenState;
        ApplyStateChangingOptions();
        onAppleRotten.Raise(gameObject);
    }

    #endregion

    #region StateMethods

    public void ApplyStateChangingOptions()
        => _currentState.ApplyStateChangingOptions();

    public void ChewApple()
        => _currentState.ChewApple();

    public void GrowApple()
        => _currentState.GrowApple();

    public void FallApple()
        => _currentState.FallApple();

    #endregion
}
