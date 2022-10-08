using UnityEngine;

public class DragAndDropSystem : MonoBehaviour
{
  [SerializeField] private LayerMask _layerMask;

  private float _rayDistance = 10000f;
  
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

      if (Physics.Raycast(ray, out hit, _rayDistance, _layerMask))
      {
        print(hit.point);
      }

      if (touch.phase == TouchPhase.Began)
        StartDrag();

      if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
        StopDrag();
    }
  }
  
  private void StartDrag()
  {

  }

  private void StopDrag()
  {
    
  }
}

