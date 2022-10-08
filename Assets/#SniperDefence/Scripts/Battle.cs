using System;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    [SerializeField] private TeamDefender _teamDefender;
    [SerializeField] private TeamEnemy _teamEnemy;

    public TeamDefender TeamDefender => _teamDefender;
    public TeamEnemy TeamEnemy => _teamEnemy;

    //[SerializeField] private Text _drawMessage;
    //[SerializeField] private Text _firstTeamWinText;
    //[SerializeField] private Text _secondTeamWinText;

    private void Awake()
    {
        InitializeEnemies();
    }

    private void OnDestroy()
    {
        foreach (var unit in _teamDefender.Units)
        {
            unit.Died -= CheckWin;
        }

        foreach (var unit in _teamEnemy.Units)
        {
            unit.Died -= CheckWin;
        }
    }

    public void InitializeDefenders()
    {
        foreach (var unit in _teamDefender.Units)
        {
            unit.Initialize(_teamEnemy.Units);
            unit.Died += CheckWin;
            //Debug.Log("InitializeDefenders");
        }
    }

    public void InitializeEnemies()
    {

        foreach (var unit in _teamEnemy.Units)
        {
            unit.Initialize(_teamDefender.Units);
            unit.Died += CheckWin;

        }
    }

    private void CheckWin()
    {
        bool firstTeamResult = _teamDefender.CheckLose();
        bool secondTeamResult = _teamEnemy.CheckLose();

        //Debug.Log("CheckWin");
        //if (firstTeamResult && secondTeamResult)
        //{
        //    _drawMessage.gameObject.SetActive(true);
        //}
        //else
        //{
        //    if (firstTeamResult)
        //        _secondTeamWinText.gameObject.SetActive(true);
        //    if (secondTeamResult)
        //        _firstTeamWinText.gameObject.SetActive(true);
        //}
    }
}
