using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private LayerMask _raycastMask;
    [SerializeField] private ButtonSelectionLogic _buttonSelectionLogic;
    [Space(10)][SerializeField] private Fencing _fencingPrefab;
    [SerializeField] private PolicemanFighter _fighterPrefab;
    [SerializeField] private PolicemanShooter _shooterPrefab;
    [SerializeField] private float _timeBeetwenSpawn;

    private float _elapsedTime;
    private Collider[] _colliders;
    private float _rayDistance = 1000f;
    private float _radius = 6f;
    private Defender _activeDefender;
    private Defender _spawnedUnit;

    public event Action<Defender> Spawned;

    private void OnEnable()
    {
        _buttonSelectionLogic.ButtonSelected += ChooseSpawnUnit;
    }

    private void OnDisable()
    {
        _buttonSelectionLogic.ButtonSelected -= ChooseSpawnUnit;
    }

    public Unit GetSpawnedUnit(List<Unit> units)
    {
        if (_spawnedUnit != null)
            return _spawnedUnit;

        return null;
    }

    private void ChooseSpawnUnit(Defender defender)
    {
        _activeDefender = defender;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (Input.GetMouseButton(0) && _activeDefender != null && _elapsedTime > _timeBeetwenSpawn)
        {
            _elapsedTime = 0;
            Hit();
        }
    }

    private bool CanSpawn(Vector3 hitPoint)
    {
        Collider[] intersecting =
          Physics.OverlapBox(hitPoint, (_activeDefender.GetComponent<MeshRenderer>().bounds.size / 2));

        foreach (var intersectin in intersecting)
        {
            if (intersectin.TryGetComponent<Unit>(out Unit defender))
                return false;
        }

        return true;
    }

    private void Hit()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 offsets = new Vector3(0, 1f, 0);

        if (Physics.Raycast(ray, out hit, _rayDistance, _raycastMask))
        {
            if (CanSpawn(hit.point))
            {
                _spawnedUnit = Instantiate(_activeDefender, (hit.point), Quaternion.identity, null);
                
                Spawned?.Invoke(_spawnedUnit);
            }
        }
    }
}