using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(EnemyDetector))]
public class PlayerLogic : MonoBehaviour {
   [SerializeField] private float _moveSpeed;
   [SerializeField] private float _jumpForce;
   private EnemyDetector _enemyDetector;

   private Rigidbody2D _rigidbody;
   private bool _isTurnRight = true;

   private void Awake() {
      _enemyDetector = GetComponent<EnemyDetector>();
   }

   private void Start() {
      _rigidbody = GetComponent<Rigidbody2D>();
   }

   public void Jump() {
      _rigidbody.AddForce(new Vector2(0f, _jumpForce));
   }

   public void Move(float direction) {
      _rigidbody.velocity = new Vector2(_moveSpeed * direction, _rigidbody.velocity.y);

      if ((direction > 0 && _isTurnRight == false) || (direction < 0 && _isTurnRight))
         Flip();
   }
   
   public void Kill() {
      Collider2D enemyCollider = _enemyDetector.GetEnemyCollider();
        if (enemyCollider != null) {
            EnemyLogic enemy = enemyCollider.GetComponent<EnemyLogic>();
            if (enemy != null)
               enemy.Die();
        }
   }

   private void Flip() {
      _isTurnRight = !_isTurnRight;
      Vector3 scale = transform.localScale;
      scale.x *= -1;
      transform.localScale = scale;
   }
}