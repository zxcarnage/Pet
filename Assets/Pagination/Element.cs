using UnityEngine;
using UnityEngine.UI;

public class Element : MonoBehaviour
{
    [SerializeField] private Skin _skin;
    [SerializeField] private Image _cellPreview;

    private State _elementState;

    public void Initialize()
    {
        _elementState = State.Disabled;
    }

    public void Unlock()
    {
        _elementState = State.Active;
        _cellPreview = _skin.SkinPreview;
    }

    enum State
    {
        Active,
        Disabled
    }
}
