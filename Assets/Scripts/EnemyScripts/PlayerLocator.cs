using UnityEngine;

public class PlayerLocator : MonoBehaviour
{
public static Transform Player;
void Awake()
{
Player = transform;
}

}