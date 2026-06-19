using TMPro;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    private int woodQuantity;

    public TMP_Text woodText;

    void Start()
    {
        woodQuantity = 0;
    }

    public int GetWoodQuantity()
    {
        return woodQuantity;
    }

    public void AddWood(int woodToAdd)
    {
        woodQuantity += woodToAdd;
    }

    public void RemoveWood(int woodToRemove)
    {
        woodQuantity -= woodToRemove;
    }

    private void Update()
    {
        woodText.text = woodQuantity.ToString();
    }
}
