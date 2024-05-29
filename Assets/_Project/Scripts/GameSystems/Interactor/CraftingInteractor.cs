using UnityEngine;

public class CraftingInteractor : IInteractorSubsystem
{
    public void TryInteract(Collider hitCollider)
    {
        if (Input.GetKeyDown(KeyCode.E) && 
            hitCollider.TryGetComponent<Workbench>(out Workbench workbench))
        {
            workbench.SendDataToCraftingModel();
        }
    }
}