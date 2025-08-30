using UnityEngine;

public class CharacterBase : MonoBehaviour {
    public bool IsDead { get; private set; } = false;

    public virtual void Die() {
        if (IsDead) return;
        IsDead = true;
    }
}