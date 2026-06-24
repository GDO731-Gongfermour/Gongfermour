
using UnityEngine;
using UnityEngine.InputSystem;

public class GatherWood : MonoBehaviour, IInteractable
{
    public PlayerAttributes playerAttributes;
    public GameObject promptText;
    private bool hideText = true;

    public void Interact()
    {
        promptText.SetActive(true);
        hideText = false;
        InputAction interactAction = InputSystem.actions.FindAction("Interact");
        if (interactAction.triggered)
        {
            playerAttributes.AddWood(1);
            Destroy(this.gameObject);
        }
    }

    private void LateUpdate()
    {
        if (hideText)
        {
            promptText.SetActive(false);
        }
        else
        {
            hideText = true;
        }
    }
}