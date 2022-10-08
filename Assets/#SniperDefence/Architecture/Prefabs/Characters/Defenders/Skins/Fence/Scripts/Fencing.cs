using UnityEngine;
using UnityEngine.AI;

public class Fencing : MonoBehaviour, IDamageable
{
    [SerializeField] private int _health;

    public void Damage(int damage)
    {
        throw new System.NotImplementedException();
    }
}
