using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour
{
    [SerializeField] private Team _enemyTeam;
    [SerializeField] private List<Unit> _units;

    public IReadOnlyList<Unit> Units => _units;

    public void StartBatte()
    {
        //_unit
        //foreach (var unit in _units)
        //{
        //    unit.Initialize(_enemyTeam.Units);
        //    unit.StartBattle();
        //}
    }

    //public void ExecuteTeam()
    //{
    //    foreach
    //}
}
