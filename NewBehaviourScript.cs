using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{

    public string code;
    public Button btn;
    public InputField InputField1;

    // Start is called before the first frame update
    void Start()
    {
    
            DontDestroyOnLoad(gameObject);
            btn.onClick.AddListener(delegate {
                code = InputField1.text;
                SceneManager.LoadScene("output");
            });
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
