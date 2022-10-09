using UnityEngine;

public class DragAndDropSystem : MonoBehaviour
{
  [SerializeField] private LayerMask _gridLayerMask;
  [SerializeField] private LayerMask _groundLayerMask;

  private float _rayDistance = float.PositiveInfinity;
  private Grid _activeGrid;
  private Grid _hoverGrid;
  private DefenderSquad _activeDefenderSquad;
  private bool _isDrag = false;

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
      {
        if (hit.collider.TryGetComponent(out Grid grid) && _isDrag == false && grid.IsBusy )
        {
          _isDrag = true;
          _activeGrid = grid;
          _activeGrid.MakeIsActive();
          _activeDefenderSquad = _activeGrid.DefenderSquad;
        }
      }

      if (touch.phase == TouchPhase.Moved && _isDrag)
      {
        if (Physics.Raycast(ray, out hit, _rayDistance, _groundLayerMask))
        {
          _activeDefenderSquad.DeactivateNavMesh();
          _activeDefenderSquad.transform.position = hit.point + new Vector3(0, 1, 0);
        }
      }

      if (touch.phase == TouchPhase.Ended && _isDrag|| touch.phase == TouchPhase.Canceled && _isDrag)
      {
        if (Physics.Raycast(ray, out hit, _rayDistance, _gridLayerMask))
        {
          if (hit.collider.TryGetComponent(out Grid grid) && grid.IsActive == false)
          {
            if (grid.IsBusy == true)
            {
            //  grid.AddUnits(_activeDefenderSquad);
              _activeDefenderSquad.transform.position = _hoverGrid.transform.position;
            }
            else
            {
              _hoverGrid = grid;
              _hoverGrid.AddUnits(_activeDefenderSquad);
              _hoverGrid.MakeIsBusy();
              _activeDefenderSquad.transform.position = _hoverGrid.transform.position;
              _activeDefenderSquad.ActivateNavMesh();

              _activeGrid.DeleteUnits();
              _activeGrid.MakeIsFree();
            }
          }
          else
            PutInPlace();
        }
        else
          PutInPlace();

        _activeGrid.MakeIsInactive();
        _isDrag = false;
        _hoverGrid = null;
        _activeGrid = null;
      }
    }
  }

  private void PutInPlace()
  {
    _activeDefenderSquad.ActivateNavMesh();
    _activeDefenderSquad.transform.position = _activeGrid.transform.position;
  }
}