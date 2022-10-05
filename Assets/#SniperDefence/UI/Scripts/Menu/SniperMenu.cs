using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SniperMenu : Menu
{
  [SerializeField] private OpticalSight _opticalSight;
  [SerializeField] private Button _startButton;

  public Button StartButton => _startButton;
  public OpticalSight OpticalSight => _opticalSight;
}
