using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PolicemanShooter : Defender
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _shootPoint;
    //[SerializeField] private 

    private void Shoot()
    {
        Bullet bullet = Instantiate(_bulletPrefab, _shootPoint.transform.position, Quaternion.identity, null);
        bullet.transform.DOMove(Target.transform.position, 2f);
    }

    public override void HitTarget()
    {
        Debug.Log("HitTarget");
        Shoot();
        //base.HitTarget();
    }

    public override void OnTargetDied()
    {
        Target.Died -= OnTargetDied;
        SetTarget();
    }
}