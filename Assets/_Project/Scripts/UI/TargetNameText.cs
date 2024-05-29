using TMPro;
using UnityEngine;

[RequireComponent (typeof(TMP_Text))]
public class TargetNameText : MonoBehaviour
{
    private TMP_Text _text;

    private void Awake() => _text = GetComponent<TMP_Text>();

    public void Text(string text) => _text.text = text;
}
