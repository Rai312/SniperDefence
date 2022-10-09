using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesManager : MonoBehaviour
{
    [SerializeField] private List<TeamEnemy> _waves;
    [SerializeField] private TeamDefender _teamDefender;

    private TeamEnemy _currentWave;

    public IReadOnlyList<TeamEnemy> Waves => _waves;

    public event Action CurrentWaveDied;

    private void EnableNextWave()
    {
        foreach (var wave in _waves)
            if (wave.IsAlive)
                wave.TeamContainer.Enable(); 
    }

    //public void InitializeWaves()
    //{
    //    foreach (var wave in _waves)
    //    {
    //        foreach (var unit in wave.Units)
    //        {
    //            unit.Initialize(_teamDefender.Units);
    //            unit.Died += CheckWin;

    //        }
    //    }
    //}
}
