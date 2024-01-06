using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZenFulcrum.EmbeddedBrowser;
using System.Threading;
using UnityEngine.UI;

public class TransData : MonoBehaviour {

    public InputField StaticSingle;//给即将输出的编码赋值
    public InputField DynamicSingle;
    public InputField StaticDouble;
    public InputField DynamicDouble;
    public InputField Notice;

    private string arr1;
    private string arr2;
    private string arr3;
    private string arr4;
    private string arr5;
    Browser browser;

	// Use this for initialization
	void Start () {
        browser = gameObject.GetComponent<Browser>();
        this.InitData();
	}

     private void Awake()
        {
            browser = gameObject.GetComponent<Browser>();//获取插件Browser组件（Unity方使用插件基础一步）
        }
	
	// Update is called once per frame
	void Update () 
    {
        if (arr1 != StaticSingle.text)
        {
            arr1 = StaticSingle.text;//获取编码框里的编码
            browser.CallFunction("OutText1", arr1).Done();//browser.CallFunction("sendEncoding", arr).Done();// 发送编码
        };
        if (arr2 != DynamicSingle.text)
        {
            arr2 = DynamicSingle.text;//获取编码框里的编码
            browser.CallFunction("OutText2", arr2).Done();//browser.CallFunction("sendEncoding", arr).Done();// 发送编码
        };
        if (arr3 != StaticDouble.text)
        {
            arr3 = StaticDouble.text;//获取编码框里的编码
            browser.CallFunction("OutText3", arr3).Done();//browser.CallFunction("sendEncoding", arr).Done();// 发送编码
        };
        if (arr4 != DynamicDouble.text)
        {
            arr4 = DynamicDouble.text;//获取编码框里的编码
            browser.CallFunction("OutText4", arr4).Done();//browser.CallFunction("sendEncoding", arr).Done();// 发送编码
        };
        if (arr5 != Notice.text)
        {
            arr5 = Notice.text;//获取编码框里的编码
            browser.CallFunction("Notice", arr5).Done();//browser.CallFunction("sendEncoding", arr).Done();// 发送编码
        };
    }

    public void InitData()
        {
	// 页面传参数到unity
            browser.RegisterFunction("knobDownHandoe", (JSONNode jk) =>
            {
                Debug.Log(jk[0].Value); // 打印传递的参数
            });
        }
}
