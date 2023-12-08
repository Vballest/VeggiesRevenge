using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
	public NavMeshAgent agent;

	public Transform player;

	public LayerMask whatIsGround;

	public LayerMask whatIsPlayer;

	public float health;

	public bool hasProyectile;

	public float attackPower;

	public float speed;

	public Vector3 walkPoint;

	private bool walkPointSet;

	public float walkPointRange;

	public float timeBetweenAttacks;

	private bool alreadyAttacked;

	public GameObject projectile;

	public float sightRange;

	public float attackRange;

	public bool playerInSightRange;

	public bool playerInAttackRange;

	private bool playerAttack;

	private void Awake()
	{
		player = GameObject.Find("Player").transform;
		agent = GetComponent<NavMeshAgent>();
	}

	private void Update()
	{
		if (!playerAttack)
		{
			playerInSightRange = Physics.CheckSphere(base.transform.position, sightRange, whatIsPlayer);
		}
		else
		{
			playerInSightRange = true;
		}
		playerInAttackRange = Physics.CheckSphere(base.transform.position, attackRange, whatIsPlayer);
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
			base.transform.LookAt(walkPoint);
		}
		if ((base.transform.position - walkPoint).magnitude < 1f)
		{
			walkPointSet = false;
		}
	}

	private void SearchWalkPoint()
	{
		float num = Random.Range(0f - walkPointRange, walkPointRange);
		float num2 = Random.Range(0f - walkPointRange, walkPointRange);
		walkPoint = new Vector3(base.transform.position.x + num2, base.transform.position.y, base.transform.position.z + num);
		if (Physics.Raycast(walkPoint, -base.transform.up, 2f, whatIsGround))
		{
			walkPointSet = true;
		}
	}

	public void ChasePlayer()
	{
		agent.SetDestination(player.position);
		base.transform.LookAt(player);
	}

	public bool ParmPlayerIsAttacking(bool _playerAttack)
	{
		playerAttack = _playerAttack;
		return playerAttack;
	}

	private void AttackPlayer()
	{
		agent.SetDestination(base.transform.position);
		base.transform.LookAt(player);
		if (alreadyAttacked)
		{
			return;
		}
		if (hasProyectile)
		{
			Rigidbody component = Object.Instantiate(projectile, base.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
			component.AddForce(base.transform.forward * 32f, ForceMode.Impulse);
			component.AddForce(base.transform.up * 8f, ForceMode.Impulse);
			alreadyAttacked = true;
			Invoke("ResetAttack", timeBetweenAttacks);
			return;
		}
		HealthControllerPlayer component2 = player.GetComponent<HealthControllerPlayer>();
		if ((bool)component2)
		{
			component2.ApplyDamage(attackPower);
		}
		alreadyAttacked = true;
		Invoke("ResetAttack", timeBetweenAttacks);
	}

	private void ResetAttack()
	{
		alreadyAttacked = false;
	}

	public void TakeDamage(int damage)
	{
		health -= damage;
		if (health <= 0f)
		{
			Invoke("DestroyEnemy", 0.5f);
		}
	}

	private void DestroyEnemy()
	{
		Object.Destroy(base.gameObject);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(base.transform.position, attackRange);
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(base.transform.position, sightRange);
	}
}
