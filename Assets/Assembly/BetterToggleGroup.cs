using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BetterToggleGroup : ToggleGroup
{
    protected override void Start()
    {
        foreach (Transform transformToggle in gameObject.transform)
        {
            var toggle = transformToggle.gameObject.GetComponent<Toggle>();
            toggle.onValueChanged.AddListener((isSelected) => {
                if (!isSelected)
                {
                    return;
                }
                var activeToggle = Active();
                OnChange(activeToggle);
            });
        }
    }

    public Toggle Active()
    {
        return ActiveToggles().FirstOrDefault();
    }

    protected virtual void OnChange(Toggle newactive)
    {
        Debug.LogError("Not Change Handle");
    }
}
