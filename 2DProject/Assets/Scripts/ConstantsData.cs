using UnityEngine;

public class ConstantsData {
   public static class AnimatorParameters {
      public static readonly int Speed = Animator.StringToHash(nameof(Speed));
      public static readonly int isJumping = Animator.StringToHash(nameof(isJumping));
      public static readonly int isFalling = Animator.StringToHash(nameof(isFalling));
      public static readonly int isAttacking = Animator.StringToHash(nameof(isAttacking));
      public static readonly int isDead = Animator.StringToHash(nameof(isDead));
      public static readonly string isActivated = nameof(isActivated);
   }

   public static class Tags {
      public const string GROUND_TAG = "Ground";
   }

   public static class InputData {
      public const string HORIZONTAL_AXIS = "Horizontal"; 
   }
}