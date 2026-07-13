using UnityEngine;

[CreateAssetMenu(fileName="Enemy Profile", menuName="AI/Enemy Profile")]
public class EnemyProfile : ScriptableObject
{
    [Header("Stats")]
    public float health = 100;
    public float moveSpeed = 3.5f;

    [Header("Vision")]
    public float visionRange = 15f;
    [Range(0,360)]
    public float visionAngle = 90f;

    [Header("Hearing")]
    public float hearingRange = 10f;

    [Header("Combat")]
    public float attackRange = 2f;
    public float attackCooldown = 2f;

    [Header("Behaviour")]
    public AIBehaviour behaviour;
}


public enum AIBehaviour
{
    Normal,
    Stalker
}