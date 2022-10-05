using System.Collections;
using DG.Tweening;
using UnityEngine;

public class OpticalSight : MonoBehaviour
{
  [SerializeField] private float _startZoom;
  [SerializeField] private GameObject _sight;

  private Camera _camera;
  private float _maximuFov = 60;
  private float _targetZoom;
  private float _duration = 1f;

  private void Awake()
  {
    _camera = GetComponent<Camera>();
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Z))
    {
      Show();
    }
    else if (Input.GetKeyDown(KeyCode.X))
      Hide();
  }

  private void Show()
  {
    _sight.SetActive(true);
    _targetZoom = _maximuFov - _startZoom;
    _camera.DOFieldOfView(_targetZoom, _duration);
  }

  private void Hide()
  {
    _sight.SetActive(false);
    _targetZoom = _maximuFov;
    _camera.DOFieldOfView(_maximuFov, _duration);
  }
}