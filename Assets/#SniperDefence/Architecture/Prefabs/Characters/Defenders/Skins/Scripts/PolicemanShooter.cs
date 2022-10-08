using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;

public class PolicemanShooter : Defender
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _shootPoint;

    private void Shoot()
    {
        SetTarget();
        Bullet bullet = Instantiate(_bulletPrefab, _shootPoint.transform.position, Quaternion.identity, null);
        bullet.transform.DOMove(Target.transform.position, 0.5f).SetEase(Ease.Linear).OnComplete(() => { bullet.gameObject.SetActive(false); });
        //Debug.Log(Target.transform.position + " - " + this);
    }

    public override void HitTarget()
    {
        //Debug.Log("HitTarget");
        Shoot();
        //base.HitTarget();
    }

    public override void OnTargetDied()
    {
        Target.Died -= OnTargetDied;
        //SetTarget();
    }
}