using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyUIManager3 : MonoBehaviour
{
    public ScrollManager[] smArr;
    public LeftTouch lts;
    public TouchSet ts;
    public LeftController lhc;
    public HandController hc;
    public LeftGesture lgc;
    public GestureSet gc;
    public Text tempText1;
    public Text tempText2;
    public Text tempText3;
    public Text tempText4;
    public GameObject panel1;
    public InputField codeText;
    public InputField codeText1;
    string t,f,a,w,o;
    int t1=0,f1=0,a1=0,w1=0,o1=0;
    string tt,ff,aa,ww,oo;
    int t2=0,f2=0,a2=0,w2=0,o2=0;
    // Start is called before the first frame update
    void Start()
    {
        //smTouch.testData = touchCode;
        //sm.testData = new string[] { "sdf", "sdfs"};
        //sm.initTest = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(sm.GetCurrentValue());
        tempText1.text = GetNum(smArr[0]);
        lts.LSetHandByCode(tempText1);

        tempText1.text = GetNum(smArr[1]);
        lhc.LSetFlexion(tempText1);

        tempText1.text = GetNum(smArr[2]);
        tempText2.text = GetNum(smArr[1]);
        lhc.LSetAB(tempText1, tempText2);

        tempText1.text = GetNum(smArr[3]);
        lhc.LSetWrist(tempText1);

        tempText1.text = GetNum(smArr[4]);
        lgc.LSetGesture(tempText1);
        //Debug.Log(GetNum(smArr[1]));
        tempText3.text = GetNum(smArr[5]);
        hc.SetFlexion(tempText3);

        tempText3.text = GetNum(smArr[6]);
        tempText4.text = GetNum(smArr[5]);
        hc.SetAB(tempText3, tempText4);

        tempText3.text = GetNum(smArr[7]);
        hc.SetWrist(tempText3);

        tempText3.text = GetNum(smArr[8]);
        ts.SetHandByCode(tempText3);

        tempText3.text = GetNum(smArr[9]);
        gc.SetGesture(tempText3);
    }

    string GetNum(ScrollManager sm)
    {
        string value = "";
        for(int i = 0; i < sm.smArr.Length; i++)
        {
            value += sm.smArr[i].GetCurrentValue();
        }
        return value;
    }

     public void InitSM()
    {

        //Debug.Log("chushihua");

        if (string.IsNullOrEmpty(codeText.text) || string.IsNullOrEmpty(codeText1.text))
        {
            Debug.Log("return" + this.gameObject.name);
            return;
        }

        if (codeText.text[0]=='L') 
        {
            for(int i= 1; i < codeText.text.Length; i++)
            {
                if(codeText.text[i]=='T')
                {
                    t=codeText.text.Substring (i+1,4);
                    i=i+5;
                    t1=1;
                }
                if(codeText.text[i]=='F')
                {
                    f=codeText.text.Substring (i+1,10);
                    i=i+11;
                    f1=1;
                }
                if(codeText.text[i]=='A')
                {
                    a=codeText.text.Substring (i+1,2);
                    i=i+3;
                    a1=1;
                }
                if(codeText.text[i]=='W')
                {
                    w=codeText.text.Substring (i+1,2);
                    i=i+3;
                    w1=1;
                }
                if(codeText.text[i]=='O')
                {
                    o=codeText.text.Substring (i+1,2);
                    i=i+3;
                    o1=1;
                }
            }
            if(t1!=1)
            {
                t="0000";
            }
            if(f1!=1)
            {
                f="0000000000";
            }            
            if(a1!=1)
            {
                a="00";
            }            
            if(w1!=1)
            {
                w="00";
            }            
            if(o1!=1)
            {
                o="14";
            }

            Debug.Log("F:" +f);
            Debug.Log("a:" +a);
            Debug.Log("w:" +w);
            Debug.Log("t:" +t);
            Debug.Log("o:" +o);

            smArr[0].SetNum(t);
            smArr[1].SetNum(f);
            smArr[2].SetNum(a);
            smArr[3].SetNum(w);
            smArr[4].SetNum(o);
        }

        if(codeText1.text[0]=='R') 
        {
            for(int i= 1; i < codeText1.text.Length; i++)
            {
                if(codeText1.text[i]=='T')
                {
                    tt=codeText1.text.Substring (i+1,4);
                    i=i+5;
                    t2=1;
                }
                if(codeText1.text[i]=='F')
                {
                    ff=codeText1.text.Substring (i+1,10);
                    i=i+11;
                    f2=1;
                }
                if(codeText1.text[i]=='A')
                {
                    aa=codeText1.text.Substring (i+1,2);
                    i=i+3;
                    a2=1;
                }
                if(codeText1.text[i]=='W')
                {
                    ww=codeText1.text.Substring (i+1,2);
                    i=i+3;
                    w2=1;
                }
                if(codeText1.text[i]=='O')
                {
                    oo=codeText1.text.Substring (i+1,2);
                    i=i+3;
                    o2=1;
                }
            }
            if(t2!=1)
            {
                tt="0000";
            }
            if(f2!=1)
            {
                ff="0000000000";
            }            
            if(a2!=1)
            {
                aa="00";
            }            
            if(w2!=1)
            {
                ww="00";
            }            
            if(o2!=1)
            {
                oo="14";
            }

            Debug.Log("F:" +f);
            Debug.Log("a:" +a);
            Debug.Log("w:" +w);
            Debug.Log("t:" +t);
            Debug.Log("o:" +o);

            smArr[8].SetNum(tt);
            smArr[5].SetNum(ff);
            smArr[6].SetNum(aa);
            smArr[7].SetNum(ww);
            smArr[9].SetNum(oo);
        }

            // smArr[0].SetNum(t);
            // smArr[1].SetNum(f);
            // smArr[2].SetNum(a);
            // smArr[3].SetNum(w);
            // smArr[4].SetNum(o);

            // panel1.SetActive(false);
        // string f = codeText.text.Substring(1, 10);
        // string a = codeText.text.Substring(12, 2);
        // string w = codeText.text.Substring(15, 2);
        // string t = codeText.text.Substring(18, 4);
        // string o = codeText.text.Substring(23, 2);

        //panel1.SetActive(false);
    }

    public void GetCodeString()
    {
        string f = GetNum(smArr[1]);
        string a = GetNum(smArr[2]);
        string w = GetNum(smArr[3]);
        string t = GetNum(smArr[0]);
        string o = GetNum(smArr[4]);
        string ff = GetNum(smArr[6]);
        string aa = GetNum(smArr[7]);
        string ww = GetNum(smArr[8]);
        string tt = GetNum(smArr[5]);
        string oo = GetNum(smArr[9]);
        codeText.text = string.Format("F{0}A{1}W{2}T{3}O{4}", f, a, w, t, o);
        codeText1.text = string.Format("F{0}A{1}W{2}T{3}O{4}", ff, aa, ww, tt, oo);
        panel1.gameObject.SetActive(true);
    }
}
