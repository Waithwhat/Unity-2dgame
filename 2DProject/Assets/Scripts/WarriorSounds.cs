using UnityEngine;

public class WarriorSounds : MonoBehaviour {
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip runSound;
    [SerializeField] private AudioClip attackSound;
    [SerializeField] private AudioClip deathSound;

    public void PlayRun() {
        audioSource.PlayOneShot(runSound);
    }

    public void PlayAttack() {
        audioSource.PlayOneShot(attackSound);
    }

    public void PlayDeath() {
        audioSource.PlayOneShot(deathSound);
    }
}