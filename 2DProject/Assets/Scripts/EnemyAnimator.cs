using UnityEngine;

public class EnemyAnimator : MonoBehaviour {
    [SerializeField] private Animator _enemyAnim;

    public void setEnemyRun(float speed) {
        _enemyAnim.SetFloat(ConstantsData.AnimatorParameters.Speed, Mathf.Abs(speed));
    }

    public void setEnemyAttack(bool isattacking) {
        _enemyAnim.SetBool(ConstantsData.AnimatorParameters.isAttacking, isattacking);
    }

    public void setEnemyDeath(bool isdead) {
        _enemyAnim.SetBool(ConstantsData.AnimatorParameters.isDead, isdead);
    }
}