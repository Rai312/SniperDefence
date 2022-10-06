using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private OpeningMenu _mainMenu;
    [SerializeField] private PlayMenu _playMenu;
    [SerializeField] private SniperMenu _sniperMenu;
    [SerializeField] private SettingsMenu _settingMenu;
    [SerializeField] private EndLevelMenu _endLevelMenu;
    [SerializeField] private FailMenu _failMenu;

    public OpeningMenu OpeningMenu => _mainMenu;
    public PlayMenu PlayMenu => _playMenu;
    public SniperMenu SniperMenu => _sniperMenu;
    public SettingsMenu SettingsMenu => _settingMenu;
    public EndLevelMenu EndLevelMenu => _endLevelMenu;
    public FailMenu FailMenu => _failMenu;
}
