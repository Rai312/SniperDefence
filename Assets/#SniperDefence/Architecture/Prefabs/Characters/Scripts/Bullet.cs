using System;
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
    print("попал");
    
    if(other.gameObject.TryGetComponent(out Unit unit))
      unit.gameObject.SetActive(false);
  }

  public void Move()
  {
    _rigidbody.AddForce(Camera.main.transform.forward * _movementSpeed, ForceMode.Impulse);
  }
}