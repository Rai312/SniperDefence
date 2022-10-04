using System;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    [SerializeField] private Team _firstTeam;
    [SerializeField] private Team _secondTeam;

    //[SerializeField] private Text _drawMessage;
    //[SerializeField] private Text _firstTeamWinText;
    //[SerializeField] private Text _secondTeamWinText;

    private void Awake()
    {
        Initialization();
    }

    private void OnDestroy()
    {
        foreach (var unit in _firstTeam.Units)
        {
            unit.Died -= CheckWin;
        }

        foreach (var unit in _secondTeam.Units)
        {
            unit.Died -= CheckWin;
        }
    }

    public void StartBattle()
    {
        foreach (var unit in _firstTeam.Units)
        {
            unit.StartBattle();
        }

        foreach (var unit in _secondTeam.Units)
        {
            unit.StartBattle();
        }
    }

    private void Initialization()
    {
        foreach (var unit in _firstTeam.Units)
        {
            unit.Initialize(_secondTeam.Units);
            unit.Died += CheckWin;

            //unit.SetNeoAvatar();
        }

        foreach (var unit in _secondTeam.Units)
        {
            unit.Initialize(_firstTeam.Units);
            unit.Died += CheckWin;

            //unit.SetJenkinsAvatar();
        }
    }

    private void CheckWin()
    {
        bool firstTeamResult = _firstTeam.CheckLose();
        bool secondTeamResult = _secondTeam.CheckLose();

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
