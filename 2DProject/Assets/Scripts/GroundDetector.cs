using UnityEngine;

public class GroundDetector : MonoBehaviour {
    [SerializeField] private Transform checkGround;
    [SerializeField] private float checkRadius = 0.15f;
    [SerializeField] private LayerMask groundLayer;

    public bool IsGround {get; private set;}

    private void Update() {
        IsGround = Physics2D.OverlapCircle(checkGround.position, checkRadius, groundLayer);
    }

    private void OnDrawGizmosSelected() {
        if (checkGround != null) {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(checkGround.position, checkRadius);
        }
    }
}