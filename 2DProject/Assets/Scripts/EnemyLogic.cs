using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D), typeof(EnemyAnimator))]
public class EnemyLogic : CharacterBase {
    [SerializeField] private float speed = 2.5f;
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float waitTime = 3f;

    private EnemyAnimator _enemyAnimator;
    private EnemyDetector _enemyDetector;

    private Vector3 targetPoint;
    private bool isAttacking = false;
    private bool _isTurnRight = false;
    private bool isWaiting = false;
    private float curSpeed;

    private void Awake() {
        _enemyAnimator = GetComponent<EnemyAnimator>();
        _enemyDetector = GetComponent<EnemyDetector>();
    }

    private void Start() {
        targetPoint = pointB.position;
    }

    private void FixedUpdate() {
        if (IsDead) {
            curSpeed = 0f;
            _enemyAnimator.setEnemyRun(curSpeed);
            _enemyAnimator.setEnemyDeath(true);
            return;
        }

        Collider2D targetCol = _enemyDetector.GetEnemyCollider();
        bool canAttack = targetCol != null && targetCol.GetComponent<CharacterBase>()?.IsDead == false;

        if (canAttack && !isAttacking) {
            Attack(targetCol);
        }
        else if (!canAttack) {
            isAttacking = false;
        }

        if (!isAttacking && !isWaiting) {
            Patrol();
        }
        else if (isWaiting) {
            curSpeed = 0f;
        }
        else {
            curSpeed = 0f;
        }

        _enemyAnimator.setEnemyRun(curSpeed);
        _enemyAnimator.setEnemyAttack(isAttacking);
        _enemyAnimator.setEnemyDeath(IsDead);
    }

    private void Patrol() {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed * Time.fixedDeltaTime);
        curSpeed = speed;

        if (Vector3.Distance(transform.position, targetPoint) <= 0.1f) {
            StartCoroutine(WaitAndSwitchTarget());
        }
    }

    private IEnumerator WaitAndSwitchTarget() {
        isWaiting = true;
        curSpeed = 0f;

        yield return new WaitForSeconds(waitTime);
        
        if (targetPoint == pointA.position)
            targetPoint = pointB.position;
        else
            targetPoint = pointA.position;

        Flip();
        isWaiting = false;
    }

    private void Attack(Collider2D targetCol) {
        curSpeed = 0f;
        isAttacking = true;

        CharacterBase target = targetCol.GetComponent<CharacterBase>();
        if (target != null && !target.IsDead) {
            target.Die();
        }
    }

    private void Flip() {
        _isTurnRight = !_isTurnRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public override void Die() {
        base.Die();
        Debug.Log("Enemy died");
    }
}