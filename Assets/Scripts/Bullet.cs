using UnityEngine;

public class Bullet : MonoBehaviour
{
   [SerializeField]
   private float speed = 10f;
   [SerializeField]
   private string tagToIgore = "Player";
   private Rigidbody rb;
   private TrailRenderer trailRenderer;
   private void Awake()
   {
    rb = GetComponent<Rigidbody>();
    trailRenderer = GetComponent<TrailRenderer>();
   }
   private void OnEnable()
   {
    rb.linearVelocity = transform.forward * speed;
    trailRenderer.Clear();
   }
   private void StopBullet()
   {
    trailRenderer.Clear();
    rb.linearVelocity = Vector3.zero;
    rb.angularVelocity = Vector3.zero;
   }
   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag(tagToIgore)) return;
    gameObject.SetActive(false);
   }
   private void OnDisable()
   {
    StopBullet();
   }
}
