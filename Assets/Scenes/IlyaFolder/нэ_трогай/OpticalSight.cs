using System;
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
  private Tween _fieldFovAnimation1;
  private Tween _fieldFovAnimation2;
  private bool _canShoot = false;

  public event Action SightIsReleased;

  private void Awake()
  {
    _camera = GetComponent<Camera>();
  }

  private void Update()
  {
    EnableSight();
  }

  public void EnableSight()
  {
    if (Input.touchCount > 0)
    {
      if (Input.GetTouch(0).phase == TouchPhase.Began)
      {
        _sight.SetActive(true);
        _targetZoom = _maximuFov - _startZoom;
        _fieldFovAnimation1 = _camera.DOFieldOfView(_targetZoom, _duration);
      }

      if (Input.GetTouch(0).phase == TouchPhase.Ended)
      {
        StartCoroutine(Hide());
      }
    }
  }

  private IEnumerator Hide()
  {
    SightIsReleased?.Invoke();
    float delay = 0.8f;
    WaitForSeconds waitForSeconds = new WaitForSeconds(delay);
    yield return waitForSeconds;
    _targetZoom = _maximuFov;
    _fieldFovAnimation1.Kill();
    _fieldFovAnimation2 = _camera.DOFieldOfView(_maximuFov, _duration);
  }
}