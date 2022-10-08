using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            Debug.Log(enemy.name);
            //enemy.gameObject.SetActive(false);
            enemy.Damage(200);
            Destroy(gameObject);
        }
    }

    public void Move()
    {
        _rigidbody.AddForce(Camera.main.transform.forward * _movementSpeed, ForceMode.Impulse);
    }
}