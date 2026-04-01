using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ButtonTextEffect : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [Header("Text Settings")]
    public TextMeshProUGUI buttonText;
    public Vector3 pressedOffset = new Vector3(-7.5f, -2.5f, 0); // Move text down and left
    public Color pressedColor = Color.gray;

    private Vector3 originalPosition;
    private Color originalColor;

    void Start()
    {
        if (buttonText != null)
        {
            // Save the original text state
            originalPosition = buttonText.rectTransform.localPosition;
            originalColor = buttonText.color;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (buttonText != null)
        {
            // Apply the offset and color
            buttonText.rectTransform.localPosition = originalPosition + pressedOffset;
            buttonText.color = pressedColor;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (buttonText != null)
        {
            // Reset to original when released
            buttonText.rectTransform.localPosition = originalPosition;
            buttonText.color = originalColor;
        }
    }
}