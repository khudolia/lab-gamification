using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProgrammingNodeModel
{
    public State state = State.Green;
    public int length = 1;

    public int id = -1;
}

public class ProgrammingNodeController : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public TMP_InputField inputField;
    public TMP_Text text;

    public ProgrammingNodeModel model = new ProgrammingNodeModel();
    private void Start()
    {
        // Attach the OnValueChanged method to the dropdown's onValueChanged event
        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
        inputField.onEndEdit.AddListener(OnInputFieldEndEdit);

        text.SetText(gameObject.name);
    }

    private void OnDropdownValueChanged(int index)
    {
        string selectedOption = dropdown.options[index].text;

        switch (selectedOption)
        {
            case "Green":
                model.state = State.Green;
                break;
            case "Red":
                model.state = State.Red;
                break;
            case "Yellow":
                model.state = State.Yellow;
                break;
            case "None":
                model.state = State.None;
                break;
            case "All":
                model.state = State.All;
                break;
            case "RedAndYellow":
                model.state = State.RedAndYellow;
                break;
            case "GreenAndYellow":
                model.state = State.GreenAndYellow;
                break;
        }
    }
    
    private void OnInputFieldEndEdit(string text)
    {
        model.length = int.Parse(text);
    }
}
