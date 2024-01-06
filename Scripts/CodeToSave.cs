using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodeToSave : MonoBehaviour
{
    public InputField Save;
    public InputField TheOne;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToSave()
    {
        Save.text = TheOne.text;
    }
}
