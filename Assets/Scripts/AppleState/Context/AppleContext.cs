using UnityEngine;

public class AppleContext : MonoBehaviour
{
    [Header("States")]
    private AppleState _growingState;
    private AppleState _wholeState;
    private AppleState _chewedState;
    private AppleState _rottenState;
    
    public AppleState GrowingState => _growingState;
    public AppleState WholeState => _wholeState;
    public AppleState ChewedState => _chewedState;
    public AppleState RottenState => _rottenState;

    [Header("Game Events")] 
    public GameObjectGenericGameEvent onAppleRotten;
    public GameObjectGenericGameEvent onAppleChewed;

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
    }

    private void OnEnable()
    {
        SwitchState(_growingState);
    }

    public void SwitchState(AppleState state)
    {
        CurrentState?.OnUnSet();
        CurrentState = state;
        CurrentState.OnSet();
    }
}
