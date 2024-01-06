using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class InstCsv : MonoBehaviour
{
    public InputField input;
    public GameObject go;
    public Button btn;
    public Text[] txts;
    public Text[] inputFields;
    DataTable dt = new DataTable();
    int num = 1;
    public RectTransform rect;
    bool isclear;
    // Start is called before the first frame update
    private void Awake()
    {
        go = GameObject.Find("NoDes");
        input.text = go.GetComponent<NewBehaviourScript>().code;
        LayoutRebuilder.ForceRebuildLayoutImmediate(rect);
    }
    void Start()
    {
        dt.Columns.Add("编码");
        dt.Columns.Add("语义");
        dt.Columns.Add("来源");
        dt.Columns.Add("类型");
        dt.Columns.Add("其他");

        btn.onClick.AddListener(delegate
        {
           

            DataRow dr = dt.NewRow();
            for (int i = 0; i < inputFields.Length; i++)
            {
                dr[txts[i].text.Replace("：",null)] = inputFields[i]. text;
                inputFields[i].text = null;
            }
            dt.Rows.Add(dr);
           
            string path = Application.dataPath + "\\data.csv";
            SaveCSV(path, dt);
            cleaeall();
            LayoutRebuilder.ForceRebuildLayoutImmediate(rect);
        });

    }

    // Update is called once per frame
    void Update()
    {
        input.text = go.GetComponent<NewBehaviourScript>().code;
        if (isclear)
        {
            cleaeall();
        }

    }
    void cleaeall()
    {
        for (int i = 1; i < inputFields.Length; i++)
        {
            inputFields[i].text = "";

        }
    }
    public static void SaveCSV(string filePath, DataTable dt)
    {
        FileInfo fi = new FileInfo(filePath);
        if (!fi.Directory.Exists)
        {
            fi.Directory.Create();
        }
        using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8))
            {
                string data = "";
                //写入表头
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    data += dt.Columns[i].ColumnName.ToString();
                    if (i < dt.Columns.Count - 1)
                    {
                        data += ",";
                    }
                }
                sw.WriteLine(data);
                //写入每一行每一列的数据
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data = "";
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        string str = dt.Rows[i][j].ToString();
                        data += str;
                        if (j < dt.Columns.Count - 1)
                        {
                            data += ",";
                        }
                    }
                    sw.WriteLine(data);
                }
                sw.Close();
                fs.Close();
            }

        }
      
    }
}

