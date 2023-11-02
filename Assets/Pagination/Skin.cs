using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "New Skin", menuName = "Skin", order = 0)]
public class Skin : ScriptableObject
{
    [SerializeField] private Image _skinPreview;

    public Image SkinPreview => _skinPreview;
}
