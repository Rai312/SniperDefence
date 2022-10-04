using System;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    [SerializeField] private Team _teamPlayer;
    [SerializeField] private Team _teamEnemy;

    //[SerializeField] private Text _drawMessage;
    //[SerializeField] private Text _firstTeamWinText;
    //[SerializeField] private Text _secondTeamWinText;

    private void Awake()
    {
        Initialization();
    }

    private void OnDestroy()
    {
        foreach (var unit in _teamPlayer.Units)
        {
            unit.Died -= CheckWin;
        }

        foreach (var unit in _teamEnemy.Units)
        {
            unit.Died -= CheckWin;
        }
    }

    public void StartBattle()
    {
        foreach (var unit in _teamPlayer.Units)
        {
            unit.StartBattle();
        }

        foreach (var unit in _teamEnemy.Units)
        {
            unit.StartBattle();
        }
    }

    private void Initialization()
    {
        foreach (var unit in _teamPlayer.Units)
        {
            unit.Initialize(_teamEnemy.Units);
            unit.Died += CheckWin;

            //unit.SetNeoAvatar();
        }

        foreach (var unit in _teamEnemy.Units)
        {
            unit.Initialize(_teamPlayer.Units);
            unit.Died += CheckWin;

            //unit.SetJenkinsAvatar();
        }
    }

    private void CheckWin()
    {
        bool firstTeamResult = _teamPlayer.CheckLose();
        bool secondTeamResult = _teamEnemy.CheckLose();

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
