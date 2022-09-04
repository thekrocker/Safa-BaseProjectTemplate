using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MobileJoystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [Title("Joystick Properties")] [SerializeField]
    private float movementRange = 100f;

    [SerializeField] private float fadeDuration = .1f;

    [Title("References")] [SerializeField] private RectTransform outerJoystick;
    [SerializeField] private RectTransform innerJoystick;


    private Vector3 _startPosition;
    private Vector2 _pointerDownPosition;
    private Vector2 _joystickVector;

    private Image _outerJoystickImage;
    private Image _innerJoystickImage;


    public static MobileJoystick Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        // Set start Position
        SetRefs();

        _startPosition = innerJoystick.anchoredPosition;
    }

    private void SetRefs()
    {
        _outerJoystickImage = outerJoystick.GetComponent<Image>();
        _innerJoystickImage = innerJoystick.GetComponent<Image>();
    }


    public void OnPointerDown(PointerEventData eventData) // When touched first
    {
        // Calculate local point, output _pointerDownPosition
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponentInParent<RectTransform>(),
            eventData.position, eventData.pressEventCamera, out _pointerDownPosition);

        // Set outer joystick
        SetOuterJoystickPosition();

        // Activate this if has do tween.
        // SetJoystickVisibility(1f); 
    }

    public void OnDrag(PointerEventData eventData) // When dragging
    {
        // Calculate local point, outpot position
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            transform.parent.GetComponentInParent<RectTransform>(), // its canvas
            eventData.position, eventData.pressEventCamera, out Vector2 position);

        // Calculate delta between start-last & clamp.
        Vector2 delta = position - _pointerDownPosition;
        delta = Vector2.ClampMagnitude(delta, movementRange);

        // Set inner joystick position via delta
        SetInnerJoystickPosition(_startPosition + (Vector3)delta);

        // Set Vector3 output
        var newPos = new Vector2(delta.x / movementRange, delta.y / movementRange);

        SetJoystickVector(newPos);
        // Invoke action
    }


    public void OnPointerUp(PointerEventData eventData) // When released
    {
        SetJoystickVector(Vector2.zero);
        
        // Activate this if has do tween.
        
        // SetJoystickVisibility(0f); 
    }


    #region Joystick Properties
    

    private void SetJoystickVector(Vector2 target)
    {
        _joystickVector = target;
    }

    private void SetInnerJoystickPosition(Vector2 targetPos)
    {
        innerJoystick.anchoredPosition = targetPos;
    }

    private void SetOuterJoystickPosition()
    {
        outerJoystick.transform.position = MouseUtils.GetMousePosition();
    }

    #endregion

    #region DoTween

    private void SetJoystickVisibility(float targetAlpha)
    {
        // Activate this is has doTween.
        
        // SetVisibility(targetAlpha, _outerJoystickImage);
        // SetVisibility(targetAlpha, _innerJoystickImage);
    }

    private void SetVisibility(float targetAlpha, Image target)
    {
        // Activate this is has doTween.
        
        // target.DOFade(targetAlpha, fadeDuration);
    }
    

    #endregion
    public bool IsUsingJoystick() => (Mathf.Abs(_joystickVector.x) + Mathf.Abs(_joystickVector.y)) != 0;

    public Vector3 GetJoystickVector(float yValue) =>
        new(_joystickVector.x, yValue, _joystickVector.y); // To get vector, just use this basically.
}