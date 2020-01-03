using UnityEngine;
using System.Collections;

public class EnemyNear : Enemy
{
    protected override void Attack()
    {

    }

    protected override void Damage(float damage)
    {
    }

    protected override void Dead()
    {
    }

    protected override void Move()
    {
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("攻擊"))
        {
            agent.velocity = Vector3.zero;
            return;
        }

        agent.SetDestination(target.position);

        if (agent.remainingDistance <= 2.5f)
        {
            Wait();
        }
        else
        {
            ani.SetBool("跑步開關", !(agent.isStopped = false));
        }
    }

    protected override void Wait()
    {
        if (timer >= data.cd)
        {
            timer = 0;
            ani.SetTrigger("攻擊觸發");
            StartCoroutine(DelayDamage());
        }
        else
        {
            agent.velocity = Vector3.zero;
            ani.SetBool("跑步開關", agent.isStopped = false);

            timer += Time.deltaTime;
        }
    }

    private IEnumerator DelayDamage()
    {
        yield return new WaitForSeconds(data.delay);
        RaycastHit hit;
        if (Physics.Raycast(transform.position + new Vector3(0, 1.5f, 0), transform.forward, out hit, 3))
        {
            print(hit.collider.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position + new Vector3(0, 1.5f, 0), transform.forward * 3);
    }
}
