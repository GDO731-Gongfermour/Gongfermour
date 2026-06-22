using UnityEngine;


public class PatrolState : AIState
{

    Vector3 patrolPoint;


    public PatrolState(EnemyAI enemy) : base(enemy){}



    public override void Enter()
    {
        patrolPoint =
            enemy.transform.position +
            Random.insideUnitSphere * 10;


        enemy.agent.SetDestination(patrolPoint);
    }



    public override void UpdateState()
    {

        if(Vector3.Distance(
            enemy.transform.position,
            patrolPoint) < 2)
        {
            Enter();
        }


        if(enemy.GetComponent<Vision>().CanSeePlayer())
        {
            enemy.ChangeState(
                new ChaseState(enemy));
        }
    }
}