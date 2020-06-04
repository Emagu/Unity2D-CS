using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private List<Object> selfObjects = new List<Object>();
    private void Start()
    {
        var lancer = Object.Create(GameAssets.i.LancerTransform, new Vector3(-5, 0));
        UI.i.CreateArmyController(lancer, selfObjects.Count, "槍兵", Lancer.CommandTypes);
        selfObjects.Add(lancer);

        var saber = Object.Create(GameAssets.i.SaberTransform, new Vector3(-7, 0));
        UI.i.CreateArmyController(saber, selfObjects.Count, "劍兵", Saber.CommandTypes);
        selfObjects.Add(saber);

        Object.Create(GameAssets.i.LancerTransform, new Vector3(5, 0), true);
    }
}
