using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public interface IMainMenuView
{
    public TextMeshProUGUI UserName { get; }
    public TextMeshProUGUI MaxScore { get; }
    public Button ChangeNameButton { get; }
    public Button StartGameButton { get; }

    public Transform NameChangeRoot { get; }
    public TMP_InputField NameInput { get; }
    public Button SubmitNameChangeButton { get; }
    public void EnableNameChangePanel();
}
