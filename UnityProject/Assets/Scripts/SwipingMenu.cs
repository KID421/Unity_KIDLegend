using UnityEngine;
using UnityEngine.UI;

public class SwipingMenu : MonoBehaviour
{
    public ScrollRect scrollRect;
    public RectTransform rectContent;

    private int index = 2;
    private float currentX = 0.666f;

    private void Start()
    {
        rectContent.anchoredPosition = new Vector2(-720 * index, 0);
    }

    private void Update()
    {
        Swiping(scrollRect.normalizedPosition);
    }

    public void Swiping(Vector2 value)
    {
        bool control = Input.mousePosition.x < Screen.width * 0.2f || Input.mousePosition.x > Screen.width * 0.8f;
        scrollRect.enabled = control;

        if (!control) return;

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            print(value);
            index = value.x < currentX ? index - 1 : index + 1;
            currentX = 0.333f * index;
            rectContent.anchoredPosition = new Vector2(-720 * index, 0);
        }
    }
}
