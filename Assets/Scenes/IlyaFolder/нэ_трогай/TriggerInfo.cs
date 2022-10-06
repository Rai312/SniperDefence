using UnityEngine;

public class TriggerInfo : MonoBehaviour
{
  public int gridX = -1;

  public TriggerInfoType Type = TriggerInfoType.MergeTrigger;
}

public enum TriggerInfoType
{
  MergeTrigger,
  RemoveTrigger
}