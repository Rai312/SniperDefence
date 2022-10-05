using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperMenu : Menu
{
  [SerializeField] private OpticalSight _opticalSight;

  public OpticalSight OpticalSight => _opticalSight;
}
