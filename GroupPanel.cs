using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroupPanel : MonoBehaviour
{

    public List<MyUIManager3> UIManagerList;

    public List<Toggle> toggleList;
    

    public Button SplitButton;

    public Button ShowButton;

    public CanvasGroup cg1;

    public ToggleGroup tg2;

    public int SelectIdx = 0;

    public 

    void OnEnable()
    {
        Debug.Log("OnEnable");
        SplitButton.onClick.AddListener(OnButtonClickEvt);
    }

    private void OnButtonClickEvt()
    {
        Debug.Log("click");
        //当点击的时候去分割字符串；

        //SelectIdx = 0;


        //tg2.NotifyToggleOn(toggleList[0]);

        UIManagerList[SelectIdx].InitSM();
        //foreach (var item in UIManagerList)
        //{
        //    //Debug.Log(item.codeText.text);
        //    //Debug.Log(item.codeText1.text);
        //    //item.
        //    //item.InitSM();
        //}
        cg1.interactable = false;
        cg1.alpha = 0;
        cg1.blocksRaycasts = false;
        ShowButton.gameObject.SetActive(true);
        //this.gameObject.SetActive(false);
    }

    void OnDisable()
    {
        Debug.Log("disabled");
        SplitButton.onClick.RemoveAllListeners();
    }

    public void ShowThisPanel()
    {
        Debug.Log("show this page");
        cg1.interactable = true;
        cg1.alpha = 1;
        cg1.blocksRaycasts = true;

    }




    // Start is called before the first frame update
    void Start()
    {
        //SplitButton.onClick.AddListener()
      var toggles= tg2.GetComponentsInChildren<Toggle>();
        toggleList = new List<Toggle>(toggles);
        foreach (var item in toggles)
        {
            item.onValueChanged.AddListener((isOn) => {

                if (isOn)
                {
                    var idx=toggleList.IndexOf(item);
                    Debug.Log(idx);
                    SelectIdx = idx;
                    if (SelectIdx < UIManagerList.Count)
                    {
                        UIManagerList[SelectIdx].InitSM();
                    }
                };
            });
        }

       
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
