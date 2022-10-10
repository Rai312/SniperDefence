using System;
using UnityEngine;

public class DragAndDropSystem : MonoBehaviour
{
  const int MaximumMergeLevel = 6;

  [SerializeField] private LayerMask _gridLayerMask;
  [SerializeField] private LayerMask _groundLayerMask;
  [SerializeField] private DefenderFactory _defenderFactory;
  [SerializeField] private Color _activeGridColor;
  [SerializeField] private Color _inactiveGridColor;

  private Grid _activeGrid;
  private Grid _hoverGrid;
  private DefenderSquad _activeDefenderSquad;
  private bool _isDrag = false;
  private float _rayDistance = float.PositiveInfinity;

  public event Action<DefenderSquad, DefenderSquad, DefenderSquad> Merged;

  private void Update()
  {
    Hit();
  }

  private void Hit()
  {
    RaycastHit hit;

    if (Input.touchCount > 0)
    {
      Touch touch = Input.GetTouch(0);

      Ray ray = Camera.main.ScreenPointToRay(touch.position);

      if (Physics.Raycast(ray, out hit, _rayDistance, _gridLayerMask))
        GetInfoAboutGrid(hit);

      if (touch.phase == TouchPhase.Moved && _isDrag)
      {
        _activeGrid.ChangeColor(_activeGridColor);
        StartDrag(ray);
      }

      if (touch.phase == TouchPhase.Ended && _isDrag || touch.phase == TouchPhase.Canceled && _isDrag)
      {
        _activeGrid.ChangeColor(_inactiveGridColor);
        StopDrag(ray);
      }
    }
  }

  private void StopDrag(Ray ray)
  {
    RaycastHit hit;

    if (Physics.Raycast(ray, out hit, _rayDistance, _gridLayerMask))
    {
      if (hit.collider.TryGetComponent(out Grid grid) && grid.IsActive == false)
      {
        if (grid.DefenderSquad != null
            && _activeGrid.DefenderSquad.Level == grid.DefenderSquad.Level &&
            _activeGrid.DefenderSquad.Type == grid.DefenderSquad.Type)
        {
          if (grid.DefenderSquad.Level == MaximumMergeLevel)
            SwapPlaces(grid);
          else
            Merge(grid);
        }
        else if (grid.IsBusy)
          SwapPlaces(grid);
        else
          SetDefenderSquadOnEmptyGrid(grid);
      }
      else
        PutInPlace();
    }
    else
      PutInPlace();

    ClearInfoAboutGrid();
  }

  private void Merge(Grid grid)
  {
    grid.ActivateMergeParticle();
    Destroy(grid.DefenderSquad.gameObject);
    Destroy(_activeGrid.DefenderSquad.gameObject);
    DefenderSquad defenderSquad =
      _defenderFactory.GetDefenderSquad(_activeGrid.DefenderSquad.Level + 1, _activeGrid.DefenderSquad.Type);
    DefenderSquad newDefenderSquad = Instantiate(defenderSquad, grid.transform.position, Quaternion.identity, null);
    Merged?.Invoke(newDefenderSquad, grid.DefenderSquad, _activeGrid.DefenderSquad);
    grid.AddDefenderSquad(newDefenderSquad);
    _activeGrid.DeleteUnits();
    _activeGrid.MakeIsFree();
    _activeGrid.MakeIsInactive();
  }

  private void SwapPlaces(Grid grid)
  {
    DefenderSquad tempDefenderSquad = grid.DefenderSquad;

    grid.AddDefenderSquad(_activeGrid.DefenderSquad);
    _activeGrid.DefenderSquad.transform.position = grid.transform.position;
    _activeGrid.AddDefenderSquad(tempDefenderSquad);
    tempDefenderSquad.transform.position = _activeGrid.transform.position;
  }

  private void GetInfoAboutGrid(RaycastHit hit)
  {
    if (hit.collider.TryGetComponent(out Grid grid) && _isDrag == false && grid.IsBusy)
    {
      _isDrag = true;
      _activeGrid = grid;
      _activeGrid.MakeIsActive();
      _activeDefenderSquad = _activeGrid.DefenderSquad;
    }
  }

  private void StartDrag(Ray ray)
  {
    RaycastHit hit;
    float yOffset = 1;
    float zeroOffset = 0;

    if (Physics.Raycast(ray, out hit, _rayDistance, _groundLayerMask))
    {
      _activeDefenderSquad.DeactivateNavMesh();
      _activeDefenderSquad.transform.position = hit.point + new Vector3(zeroOffset, yOffset, zeroOffset);
    }
  }

  private void SetDefenderSquadOnEmptyGrid(Grid grid)
  {
    _hoverGrid = grid;
    _hoverGrid.AddDefenderSquad(_activeDefenderSquad);
    _hoverGrid.MakeIsBusy();
    _activeDefenderSquad.transform.position = _hoverGrid.transform.position;
    _activeDefenderSquad.ActivateNavMesh();

    _activeGrid.DeleteUnits();
    _activeGrid.MakeIsFree();
  }

  private void ClearInfoAboutGrid()
  {
    _activeGrid.MakeIsInactive();
    _isDrag = false;
    _hoverGrid = null;
    _activeGrid = null;
  }

  private void PutInPlace()
  {
    _activeDefenderSquad.ActivateNavMesh();
    _activeDefenderSquad.transform.position = _activeGrid.transform.position;
  }
}