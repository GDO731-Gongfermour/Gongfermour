using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class LanternFuel : MonoBehaviour
{
    private int fuelQuantity;
    public TMP_Text fuelQuantityText;
    private bool lanternHeld = false;
    private int lanternCapacity = 100;
    private bool cooldown = true;

    void Start()
    {
        fuelQuantity = 100;
    }

    void Update()
    {
        InputAction equipLantern = InputSystem.actions.FindAction("EquipLantern");
        fuelQuantityText.text = fuelQuantity.ToString();
        if (fuelQuantity == 0)
        {
            UnequipLantern();
        }
        if (equipLantern.IsPressed())
        {
            EquipLantern();
        }
        if (lanternHeld)
        {
            if (cooldown)
            {
                cooldown = false;
                Invoke("BurnFuel", 1f);
            }
        }
    }

    public void EquipLantern()
    {
        lanternHeld = true;
    }

    public void UnequipLantern()
    {
        lanternHeld = false;
    }

    public void AddFuel(int fuelToAdd)
    {
        fuelQuantity += fuelToAdd;
        if (fuelQuantity >  lanternCapacity)
        {
            fuelQuantity = lanternCapacity;
        }
    }

    public void BurnFuel()
    {
        fuelQuantity--;
        cooldown = true;
    }
}