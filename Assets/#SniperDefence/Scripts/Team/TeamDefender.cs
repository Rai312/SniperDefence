using UnityEngine;

public class TeamDefender : Team
{
  [SerializeField] private DragAndDropSystem _dragAndDropSystem;

  public DragAndDropSystem DragAndDropSystem => _dragAndDropSystem;
  
  public void RemoveDefendersMerge(DefenderSquad[] defenderSquads)
  {
        // тут надо удалить дефендеров
  }
}
