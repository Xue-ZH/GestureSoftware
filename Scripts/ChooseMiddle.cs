using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseMiddle : MonoBehaviour
{
    public InputField[] inputArr;
    public InputField Middle;
    public LeftTouch ts;
    public LeftController hc;
    public LeftGesture gc;
    public Text tempText1;
    public Text tempText2;
    public TouchSet rts;
    public HandController rhc;
    public GestureSet rgc;
    public Text tempText3;
    public Text tempText4;

    string t, f, a, w, o;
    string tt, ff, aa, ww, oo;
    int judge = 0;
    int judge1 = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateGesture(int index)
    {
        string str = inputArr[index].text;
        if (str[0] == 'L')
        {
            for (int q = 1; q < str.Length; q++)
            {
                if (str[q] == 'R')
                {
                    judge = 1;
                    judge1 = q;
                }
            }
            if (judge == 1)
            {
                for (int i = 1; i < judge1; i++)
                {
                    if (str[i] == 'T')
                    {
                        t = str.Substring(i + 1, 4);
                        i = i + 5;
                    }
                    if (str[i] == 'F')
                    {
                        f = str.Substring(i + 1, 10);
                        i = i + 11;
                    }
                    if (str[i] == 'A')
                    {
                        a = str.Substring(i + 1, 2);
                        i = i + 3;
                    }
                    if (str[i] == 'W')
                    {
                        w = str.Substring(i + 1, 2);
                        i = i + 3;
                    }
                    if (str[i] == 'O')
                    {
                        o = str.Substring(i + 1, 2);
                        i = i + 3;
                    }
                }
                for (int j = judge1 + 1; j < str.Length; j++)
                {
                    if (str[j] == 'T')
                    {
                        tt = str.Substring(j + 1, 4);
                        j = j + 5;
                    }
                    if (str[j] == 'F')
                    {
                        ff = str.Substring(j + 1, 10);
                        j = j + 11;
                    }
                    if (str[j] == 'A')
                    {
                        aa = str.Substring(j + 1, 2);
                        j = j + 3;
                    }
                    if (str[j] == 'W')
                    {
                        ww = str.Substring(j + 1, 2);
                        j = j + 3;
                    }
                    if (str[j] == 'O')
                    {
                        oo = str.Substring(j + 1, 2);
                        j = j + 3;
                    }
                }

                tempText1.text = t;
                ts.LSetHandByCode(tempText1);

                tempText1.text = f;
                hc.LSetFlexion(tempText1);

                tempText1.text = a;
                tempText2.text = f;
                hc.LSetAB(tempText1, tempText2);

                tempText1.text = w;
                hc.LSetWrist(tempText1);

                tempText1.text = o;
                gc.LSetGesture(tempText1);

                tempText3.text = tt;
                rts.SetHandByCode(tempText3);

                tempText3.text = ff;
                rhc.SetFlexion(tempText3);

                tempText3.text = aa;
                tempText4.text = ff;
                rhc.SetAB(tempText3, tempText4);

                tempText3.text = ww;
                rhc.SetWrist(tempText3);

                tempText3.text = oo;
                rgc.SetGesture(tempText3);



            }

            else
            {
                for (int i = 1; i < str.Length; i++)
                {
                    if (str[i] == 'T')
                    {
                        t = str.Substring(i + 1, 4);
                        i = i + 5;
                    }
                    if (str[i] == 'F')
                    {
                        f = str.Substring(i + 1, 10);
                        i = i + 11;
                    }
                    if (str[i] == 'A')
                    {
                        a = str.Substring(i + 1, 2);
                        i = i + 3;
                    }
                    if (str[i] == 'W')
                    {
                        w = str.Substring(i + 1, 2);
                        i = i + 3;
                    }
                    if (str[i] == 'O')
                    {
                        o = str.Substring(i + 1, 2);
                        i = i + 3;
                    }
                }
                tempText1.text = t;
                ts.LSetHandByCode(tempText1);

                tempText1.text = f;
                hc.LSetFlexion(tempText1);

                tempText1.text = a;
                tempText2.text = f;
                hc.LSetAB(tempText1, tempText2);

                tempText1.text = w;
                hc.LSetWrist(tempText1);

                tempText1.text = o;
                gc.LSetGesture(tempText1);
            }
        }


        if (str[0] == 'R')
        {
            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] == 'T')
                {
                    t = str.Substring(i + 1, 4);
                    i = i + 5;
                }
                if (str[i] == 'F')
                {
                    f = str.Substring(i + 1, 10);
                    i = i + 11;
                }
                if (str[i] == 'A')
                {
                    a = str.Substring(i + 1, 2);
                    i = i + 3;
                }
                if (str[i] == 'W')
                {
                    w = str.Substring(i + 1, 2);
                    i = i + 3;
                }
                if (str[i] == 'O')
                {
                    o = str.Substring(i + 1, 2);
                    i = i + 3;
                }
            }
            tempText3.text = t;
            rts.SetHandByCode(tempText3);

            tempText3.text = f;
            rhc.SetFlexion(tempText3);

            tempText3.text = a;
            tempText4.text = f;
            rhc.SetAB(tempText3, tempText4);

            tempText3.text = w;
            rhc.SetWrist(tempText3);

            tempText3.text = o;
            rgc.SetGesture(tempText3);
        }


        // string f = str.Substring(1, 10);
        // string a = str.Substring(12, 2);
        // string w = str.Substring(15, 2);
        // string t = str.Substring(18, 4);
        // string o = str.Substring(23, 2);

        //Debug.Log(sm.GetCurrentValue());

    }

    public void ChooseMid(int index)
    {
        Middle.text= inputArr[index].text;
    }
}
