using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandController : MonoBehaviour
{
    //Wrist
    public GameObject Wrist;
    //Thumb
    public GameObject Thumb_TMC;
    public GameObject Thumb_MCP;
    public GameObject Thumb_IP;
    //public GameObject Thumb_Distal;
    //Index
    public GameObject Index_MCP;
    public GameObject Index_PIP;
    public GameObject Index_DIP;
    //public GameObject Index_Distal;
    //Middle
    public GameObject Middle_MCP;
    public GameObject Middle_PIP;
    public GameObject Middle_DIP;
    //public GameObject Middle_Distal;
    //Ring
    public GameObject Ring_MCP;
    public GameObject Ring_PIP;
    public GameObject Ring_DIP;
    //public GameObject Ring_Distal;
    //Little
    public GameObject Little_MCP;
    public GameObject Little_PIP;
    public GameObject Little_DIP;
    //public GameObject Little_Distal;

    //SetHandByCode
    public void SetHandByCode(Text code)
    {
        int up = code.text.Length;
        //Flexion
        int i = 0;
        while (code.text[i].ToString() != "F" && i < up) i++;
        if (i != 0 && code.text[i - 1].ToString() == "F") 
        {
        //Thumb
        Set_Thumb_IP(int.Parse(code.text[i].ToString()));
        Set_Thumb_MCP(int.Parse(code.text[i + 1].ToString()));
        //Index
        Set_Index_PIP(int.Parse(code.text[i + 2].ToString()));
        Set_Index_MCP(int.Parse(code.text[i + 3].ToString()));
        //Middle
        Set_Middle_PIP(int.Parse(code.text[i + 4].ToString()));
        Set_Middle_MCP(int.Parse(code.text[i + 5].ToString()));
        //Ring
        Set_Ring_PIP(int.Parse(code.text[i + 6].ToString()));
        Set_Ring_MCP(int.Parse(code.text[i + 7].ToString()));
        //Little
        Set_Little_PIP(int.Parse(code.text[i + 8].ToString()));
        Set_Little_MCP(int.Parse(code.text[i + 9].ToString()));

        }

        //Abduction
        int j = 0;
        while (code.text[j].ToString() != "A" && j < up) j++;
        if (j != 0 && code.text[j - 1].ToString() == "A")
        {
            Set_Finger_Ab(int.Parse(code.text[j].ToString()), int.Parse(code.text[i + 3].ToString()), int.Parse(code.text[i + 5].ToString()), int.Parse(code.text[i + 7].ToString()), int.Parse(code.text[i + 9].ToString()));

        }
        //Wrist
        int k = 0;
        while (code.text[k].ToString() != "W" && k < up) k++;
        if (k != 0 && code.text[k - 1].ToString() == "W")
        {
            Set_Wrist_FL(int.Parse(code.text[k].ToString()));
            Set_Wrist_RDev(int.Parse(code.text[k+1].ToString()));
        }
    }
    public void SetFlexion(Text code)
    {
        //Thumb
        Set_Thumb_IP(int.Parse(code.text[0].ToString()));
        Set_Thumb_MCP(int.Parse(code.text[1].ToString()));
        //Index
        Set_Index_PIP(int.Parse(code.text[2].ToString()));
        Set_Index_MCP(int.Parse(code.text[3].ToString()));
        //Middle
        Set_Middle_PIP(int.Parse(code.text[4].ToString()));
        Set_Middle_MCP(int.Parse(code.text[5].ToString()));
        //Ring
        Set_Ring_PIP(int.Parse(code.text[6].ToString()));
        Set_Ring_MCP(int.Parse(code.text[7].ToString()));
        //Little
        Set_Little_PIP(int.Parse(code.text[8].ToString()));
        Set_Little_MCP(int.Parse(code.text[9].ToString()));
    }
    public void SetWrist(Text code)
    {
        //Wrist
        Set_Wrist_FL(int.Parse(code.text[0].ToString()));
        Set_Wrist_RDev(int.Parse(code.text[1].ToString()));
    }
    public void SetAB(Text code1, Text code2)
    {

        //FingerAb
        Set_Thumb_Ab(int.Parse(code1.text[0].ToString()));
        Set_Finger_Ab(int.Parse(code1.text[1].ToString()), int.Parse(code2.text[3].ToString()), int.Parse(code2.text[5].ToString()), int.Parse(code2.text[7].ToString()), int.Parse(code2.text[9].ToString()));
    }
    //****************************************Basic Function Modle****************************************//
    //Wrist_FL_three states
    public void Set_Wrist_FL(int code)
    {
        Vector3 JointRotation = Wrist.transform.localEulerAngles;
        if (code == 1)
        {
            JointRotation.z = 0;
            Wrist.transform.localEulerAngles = JointRotation;
        }
        if (code == 2)
        {
            JointRotation.z = -49;
            Wrist.transform.localEulerAngles = JointRotation;
        }
        if (code == 3)
        {
            JointRotation.z = -44;
            Wrist.transform.localEulerAngles = JointRotation;
        }
    }
    //Wrist_RDev_two states
    public void Set_Wrist_RDev(int code)
    {
        Vector3 JointRotation = Wrist.transform.localEulerAngles;
        if (code == 1)
        {
            JointRotation.y = 0;
            Wrist.transform.localEulerAngles = JointRotation;
        }
        if (code == 2)
        {
            JointRotation.y = 38;
            Wrist.transform.localEulerAngles = JointRotation;
        }
    }
    //Thumb IP
    public void Set_Thumb_IP(int code)
    {
        Vector3 JointRotation = Thumb_IP.transform.localEulerAngles;
        if (code == 1)
        {
            JointRotation.y = 0;
            Thumb_IP.transform.localEulerAngles = JointRotation;
        }
        if (code == 2)
        {
            JointRotation.y = 74;
            Thumb_IP.transform.localEulerAngles = JointRotation;
        }
    }
    //Thumb MCP
    public void Set_Thumb_MCP(int code)
    {
        Vector3 TMCRotation = Thumb_TMC.transform.localEulerAngles;
        Vector3 MCPRotation = Thumb_MCP.transform.localEulerAngles;
        if (code == 1)
        {
            //TMC
            TMCRotation.x = -55;
            Thumb_TMC.transform.localEulerAngles = TMCRotation;
            //MCP
            MCPRotation.x = 0;
            Thumb_MCP.transform.localEulerAngles = MCPRotation;
        }
        else if (code == 2)
        {
            //TMC
            TMCRotation.x = 0;
            Thumb_TMC.transform.localEulerAngles = TMCRotation;
            //MCP
            MCPRotation.x = 40;
            Thumb_MCP.transform.localEulerAngles = MCPRotation;
        }
        else if (code == 3)
        {
            //TMC
            TMCRotation.x = 50;
            Thumb_TMC.transform.localEulerAngles = TMCRotation;
            //MCP
            MCPRotation.x = 80;
            Thumb_MCP.transform.localEulerAngles = MCPRotation;
        }
    }
    //Thumb Ab
    public void Set_Thumb_Ab(int code)
    {
        Vector3 TMCRotation = Thumb_TMC.transform.localEulerAngles;
        Vector3 MCPRotation = Thumb_MCP.transform.localEulerAngles;
        if (code == 1)
        {
            //TMC
            TMCRotation.y = 15;
            Thumb_TMC.transform.localEulerAngles = TMCRotation;
            //MCP
            MCPRotation.y=25f;
            Thumb_MCP.transform.localEulerAngles = MCPRotation;
        }
        else if (code == 2)
        {
            //TMC
            TMCRotation.y = 0;
            Thumb_TMC.transform.localEulerAngles = TMCRotation;
            //MCP
            MCPRotation.y=0f;
            Thumb_MCP.transform.localEulerAngles = MCPRotation;
        }
    }
    //Finger Ab
    public void Set_Finger_Ab(int Abcode,int Indexcode,int Middlecode,int Ringcode,int Littlecode)
    {
        //0-2转换为0-1
        int Index=0, Middle = 0, Ring = 0, Little = 0;
        if (Indexcode == 0) { Index = 1; }
        if (Middlecode == 0) { Middle = 1; }
        if (Ringcode == 0) { Ring = 1; }
        if (Littlecode == 0) { Little = 1; }
        //只有一根手指伸展或没有手指伸展，无效的外展状态
        if (Index + Middle + Ring + Little == 0 || Index + Middle + Ring + Little == 0) { Debug.Log("无效的四指外展状态"); }
        //四指伸展
        if (Index + Middle + Ring + Little == 4)
        {
            if (Abcode == 1)
            {
                //Index
                Vector3 JointRotation = Index_MCP.transform.localEulerAngles;
                JointRotation.y = 0;
                Index_MCP.transform.localEulerAngles=JointRotation;
                //Middle
                JointRotation = Middle_MCP.transform.localEulerAngles;
                JointRotation.y = 0;
                Middle_MCP.transform.localEulerAngles = JointRotation;
                //Ring
                JointRotation = Ring_MCP.transform.localEulerAngles;
                JointRotation.y = 0;
                Ring_MCP.transform.localEulerAngles = JointRotation;
                //Little
                JointRotation = Little_MCP.transform.localEulerAngles;
                JointRotation.y = 0;
                Little_MCP.transform.localEulerAngles = JointRotation;
            }
            if (Abcode == 2)
            {
                //Index
                Vector3 JointRotation = Index_MCP.transform.localEulerAngles;
                JointRotation.y = -20;
                Index_MCP.transform.localEulerAngles = JointRotation;
                //Middle
                JointRotation = Middle_MCP.transform.localEulerAngles;
                JointRotation.y = -11;
                Middle_MCP.transform.localEulerAngles = JointRotation;
                //Ring
                JointRotation = Ring_MCP.transform.localEulerAngles;
                JointRotation.y = 11;
                Ring_MCP.transform.localEulerAngles = JointRotation;
                //Little
                JointRotation = Little_MCP.transform.localEulerAngles;
                JointRotation.y = 20;
                Little_MCP.transform.localEulerAngles = JointRotation;
            }
        }
        //两指伸展
        if (Index + Middle + Ring + Little == 2)
        {
            GameObject FingerOne= Index_MCP;
            GameObject FingerTwo= Middle_MCP;
            if (Index == 1 && Middle == 1) { FingerOne = Index_MCP; FingerTwo = Middle_MCP; }
            else if (Index == 1 && Ring == 1) { FingerOne = Index_MCP; FingerTwo = Ring_MCP; }
            else if (Index == 1 && Little == 1) { FingerOne = Index_MCP; FingerTwo = Little_MCP; }
            else if (Middle == 1 && Ring == 1) { FingerOne = Middle_MCP; FingerTwo = Ring_MCP; }
            else if (Middle == 1 && Little == 1) { FingerOne = Middle_MCP; FingerTwo = Little_MCP; }
            else if (Ring == 1 && Little == 1) { FingerOne = Index_MCP; FingerTwo = Little_MCP; }
            //Set Angle
            if (Abcode == 1)
            {
                //One
                Vector3 JointRotation = FingerOne.transform.localEulerAngles;
                JointRotation.y = 0;
                FingerOne.transform.localEulerAngles = JointRotation;
                //Two
                JointRotation = FingerTwo.transform.localEulerAngles;
                JointRotation.y = 0;
                FingerTwo.transform.localEulerAngles = JointRotation;
            }
            if (Abcode == 2)
            {
                //One
                if (FingerOne == Index_MCP)
                {
                    Vector3 JointRotation = FingerOne.transform.localEulerAngles;
                    JointRotation.y = -20;
                    FingerOne.transform.localEulerAngles = JointRotation;
                }
                else if (FingerOne == Middle_MCP)
                {
                    Vector3 JointRotation = FingerOne.transform.localEulerAngles;
                    JointRotation.y = -11;
                    FingerOne.transform.localEulerAngles = JointRotation;
                }
                else if (FingerOne == Ring_MCP)
                {
                    Vector3 JointRotation = FingerOne.transform.localEulerAngles;
                    JointRotation.y = 11;
                    FingerOne.transform.localEulerAngles = JointRotation;
                }
                else
                {
                    Vector3 JointRotation = FingerOne.transform.localEulerAngles;
                    JointRotation.y = 20;
                    FingerOne.transform.localEulerAngles = JointRotation;
                }
                //Two
                if (FingerTwo == Index_MCP)
                {
                    Vector3 JointRotation = FingerOne.transform.localEulerAngles;
                    JointRotation.y = -20;
                    FingerOne.transform.localEulerAngles = JointRotation;
                }
                else if (FingerTwo == Middle_MCP)
                {
                    Vector3 JointRotation = FingerOne.transform.localEulerAngles;
                    JointRotation.y = -11;
                    FingerOne.transform.localEulerAngles = JointRotation;
                }
                else if (FingerTwo == Ring_MCP)
                {
                    Vector3 JointRotation = FingerOne.transform.localEulerAngles;
                    JointRotation.y = 11;
                    FingerOne.transform.localEulerAngles = JointRotation;
                }
                else
                {
                    Vector3 JointRotation = FingerOne.transform.localEulerAngles;
                    JointRotation.y = 20;
                    FingerOne.transform.localEulerAngles = JointRotation;
                }
            }
        }
        //三指伸展
        if (Index + Middle + Ring + Little == 3)
        {
            // Except Index
            if (Index == 0)
            {
                if (Abcode == 1)
                {
                    //Middle
                    Vector3 JointRotation = Middle_MCP.transform.localEulerAngles;
                    JointRotation.y = 0;
                    Middle_MCP.transform.localEulerAngles = JointRotation;
                    //Ring
                    JointRotation = Ring_MCP.transform.localEulerAngles;
                    JointRotation.y = 0;
                    Ring_MCP.transform.localEulerAngles = JointRotation;
                    //Little
                    JointRotation = Little_MCP.transform.localEulerAngles;
                    JointRotation.y = 0;
                    Little_MCP.transform.localEulerAngles = JointRotation;
                }
                if (Abcode == 2)
                {
                    //Middle
                    Vector3 JointRotation = Middle_MCP.transform.localEulerAngles;
                    JointRotation.y = -11;
                    Middle_MCP.transform.localEulerAngles = JointRotation;
                    //Ring
                    JointRotation = Ring_MCP.transform.localEulerAngles;
                    JointRotation.y = 11;
                    Ring_MCP.transform.localEulerAngles = JointRotation;
                    //Little
                    JointRotation = Little_MCP.transform.localEulerAngles;
                    JointRotation.y = 20;
                    Little_MCP.transform.localEulerAngles = JointRotation;
                }
            }
            //Except Middle
            if (Middle == 0)
            {
                if (Abcode == 1)
                {
                    //Index
                    Vector3 JointRotation = Index_MCP.transform.localEulerAngles;
                    JointRotation.y = 0;
                    Index_MCP.transform.localEulerAngles = JointRotation;
                    //Ring
                    JointRotation = Ring_MCP.transform.localEulerAngles;
                    JointRotation.y = 0;
                    Ring_MCP.transform.localEulerAngles = JointRotation;
                    //Little
                    JointRotation = Little_MCP.transform.localEulerAngles;
                    JointRotation.y = 0;
                    Little_MCP.transform.localEulerAngles = JointRotation;
                }
                if (Abcode == 2)
                {
                    //Index
                    Vector3 JointRotation = Index_MCP.transform.localEulerAngles;
                    JointRotation.y = -20;
                    Index_MCP.transform.localEulerAngles = JointRotation;
                    //Ring
                    JointRotation = Ring_MCP.transform.localEulerAngles;
                    JointRotation.y = 11;
                    Ring_MCP.transform.localEulerAngles = JointRotation;
                    //Little
                    JointRotation = Little_MCP.transform.localEulerAngles;
                    JointRotation.y = 20;
                    Little_MCP.transform.localEulerAngles = JointRotation;
                }
            }
            //Except Ring
            if (Index == 0)
            {
                if (Abcode == 1)
                {
                    //Index
                    Vector3 JointRotation = Index_MCP.transform.localEulerAngles;
                    JointRotation.y = 0;
                    Index_MCP.transform.localEulerAngles = JointRotation;
                    //Middle
                    JointRotation = Middle_MCP.transform.localEulerAngles;
                    JointRotation.y = 0;
                    Middle_MCP.transform.localEulerAngles = JointRotation;
                    //Little
                    JointRotation = Little_MCP.transform.localEulerAngles;
                    JointRotation.y = 0;
                    Little_MCP.transform.localEulerAngles = JointRotation;
                }
                if (Abcode == 2)
                {
                    //Index
                    Vector3 JointRotation = Index_MCP.transform.localEulerAngles;
                    JointRotation.y = -20;
                    Index_MCP.transform.localEulerAngles = JointRotation;
                    //Middle
                    JointRotation = Middle_MCP.transform.localEulerAngles;
                    JointRotation.y = -11;
                    Middle_MCP.transform.localEulerAngles = JointRotation;
                    //Little
                    JointRotation = Little_MCP.transform.localEulerAngles;
                    JointRotation.y = 20;
                    Little_MCP.transform.localEulerAngles = JointRotation;
                }
            }
            //Except Little
            if (Index == 0)
            {
                if (Abcode == 1)
                {
                    //Index
                    Vector3 JointRotation = Index_MCP.transform.localEulerAngles;
                    JointRotation.y = 0;
                    Index_MCP.transform.localEulerAngles = JointRotation;
                    //Middle
                    JointRotation = Middle_MCP.transform.localEulerAngles;
                    JointRotation.y = 0;
                    Middle_MCP.transform.localEulerAngles = JointRotation;
                    //Ring
                    JointRotation = Ring_MCP.transform.localEulerAngles;
                    JointRotation.y = 0;
                    Ring_MCP.transform.localEulerAngles = JointRotation;
                }
                if (Abcode == 2)
                {
                    //Index
                    Vector3 JointRotation = Index_MCP.transform.localEulerAngles;
                    JointRotation.y = -20;
                    Index_MCP.transform.localEulerAngles = JointRotation;
                    //Middle
                    JointRotation = Middle_MCP.transform.localEulerAngles;
                    JointRotation.y = -11;
                    Middle_MCP.transform.localEulerAngles = JointRotation;
                    //Ring
                    JointRotation = Ring_MCP.transform.localEulerAngles;
                    JointRotation.y = 11;
                    Ring_MCP.transform.localEulerAngles = JointRotation;
                }
            }
        }
    }
    //Index PIP
    public void Set_Index_PIP(int code)
    {
        Vector3 JointRotation = Index_PIP.transform.localEulerAngles;
        if (code == 1)
        {
            JointRotation.z = 0;
            Index_PIP.transform.localEulerAngles = JointRotation;
            Index_DIP.transform.localEulerAngles = JointRotation;
        }
        if (code == 2)
        {
            JointRotation.z = -51;
            Index_PIP.transform.localEulerAngles = JointRotation;
            JointRotation.z = -51*2/3;
            Index_DIP.transform.localEulerAngles = JointRotation;
        }
        if (code == 3)
        {
            JointRotation.z = -91;
            Index_PIP.transform.localEulerAngles = JointRotation;
            JointRotation.z = -91*2/3;
            Index_DIP.transform.localEulerAngles = JointRotation;
        }
    }
    //Index MCP
    public void Set_Index_MCP(int code)
    {
        Vector3 JointRotation = Index_MCP.transform.localEulerAngles;
        if (code == 1)
        {
            JointRotation.z = 0;
            Index_MCP.transform.localEulerAngles = JointRotation;
        }
        if (code == 2)
        {
            JointRotation.z = -40;
            Index_MCP.transform.localEulerAngles = JointRotation;
        }
        if (code == 3)
        {
            JointRotation.z = -74;
            Index_MCP.transform.localEulerAngles = JointRotation;
        }
    }
    //Middle PIP
    public void Set_Middle_PIP(int code)
    {
        Vector3 JointRotation = Middle_PIP.transform.localEulerAngles;
        if (code == 1)
        {
            JointRotation.z = 0;
            Middle_PIP.transform.localEulerAngles = JointRotation;
            Middle_DIP.transform.localEulerAngles = JointRotation;
        }
        if (code == 2)
        {
            JointRotation.z = -51;
            Middle_PIP.transform.localEulerAngles = JointRotation;
            JointRotation.z = -51 * 2 / 3;
            Middle_DIP.transform.localEulerAngles = JointRotation;
        }
        if (code == 3)
        {
            JointRotation.z = -91;
            Middle_PIP.transform.localEulerAngles = JointRotation;
            JointRotation.z = -91 * 2 / 3;
            Middle_DIP.transform.localEulerAngles = JointRotation;
        }
    }
    //Middle MCP
    public void Set_Middle_MCP(int code)
    {
        Vector3 JointRotation = Middle_MCP.transform.localEulerAngles;
        if (code == 1)
        {
            JointRotation.z = 0;
            Middle_MCP.transform.localEulerAngles = JointRotation;
        }
        if (code == 2)
        {
            JointRotation.z = -40;
            Middle_MCP.transform.localEulerAngles = JointRotation;
        }
        if (code == 3)
        {
            JointRotation.z = -74;
            Middle_MCP.transform.localEulerAngles = JointRotation;
        }
    }
    //Ring PIP
    public void Set_Ring_PIP(int code)
    {
        Vector3 JointRotation = Ring_PIP.transform.localEulerAngles;
        if (code == 1)
        {
            JointRotation.z = 0;
            Ring_PIP.transform.localEulerAngles = JointRotation;
            Ring_DIP.transform.localEulerAngles = JointRotation;
        }
        if (code == 2)
        {
            JointRotation.z = -51;
            Ring_PIP.transform.localEulerAngles = JointRotation;
            JointRotation.z = -51 * 2 / 3;
            Ring_DIP.transform.localEulerAngles = JointRotation;
        }
        if (code == 3)
        {
            JointRotation.z = -91;
            Ring_PIP.transform.localEulerAngles = JointRotation;
            JointRotation.z = -91 * 2 / 3;
            Ring_DIP.transform.localEulerAngles = JointRotation;
        }
    }
    //Ring MCP
    public void Set_Ring_MCP(int code)
    {
        Vector3 JointRotation = Ring_MCP.transform.localEulerAngles;
        if (code == 1)
        {
            JointRotation.z = 0;
            Ring_MCP.transform.localEulerAngles = JointRotation;
        }
        if (code == 2)
        {
            JointRotation.z = -40;
            Ring_MCP.transform.localEulerAngles = JointRotation;
        }
        if (code == 3)
        {
            JointRotation.z = -74;
            Ring_MCP.transform.localEulerAngles = JointRotation;
        }
    }
    //Little PIP
    public void Set_Little_PIP(int code)
    {
        Vector3 JointRotation = Little_PIP.transform.localEulerAngles;
        if (code == 1)
        {
            JointRotation.z = 0;
            Little_PIP.transform.localEulerAngles = JointRotation;
            Little_DIP.transform.localEulerAngles = JointRotation;
        }
        if (code == 2)
        {
            JointRotation.z = -51;
            Little_PIP.transform.localEulerAngles = JointRotation;
            JointRotation.z = -51 * 2 / 3;
            Little_DIP.transform.localEulerAngles = JointRotation;
        }
        if (code == 3)
        {
            JointRotation.z = -91;
            Little_PIP.transform.localEulerAngles = JointRotation;
            JointRotation.z = -91 * 2 / 3;
            Little_DIP.transform.localEulerAngles = JointRotation;
        }
    }
    //Little MCP
    public void Set_Little_MCP(int code)
    {
        Vector3 JointRotation = Little_MCP.transform.localEulerAngles;
        if (code == 1)
        {
            JointRotation.z = 0;
            Little_MCP.transform.localEulerAngles = JointRotation;
        }
        if (code == 2)
        {
            JointRotation.z = -40;
            Little_MCP.transform.localEulerAngles = JointRotation;
        }
        if (code == 3)
        {
            JointRotation.z = -74;
            Little_MCP.transform.localEulerAngles = JointRotation;
        }
    }
}
