using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObjectGenericGameEvent onAppleClicked;
    [SerializeField] private DataContainer dataContainer;

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayHit.collider) return;

        dataContainer.ClickedApple = rayHit.collider.GetComponent<AppleContext>();
        onAppleClicked.Raise(rayHit.collider.gameObject);
    }
}
