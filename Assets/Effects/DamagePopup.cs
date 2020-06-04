using UnityEngine;
using TMPro;
public class DamagePopup : MonoBehaviour
{
    private const float MAX_MOVE_SPEED = 4f;
    private const float DISAPPEAR_SPEED = 2f;
    private const float MAX_DISAPPEAR_TIMER = 1f;
    private static int sorting = 0;

    private TextMeshPro textMesh;
    private Vector3 moveSpeed;
    private float disappearTimer;
    private Color textColor;
    private bool isCrit = false;
    public static DamagePopup Create(Vector3 position, int damageAmount, bool isCrit)
    {
        Transform damageTransform = Instantiate(GameAssets.i.DamagePopup, position, Quaternion.identity);
        DamagePopup damagePopup = damageTransform.GetComponent<DamagePopup>();
        
        damagePopup.Setup(damageAmount, isCrit);
        return damagePopup;
    }

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }

    private void Update()
    {
        if (isCrit)
        {
            if (disappearTimer > MAX_DISAPPEAR_TIMER * .5f)
            {
                float increaseScaleRate = 2f;
                transform.localScale += Vector3.one * increaseScaleRate * Time.deltaTime;
            }
            else
            {
                float decreaseScaleRate = 2f;
                transform.localScale -= Vector3.one * decreaseScaleRate * Time.deltaTime;
            }
        }
        
        transform.position += moveSpeed * Time.deltaTime;
        moveSpeed -= moveSpeed * Time.deltaTime;
        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            textColor.a -= DISAPPEAR_SPEED * Time.deltaTime;
            textMesh.color = textColor;
            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Setup(int damage, bool isCrit)
    {
        textMesh.SetText(damage.ToString());
        disappearTimer = MAX_DISAPPEAR_TIMER;
        this.isCrit = isCrit;
        if (isCrit)
        {
            textMesh.fontSize = 5;
            textColor = new Color(0.9528302f, 0.5443501f, 0.4988875f, 1f);
        }
        else
        {
            textMesh.fontSize = 4;
            textColor = new Color(0.8018868f, 0.7132899f, 0.04160734f, 1f);
        }
        textMesh.color = textColor;

        if (sorting > 100000)
        {
            sorting = 0;
        }
        textMesh.sortingOrder = ++sorting;

        float xSpeed = Random.Range(-1f, 2f);
        moveSpeed = new Vector3(xSpeed, MAX_MOVE_SPEED - Mathf.Abs(xSpeed), 0);
    }
}
