using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    [Header("基本資料")]
    public EnemyData data;


    protected float timer;
    protected Animator ani;
    protected NavMeshAgent agent;
    protected Transform target;

    protected virtual void Start()
    {
        ani = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = data.speed;

        target = GameObject.Find("玩家").transform;
    }

    protected virtual void Update()
    {
        Move();
    }

    protected abstract void Move();
    protected abstract void Attack();
    protected abstract void Wait();
    protected abstract void Damage(float damage);
    protected abstract void Dead();
}
