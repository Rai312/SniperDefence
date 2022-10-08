using System;
using UnityEngine;

public abstract class BuyButton : MonoBehaviour
{
  // [field: SerializeField] public Defender DefenderPrefab { get; private set; }
  [field: SerializeField] public DefenderSquad DefenderSquad { get; private set; }

  public event Action<DefenderSquad> ButtonClick;

  protected virtual void OnButtonClick()
  {
    ButtonClick?.Invoke(DefenderSquad);
  }
}