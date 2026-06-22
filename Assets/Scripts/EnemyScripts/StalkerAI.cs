using UnityEngine;


public class StalkerState : AIState
{
    float timer;
    public StalkerState(EnemyAI enemy)
    : base(enemy){}

    public override void Enter()
    {
    timer = 8;
    }

    public override void UpdateState()
    {
        timer -= Time.deltaTime;
        if(timer <=0)
        {

        Vector3 offset = Random.insideUnitSphere * 10;

        enemy.agent.SetDestination(
        enemy.target.position + offset);

        }

    }

}