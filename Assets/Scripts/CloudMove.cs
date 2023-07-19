using UnityEngine;

public class CloudMove : MonoBehaviour
{
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;

    private float speed;
    private void Start()
    {
        speed = GetRandomSpeed();
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private float GetRandomSpeed()
    {
        return Random.Range(minSpeed, maxSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
