using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RootMotion.FinalIK;

public class LeftTouch : MonoBehaviour
{
    public GameObject LTouchTarget;
    public GameObject LIndexTip;
    public GameObject LMiddleTip;
    public GameObject LRingTip;
    public GameObject LPinkTip;
    public List<Vector3> LTouchPositions = new List<Vector3>();
    public FingerRig LeftHandFingerFig;
    public void LSetHandByCode(Text code)
    {
        if (code.text.Length < 4) return;
        if (code.text[0] == '1')
        {
            //Debug.Log(1);
            LTouchPositions.Add(LIndexTip.transform.position);
        }
        if (code.text[1] == '1')
        {
            //Debug.Log(2);
            LTouchPositions.Add(LMiddleTip.transform.position);
        }
        if (code.text[2] == '1')
        {
            //Debug.Log(3);
            LTouchPositions.Add(LRingTip.transform.position);
        }
        if (code.text[3] == '1')
        {
            //Debug.Log(4);
            LTouchPositions.Add(LPinkTip.transform.position);
        }
        Vector3 TargetPosition = new Vector3(0, 0, 0);
        foreach (Vector3 vector3 in LTouchPositions)
        {
            TargetPosition += vector3;
        }
        if (LTouchPositions.Count <= 0) return;
        LTouchTarget.transform.position = TargetPosition / LTouchPositions.Count;
        LeftHandFingerFig.enabled = true;
        LeftHandFingerFig.fingers[0].target = LTouchTarget.transform;
        if (code.text[0] == '1')
        {
            LeftHandFingerFig.fingers[1].target = LTouchTarget.transform;
        }
        if (code.text[1] == '1')
        {
            LeftHandFingerFig.fingers[2].target = LTouchTarget.transform;
        }
        if (code.text[2] == '1')
        {
            LeftHandFingerFig.fingers[3].target = LTouchTarget.transform;
        }
        if (code.text[3] == '1')
        {
            LeftHandFingerFig.fingers[4].target = LTouchTarget.transform;
        }
        //RightHandFingerFig.enabled = false;
        LTouchPositions.Clear();
        //StartCoroutine(Wait());
    }
    IEnumerator LWait()
    {
        yield return new WaitForSeconds(1f);
        LeftHandFingerFig.fingers[0].target = null;
        LeftHandFingerFig.enabled = false;
    }
}
