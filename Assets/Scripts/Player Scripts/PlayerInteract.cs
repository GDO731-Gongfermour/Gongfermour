using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    public GameObject defaultCamera;
    public LayerMask player;

    
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(defaultCamera.transform.position, defaultCamera.transform.TransformDirection(Vector3.forward * 10f), out hit, 4f, ~player))
        {
            InteractWithObject(hit.collider.gameObject);
        }
    }

    public void InteractWithObject(GameObject obj)
    {
        if (obj.TryGetComponent(out IInteractable interactable))
        {
            interactable.Interact();
        }
    }
}
