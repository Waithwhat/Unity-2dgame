using UnityEngine;

public class EnemyDetector : MonoBehaviour {
    [SerializeField] private Transform enemyCheck;
    [SerializeField] private float checkRadius = 0.9f;
    [SerializeField] private LayerMask enemyLayer;

    public bool IsEnemy() {
        return Physics2D.OverlapCircle(enemyCheck.position, checkRadius, enemyLayer);
    }
    
    public Collider2D GetEnemyCollider() {
        return Physics2D.OverlapCircle(enemyCheck.position, checkRadius, enemyLayer);
    }

    private void OnDrawGizmosSelected() {
        if (enemyCheck != null) {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(enemyCheck.position, checkRadius);
        }
    }
}