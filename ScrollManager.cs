using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollManager : MonoBehaviour
{
    public ScrollMechanic[] smArr;
    public int[] maxNum;
    public int[] minNum;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < smArr.Length; i++)
        {
            string[] numStr = new string[maxNum[i] + 1];
            for(int j = 0; j <= maxNum[i]; j++)
            {
                numStr[j] = j.ToString();
            }
            smArr[i].testData = numStr;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNum(string content)
    {
        for (int i = 0; i < smArr.Length; i++)
        {
            string[] numStr = new string[maxNum[i] + 1];
            for (int j = 0; j <= maxNum[i]; j++)
            {
                numStr[j] = j.ToString();
            }
            var newList = new List<string>();
            for (int j = 0; j < numStr.Length; j++)
            {
                newList.Add(numStr[j]);
            }
            smArr[i].Initialize(newList, false, int.Parse(content[i].ToString()));
        }
    }
}
