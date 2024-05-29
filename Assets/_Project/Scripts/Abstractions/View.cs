using UnityEngine;

public abstract class View : MonoBehaviour
{
    protected GameObject SystemCanvas;
    protected Transform SystemSlotsGrid;
    protected Slot SystemSlotPrefab;
    protected Interactor Interactor;
    protected FirstPersonController Controller;

    public virtual void SwitchInterface()
    {
        bool systemIsActive = SystemCanvas.activeInHierarchy;
        SystemCanvas.SetActive(!systemIsActive);
        Interactor.IsActive = systemIsActive;
        Controller.playerCanMove = systemIsActive;
        Controller.cameraCanMove = systemIsActive;
        Controller.enableHeadBob = systemIsActive;
        Cursor.visible = !systemIsActive;
        Cursor.lockState = systemIsActive ? CursorLockMode.Locked : CursorLockMode.None;
    }
}
