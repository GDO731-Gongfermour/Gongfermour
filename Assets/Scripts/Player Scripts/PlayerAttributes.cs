using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class PlayerAttributes : MonoBehaviour
{
    private Dictionary<string, int> resources;

    public TMP_Text woodText;

    void Start()
    {
        if (resources == null)
        {
            resources = new Dictionary<string, int>()
            {
                {"wood", 0 },
                {"fuel", 0 }
            };
        }
    }

    public int GetResourceQuantity(string resourceType)
    {
        return resources[resourceType];
    }

    public void AddResource(string resourceType, int resourceQuantity)
    {
        resources[resourceType] += resourceQuantity;
    }

    public void RemoveResource(string resourceType, int resourceQuantity)
    {
        resources[resourceType] -= resourceQuantity;
    }

    private void Update()
    {
        woodText.text = resources["wood"].ToString();
    }
}
