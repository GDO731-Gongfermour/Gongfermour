
using UnityEngine;

public class GatherWood : MonoBehaviour, IInteractable
{
    public PlayerAttributes playerAttributes;   

    public void Interact()
    {
        playerAttributes.AddWood(1);
        Destroy(this.gameObject);
    }
}
