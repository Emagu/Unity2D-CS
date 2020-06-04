using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;

    public static GameAssets i
    {
        get
        {
            if (_i == null) 
            {
                _i = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            }
            return _i;
        }
    }


    #region Effects
    public Transform DamagePopup;
    #endregion

    #region Units
    public Transform LancerTransform;

    public Transform SaberTransform;
    #endregion


}
