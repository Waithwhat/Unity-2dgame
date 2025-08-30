using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour {
   public event Action<Finish> FinishReached;
   public event Action DeathGroundTouched;

   private void OnTriggerEnter2D(Collider2D collision) {
      if (collision.TryGetComponent(out Finish finish)){
         FinishReached?.Invoke(finish);
      }
   }
   
   private void OnCollisionEnter2D(Collision2D collision) {
      if (collision.gameObject.CompareTag("GroundDeath")) {
         DeathGroundTouched?.Invoke();
      }
   }
}