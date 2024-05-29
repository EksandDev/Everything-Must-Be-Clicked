using UnityEngine;
using Zenject;

public class ShowTextInteractor : IInteractorSubsystem
{
    private TargetNameText _targetNameText;
    private bool _textIsVanished = false;

    #region Zenject init
    [Inject]
    private void Initialize(TargetNameText targetNameText)
    {
        _targetNameText = targetNameText;
    }
    #endregion

    public void TryInteract(Collider hitCollider)
    {
        if (hitCollider.TryGetComponent<INameable>(out INameable nameable))
        {
            _targetNameText.Text(nameable.Name);
            _textIsVanished = false;
        }
    }

    public void TryVanishText()
    {
        if (!_textIsVanished)
        {
            _targetNameText.Text("");
            _textIsVanished = true;
        }
    }
}