using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using UnityEngine.UI;
using ZenFulcrum.EmbeddedBrowser;



public class DownloadFile : MonoBehaviour
{    
    public string server;
    public string address;
    // Start is called before the first frame update
    Browser browser;
    void Start()
    {
        browser = gameObject.GetComponent<Browser>();
        this.InitData();
    }

    // Update is called once per frame
    void Update()
    {
        //downloadFile(server.ToString());
    }
    
void downloadFile(string url)
    {
        WebClient client = new WebClient();
        int result = url.ToString().IndexOf(".xls");
        if (-1 != result)
        {
            client.DownloadFile(url.ToString(), address.ToString() + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".xls");
        }
        else
        {
            client.DownloadFile(url.ToString(), address.ToString() + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".txt");
        }
    }
    public void InitData()
    {
        // ҳ�洫������unity
        browser.RegisterFunction("downloadFile", (JSONNode jk) =>
        {
            Debug.Log(jk[0].Value); // ��ӡ���ݵĲ���
            downloadFile(jk[0].Value.ToString());
        });
    }
}