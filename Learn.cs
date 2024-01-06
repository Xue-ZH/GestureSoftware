using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Learn : MonoBehaviour
{
    public InputField[] inputArr;
    public InputField Codes;
    public Text T;
    public Text F;
    public Text A;
    public Text W;
    public Text O;
    public Text TT;
    public Text FF;
    public Text AA;
    public Text WW;
    public Text OO;
    public Text L;
    public Text R;
    public LeftTouch lts;
    public LeftController lhc;
    public LeftGesture lgc;
    public Text tempText1;
    public Text tempText2;
    public TouchSet ts;
    public HandController hc;
    public GestureSet gc;
    public Text tempText3;
    public Text tempText4;

    string t, f, a, w, o;
    string tt, ff, aa, ww, oo;
    int judge1 = 0;
    int judge2 = 0;
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
        for (int i = 1; i < str.Length; i++)
        {
            if (str[i] == 'R')
            {
                judge1 = 1;
                judge2 = i;
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

            //Debug.Log(sm.GetCurrentValue());
            if (!string.IsNullOrEmpty(t))
            {
                T.text = t;
                tempText1.text = t;
                ts.SetHandByCode(tempText1);
            }
            else
            {
                T.text = "//";
            }

            if (!string.IsNullOrEmpty(f))
            {
                F.text = f;
                tempText1.text = f;
                hc.SetFlexion(tempText1);
            }
            else
            {
                F.text = "//";
            }

            if (!string.IsNullOrEmpty(a) && !string.IsNullOrEmpty(f))
            {
                A.text = a;
                tempText1.text = a;
                tempText2.text = f;
                hc.SetAB(tempText1, tempText2);
            }
            else
            {
                A.text = "//";
            }

            if (!string.IsNullOrEmpty(w))
            {
                W.text = w;
                tempText1.text = w;
                hc.SetWrist(tempText1);
            }
            else
            {
                W.text = "//";
            }

            if (!string.IsNullOrEmpty(o))
            {
                O.text = o;
                tempText1.text = o;
                gc.SetGesture(tempText1);
            }
            else
            {
                O.text = "//";
            }
        }
        if (str[0] == 'L')
        {
            if (judge1 == 1)
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
                L.text = "L";
                for (int j = judge2; j < str.Length; j++)
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
                R.text = "R";
                if (!string.IsNullOrEmpty(t))
                {
                    T.text = "T"+t;
                    tempText1.text = t;
                    lts.LSetHandByCode(tempText1);
                }
                else
                {
                    T.text = "//";
                }

                if (!string.IsNullOrEmpty(tt))
                {
                    TT.text = tt;
                    tempText3.text = tt;
                    ts.SetHandByCode(tempText3);
                }
                else
                {
                    TT.text = "//";
                }

                if (!string.IsNullOrEmpty(f))
                {
                    F.text = "F"+f;
                    tempText1.text = f;
                    lhc.LSetFlexion(tempText1);
                }
                else
                {
                    F.text = "//";
                }

                if (!string.IsNullOrEmpty(ff))
                {
                    FF.text = ff;
                    tempText3.text = ff;
                    hc.SetFlexion(tempText3);
                }
                else
                {
                    FF.text = "//";
                }

                if (!string.IsNullOrEmpty(a) && !string.IsNullOrEmpty(f))
                {
                    A.text ="A"+ a;
                    tempText1.text = a;
                    tempText2.text = f;
                    lhc.LSetAB(tempText1, tempText2);
                }
                else
                {
                    A.text = "//";
                }

                if (!string.IsNullOrEmpty(aa) && !string.IsNullOrEmpty(ff))
                {
                    AA.text = aa;
                    tempText3.text = aa;
                    tempText4.text = ff;
                    hc.SetAB(tempText3, tempText4);
                }
                else
                {
                    AA.text = "//";
                }

                if (!string.IsNullOrEmpty(w))
                {
                    W.text = "W"+w;
                    tempText1.text = w;
                    lhc.LSetWrist(tempText1);
                }
                else
                {
                    W.text = "//";
                }

                if (!string.IsNullOrEmpty(ww))
                {
                    WW.text = ww;
                    tempText3.text = ww;
                    hc.SetWrist(tempText3);
                }
                else
                {
                    WW.text = "//";
                }

                if (!string.IsNullOrEmpty(o))
                {
                    O.text = "O"+o;
                    tempText1.text = o;
                    lgc.LSetGesture(tempText1);
                }
                else
                {
                    O.text = "//";
                }

                if (!string.IsNullOrEmpty(oo))
                {
                    OO.text = oo;
                    tempText3.text = oo;
                    gc.SetGesture(tempText3);
                }
                else
                {
                    OO.text = "//";
                }

            }
            if (judge1 == 0)
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
                L.text = "L";
                if (!string.IsNullOrEmpty(t))
                {
                    T.text = "T"+t;
                    tempText1.text = t;
                    lts.LSetHandByCode(tempText1);
                }
                else
                {
                    T.text = "//";
                }

                if (!string.IsNullOrEmpty(f))
                {
                    F.text = "F"+f;
                    tempText1.text = f;
                    lhc.LSetFlexion(tempText1);
                }
                else
                {
                    F.text = "//";
                }

                if (!string.IsNullOrEmpty(a) && !string.IsNullOrEmpty(f))
                {
                    A.text = "A"+a;
                    tempText1.text = a;
                    tempText2.text = f;
                    lhc.LSetAB(tempText1, tempText2);
                }
                else
                {
                    A.text = "//";
                }

                if (!string.IsNullOrEmpty(w))
                {
                    W.text = "W"+w;
                    tempText1.text = w;
                    lhc.LSetWrist(tempText1);
                }
                else
                {
                    W.text = "//";
                }

                if (!string.IsNullOrEmpty(o))
                {
                    O.text = "O"+o;
                    tempText1.text = o;
                    lgc.LSetGesture(tempText1);
                }
                else
                {
                    O.text = "//";
                }
            }
        }
    }

    public void ThisCodes(int index)
    {
        Codes.text = inputArr[index].text;
    }
}
