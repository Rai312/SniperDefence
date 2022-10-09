using UnityEngine.AI;

public class Defender : Unit
{
  private NavMeshAgent _navmeshAgent;

  private void Awake()
  {
    _navmeshAgent = GetComponent<NavMeshAgent>();
  }

  public void ActivateNavMeshAgent()
  {
    _navmeshAgent.enabled = true;
  }

  public void DeactivateNavMeshAgent()
  {
    _navmeshAgent.enabled = false;
  }
}