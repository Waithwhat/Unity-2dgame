using UnityEngine;

public class StaticBackground : MonoBehaviour {
    [SerializeField] private Transform cam;
    [SerializeField] private float parallaxEffect;

    private Vector3 lastCamPos;

    void Start() {
        if (cam == null)
            cam = Camera.main.transform;

        lastCamPos = cam.position;
    }

    void LateUpdate() {
        Vector3 deltaMovement = cam.position - lastCamPos;
        transform.position += new Vector3(deltaMovement.x * parallaxEffect, deltaMovement.y * parallaxEffect, 0);
        lastCamPos = cam.position;
    }
}