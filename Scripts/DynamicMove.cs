using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;
using System.IO;
using System.Data;
using UnityEngine.UI;


public class DynamicMove : MonoBehaviour
{
    public GameObject UpTarget;
    public GameObject DownTarget;
    public GameObject LeftTarget;
    public GameObject RightTarget;
    public GameObject ForwordTarget;
    public GameObject BackTarget;

    public GameObject Left_UpTarget;
    public GameObject Right_UpTarget;
    public GameObject Left_DownTarget;
    public GameObject Right_DownTarget;

    public GameObject RealTarget;
    public GameObject FakeHand;
    public GameObject RealHand;

    public GameObject CircleTarget;
    public GameObject CircleRotate;
    Vector3 CenterPosition;
    float RotateAngle=0;


    public GameObject Role;

    bool IsMoving = false;
    string MoveMode;
    float MoveSpeed = 0.5f;

    //public GameObject StateCode;

    //动作复制
    HumanPoseHandler initbody;
    HumanPoseHandler midbody;
    public GameObject initmodel;
    public GameObject midlmodel;
    public GameObject midforearm;
    public GameObject midlowarm;
    public GameObject setforearm;
    public GameObject setlowarm;

    private void Start()
    {
        Role.GetComponent<BipedIK>().enabled = true;
        Role.GetComponent<BipedIK>().solvers.rightHand.bone3.transform = FakeHand.transform;
        RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        Role.GetComponent<BipedIK>().enabled = false;

        initbody = new HumanPoseHandler(initmodel.GetComponent<Animator>().avatar, initmodel.transform);
        midbody = new HumanPoseHandler(midlmodel.GetComponent<Animator>().avatar, midlmodel.transform);
    }
    // Update is called once per frame
    void Update()
    {
        if (IsMoving)
        {
            HumanPose m_humanPose = new HumanPose();
            initbody.GetHumanPose(ref m_humanPose);
            midbody.SetHumanPose(ref m_humanPose);
            setforearm.transform.rotation = midforearm.transform.rotation;
            setlowarm.transform.rotation = midlowarm.transform.rotation;

            if (MoveMode == "W1")
            {
                RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                RealTarget.transform.position = Vector3.MoveTowards(RealTarget.transform.position, ForwordTarget.transform.position, MoveSpeed * Time.deltaTime);
                if ((RealTarget.transform.position - ForwordTarget.transform.position).sqrMagnitude < 0.001)
                {
                    IsMoving = false;
                    Role.GetComponent<BipedIK>().enabled = false;
                }
            }
            else if (MoveMode == "W2")
            {
                RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                RealTarget.transform.position = Vector3.MoveTowards(RealTarget.transform.position, BackTarget.transform.position, MoveSpeed * Time.deltaTime);
                if ((RealTarget.transform.position - BackTarget.transform.position).sqrMagnitude < 0.001)
                {
                    IsMoving = false;
                    Role.GetComponent<BipedIK>().enabled = false;
                }
            }
            else if (MoveMode == "W3")
            {
                RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                RealTarget.transform.position = Vector3.MoveTowards(RealTarget.transform.position, LeftTarget.transform.position, MoveSpeed * Time.deltaTime);
                if ((RealTarget.transform.position - LeftTarget.transform.position).sqrMagnitude < 0.001)
                {
                    IsMoving = false;
                    Role.GetComponent<BipedIK>().enabled = false;
                }
            }
            else if (MoveMode == "W4")
            {
                RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                RealTarget.transform.position = Vector3.MoveTowards(RealTarget.transform.position, RightTarget.transform.position, MoveSpeed * Time.deltaTime);
                if ((RealTarget.transform.position - RightTarget.transform.position).sqrMagnitude < 0.001)
                {
                    IsMoving = false;
                    Role.GetComponent<BipedIK>().enabled = false;
                }
            }
            else if (MoveMode == "W5")
            {
                RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                RealTarget.transform.position = Vector3.MoveTowards(RealTarget.transform.position, UpTarget.transform.position, MoveSpeed * Time.deltaTime);
                if ((RealTarget.transform.position - UpTarget.transform.position).sqrMagnitude < 0.001)
                {
                    IsMoving = false;
                    Role.GetComponent<BipedIK>().enabled = false;
                }
            }
            else if (MoveMode == "W6")
            {
                RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                RealTarget.transform.position = Vector3.MoveTowards(RealTarget.transform.position, DownTarget.transform.position, MoveSpeed * Time.deltaTime);
                if ((RealTarget.transform.position - DownTarget.transform.position).sqrMagnitude < 0.001)
                {
                    IsMoving = false;
                    Role.GetComponent<BipedIK>().enabled = false;
                }
            }
            else if (MoveMode == "W7")
            {
                RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                RealTarget.transform.position = Vector3.MoveTowards(RealTarget.transform.position, Left_UpTarget.transform.position, MoveSpeed * Time.deltaTime);
                if ((RealTarget.transform.position - Left_UpTarget.transform.position).sqrMagnitude < 0.001)
                {
                    IsMoving = false;
                    Role.GetComponent<BipedIK>().enabled = false;
                }
            }
            else if (MoveMode == "W8")
            {
                RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                RealTarget.transform.position = Vector3.MoveTowards(RealTarget.transform.position, Left_DownTarget.transform.position, MoveSpeed * Time.deltaTime);
                if ((RealTarget.transform.position - Left_DownTarget.transform.position).sqrMagnitude < 0.001)
                {
                    IsMoving = false;
                    Role.GetComponent<BipedIK>().enabled = false;
                }
            }
            else if (MoveMode == "W9")
            {
                RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                RealTarget.transform.position = Vector3.MoveTowards(RealTarget.transform.position, Right_UpTarget.transform.position, MoveSpeed * Time.deltaTime);
                if ((RealTarget.transform.position - Right_UpTarget.transform.position).sqrMagnitude < 0.001)
                {
                    IsMoving = false;
                    Role.GetComponent<BipedIK>().enabled = false;
                }
            }
            else if (MoveMode == "W10")
            {
                RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                RealTarget.transform.position = Vector3.MoveTowards(RealTarget.transform.position, Right_DownTarget.transform.position, MoveSpeed * Time.deltaTime);
                if ((RealTarget.transform.position - Right_DownTarget.transform.position).sqrMagnitude < 0.001)
                {
                    IsMoving = false;
                    Role.GetComponent<BipedIK>().enabled = false;
                }
            }
            else if (MoveMode == "C1")
            {
                //
                RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                //
                RotateAngle += MoveSpeed * Time.deltaTime*5;
                CircleTarget.transform.localPosition= new Vector3(0.15f*Mathf.Sin(RotateAngle),0.15f*Mathf.Cos(RotateAngle), 0f); 
                if (Mathf.Abs(RotateAngle-3.1415926f*2)<0.05)
                {
                    //重置移动状态
                    IsMoving = false;
                    Role.GetComponent<BipedIK>().enabled = false;
                    //回归默认状态
                    CircleTarget.transform.localPosition = CenterPosition;
                    CircleRotate.transform.localEulerAngles = new Vector3(0, 0, 0);
                    RotateAngle = 0;
                }
            }
            else if (MoveMode == "C2")
            {
                //
                RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                //
                RotateAngle += MoveSpeed * Time.deltaTime * 5;
                CircleTarget.transform.localPosition = new Vector3(0.15f * Mathf.Sin(RotateAngle), 0.15f * Mathf.Cos(RotateAngle), 0f);
                if (Mathf.Abs(RotateAngle - 3.1415926f * 2) < 0.05)
                {
                    //重置移动状态
                    IsMoving = false;
                    Role.GetComponent<BipedIK>().enabled = false;
                    //回归默认状态
                    CircleTarget.transform.localPosition = CenterPosition;
                    CircleRotate.transform.localEulerAngles = new Vector3(0, 0, 0);
                    RotateAngle = 0;
                }
            }
            else if (MoveMode == "C3")
            {
                //
                RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                //
                RotateAngle += MoveSpeed * Time.deltaTime * 5;
                CircleTarget.transform.localPosition = new Vector3(0.15f * Mathf.Sin(RotateAngle), 0.15f * Mathf.Cos(RotateAngle), 0f);
                if (Mathf.Abs(RotateAngle - 3.1415926f * 2) < 0.05)
                {
                    //重置移动状态
                    IsMoving = false;
                    Role.GetComponent<BipedIK>().enabled = false;
                    //回归默认状态
                    CircleTarget.transform.localPosition = CenterPosition;
                    CircleRotate.transform.localEulerAngles = new Vector3(0, 0, 0);
                    RotateAngle = 0;
                }
            }
            else if (MoveMode == "C4")
            {
                //
                RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                //
                RotateAngle += MoveSpeed * Time.deltaTime * 5;
                CircleTarget.transform.localPosition = new Vector3(0.15f * Mathf.Sin(RotateAngle), 0.15f * Mathf.Cos(RotateAngle), 0f);
                if (Mathf.Abs(RotateAngle - 3.1415926f * 2) < 0.05)
                {
                    //重置移动状态
                    IsMoving = false;
                    Role.GetComponent<BipedIK>().enabled = false;
                    //回归默认状态
                    CircleTarget.transform.localPosition = CenterPosition;
                    CircleRotate.transform.localEulerAngles = new Vector3(0, 0, 0);
                    RotateAngle = 0;
                }
            }
            else if (MoveMode == "C5")
            {
                //
                RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                //
                RotateAngle += MoveSpeed * Time.deltaTime * 5;
                CircleTarget.transform.localPosition = new Vector3(0.15f * Mathf.Sin(RotateAngle), 0.15f * Mathf.Cos(RotateAngle), 0f);
                if (Mathf.Abs(RotateAngle - 3.1415926f * 2) < 0.05)
                {
                    //重置移动状态
                    IsMoving = false;
                    Role.GetComponent<BipedIK>().enabled = false;
                    //回归默认状态
                    CircleTarget.transform.localPosition = CenterPosition;
                    CircleRotate.transform.localEulerAngles = new Vector3(0, 0, 0);
                    RotateAngle = 0;
                }
            }
            else if (MoveMode == "C6")
            {
                //
                RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                //
                RotateAngle += MoveSpeed * Time.deltaTime * 5;
                CircleTarget.transform.localPosition = new Vector3(0.15f * Mathf.Sin(RotateAngle), 0.15f * Mathf.Cos(RotateAngle), 0f);
                if (Mathf.Abs(RotateAngle - 3.1415926f * 2) < 0.05)
                {
                    //重置移动状态
                    IsMoving = false;
                    Role.GetComponent<BipedIK>().enabled = false;
                    //回归默认状态
                    CircleTarget.transform.localPosition = CenterPosition;
                    CircleRotate.transform.localEulerAngles = new Vector3(0, 0, 0);
                    RotateAngle = 0;
                }
            }
            else if (MoveMode == "C7")
            {
                //
                RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                //
                RotateAngle += MoveSpeed * Time.deltaTime * 5;
                CircleTarget.transform.localPosition = new Vector3(0.15f * Mathf.Sin(RotateAngle), 0.15f * Mathf.Cos(RotateAngle), 0f);
                if (Mathf.Abs(RotateAngle - 3.1415926f * 2) < 0.05)
                {
                    //重置移动状态
                    IsMoving = false;
                    Role.GetComponent<BipedIK>().enabled = false;
                    //回归默认状态
                    CircleTarget.transform.localPosition = CenterPosition;
                    CircleRotate.transform.localEulerAngles = new Vector3(0, 0, 0);
                    RotateAngle = 0;
                }
            }
            else if (MoveMode == "C8")
            {
                //
                RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                //
                RotateAngle += MoveSpeed * Time.deltaTime * 5;
                CircleTarget.transform.localPosition = new Vector3(0.15f * Mathf.Sin(RotateAngle), 0.15f * Mathf.Cos(RotateAngle), 0f);
                if (Mathf.Abs(RotateAngle - 3.1415926f * 2) < 0.05)
                {
                    //重置移动状态
                    IsMoving = false;
                    Role.GetComponent<BipedIK>().enabled = false;
                    //回归默认状态
                    CircleTarget.transform.localPosition = CenterPosition;
                    CircleRotate.transform.localEulerAngles = new Vector3(0, 0, 0);
                    RotateAngle = 0;
                }
            }
            else if (MoveMode == "C9")
            {
                //
                RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                //
                RotateAngle += MoveSpeed * Time.deltaTime * 5;
                CircleTarget.transform.localPosition = new Vector3(0.15f * Mathf.Sin(RotateAngle), 0.15f * Mathf.Cos(RotateAngle), 0f);
                if (Mathf.Abs(RotateAngle - 3.1415926f * 2) < 0.05)
                {
                    //重置移动状态
                    IsMoving = false;
                    Role.GetComponent<BipedIK>().enabled = false;
                    //回归默认状态
                    CircleTarget.transform.localPosition = CenterPosition;
                    CircleRotate.transform.localEulerAngles = new Vector3(0, 0, 0);
                    RotateAngle = 0;
                }
            }
            else if (MoveMode == "C10")
            {
                //
                RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                //
                RotateAngle += MoveSpeed * Time.deltaTime * 5;
                CircleTarget.transform.localPosition = new Vector3(0.15f * Mathf.Sin(RotateAngle), 0.15f * Mathf.Cos(RotateAngle), 0f);
                if (Mathf.Abs(RotateAngle - 3.1415926f * 2) < 0.05)
                {
                    //重置移动状态
                    IsMoving = false;
                    Role.GetComponent<BipedIK>().enabled = false;
                    //回归默认状态
                    CircleTarget.transform.localPosition = CenterPosition;
                    CircleRotate.transform.localEulerAngles = new Vector3(0, 0, 0);
                    RotateAngle = 0;
                }
            }
        }
    }
    public void SetDynamicState(Text initcode)
    {
        string code= initcode.text;
        if (code == "W1")
        {
            //前
            RealTarget.transform.position = BackTarget.transform.position;
            IsMoving = true;
            MoveMode = code;
            Role.GetComponent<BipedIK>().enabled = true;
            //
            RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            Role.GetComponent<BipedIK>().solvers.rightHand.bone3.transform = FakeHand.transform;
            Role.GetComponent<BipedIK>().solvers.rightHand.target = RealTarget.transform;
            RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (code == "W2")
        {
            //后
            RealTarget.transform.position = ForwordTarget.transform.position;
            IsMoving = true;
            MoveMode = code;
            Role.GetComponent<BipedIK>().enabled = true;
            //调整手部的位置状态
            RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            Role.GetComponent<BipedIK>().solvers.rightHand.bone3.transform = FakeHand.transform;
            Role.GetComponent<BipedIK>().solvers.rightHand.target = RealTarget.transform;
            RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (code == "W3")
        {
            //左
            RealTarget.transform.position = RightTarget.transform.position;
            IsMoving = true;
            MoveMode = code;
            Role.GetComponent<BipedIK>().enabled = true;
            //调整手部的位置状态
            RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            Role.GetComponent<BipedIK>().solvers.rightHand.bone3.transform = FakeHand.transform;
            Role.GetComponent<BipedIK>().solvers.rightHand.target = RealTarget.transform;
            RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (code == "W4")
        {
            //右
            RealTarget.transform.position = LeftTarget.transform.position;
            IsMoving = true;
            MoveMode = code;
            Role.GetComponent<BipedIK>().enabled = true;
            //调整手部的位置状态
            RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            Role.GetComponent<BipedIK>().solvers.rightHand.bone3.transform = FakeHand.transform;
            Role.GetComponent<BipedIK>().solvers.rightHand.target = RealTarget.transform;
            RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (code == "W5")
        {
            //上
            RealTarget.transform.position = DownTarget.transform.position;
            IsMoving = true;
            MoveMode = code;
            Role.GetComponent<BipedIK>().enabled = true;
            //调整手部的位置状态
            RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            Role.GetComponent<BipedIK>().solvers.rightHand.bone3.transform = FakeHand.transform;
            Role.GetComponent<BipedIK>().solvers.rightHand.target = RealTarget.transform;
            RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (code == "W6")
        {
            //下
            RealTarget.transform.position = UpTarget.transform.position;
            IsMoving = true;
            MoveMode = code;
            Role.GetComponent<BipedIK>().enabled = true;
            //调整手部的位置状态
            RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            Role.GetComponent<BipedIK>().solvers.rightHand.bone3.transform = FakeHand.transform;
            Role.GetComponent<BipedIK>().solvers.rightHand.target = RealTarget.transform;
            RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (code == "W7")
        {
            //左上
            RealTarget.transform.position = Right_DownTarget.transform.position;
            IsMoving = true;
            MoveMode = code;
            Role.GetComponent<BipedIK>().enabled = true;
            //调整手部的位置状态
            RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            Role.GetComponent<BipedIK>().solvers.rightHand.bone3.transform = FakeHand.transform;
            Role.GetComponent<BipedIK>().solvers.rightHand.target = RealTarget.transform;
            RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (code == "W8")
        {
            //左下
            RealTarget.transform.position = Right_UpTarget.transform.position;
            IsMoving = true;
            MoveMode = code;
            Role.GetComponent<BipedIK>().enabled = true;
            //调整手部的位置状态
            RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            Role.GetComponent<BipedIK>().solvers.rightHand.bone3.transform = FakeHand.transform;
            Role.GetComponent<BipedIK>().solvers.rightHand.target = RealTarget.transform;
            RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (code == "W9")
        {
            //右上
            RealTarget.transform.position = Left_DownTarget.transform.position;
            IsMoving = true;
            MoveMode = code;
            Role.GetComponent<BipedIK>().enabled = true;
            //调整手部的位置状态
            RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            Role.GetComponent<BipedIK>().solvers.rightHand.bone3.transform = FakeHand.transform;
            Role.GetComponent<BipedIK>().solvers.rightHand.target = RealTarget.transform;
            RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (code == "W10")
        {
            //右下
            RealTarget.transform.position = Left_UpTarget.transform.position;
            IsMoving = true;
            MoveMode = code;
            Role.GetComponent<BipedIK>().enabled = true;
            //调整手部的位置状态
            RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            Role.GetComponent<BipedIK>().solvers.rightHand.bone3.transform = FakeHand.transform;
            Role.GetComponent<BipedIK>().solvers.rightHand.target = RealTarget.transform;
            RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (code == "C1")
        {
            //前转圈
            CenterPosition = CircleTarget.transform.localPosition;
            CircleTarget.transform.localPosition = CircleTarget.transform.localPosition + new Vector3(0, 0.15f, 0);
            IsMoving = true;
            MoveMode = code;
            Role.GetComponent<BipedIK>().enabled = true;
            RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            Role.GetComponent<BipedIK>().solvers.rightHand.bone3.transform = FakeHand.transform;
            Role.GetComponent<BipedIK>().solvers.rightHand.target = CircleTarget.transform;
            RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            CircleRotate.transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        else if (code == "C2")
        {
            //前转圈
            CenterPosition = CircleTarget.transform.localPosition;
            CircleTarget.transform.localPosition = CircleTarget.transform.localPosition + new Vector3(0, 0.15f, 0);
            IsMoving = true;
            MoveMode = code;
            Role.GetComponent<BipedIK>().enabled = true;
            RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            Role.GetComponent<BipedIK>().solvers.rightHand.bone3.transform = FakeHand.transform;
            Role.GetComponent<BipedIK>().solvers.rightHand.target = CircleTarget.transform;
            RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            //配置旋转方向
            CircleRotate.transform.localEulerAngles = new Vector3(0, 180, 180);
        }
        else if (code == "C3")
        {
            //前转圈
            CenterPosition = CircleTarget.transform.localPosition;
            CircleTarget.transform.localPosition = CircleTarget.transform.localPosition + new Vector3(0, 0.15f, 0);
            IsMoving = true;
            MoveMode = code;
            Role.GetComponent<BipedIK>().enabled = true;
            RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            Role.GetComponent<BipedIK>().solvers.rightHand.bone3.transform = FakeHand.transform;
            Role.GetComponent<BipedIK>().solvers.rightHand.target = CircleTarget.transform;
            RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            CircleRotate.transform.localEulerAngles = new Vector3(0, -90, -90);
        }
        else if (code == "C4")
        {
            //前转圈
            CenterPosition = CircleTarget.transform.localPosition;
            CircleTarget.transform.localPosition = CircleTarget.transform.localPosition + new Vector3(0, 0.15f, 0);
            IsMoving = true;
            MoveMode = code;
            Role.GetComponent<BipedIK>().enabled = true;
            RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            Role.GetComponent<BipedIK>().solvers.rightHand.bone3.transform = FakeHand.transform;
            Role.GetComponent<BipedIK>().solvers.rightHand.target = CircleTarget.transform;
            RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            CircleRotate.transform.localEulerAngles = new Vector3(0, 90, 90);
        }
        else if (code == "C5")
        {
            //前转圈
            CenterPosition = CircleTarget.transform.localPosition;
            CircleTarget.transform.localPosition = CircleTarget.transform.localPosition + new Vector3(0, 0.15f, 0);
            IsMoving = true;
            MoveMode = code;
            Role.GetComponent<BipedIK>().enabled = true;
            RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            Role.GetComponent<BipedIK>().solvers.rightHand.bone3.transform = FakeHand.transform;
            Role.GetComponent<BipedIK>().solvers.rightHand.target = CircleTarget.transform;
            RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            CircleRotate.transform.localEulerAngles = new Vector3(-90, -90, 0);
        }
        else if (code == "C6")
        {
            //前转圈
            CenterPosition = CircleTarget.transform.localPosition;
            CircleTarget.transform.localPosition = CircleTarget.transform.localPosition + new Vector3(0, 0.15f, 0);
            IsMoving = true;
            MoveMode = code;
            Role.GetComponent<BipedIK>().enabled = true;
            RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            Role.GetComponent<BipedIK>().solvers.rightHand.bone3.transform = FakeHand.transform;
            Role.GetComponent<BipedIK>().solvers.rightHand.target = CircleTarget.transform;
            RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            CircleRotate.transform.localEulerAngles = new Vector3(90, -90, 0);
        }
        else if (code == "C7")
        {
            //前转圈
            CenterPosition = CircleTarget.transform.localPosition;
            CircleTarget.transform.localPosition = CircleTarget.transform.localPosition + new Vector3(0, 0.15f, 0);
            IsMoving = true;
            MoveMode = code;
            Role.GetComponent<BipedIK>().enabled = true;
            RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            Role.GetComponent<BipedIK>().solvers.rightHand.bone3.transform = FakeHand.transform;
            Role.GetComponent<BipedIK>().solvers.rightHand.target = CircleTarget.transform;
            RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            CircleRotate.transform.localEulerAngles = new Vector3(-45, -45, -45);
        }
        else if (code == "C8")
        {
            //前转圈
            CenterPosition = CircleTarget.transform.localPosition;
            CircleTarget.transform.localPosition = CircleTarget.transform.localPosition + new Vector3(0, 0.15f, 0);
            IsMoving = true;
            MoveMode = code;
            Role.GetComponent<BipedIK>().enabled = true;
            RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            Role.GetComponent<BipedIK>().solvers.rightHand.bone3.transform = FakeHand.transform;
            Role.GetComponent<BipedIK>().solvers.rightHand.target = CircleTarget.transform;
            RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            CircleRotate.transform.localEulerAngles = new Vector3(45, -45, 45);
        }
        else if (code == "C9")
        {
            //前转圈
            CenterPosition = CircleTarget.transform.localPosition;
            CircleTarget.transform.localPosition = CircleTarget.transform.localPosition + new Vector3(0, 0.15f, 0);
            IsMoving = true;
            MoveMode = code;
            Role.GetComponent<BipedIK>().enabled = true;
            RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            Role.GetComponent<BipedIK>().solvers.rightHand.bone3.transform = FakeHand.transform;
            Role.GetComponent<BipedIK>().solvers.rightHand.target = CircleTarget.transform;
            RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            CircleRotate.transform.localEulerAngles = new Vector3(-45, 45, -45);
        }
        else if (code == "C10")
        {
            //前转圈
            CenterPosition = CircleTarget.transform.localPosition;
            CircleTarget.transform.localPosition = CircleTarget.transform.localPosition + new Vector3(0, 0.15f, 0);
            IsMoving = true;
            MoveMode = code;
            Role.GetComponent<BipedIK>().enabled = true;
            RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            Role.GetComponent<BipedIK>().solvers.rightHand.bone3.transform = FakeHand.transform;
            Role.GetComponent<BipedIK>().solvers.rightHand.target = CircleTarget.transform;
            RealHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            CircleRotate.transform.localEulerAngles = new Vector3(45,45, 45);
        }
        else Debug.Log("无效代码");
    }
}
