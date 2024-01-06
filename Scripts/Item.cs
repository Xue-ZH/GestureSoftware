/****************************************************
    文件：Item.cs
	作者：叶少
	微信：15970843394
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public void InitItem(string value)
    {
        transform.GetChild(1).GetComponent<Text>().text = value;
    }
    public void ItemToggleEvent()
    {
        //if (transform.parent.parent.parent.name == "Template1")
        //{
        //    GameManager.Instance.SetValue_1();
        //}
        transform.parent.parent.parent.gameObject.SetActive(false);
    }
}