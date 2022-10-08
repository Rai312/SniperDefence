using UnityEngine;
using UnityEngine.AI;

public class Fencing : MonoBehaviour, IDamageable
{
    [SerializeField] private int _health;

    public bool IsAlive { get; private set; }

    private void OnEnable()
    {
        IsAlive = true;
    }

    public void Damage(int damage)
    {

    }
}
