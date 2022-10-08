using UnityEngine;

public class Bullet : MonoBehaviour//сделать абстрактным
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private int _damage;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            //Debug.Log(enemy.name);
            //enemy.gameObject.SetActive(false);
            enemy.Damage(_damage);
            Destroy(gameObject);
        }
    }

    public void Move()
    {
        _rigidbody.AddForce(Camera.main.transform.forward * _movementSpeed, ForceMode.Impulse);
    }
}