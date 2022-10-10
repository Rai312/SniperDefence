using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamEnemy : Team
{
  [SerializeField] private TeamContainer teamContainer;

  public TeamContainer TeamContainer => teamContainer;

}
