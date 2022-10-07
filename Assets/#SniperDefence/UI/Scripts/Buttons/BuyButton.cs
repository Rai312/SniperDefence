using System;
using UnityEngine;

public abstract class BuyButton : MonoBehaviour
{
  // [field: SerializeField] public Defender DefenderPrefab { get; private set; }
  [field: SerializeField] public DefenderSquat DefenderSquat { get; private set; }

  public event Action<DefenderSquat> ButtonClick;

  protected virtual void OnButtonClick()
  {
    ButtonClick?.Invoke(DefenderSquat);
  }
}