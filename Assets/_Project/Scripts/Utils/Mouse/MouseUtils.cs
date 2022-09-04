using UnityEngine;
using UnityEngine.InputSystem;

public static class MouseUtils
{
    public static Vector2 GetMousePosition() => Mouse.current.position.ReadValue();
    public static RaycastHit GetRayHit(Camera cam, LayerMask mask)
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, mask);
        return hit;
    }
    public static RaycastHit GetRayHitSphere(Camera cam, LayerMask mask, float radius)
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Physics.SphereCast(ray, radius, out RaycastHit hit, Mathf.Infinity, mask);
        return hit;
    }
    
    
}