using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    Animator animE;
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public int maxHealthE = 3;
    public int currentHealthE;
    public float timeToDestroy = 3;
    [SerializeField] EnemySword sword;
    [SerializeField] Image uiHealthbar;

    //Patrol
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    //Sound
    public AudioSource source;
    public AudioClip swordSoundEnemy;
    public AudioClip deadEnemy;

    private void Awake()
    {
        player = GameObject.Find("Frodo Variant").transform;
        agent = GetComponent<NavMeshAgent>();
        currentHealthE = maxHealthE;
        animE = GetComponent<Animator>();
        source.playOnAwake = false;
        source.loop = false;

    }
    private void Update()
    {
        if (currentHealthE <= 0)
            return;
        //Para vision y comprobacion de rango
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (!playerInSightRange && !playerInAttackRange)
        {
            Patroling();
        }
        if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
        }
        if (playerInAttackRange && playerInSightRange)
        {
            AttackPlayer();
        }
    }
    private void Patroling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }
        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }
        //WalkPoint encontrado
        if (!agent.pathPending && agent.hasPath && agent.remainingDistance < 2f)
        {            
            walkPointSet = false;
        }
        animE.SetBool("IsRunning", true);
    }
    private void SearchWalkPoint()
    {
        //calcular los puntos en rango
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y + 3f, transform.position.z + randomZ);
        RaycastHit impact;
        NavMeshHit hit;
        if (Physics.Raycast(walkPoint, -transform.up, out impact,Mathf.Infinity, whatIsGround) && NavMesh.SamplePosition(impact.point,out hit, 1f, NavMesh.AllAreas))
        {           
            walkPoint = impact.point;
            walkPointSet = true;
        }
        animE.SetBool("IsRunning", true);
    }
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        animE.SetBool("IsRunning", true);
    }
    private void AttackPlayer()
    {
        //Asegurarse de que el enemigo no se mueve
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            sword.gameObject.SetActive(true);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
            source.clip = swordSoundEnemy;
            source.Play();
        }
        animE.SetTrigger("Attack");
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject, timeToDestroy);
        source.clip = deadEnemy;
        source.Play();
        animE.SetBool("isDead", true);
        GetComponent<Collider>().enabled = false;
    }

    public void TakeDamage(int amount)
    {
        currentHealthE -= amount;
        uiHealthbar.fillAmount = ((float)currentHealthE) / maxHealthE;
        animE.SetTrigger("ReceiveDamage");
        animE.ResetTrigger("Attack");
        CancelInvoke();
        Debug.LogError("Ehnemy took damage");
        if(currentHealthE <= 0)
        {
            DestroyEnemy();
        }
    }

}
