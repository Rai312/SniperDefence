using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private GameObject _squareIndicator;
    [SerializeField] private Color _indicatorDefaultColor;
    [SerializeField] private Color _indicatorActiveColor;
    [SerializeField] private Color _indicatorRemoveColor;
    [SerializeField] private List<Transform> _gridPositions;
    [SerializeField] private Transform _placeToRemove;

    private GameObject[] _indicatorArray;
    private TriggerInfo[] _triggerArray;
    private GameObject _indicatorContainer;

    public Plane Plane { get; private set; }
    public TriggerInfo[] TriggerArray => _triggerArray;
    public List<Transform> GridPositions => _gridPositions;
    public Color IndicatorActiveColor => _indicatorActiveColor;
    public Color IndicatorRemoveColor => _indicatorRemoveColor;

    private void Start()
    {
        CreateIndicators();
        HideIndicators();

        Plane = new Plane(Vector3.up, _gridPositions[0].position);
    }

    private void CreateIndicators()
    {
        _indicatorContainer = new GameObject();
        _indicatorContainer.name = "IndicatorContainer";

        GameObject triggerContainer = new GameObject();
        triggerContainer.name = "TriggerContainer";

        _indicatorArray = new GameObject[_gridPositions.Count + 1];
        _triggerArray = new TriggerInfo[_gridPositions.Count + 1];

        for (int i = 0; i < _gridPositions.Count; i++)
        {
            CreateGridPoint(triggerContainer, _gridPositions[i].position, i, TriggerInfoType.MergeTrigger);
        }

        CreateGridPoint(triggerContainer, _placeToRemove.position, _gridPositions.Count, TriggerInfoType.RemoveTrigger);
    }

    private void CreateGridPoint(GameObject triggerContainer, Vector3 position, int index, TriggerInfoType type)
    {
        GameObject indicatorGO = Instantiate(_squareIndicator);

        indicatorGO.transform.position = position;

        indicatorGO.transform.parent = _indicatorContainer.transform;

        _indicatorArray[index] = indicatorGO;

        GameObject trigger = CreateBoxTrigger(index, type);

        trigger.transform.parent = triggerContainer.transform;

        trigger.transform.position = position;

        _triggerArray[index] = trigger.GetComponent<TriggerInfo>();
    }

    public Vector3 GetMapHitPoint(Vector3 position)
    {
        Vector3 newPosition = position;

        RaycastHit hit;

        if (Physics.Raycast(newPosition + new Vector3(0, 10, 0), Vector3.down, out hit, 15))
        {
            newPosition = hit.point;
        }

        return newPosition;
    }

    private GameObject CreateBoxTrigger(int x, TriggerInfoType type)
    {
        GameObject trigger = new GameObject();

        BoxCollider collider = trigger.AddComponent<BoxCollider>();

        collider.size = new Vector3(1.5f, 0.5f, 1.5f);

        collider.isTrigger = true;

        TriggerInfo trigerInfo = trigger.AddComponent<TriggerInfo>();
        trigerInfo.gridX = x;
        trigerInfo.Type = type;

        trigger.layer = LayerMask.NameToLayer("Triggers");

        return trigger;
    }

    public GameObject GetIndicatorFromTriggerInfo(TriggerInfo triggerinfo)
    {
        GameObject triggerGo = null;

        triggerGo = _indicatorArray[triggerinfo.gridX];

        return triggerGo;
    }

    public void ResetIndicators()
    {
        for (int x = 0; x < _gridPositions.Count + 1; x++)
        {
            _indicatorArray[x].GetComponent<MeshRenderer>().material.color = _indicatorDefaultColor;
        }
    }

    public void ShowIndicators()
    {
        _indicatorContainer.SetActive(true);
    }

    public void HideIndicators()
    {
        _indicatorContainer.SetActive(false);
    }
}
