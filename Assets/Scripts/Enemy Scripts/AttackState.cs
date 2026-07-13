using UnityEngine;


public class AttackState : AIState
{

float cooldown;

public AttackState(EnemyAI enemy)
: base(enemy){}

    public override void UpdateState()
    {

    cooldown -= Time.deltaTime;

    if(cooldown <=0)
    {
    Debug.Log(
    enemy.name + " attacks");

    cooldown = enemy.profile.attackCooldown;
    }

    float distance = Vector3.Distance(enemy.transform.position, enemy.target.position);

    if(distance >
    enemy.profile.attackRange)
        {
        enemy.ChangeState(
        new ChaseState(enemy));
        }
    }
}