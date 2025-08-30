using UnityEngine;

[RequireComponent(typeof(GroundDetector))]
public class InputReader : MonoBehaviour {
   private GroundDetector _groundDetector;
   private bool _isJump;
   private bool _isFall;
   private bool _isInteract;
   private bool _isAttack;
   private bool _isPaused;

   public float Direction { get; private set; }

   private void Awake() {
      _groundDetector = GetComponent<GroundDetector>();
   }

   private void Update() {
      Direction = Input.GetAxis(ConstantsData.InputData.HORIZONTAL_AXIS);

      if (Input.GetKeyDown(KeyCode.W))
         _isJump = true;

      if (Input.GetKeyDown(KeyCode.F))
         _isInteract = true;

      if(!_groundDetector.IsGround)
         _isFall = true;

      if(Input.GetMouseButtonDown(0))
         _isAttack = true;

      if(Input.GetKeyDown(KeyCode.Escape))
         _isPaused = true;
         
   }

   public bool GetIsJump() => GetBoolAsTrigger(ref _isJump);
   public bool GetIsInteract() => GetBoolAsTrigger(ref _isInteract);
   public bool GetIsFall() => GetBoolAsTrigger(ref _isFall);
   public bool GetIsAttack() => GetBoolAsTrigger(ref _isAttack);
   public bool GetIsPaused() => GetBoolAsTrigger(ref _isPaused);

   private bool GetBoolAsTrigger(ref bool value) {
      bool localValue = value;
      value = false;

      return localValue;
   }
}