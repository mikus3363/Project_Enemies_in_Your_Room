using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public NavMeshAgent agent;
    public float speed = 0.2f;
    public float attackRange = 2f;          // zwiększony zasięg
    public float attackCooldown = 1.5f;     // odstęp między atakami

    public Animator animator;
    private Transform target;
    private bool isAttacking = false;
    private bool isDead = false;
    public int maxHealth = 2;
    private int currentHealth;
    private int torsoHits = 0;
    private bool isFalling = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        target = Camera.main.transform;

        currentHealth = maxHealth;
        agent.speed = speed;
        agent.stoppingDistance = 0.5f;      // żeby podchodził możliwie blisko
    }

    void Update()
    {
        if (isDead || !agent || !target || !agent.isOnNavMesh)
            return;

        float distance = Vector3.Distance(transform.position, target.position);

        // Zombie patrzy na gracza (tylko w poziomie)
        Vector3 lookDir = target.position - transform.position;
        lookDir.y = 0f;
        if (lookDir.sqrMagnitude > 0.01f)
        {
            Quaternion rotation = Quaternion.LookRotation(lookDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5f);
        }

        float remainingDistance = agent.remainingDistance;

        // ✳️ Przerwij atak jeśli gracz się oddali
        if (isAttacking && distance > 0.5f)
        {
            isAttacking = false;
            animator.SetBool("isAttacking", false);

            agent.isStopped = false;
            agent.SetDestination(target.position);
        }

        // ✳️ Wejdź w atak tylko jeśli agent dotarł naprawdę blisko
        else if (!isAttacking && !agent.pathPending && agent.hasPath && remainingDistance > 0 && remainingDistance <= agent.stoppingDistance + 0.05f)
        {
            isAttacking = true;
            animator.SetBool("isAttacking", true);

            agent.isStopped = true;
            agent.ResetPath();
        }

        // ✳️ Jeśli nie atakuje, to ruszaj
        else if (!isAttacking)
        {
            if (agent.isStopped)
                agent.isStopped = false;

            agent.SetDestination(target.position);
        }

        animator.SetFloat("Speed", agent.velocity.magnitude);
    }

    public void Kill()
    {
        if (isDead) return; // zabezpieczenie przed powtórnym wywołaniem

        isDead = true;
        isFalling = false;

        // Powiadom spawner, że zombie umarł
        ZombieSpawner spawner = FindFirstObjectByType<ZombieSpawner>();
        if (spawner != null)
            spawner.NotifyZombieDied();

        // DODAJ PUNKTY do GameManagera
        var gm = FindFirstObjectByType<GameStartUI>();
        if (gm != null)
            gm.AddPoints(150);

        if (agent != null)
            agent.enabled = false;

        animator.SetBool("isAttacking", false);
        animator.SetTrigger("gotShot");

        StartCoroutine(DieAfterDelay(5f));
    }

    private IEnumerator DieAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    public void TakeDamage(int amount, bool isHeadshot = false)
    {
        if (isDead || isFalling) return;

        animator.SetBool("hitToHead", isHeadshot);
        animator.SetTrigger("gotShot");

        if (isHeadshot)
        {
            Kill();
            return;
        }

        torsoHits++;
        currentHealth -= amount;

        if (torsoHits >= 2 || currentHealth <= 0)
        {
            Kill(); // po 2. trafieniu – pełna śmierć
        }
        else
        {
            // Odpal lekką reakcję – animację upadania, ale wróć po chwili do Idle
            StartCoroutine(TemporaryFallingForward());
        }
    }

    private IEnumerator TemporaryFallingForward()
    {
        isFalling = true;

        if (agent != null)
        {
            agent.isStopped = true;
            agent.ResetPath();

            // Spowolnij zombie
            float originalSpeed = agent.speed;
            agent.speed = 0.05f;

            animator.SetTrigger("gotShot");

            yield return new WaitForSeconds(0.5f); // czas potknięcia

            // Przywróć oryginalną prędkość i wznowij ruch
            if (!isDead)
            {
                agent.speed = originalSpeed;
                agent.isStopped = false;
                agent.SetDestination(target.position);
            }
        }

        isFalling = false;
    }
}
