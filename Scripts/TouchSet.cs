using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RootMotion.FinalIK;

public class TouchSet : MonoBehaviour
{
    public GameObject TouchTarget;
    public GameObject IndexTip;
    public GameObject MiddleTip;
    public GameObject RingTip;
    public GameObject PinkTip;
    public List<Vector3> TouchPositions = new List<Vector3>();
    public FingerRig RightHandFingerFig;

    /*
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

    //Thumb
    public GameObject Thumb_TMC_Set;
    public GameObject Thumb_MCP_Set;
    public GameObject Thumb_IP_Set;
    //public GameObject Thumb_Distal;
    //Index
    public GameObject Index_MCP_Set;
    public GameObject Index_PIP_Set;
    public GameObject Index_DIP_Set;
    //public GameObject Index_Distal;
    //Middle
    public GameObject Middle_MCP_Set;
    public GameObject Middle_PIP_Set;
    public GameObject Middle_DIP_Set;
    //public GameObject Middle_Distal;
    //Ring
    public GameObject Ring_MCP_Set;
    public GameObject Ring_PIP_Set;
    public GameObject Ring_DIP_Set;
    //public GameObject Ring_Distal;
    //Little
    public GameObject Little_MCP_Set;
    public GameObject Little_PIP_Set;
    public GameObject Little_DIP_Set;
    //public GameObject Little_Distal;*/

    public void SetHandByCode(Text code)
    {
        if (code.text.Length < 4) return;
        if (code.text[0] == '1')
        {
            //Debug.Log(1);
            TouchPositions.Add(IndexTip.transform.position);
        }
        if (code.text[1] == '1')
        {
            //Debug.Log(2);
            TouchPositions.Add(MiddleTip.transform.position);
        }
        if (code.text[2] == '1')
        {
            //Debug.Log(3);
            TouchPositions.Add(RingTip.transform.position);
        }
       if (code.text[3] == '1')
        {
            //Debug.Log(4);
            TouchPositions.Add(PinkTip.transform.position);
        }
        Vector3 TargetPosition = new Vector3(0,0,0);
        foreach (Vector3 vector3 in TouchPositions)
        {
            TargetPosition += vector3;
        }
        if (TouchPositions.Count <= 0) return;
        TouchTarget.transform.position = TargetPosition/ TouchPositions.Count;
        RightHandFingerFig.enabled = true;
        RightHandFingerFig.fingers[0].target = TouchTarget.transform;
        if (code.text[0] == '1')
        {
            RightHandFingerFig.fingers[1].target = TouchTarget.transform;
        }
        if (code.text[1] == '1')
        {
            RightHandFingerFig.fingers[2].target = TouchTarget.transform;
        }
        if (code.text[2] == '1')
        {
            RightHandFingerFig.fingers[3].target = TouchTarget.transform;
        }
        if (code.text[3] == '1')
        {
            RightHandFingerFig.fingers[4].target = TouchTarget.transform;
        }
        //RightHandFingerFig.enabled = false;
        TouchPositions.Clear();
        //StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        RightHandFingerFig.fingers[0].target = null;
        RightHandFingerFig.enabled = false;
    }
}
