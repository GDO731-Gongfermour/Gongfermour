using UnityEngine;


public class NoiseManager : MonoBehaviour
{
    public static void MakeNoise(
        Vector3 position,
        float radius,
        NoiseType type)
    {
        foreach (EnemyAI enemy in FindObjectsOfType<EnemyAI>())
        {
            float distance = Vector3.Distance(
                enemy.transform.position,
                position
            );


            if (distance <= radius)
            {
                enemy.HearNoise(position, type);
            }
        }
    }
}

public enum NoiseType
{
    Footstep,
    Door,
    Weapon,
    Explosion
}