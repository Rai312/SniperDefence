using UnityEngine;

public class TeamDefender : Team
{
  [SerializeField] private DragAndDropSystem _dragAndDropSystem;

  public DragAndDropSystem DragAndDropSystem => _dragAndDropSystem;

}
