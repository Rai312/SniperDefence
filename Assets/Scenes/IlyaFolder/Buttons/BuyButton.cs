using System;
using UnityEngine;

public abstract class BuyButton : MonoBehaviour
{
  [field: SerializeField] public Unit DefenderPrefab { get; private set; }

  public event Action<BuyButton> ButtonClick;

  protected virtual void OnButtonClick()
  {
    ButtonClick?.Invoke(this);
  }
}