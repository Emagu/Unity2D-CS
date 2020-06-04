using UnityEngine;
using TMPro;
public class DamagePopup : MonoBehaviour
{
    private const float MaxSpeed = 4f;
    private const float DisappearSpeed = 2f;
    private TextMeshPro textMesh;
    private Vector3 moveSpeed;
    private float disappearTimer;
    private Color textColor;

    public static DamagePopup Create(Vector3 position, int damageAmount)
    {
        Transform damageTransform = Instantiate(GameAssets.i.DamagePopup, position, Quaternion.identity);
        DamagePopup damagePopup = damageTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(damageAmount);
        return damagePopup;
    }

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
        textColor = textMesh.color;
        disappearTimer = 1f;
        float xSpeed = Random.Range(-1f, 2f);
        moveSpeed = new Vector3(xSpeed, MaxSpeed - Mathf.Abs(xSpeed), 0);
    }

    private void Update()
    {
        transform.position += moveSpeed * Time.deltaTime;
        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            textColor.a -= DisappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Setup(int damage)
    {
        textMesh.SetText(damage.ToString());
    }
}
