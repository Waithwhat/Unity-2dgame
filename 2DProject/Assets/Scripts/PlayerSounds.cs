using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip runSound1;
    [SerializeField] private AudioClip runSound2;
    [SerializeField] private AudioClip attackSound;
    [SerializeField] private AudioClip deathSound;

    public void PlayRun1() {
        audioSource.PlayOneShot(runSound1);
    }

    public void PlayRun2() {
        audioSource.PlayOneShot(runSound2);
    }

    public void PlayAttack() {
        audioSource.PlayOneShot(attackSound);
    }

    public void PlayDeath() {
        audioSource.PlayOneShot(deathSound);
    }
}