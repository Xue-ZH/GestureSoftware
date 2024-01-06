using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveDCode : MonoBehaviour
{
    public InputField code1;
    public InputField code2;
    public InputField code3;
    public InputField code4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Together()
    {
        code4.text = code1.text +">"+ code2.text + ">"+code3.text;
    }
}
