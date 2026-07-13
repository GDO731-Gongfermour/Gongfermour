using UnityEngine;
using UnityEngine.AI;

public class NormalEnemyState : AIState
{
    Vector3 patrolPoint;

    public NormalEnemyState(EnemyAI enemy)
        : base(enemy)
    {
    }

    public override void Enter()
    {
        MoveToRandomPoint();
    }

    public override void UpdateState()
    {
        // ALWAYS use the Vision component once (no GetComponent spam)
        Vision vision = enemy.GetComponent<Vision>();

        if (vision != null && vision.CanSeePlayer())
        {
            enemy.target = PlayerLocator.Player;

            enemy.ChangeState(new ChaseState(enemy));
            return;
        }

        // Patrol logic
        if (!enemy.agent.pathPending &&
            enemy.agent.remainingDistance < 1f)
        {
            MoveToRandomPoint();
        }
    }

    void MoveToRandomPoint()
    {
        Vector3 origin = enemy.transform.position;

        Vector3 randomPoint =
            origin + Random.insideUnitSphere * 8f;

        NavMeshHit hit;

        if (NavMesh.SamplePosition(
            randomPoint,
            out hit,
            8f,
            NavMesh.AllAreas))
        {
            patrolPoint = hit.position;
            enemy.agent.SetDestination(patrolPoint);
        }
    }
}