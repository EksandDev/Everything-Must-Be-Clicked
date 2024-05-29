using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;

public class Message : MonoBehaviour
{
    [SerializeField] private TMP_Text _messagePrefab;
    [SerializeField] private RectTransform _messageSpawnGrid;
    [SerializeField] private Color _fadeOutColor;

    public void Send(string text)
    {
        TMP_Text message = Instantiate(_messagePrefab, _messageSpawnGrid);
        message.text = text;

        DOTween.Sequence().
            Append(message.transform.DOScale(1.2f, 0.5f)).
            Append(message.transform.DOScale(0.9f, 0.5f)).
            Append(message.transform.DOScale(1, 0.5f)).
            SetLink(message.gameObject);

        StartCoroutine(Vanish(message));
    }

    private IEnumerator Vanish(TMP_Text message)
    {
        yield return new WaitForSeconds(3);

        Tween myTween = 
            DOTween.Sequence().
            Append(message.transform.DOScale(1.2f, 0.5f)).
            Append(message.transform.DOScale(0, 0.5f)).
            SetLink(message.gameObject);

        yield return myTween.WaitForKill();

        Destroy(message.gameObject);
    }
}
