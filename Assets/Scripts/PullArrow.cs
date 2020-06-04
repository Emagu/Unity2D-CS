using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullArrow : MonoBehaviour
{
    //指向String子物件
    public GameObject MyString;
    public GameObject Arrow;
	public GameObject HoldArrow;
	public float countDownSetting = 3.0f, ArrowPower = 25.0f;
	
    //用來讀取MyString上的LineRender Component
    private LineRenderer MyStringLine;
	private bool isClick = false, shootted = false;
    private Vector3 ClickPosition;
	private float length, countDown = 0f;
	
    // Start is called before the first frame update
    void Start()
    {
        MyStringLine = MyString.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //按住滑鼠左鍵開始進行拉弓功能
        if (Input.GetMouseButton(0) && !isClick && !shootted)
        {
            //呼叫拉弓功能
			//儲存滑鼠所點擊的座標
            ClickPosition = Input.mousePosition;
			isClick = true;
        }

		//放掉滑鼠左鍵
        if(isClick)
		{
			if (Input.GetMouseButtonUp(0))
			{
				//呼叫拉弓功能，使弓弦回彈
				isClick = false;
				shootted = true;
				ShootArrow();
			}
			StringNodeChange();
		}
		
		if(shootted)
		{
			countDown += Time.deltaTime;
			if(countDown > countDownSetting)
			{
				countDown = 0f;
				this.HoldArrow = Instantiate(Arrow, Arrow.transform.position, new Quaternion(0,0,0,0), this.transform);
				HoldArrow.transform.localPosition = Arrow.transform.localPosition;
				HoldArrow.transform.localRotation = Arrow.transform.localRotation;
				shootted = false;
			}
		}
    }
	
    //弓弦依照拖曳幅度length變形
    private void StringNodeChange()
    {
		Vector3 deltaVector = new Vector3();
		if(isClick)
		{
			deltaVector = Input.mousePosition - ClickPosition;
			float angleZ = Mathf.Atan2(deltaVector.y, deltaVector.x) * Mathf.Rad2Deg;
			transform.eulerAngles = new Vector3(0, 0, angleZ);
		}
		
		length = Mathf.Clamp(deltaVector.magnitude / 20f, 0, 2);
		
        //改變LineRender中第2個點的座標藉此達到拉弓效果
        MyStringLine.SetPosition(1, new Vector3(3.7f + length, -0.9f, 1));
		
		//將箭矢向後拉動
		Vector3 arrowPosition = Arrow.transform.localPosition;
		arrowPosition.x += length;
		HoldArrow.transform.localPosition = arrowPosition;
    }
	
	//射箭函式
    private void ShootArrow()
    {
        if (HoldArrow.GetComponent<Rigidbody>() == null)
        {
			HoldArrow.transform.parent = this.transform.parent;
			// 給箭矢Rigidbod以便施加衝力
            Rigidbody arrowBody = HoldArrow.AddComponent<Rigidbody>();
			arrowBody.mass = 5;
            // 給箭矢朝旋轉角度施加衝力
            arrowBody.AddForce(Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z)) * new Vector3(-ArrowPower * length, 0, 0), ForceMode.VelocityChange);
        }
	}
}
