using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(InputReader), typeof(GroundDetector), typeof(PlayerLogic))]
[RequireComponent(typeof(PlayerAnimator), typeof(CollisionHandler), typeof(EnemyDetector))]
public class Player : CharacterBase {
   private InputReader _inputReader;
   private GroundDetector _groundDetector;
   private PlayerLogic _playerLogic;
   private PlayerAnimator _playerAnimator;
   private CollisionHandler _collisionHandler;
   private EnemyDetector _enemyDetector;

   private Finish _finish;

   private void Awake() {
      _inputReader = GetComponent<InputReader>();
      _groundDetector = GetComponent<GroundDetector>();
      _playerLogic = GetComponent<PlayerLogic>();
      _playerAnimator = GetComponent<PlayerAnimator>();
      _collisionHandler = GetComponent<CollisionHandler>();
      _enemyDetector = GetComponent<EnemyDetector>();
   }

   private void OnEnable() {
      _collisionHandler.FinishReached += OnFinishReached;
      _collisionHandler.DeathGroundTouched += OnDeathGroundTouched;
   }

   private void OnDisable() {
      _collisionHandler.FinishReached -= OnFinishReached;
      _collisionHandler.DeathGroundTouched -= OnDeathGroundTouched;
   }

   private void FixedUpdate() {
      if(!IsDead) {
         bool jumpCondition = _inputReader.GetIsJump();
         bool attackCondition = _inputReader.GetIsAttack();
      
         _playerAnimator.setSpeed(_inputReader.Direction);
         _playerAnimator.setJumping(jumpCondition);
         _playerAnimator.setFalling(_inputReader.GetIsFall());
         if (attackCondition) {
    _playerAnimator.setAttacking();
}

         if (_inputReader.Direction != 0)
            _playerLogic.Move(_inputReader.Direction);

         if (jumpCondition && _groundDetector.IsGround)
            _playerLogic.Jump();

         if (attackCondition && _enemyDetector.IsEnemy() && _inputReader.Direction < 0.01)
            _playerLogic.Kill();

         if (_inputReader.GetIsInteract() && _finish != null)
            _finish.Interact();
      }
      else {
         _playerAnimator.setDeath(IsDead);
      }
   }

   public override void Die() {
      base.Die();
      Debug.Log("Player died");
   }

   private void OnFinishReached(Finish finish) {
      _finish = finish;
      int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
      SceneManager.LoadScene(currentSceneIndex - 1);
   }
   private void OnDeathGroundTouched() {
      Die();
   }
}