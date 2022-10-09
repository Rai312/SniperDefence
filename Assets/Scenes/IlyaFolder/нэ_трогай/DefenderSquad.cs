using UnityEngine;

public class DefenderSquad : MonoBehaviour
{
  [field: SerializeField] public DefenderType Type { get; private set; }
  [field: SerializeField] public int Level { get; private set; }

  private Defender[] _defenders;

  private void Awake()
  {
    _defenders = GetComponentsInChildren<Defender>();
  }

  public void DeactivateNavMesh()
  {
    for (int i = 0; i < _defenders.Length; i++)
    {
      _defenders[i].DeactivateNavMeshAgent();
    }
  }

  public void ActivateNavMesh()
  {
    for (int i = 0; i < _defenders.Length; i++)
    {
      _defenders[i].ActivateNavMeshAgent();
    }
  }
}