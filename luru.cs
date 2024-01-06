using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class luru : MonoBehaviour
{

    public List<string> contents = new List<string>();
    public InputField input;
    
    public void OnEnable()
    {
        if (contents.Count <= 0)
            return;
        foreach(string item in contents)
        {
            GameObject btn = Resources.Load("btn") as GameObject;
            GameObject go = Instantiate(btn, this.transform);
            go.GetComponentInChildren<Text>().text = item;
            go.GetComponent<Button>().onClick.AddListener(() => {
                this.transform.parent.parent.gameObject.SetActive(false);
                input.text = item;
            });
        }
    }

    public void add()
    {
        contents.Add(input.text);
    }

    public void OnDisable()
    {
        int count = this.transform.childCount;
        for(int i=0;i<count;i++)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }
    }
    public void Awake()
    {
        
    }
}
