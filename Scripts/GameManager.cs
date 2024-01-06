/****************************************************
    文件：GameManager.cs
	作者：叶少
	微信：15970843394
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Transform[] GoParents;
    public InputField[] IFs;
    public GameObject PrefabGo;
    public luru[] lurus;
    private void Awake()
    {
        Instance = this;
    }

    public void Btn1()
    {
        //取消录入
        InitIF();
    }
    public void Btn2()
    {
        //确认录入
        //for (int i = 0; i < IFs.Length; i++)
        //{
        //    if (IFs[i].text != "")
        //        Instantiate(PrefabGo, GoParents[i]).GetComponent<Item>().InitItem(IFs[i].text);
        //}

        foreach(luru l in lurus)
        {
            l.add();
        }
        InitIF();
    }

    private void InitIF()
    {
        //for (int i = 0; i < IFs.Length; i++)
        //{
        //    IFs[i].text = "";
        //}
    }

    public void SetValue_1()
    {

    }
    public void SetValue_2()
    {

    }
    public void SetValue_3()
    {

    }
    public void SetValue_4()
    {

    }
}