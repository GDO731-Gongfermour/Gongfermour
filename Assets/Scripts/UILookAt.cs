using Unity.VisualScripting;
using UnityEngine;

public class UILookAt : MonoBehaviour
{
    public GameObject lookAt;

    void LateUpdate()
    {
        transform.LookAt(lookAt.transform);
        transform.rotation = Quaternion.LookRotation(lookAt.transform.forward);
    }
}