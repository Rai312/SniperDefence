using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
  private const int DefenderCount = 3;

  [SerializeField] private LayerMask _raycastMask;
  [SerializeField] private ButtonSelectionLogic _buttonSelectionLogic;
  [Space(10)] [SerializeField] private Fencing _fencingPrefab;
  [SerializeField] private PolicemanFighter _fighterPrefab;
  [SerializeField] private PolicemanShooter _shooterPrefab;
  [SerializeField] private float _timeBeetwenSpawn;

  private List<Vector3> _targetPoints = new List<Vector3>();
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

  public void Initialize()
  {
    Disable();
  }

  public void Enable()
  {
    enabled = true;
  }

  public void Disable()
  {
    //Debug.Log("DisableSpawner");
    enabled = false;
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
      Physics.OverlapBox(hitPoint, (_activeDefender.GetComponentInChildren<MeshRenderer>().bounds.size / 2));

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
    Vector3 firstPoint;
    Vector3 secondPoint;
    Vector3 threePoint;

    if (Physics.Raycast(ray, out hit, _rayDistance, _raycastMask))
    {
      if (CanSpawn(hit.point))
      {
        firstPoint = new Vector3(hit.point.x + 1f, hit.point.y, hit.point.z);
        secondPoint = new Vector3(hit.point.x - 1f, hit.point.y, hit.point.z);
        threePoint = new Vector3(hit.point.x, hit.point.y, hit.point.z + 1.5f);
        
        _targetPoints.Add(firstPoint);
        _targetPoints.Add(secondPoint);
        _targetPoints.Add(threePoint);
        
        for (int i = 0; i < DefenderCount; i++)
        {
          _spawnedUnit = Instantiate(_activeDefender, _targetPoints[i], Quaternion.identity, null);
          Spawned?.Invoke(_spawnedUnit);
        }

        _targetPoints.Clear();
      }
    }
  }
}