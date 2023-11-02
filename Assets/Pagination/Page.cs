using UnityEngine;

public class Page : MonoBehaviour
{
    [SerializeField] private int _elementsCount;
    [SerializeField] private Element _element;
    public void Initialize()
    {
        for (int i = 0; i < _elementsCount; i++)
        {
            var element = Instantiate(_element, transform);
            element.Initialize();
        }
    }

    public void Resize(RectTransform targetSizes)
    {
        var contentSize = targetSizes.rect.size;
        var objectRect = GetComponent<RectTransform>();
        objectRect.sizeDelta = contentSize;
        objectRect.localPosition = Vector3.zero;
    }
}
