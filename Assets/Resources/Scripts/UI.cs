using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    private static UI _i;

    public static UI i
    {
        get
        {
            if (_i == null)
            {
                _i = Instantiate(Resources.Load<UI>("UI"));
            }
            return _i;
        }
    }
    public Transform Create(Transform transform)
    {
        return Instantiate(transform, this.transform);
    }

    public void CreateArmyController(Object unit, int paddingCount, string name, List<CommandType> commands)
    {
        var controllerTransform = Create(ArmyController);
        controllerTransform.localPosition += Vector3.right * paddingCount * 200;
        controllerTransform.GetChild(0).GetComponent<Text>().text = name;
        var toggleGroupTransform = controllerTransform.GetChild(1);
        var toggleGroupScript = toggleGroupTransform.gameObject.GetComponent<Command>();
        toggleGroupScript.HandlerUnit = unit;
        int commandYPending = 30;
        UnityEngine.UI.Toggle handle = null;
        foreach (var command in commands)
        {
            Transform toggleTransform = Instantiate(ToggleTransform, toggleGroupTransform);
            RectTransform rect = toggleTransform.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(0, commandYPending);
            UnityEngine.UI.Toggle toggle = toggleTransform.gameObject.GetComponent<UnityEngine.UI.Toggle>();
            toggle.group = toggleGroupTransform.gameObject.GetComponent<ToggleGroup>();
            toggle.name = command.ToString();
            Text label = toggleTransform.GetChild(1).GetComponent<Text>();
            label.text = command.ToString();
            commandYPending -= 30;
            if (command == CommandType.Hold)
            {
                handle = toggle;
            }
        }
        handle.isOn = true;
    }


    #region UI
    public Transform ArmyController;

    public Transform ToggleTransform;
    #endregion

}
