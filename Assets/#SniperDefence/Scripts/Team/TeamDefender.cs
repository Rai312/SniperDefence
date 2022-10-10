using UnityEngine;

public class TeamDefender : Team
{
  [SerializeField] private DragAndDropSystem _dragAndDropSystem;

  public DragAndDropSystem DragAndDropSystem => _dragAndDropSystem;
  
  //public void RemoveDefendersMerge(DefenderSquad[] defenderSquads)
  //{
  //      // тут надо удалить дефендеров
  //      for (int i = 0; i < defenderSquads.Length; i++)
  //      {
  //          //var defenders = defenderSquat[i].GetComponentsInChildren<Defender>();
  //          var defenders = defenderSquads[i].GetComponentsInChildren<Defender>();
  //          for (int j = 0; j < defenders.Length; j++)
  //          {
  //              defenders[i].Died -= OnDied;
  //          }
  //      }
  //}
}
