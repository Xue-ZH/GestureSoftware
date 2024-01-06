using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftController : MonoBehaviour
{
    //Wrist
    public GameObject LWrist;
    //Thumb
    public GameObject LThumb_TMC;
    public GameObject LThumb_MCP;
    public GameObject LThumb_IP;
    //public GameObject Thumb_Distal;
    //Index
    public GameObject LIndex_MCP;
    public GameObject LIndex_PIP;
    public GameObject LIndex_DIP;
    //public GameObject Index_Distal;
    //Middle
    public GameObject LMiddle_MCP;
    public GameObject LMiddle_PIP;
    public GameObject LMiddle_DIP;
    //public GameObject Middle_Distal;
    //Ring
    public GameObject LRing_MCP;
    public GameObject LRing_PIP;
    public GameObject LRing_DIP;
    //public GameObject Ring_Distal;
    //Little
    public GameObject LLittle_MCP;
    public GameObject LLittle_PIP;
    public GameObject LLittle_DIP;
    //public GameObject Little_Distal;

    public Text code3;
    public Text code4;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //SetHandByCode
    public void LSetHandByCode(Text code)
    {
        //Thumb
        LSet_Thumb_IP(int.Parse(code.text[0].ToString()));
        LSet_Thumb_MCP(int.Parse(code.text[1].ToString()));
        //Index
        LSet_Index_PIP(int.Parse(code.text[2].ToString()));
        LSet_Index_MCP(int.Parse(code.text[3].ToString()));
        //Middle
        LSet_Middle_PIP(int.Parse(code.text[4].ToString()));
        LSet_Middle_MCP(int.Parse(code.text[5].ToString()));
        //Ring
        LSet_Ring_PIP(int.Parse(code.text[6].ToString()));
        LSet_Ring_MCP(int.Parse(code.text[7].ToString()));
        //Little
        LSet_Little_PIP(int.Parse(code.text[8].ToString()));
        LSet_Little_MCP(int.Parse(code.text[9].ToString()));
        //FingerAb
        LSet_Finger_Ab(int.Parse(code.text[10].ToString()), int.Parse(code.text[3].ToString()), int.Parse(code.text[5].ToString()), int.Parse(code.text[7].ToString()), int.Parse(code.text[9].ToString()));
        //Wrist
        LSet_Wrist_FL(int.Parse(code.text[12].ToString()));
        LSet_Wrist_RDev(int.Parse(code.text[13].ToString()));
    }
    public void LSetFlexion(Text code)
    {
        //Thumb
        LSet_Thumb_IP(int.Parse(code.text[0].ToString()));
        LSet_Thumb_MCP(int.Parse(code.text[1].ToString()));
        //Index
        LSet_Index_PIP(int.Parse(code.text[2].ToString()));
        LSet_Index_MCP(int.Parse(code.text[3].ToString()));
        //Middle
        LSet_Middle_PIP(int.Parse(code.text[4].ToString()));
        LSet_Middle_MCP(int.Parse(code.text[5].ToString()));
        //Ring
        LSet_Ring_PIP(int.Parse(code.text[6].ToString()));
        LSet_Ring_MCP(int.Parse(code.text[7].ToString()));
        //Little
        LSet_Little_PIP(int.Parse(code.text[8].ToString()));
        LSet_Little_MCP(int.Parse(code.text[9].ToString()));
    }
    public void LSetWrist(Text code)
    {
        //Wrist
        LSet_Wrist_FL(int.Parse(code.text[0].ToString()));
        LSet_Wrist_RDev(int.Parse(code.text[1].ToString()));
    }
    public void LSetAB(Text code3, Text code4)
    {

        //FingerAb
        Set_Thumb_Ab(int.Parse(code3.text[0].ToString()));
        LSet_Finger_Ab(int.Parse(code3.text[1].ToString()), int.Parse(code4.text[3].ToString()), int.Parse(code4.text[5].ToString()), int.Parse(code4.text[7].ToString()), int.Parse(code4.text[9].ToString()));
    }
    //****************************************Basic Function Modle****************************************//
    //Wrist_FL_three states
    public void LSet_Wrist_FL(int code)
    {
        Vector3 JointRotation = LWrist.transform.localEulerAngles;
        if (code == 1)
        {
            JointRotation.z = 0;
            LWrist.transform.localEulerAngles = JointRotation;
        }
        if (code == 2)
        {
            JointRotation.z = 49;
            LWrist.transform.localEulerAngles = JointRotation;
        }
        if (code == 3)
        {
            JointRotation.z = 44;
            LWrist.transform.localEulerAngles = JointRotation;
        }
    }
    //Wrist_RDev_two states
    public void LSet_Wrist_RDev(int code)
    {
        Vector3 JointRotation = LWrist.transform.localEulerAngles;
        if (code == 1)
        {
            JointRotation.y = 0;
            LWrist.transform.localEulerAngles = JointRotation;
        }
        if (code == 2)
        {
            JointRotation.y = -38;
            LWrist.transform.localEulerAngles = JointRotation;
        }
    }
    //Thumb IP
    public void LSet_Thumb_IP(int code)
    {
        Vector3 JointRotation = LThumb_IP.transform.localEulerAngles;
        if (code == 1)
        {
            JointRotation.y = 0;
            LThumb_IP.transform.localEulerAngles = JointRotation;
        }
        if (code == 2)
        {
            JointRotation.y = -74;
            LThumb_IP.transform.localEulerAngles = JointRotation;
        }
    }
    //Thumb MCP
    public void LSet_Thumb_MCP(int code)
    {
        Vector3 TMCRotation = LThumb_TMC.transform.localEulerAngles;
        Vector3 MCPRotation = LThumb_MCP.transform.localEulerAngles;
        if (code == 1)
        {
            //TMC
            TMCRotation.x = -55;
            LThumb_TMC.transform.localEulerAngles = TMCRotation;
            //MCP
            MCPRotation.x = 0;
            LThumb_MCP.transform.localEulerAngles = MCPRotation;
        }
        else if (code == 2)
        {
            //TMC
            TMCRotation.x = 0;
            LThumb_TMC.transform.localEulerAngles = TMCRotation;
            //MCP
            MCPRotation.x = 40;
            LThumb_MCP.transform.localEulerAngles = MCPRotation;
        }
        else if (code == 3)
        {
            //TMC
            TMCRotation.x = 50;
            LThumb_TMC.transform.localEulerAngles = TMCRotation;
            //MCP
            MCPRotation.x = 80;
            LThumb_MCP.transform.localEulerAngles = MCPRotation;
        }
    }
    //Thumb Ab
    public void Set_Thumb_Ab(int code)
    {
        Vector3 TMCRotation = LThumb_TMC.transform.localEulerAngles;
        Vector3 MCPRotation = LThumb_MCP.transform.localEulerAngles;
        if (code == 1)
        {
            //TMC
            TMCRotation.y = -15;
            LThumb_TMC.transform.localEulerAngles = TMCRotation;
            //MCP
            MCPRotation.y = -25f;
            LThumb_MCP.transform.localEulerAngles = MCPRotation;
        }
        else if (code == 2)
        {
            //TMC
            TMCRotation.y = 0;
            LThumb_TMC.transform.localEulerAngles = TMCRotation;
            //MCP
            MCPRotation.y = 0f;
            LThumb_MCP.transform.localEulerAngles = MCPRotation;
        }
    }
    //Finger Ab
    public void LSet_Finger_Ab(int Abcode, int Indexcode, int Middlecode, int Ringcode, int Littlecode)
    {
        //0-2转换为0-1
        int Index = 0, Middle = 0, Ring = 0, Little = 0;
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
                Vector3 JointRotation = LIndex_MCP.transform.localEulerAngles;
                JointRotation.y = 0;
                LIndex_MCP.transform.localEulerAngles = JointRotation;
                //Middle
                JointRotation = LMiddle_MCP.transform.localEulerAngles;
                JointRotation.y = 0;
                LMiddle_MCP.transform.localEulerAngles = JointRotation;
                //Ring
                JointRotation = LRing_MCP.transform.localEulerAngles;
                JointRotation.y = 0;
                LRing_MCP.transform.localEulerAngles = JointRotation;
                //Little
                JointRotation = LLittle_MCP.transform.localEulerAngles;
                JointRotation.y = 0;
                LLittle_MCP.transform.localEulerAngles = JointRotation;
            }
            if (Abcode == 2)
            {
                //Index
                Vector3 JointRotation = LIndex_MCP.transform.localEulerAngles;
                JointRotation.y = 20;
                LIndex_MCP.transform.localEulerAngles = JointRotation;
                //Middle
                JointRotation = LMiddle_MCP.transform.localEulerAngles;
                JointRotation.y = 11;
                LMiddle_MCP.transform.localEulerAngles = JointRotation;
                //Ring
                JointRotation = LRing_MCP.transform.localEulerAngles;
                JointRotation.y = -11;
                LRing_MCP.transform.localEulerAngles = JointRotation;
                //Little
                JointRotation = LLittle_MCP.transform.localEulerAngles;
                JointRotation.y = -20;
                LLittle_MCP.transform.localEulerAngles = JointRotation;
            }
        }
        //两指伸展
        if (Index + Middle + Ring + Little == 2)
        {
            GameObject FingerOne = LIndex_MCP;
            GameObject FingerTwo = LMiddle_MCP;
            if (Index == 1 && Middle == 1) { FingerOne = LIndex_MCP; FingerTwo = LMiddle_MCP; }
            else if (Index == 1 && Ring == 1) { FingerOne = LIndex_MCP; FingerTwo = LRing_MCP; }
            else if (Index == 1 && Little == 1) { FingerOne = LIndex_MCP; FingerTwo = LLittle_MCP; }
            else if (Middle == 1 && Ring == 1) { FingerOne = LMiddle_MCP; FingerTwo = LRing_MCP; }
            else if (Middle == 1 && Little == 1) { FingerOne = LMiddle_MCP; FingerTwo = LLittle_MCP; }
            else if (Ring == 1 && Little == 1) { FingerOne = LIndex_MCP; FingerTwo = LLittle_MCP; }
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
                if (FingerOne == LIndex_MCP)
                {
                    Vector3 JointRotation = FingerOne.transform.localEulerAngles;
                    JointRotation.y = 20;
                    FingerOne.transform.localEulerAngles = JointRotation;
                }
                else if (FingerOne == LMiddle_MCP)
                {
                    Vector3 JointRotation = FingerOne.transform.localEulerAngles;
                    JointRotation.y = 11;
                    FingerOne.transform.localEulerAngles = JointRotation;
                }
                else if (FingerOne == LRing_MCP)
                {
                    Vector3 JointRotation = FingerOne.transform.localEulerAngles;
                    JointRotation.y = -11;
                    FingerOne.transform.localEulerAngles = JointRotation;
                }
                else
                {
                    Vector3 JointRotation = FingerOne.transform.localEulerAngles;
                    JointRotation.y = -20;
                    FingerOne.transform.localEulerAngles = JointRotation;
                }
                //Two
                if (FingerTwo == LIndex_MCP)
                {
                    Vector3 JointRotation = FingerOne.transform.localEulerAngles;
                    JointRotation.y = 20;
                    FingerOne.transform.localEulerAngles = JointRotation;
                }
                else if (FingerTwo == LMiddle_MCP)
                {
                    Vector3 JointRotation = FingerOne.transform.localEulerAngles;
                    JointRotation.y = 11;
                    FingerOne.transform.localEulerAngles = JointRotation;
                }
                else if (FingerTwo == LRing_MCP)
                {
                    Vector3 JointRotation = FingerOne.transform.localEulerAngles;
                    JointRotation.y = -11;
                    FingerOne.transform.localEulerAngles = JointRotation;
                }
                else
                {
                    Vector3 JointRotation = FingerOne.transform.localEulerAngles;
                    JointRotation.y = -20;
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
                    Vector3 JointRotation = LMiddle_MCP.transform.localEulerAngles;
                    JointRotation.y = 0;
                    LMiddle_MCP.transform.localEulerAngles = JointRotation;
                    //Ring
                    JointRotation = LRing_MCP.transform.localEulerAngles;
                    JointRotation.y = 0;
                    LRing_MCP.transform.localEulerAngles = JointRotation;
                    //Little
                    JointRotation = LLittle_MCP.transform.localEulerAngles;
                    JointRotation.y = 0;
                    LLittle_MCP.transform.localEulerAngles = JointRotation;
                }
                if (Abcode == 2)
                {
                    //Middle
                    Vector3 JointRotation = LMiddle_MCP.transform.localEulerAngles;
                    JointRotation.y = 11;
                    LMiddle_MCP.transform.localEulerAngles = JointRotation;
                    //Ring
                    JointRotation = LRing_MCP.transform.localEulerAngles;
                    JointRotation.y = -11;
                    LRing_MCP.transform.localEulerAngles = JointRotation;
                    //Little
                    JointRotation = LLittle_MCP.transform.localEulerAngles;
                    JointRotation.y = -20;
                    LLittle_MCP.transform.localEulerAngles = JointRotation;
                }
            }
            //Except Middle
            if (Middle == 0)
            {
                if (Abcode == 1)
                {
                    //Index
                    Vector3 JointRotation = LIndex_MCP.transform.localEulerAngles;
                    JointRotation.y = 0;
                    LIndex_MCP.transform.localEulerAngles = JointRotation;
                    //Ring
                    JointRotation = LRing_MCP.transform.localEulerAngles;
                    JointRotation.y = 0;
                    LRing_MCP.transform.localEulerAngles = JointRotation;
                    //Little
                    JointRotation = LLittle_MCP.transform.localEulerAngles;
                    JointRotation.y = 0;
                    LLittle_MCP.transform.localEulerAngles = JointRotation;
                }
                if (Abcode == 2)
                {
                    //Index
                    Vector3 JointRotation = LIndex_MCP.transform.localEulerAngles;
                    JointRotation.y = 20;
                    LIndex_MCP.transform.localEulerAngles = JointRotation;
                    //Ring
                    JointRotation = LRing_MCP.transform.localEulerAngles;
                    JointRotation.y = -11;
                    LRing_MCP.transform.localEulerAngles = JointRotation;
                    //Little
                    JointRotation = LLittle_MCP.transform.localEulerAngles;
                    JointRotation.y = -20;
                    LLittle_MCP.transform.localEulerAngles = JointRotation;
                }
            }
            //Except Ring
            if (Index == 0)
            {
                if (Abcode == 1)
                {
                    //Index
                    Vector3 JointRotation = LIndex_MCP.transform.localEulerAngles;
                    JointRotation.y = 0;
                    LIndex_MCP.transform.localEulerAngles = JointRotation;
                    //Middle
                    JointRotation = LMiddle_MCP.transform.localEulerAngles;
                    JointRotation.y = 0;
                    LMiddle_MCP.transform.localEulerAngles = JointRotation;
                    //Little
                    JointRotation = LLittle_MCP.transform.localEulerAngles;
                    JointRotation.y = 0;
                    LLittle_MCP.transform.localEulerAngles = JointRotation;
                }
                if (Abcode == 2)
                {
                    //Index
                    Vector3 JointRotation = LIndex_MCP.transform.localEulerAngles;
                    JointRotation.y = 20;
                    LIndex_MCP.transform.localEulerAngles = JointRotation;
                    //Middle
                    JointRotation = LMiddle_MCP.transform.localEulerAngles;
                    JointRotation.y = 11;
                    LMiddle_MCP.transform.localEulerAngles = JointRotation;
                    //Little
                    JointRotation = LLittle_MCP.transform.localEulerAngles;
                    JointRotation.y = -20;
                    LLittle_MCP.transform.localEulerAngles = JointRotation;
                }
            }
            //Except Little
            if (Index == 0)
            {
                if (Abcode == 1)
                {
                    //Index
                    Vector3 JointRotation = LIndex_MCP.transform.localEulerAngles;
                    JointRotation.y = 0;
                    LIndex_MCP.transform.localEulerAngles = JointRotation;
                    //Middle
                    JointRotation = LMiddle_MCP.transform.localEulerAngles;
                    JointRotation.y = 0;
                    LMiddle_MCP.transform.localEulerAngles = JointRotation;
                    //Ring
                    JointRotation = LRing_MCP.transform.localEulerAngles;
                    JointRotation.y = 0;
                    LRing_MCP.transform.localEulerAngles = JointRotation;
                }
                if (Abcode == 2)
                {
                    //Index
                    Vector3 JointRotation = LIndex_MCP.transform.localEulerAngles;
                    JointRotation.y = 20;
                    LIndex_MCP.transform.localEulerAngles = JointRotation;
                    //Middle
                    JointRotation = LMiddle_MCP.transform.localEulerAngles;
                    JointRotation.y = 11;
                    LMiddle_MCP.transform.localEulerAngles = JointRotation;
                    //Ring
                    JointRotation = LRing_MCP.transform.localEulerAngles;
                    JointRotation.y = -11;
                    LRing_MCP.transform.localEulerAngles = JointRotation;
                }
            }
        }
    }
    //Index PIP
    public void LSet_Index_PIP(int code)
    {
        Vector3 JointRotation = LIndex_PIP.transform.localEulerAngles;
        if (code == 1)
        {
            JointRotation.z = 0;
            LIndex_PIP.transform.localEulerAngles = JointRotation;
            LIndex_DIP.transform.localEulerAngles = JointRotation;
        }
        if (code == 2)
        {
            JointRotation.z = 51;
            LIndex_PIP.transform.localEulerAngles = JointRotation;
            JointRotation.z = 51 * 2 / 3;
            LIndex_DIP.transform.localEulerAngles = JointRotation;
        }
        if (code == 3)
        {
            JointRotation.z = 91;
            LIndex_PIP.transform.localEulerAngles = JointRotation;
            JointRotation.z = 91 * 2 / 3;
            LIndex_DIP.transform.localEulerAngles = JointRotation;
        }
    }
    //Index MCP
    public void LSet_Index_MCP(int code)
    {
        Vector3 JointRotation = LIndex_MCP.transform.localEulerAngles;
        if (code == 1)
        {
            JointRotation.z = 0;
            LIndex_MCP.transform.localEulerAngles = JointRotation;
        }
        if (code == 2)
        {
            JointRotation.z = 40;
            LIndex_MCP.transform.localEulerAngles = JointRotation;
        }
        if (code == 3)
        {
            JointRotation.z = 74;
            LIndex_MCP.transform.localEulerAngles = JointRotation;
        }
    }
    //Middle PIP
    public void LSet_Middle_PIP(int code)
    {
        Vector3 JointRotation = LMiddle_PIP.transform.localEulerAngles;
        if (code == 1)
        {
            JointRotation.z = 0;
            LMiddle_PIP.transform.localEulerAngles = JointRotation;
            LMiddle_DIP.transform.localEulerAngles = JointRotation;
        }
        if (code == 2)
        {
            JointRotation.z = 51;
            LMiddle_PIP.transform.localEulerAngles = JointRotation;
            JointRotation.z = 51 * 2 / 3;
            LMiddle_DIP.transform.localEulerAngles = JointRotation;
        }
        if (code == 3)
        {
            JointRotation.z = 91;
            LMiddle_PIP.transform.localEulerAngles = JointRotation;
            JointRotation.z = 91 * 2 / 3;
            LMiddle_DIP.transform.localEulerAngles = JointRotation;
        }
    }
    //Middle MCP
    public void LSet_Middle_MCP(int code)
    {
        Vector3 JointRotation = LMiddle_MCP.transform.localEulerAngles;
        if (code == 1)
        {
            JointRotation.z = 0;
            LMiddle_MCP.transform.localEulerAngles = JointRotation;
        }
        if (code == 2)
        {
            JointRotation.z = 40;
            LMiddle_MCP.transform.localEulerAngles = JointRotation;
        }
        if (code == 3)
        {
            JointRotation.z = 74;
            LMiddle_MCP.transform.localEulerAngles = JointRotation;
        }
    }
    //Ring PIP
    public void LSet_Ring_PIP(int code)
    {
        Vector3 JointRotation = LRing_PIP.transform.localEulerAngles;
        if (code == 1)
        {
            JointRotation.z = 0;
            LRing_PIP.transform.localEulerAngles = JointRotation;
            LRing_DIP.transform.localEulerAngles = JointRotation;
        }
        if (code == 2)
        {
            JointRotation.z = 51;
            LRing_PIP.transform.localEulerAngles = JointRotation;
            JointRotation.z = 51 * 2 / 3;
            LRing_DIP.transform.localEulerAngles = JointRotation;
        }
        if (code == 3)
        {
            JointRotation.z = 91;
            LRing_PIP.transform.localEulerAngles = JointRotation;
            JointRotation.z = 91 * 2 / 3;
            LRing_DIP.transform.localEulerAngles = JointRotation;
        }
    }
    //Ring MCP
    public void LSet_Ring_MCP(int code)
    {
        Vector3 JointRotation = LRing_MCP.transform.localEulerAngles;
        if (code == 1)
        {
            JointRotation.z = 0;
            LRing_MCP.transform.localEulerAngles = JointRotation;
        }
        if (code == 2)
        {
            JointRotation.z = 40;
            LRing_MCP.transform.localEulerAngles = JointRotation;
        }
        if (code == 3)
        {
            JointRotation.z = 74;
            LRing_MCP.transform.localEulerAngles = JointRotation;
        }
    }
    //Little PIP
    public void LSet_Little_PIP(int code)
    {
        Vector3 JointRotation = LLittle_PIP.transform.localEulerAngles;
        if (code == 1)
        {
            JointRotation.z = 0;
            LLittle_PIP.transform.localEulerAngles = JointRotation;
            LLittle_DIP.transform.localEulerAngles = JointRotation;
        }
        if (code == 2)
        {
            JointRotation.z = 51;
            LLittle_PIP.transform.localEulerAngles = JointRotation;
            JointRotation.z = 51 * 2 / 3;
            LLittle_DIP.transform.localEulerAngles = JointRotation;
        }
        if (code == 3)
        {
            JointRotation.z = 91;
            LLittle_PIP.transform.localEulerAngles = JointRotation;
            JointRotation.z = 91 * 2 / 3;
            LLittle_DIP.transform.localEulerAngles = JointRotation;
        }
    }
    //Little MCP
    public void LSet_Little_MCP(int code)
    {
        Vector3 JointRotation = LLittle_MCP.transform.localEulerAngles;
        if (code == 1)
        {
            JointRotation.z = 0;
            LLittle_MCP.transform.localEulerAngles = JointRotation;
        }
        if (code == 2)
        {
            JointRotation.z = 40;
            LLittle_MCP.transform.localEulerAngles = JointRotation;
        }
        if (code == 3)
        {
            JointRotation.z = 74;
            LLittle_MCP.transform.localEulerAngles = JointRotation;
        }
    }
}
