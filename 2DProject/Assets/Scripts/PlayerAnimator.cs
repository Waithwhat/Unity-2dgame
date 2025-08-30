using UnityEngine;

public class PlayerAnimator : MonoBehaviour {
   [SerializeField] private Animator _animator;

   public void setSpeed(float speed) {
      _animator.SetFloat(ConstantsData.AnimatorParameters.Speed, Mathf.Abs(speed));
   }

   public void setJumping(bool isjumping){
      _animator.SetBool(ConstantsData.AnimatorParameters.isJumping, isjumping);
   }

   public void setFalling(bool isfalling){
      _animator.SetBool(ConstantsData.AnimatorParameters.isFalling, isfalling);
   }

   public void setAttacking(){
      _animator.SetTrigger(ConstantsData.AnimatorParameters.isAttacking);
   }
   
   public void setDeath(bool isdead){
      _animator.SetBool(ConstantsData.AnimatorParameters.isDead, isdead);
   }
}