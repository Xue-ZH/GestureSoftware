using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;
using Leap;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;
using UnityEngine.UI;


public class JHandGestureCode : MonoBehaviour
{
    public InputField tx1;
    public InputField tx1s;
    public InputField tx1save;
    public InputField tx2;
    public InputField tx2s;
    public InputField tx21;
    public InputField tx22;
    public InputField tx2save;
    public InputField tx3;
    public InputField txstaticsingle;
    public InputField txstaticdouble;
    public Text timetext;

    string handres3;
    string handres4;
    string handres5;
    string handres6;
    string staticsingle;
    string staticdouble;
    private Frame frame;
    LeapProvider provider; //为获取当前的Provider做准备

    [Tooltip("Velocity (m/s) move toward ")]
    const float smallestVelocity = 0.1f;
    [Tooltip("Velocity (m/s) move toward ")]
    protected float deltaVelocity = 0.05f;// deltaVelocity = 0.000001f

    [Tooltip("Delta degree to check 2 vectors same direction")]//三角度检查2个向量的方向相同
    protected float handForwardDegree = 45f;
    //string handWave = "W0";
    string handres0 = null;
    string handres1 = null;
    string handsTouch = "000";

    //画圈需要
    public int point = 6;
    // 画圆的精度差值，值越低要求画的越圆
    public float num = 100f;
    CODEUNIT codeStart = new CODEUNIT();
    CODEUNIT codeEnd = new CODEUNIT();
    CODEUNIT codeRefer = new CODEUNIT();

    //右手动态手势相关参数
    string handWave = "W0";
    float beginTimer = 0;
    float betweenTimer = 0;
    Vector3 beginPos;
    Vector3 endPos;
    Vector3 betweenPos;
    List<float> posFloat;
    List<Vector3> posVector3;
    int maxIndex = 0;
    int i = 0;
    bool isBool = false;
    float radius = 0f;
    float TimeData = 0;
    float DynamicStart_Time = 0;
    bool DynamicFirstIn = false;

    //左手动态手势相关参数
    string LhandWave = "W0";
    float LbeginTimer = 0;
    float LbetweenTimer = 0;
    Vector3 LbeginPos;
    Vector3 LendPos;
    Vector3 LbetweenPos;
    List<float> LposFloat;
    List<Vector3> LposVector3;
    int LmaxIndex = 0;
    int Li = 0;
    bool LisBool = false;
    float Lradius = 0f;
    float LDynamicStart_Time = 0;
    bool LDynamicFirstIn = false;

    CODEUNIT LcodeStart = new CODEUNIT();
    CODEUNIT LcodeEnd = new CODEUNIT();
    CODEUNIT LcodeRefer = new CODEUNIT();

    public string testeename;

    Hand LeftHand;
    Hand RightHand;
    bool HaveLeftHand = false;
    bool HaveRightHand = false;

    public bool isStartCountDown = false;

    public class CODEUNIT //单手静态
    {
        public char[] fingerTouch = new char[5] { 'T', '0', '0', '0', '0' };
        public char[] knuckleCode = new char[11] { 'F', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0' };
        public char[] abductionCode = new char[3] { 'A', '0', '0' };
        public char[] wristCode = new char[3] { 'W', '0', '0' };
        public char[] orientCode = new char[3] { 'O', '0', '0' };
        public string lrHandState = "L";

        public void Clear()
        {
            fingerTouch[0] = 'T';
            knuckleCode[0] = 'F';
            abductionCode[0] = 'A';
            wristCode[0] = 'W';
            orientCode[0] = 'O';
            lrHandState = "L";
            for (int i = 1; i < 5; i++)
            {
                fingerTouch[i] = '0';
            }
            for (int i = 1; i < 11; i++)
            {
                knuckleCode[i] = '0';
            }
            for (int i = 1; i < 3; i++)
            {
                abductionCode[i] = '0';
                wristCode[i] = '0';
                orientCode[i] = '0';
            }

        }

    }

    public int Min(float[] num, int n) //返回最小索引序号
    {

        float a = num[0];
        int b = 0;
        for (int i = 0; i < n; i++)
        {
            if (num[i] < a)
            {

                a = num[i];
                b = i;
            }
        }

        return b + 1;

    }

    public CODEUNIT SingleHandCode(Hand handA)
    {
        CODEUNIT code1 = new CODEUNIT();
        //指尖接触状态
        float disTI = (handA.GetThumb().TipPosition.ToVector3() - handA.GetIndex().TipPosition.ToVector3()).magnitude;
        float disTM = (handA.GetThumb().TipPosition.ToVector3() - handA.GetMiddle().TipPosition.ToVector3()).magnitude;
        float disTR = (handA.GetThumb().TipPosition.ToVector3() - handA.GetRing().TipPosition.ToVector3()).magnitude;
        float disTP = (handA.GetThumb().TipPosition.ToVector3() - handA.GetPinky().TipPosition.ToVector3()).magnitude;
        //Debug.Log(disTI);
        if (disTI < 0.03f)
        {
            code1.fingerTouch[1] = '1';
        }
        if (disTM < 0.03f)
        {
            code1.fingerTouch[2] = '1';
        }
        if (disTR < 0.03f)
        {
            code1.fingerTouch[3] = '1';

        }
        if (disTP < 0.03f)
        {
            code1.fingerTouch[4] = '1';
        }
        if (code1.fingerTouch[1] != '1' && code1.fingerTouch[2] != '1' && code1.fingerTouch[3] != '1' && code1.fingerTouch[4] != '1')
        {
            code1.fingerTouch[0] = '0';
            code1.fingerTouch[1] = '0';
            code1.fingerTouch[2] = '0';
            code1.fingerTouch[3] = '0';
            code1.fingerTouch[4] = '0';
        }
        else
        {
            if (code1.fingerTouch[1] != '1') code1.fingerTouch[1] = '2';
            if (code1.fingerTouch[2] != '1') code1.fingerTouch[2] = '2';
            if (code1.fingerTouch[3] != '1') code1.fingerTouch[3] = '2';
            if (code1.fingerTouch[4] != '1') code1.fingerTouch[4] = '2';
        }

            //关节弯曲状态(向量关节夹角)
            float[] angle = new float[10];
        code1.knuckleCode[0] = 'F';
        Vector3 vt1 = handA.GetThumb().Bone(Bone.BoneType.TYPE_PROXIMAL).Direction.ToVector3();
        Vector3 vt2 = handA.GetThumb().Bone(Bone.BoneType.TYPE_INTERMEDIATE).Direction.ToVector3();
        Vector3 vt3 = handA.GetThumb().Bone(Bone.BoneType.TYPE_DISTAL).Direction.ToVector3();
        angle[1] = Vector3.Angle(vt2, vt3);
        angle[0] = Vector3.Angle(vt1, vt2);
        Vector3 vi1 = handA.GetIndex().Bone(Bone.BoneType.TYPE_METACARPAL).Direction.ToVector3();
        Vector3 vi2 = handA.GetIndex().Bone(Bone.BoneType.TYPE_PROXIMAL).Direction.ToVector3();
        Vector3 vi3 = handA.GetIndex().Bone(Bone.BoneType.TYPE_INTERMEDIATE).Direction.ToVector3();
        angle[3] = Vector3.Angle(vi2, vi3);
        angle[2] = Vector3.Angle(vi1, vi2);
        Vector3 vm1 = handA.GetMiddle().Bone(Bone.BoneType.TYPE_METACARPAL).Direction.ToVector3();
        Vector3 vm2 = handA.GetMiddle().Bone(Bone.BoneType.TYPE_PROXIMAL).Direction.ToVector3();
        Vector3 vm3 = handA.GetMiddle().Bone(Bone.BoneType.TYPE_INTERMEDIATE).Direction.ToVector3();
        angle[5] = Vector3.Angle(vm2, vm3);
        angle[4] = Vector3.Angle(vm1, vm2);
        Vector3 vr1 = handA.GetRing().Bone(Bone.BoneType.TYPE_METACARPAL).Direction.ToVector3();
        Vector3 vr2 = handA.GetRing().Bone(Bone.BoneType.TYPE_PROXIMAL).Direction.ToVector3();
        Vector3 vr3 = handA.GetRing().Bone(Bone.BoneType.TYPE_INTERMEDIATE).Direction.ToVector3();
        angle[7] = Vector3.Angle(vr2, vr3);
        angle[6] = Vector3.Angle(vr1, vr2);
        Vector3 vp1 = handA.GetPinky().Bone(Bone.BoneType.TYPE_METACARPAL).Direction.ToVector3();
        Vector3 vp2 = handA.GetPinky().Bone(Bone.BoneType.TYPE_PROXIMAL).Direction.ToVector3();
        Vector3 vp3 = handA.GetPinky().Bone(Bone.BoneType.TYPE_INTERMEDIATE).Direction.ToVector3();
        angle[9] = Vector3.Angle(vp2, vp3);
        angle[8] = Vector3.Angle(vp1, vp2);


        if (angle[1] <= 22.2)//0-29.4
        {
            code1.knuckleCode[1] = '1';
        }
        else
        {
            code1.knuckleCode[1] = '2';
        }
        if (angle[0] <= 21.4)
        {
            code1.knuckleCode[2] = '1';
        }
        else
        {
            code1.knuckleCode[2] = '2';
        }


        for (int i = 2; i <= 9; i++)
        {
            if (i % 2 != 0 && angle[i] < 30.1) //四指PIP
            {
                code1.knuckleCode[i + 1] = '1';
            }
            if (i % 2 != 0 && angle[i] >= 30.1 && angle[i] < 65.1)
            {
                code1.knuckleCode[i + 1] = '2';
            }
            if (i % 2 != 0 && angle[i] >= 65.1)
            {
                code1.knuckleCode[i + 1] = '3';
            }
            if (i % 2 == 0 && angle[i] < 23.1)  //四指MCP
            {
                code1.knuckleCode[i + 1] = '1';
            }
            if (i % 2 == 0 && angle[i] >= 23.1 && angle[i] < 60.5)
            {
                code1.knuckleCode[i + 1] = '2';
            }
            if (i % 2 == 0 && angle[i] >= 60.5)
            {
                code1.knuckleCode[i + 1] = '3';
            }

        }


        //手指外展状态
        float[] angleAb = new float[2];
        code1.abductionCode[0] = 'A';
        if (true) //拇指外展
        {
            angleAb[0] = Vector3.Angle(vt2, vm1);
            if (angleAb[0] < 28.1f)
            {
                code1.abductionCode[1] = '1';
            }
            else
            {
                code1.abductionCode[1] = '2';
            }

        }
        else
        {
            code1.abductionCode[1] = '2';
        }

        //四指外展
        if (code1.knuckleCode[2] == '1' && code1.knuckleCode[4] == '1' && code1.knuckleCode[6] == '1' && code1.knuckleCode[8] == '1') //四指伸直
        {
            angleAb[1] = (Vector3.Angle(vi2, vm2) + Vector3.Angle(vm2, vr2) + Vector3.Angle(vr2, vp2)) / 3;
        }

        if (code1.knuckleCode[2] == '2' && code1.knuckleCode[4] == '1' && code1.knuckleCode[6] == '1' && code1.knuckleCode[8] == '1') //1指弯曲
        {
            angleAb[1] = (Vector3.Angle(vm2, vr2) + Vector3.Angle(vr2, vp2)) / 2;
        }
        if (code1.knuckleCode[2] == '1' && code1.knuckleCode[4] == '2' && code1.knuckleCode[6] == '1' && code1.knuckleCode[8] == '1')
        {
            angleAb[1] = Vector3.Angle(vr2, vp2);
        }
        if (code1.knuckleCode[2] == '1' && code1.knuckleCode[4] == '1' && code1.knuckleCode[6] == '2' && code1.knuckleCode[8] == '1')
        {
            angleAb[1] = Vector3.Angle(vi2, vm2);
        }
        if (code1.knuckleCode[2] == '1' && code1.knuckleCode[4] == '1' && code1.knuckleCode[6] == '1' && code1.knuckleCode[8] == '2')
        {
            angleAb[1] = (Vector3.Angle(vi2, vm2) + Vector3.Angle(vm2, vr2)) / 2;
        }
        if (code1.knuckleCode[2] == '2' && code1.knuckleCode[4] == '2' && code1.knuckleCode[6] == '1' && code1.knuckleCode[8] == '1') //2指弯曲
        {
            angleAb[1] = Vector3.Angle(vr2, vp2);
        }
        if (code1.knuckleCode[2] == '1' && code1.knuckleCode[4] == '1' && code1.knuckleCode[6] == '2' && code1.knuckleCode[8] == '2')
        {
            angleAb[1] = Vector3.Angle(vi2, vm2);
        }
        if (angleAb[1] < 24.6) //判断四指外展状态
        {
            code1.abductionCode[2] = '1';
        }
        else
        {
            code1.abductionCode[2] = '2';
        }

        //手腕状态
        code1.wristCode[0] = 'W';
        Quaternion normalizevector = handA.Rotation.ToQuaternion();//四元数 绕轴旋转
        normalizevector.w = -normalizevector.w;
        Vector3 va = normalizevector * handA.Arm.Direction.ToVector3();
        Vector3 vh = normalizevector * handA.Direction.ToVector3();
        Vector3 vp = normalizevector * handA.PalmNormal.ToVector3();

        float ahAngle1 = Vector3.Angle(new Vector3(0, va.y, va.z), new Vector3(0, vh.y, vh.z));
        if (va.normalized.y < 0)
        {
            if (ahAngle1 > 32.6)
            {
                code1.wristCode[1] = '1';
            }
            else
                code1.wristCode[1] = '2';
        }
        else
        {
            if (ahAngle1 < 30.1)
            {
                code1.wristCode[1] = '2';
            }
            else
            {
                code1.wristCode[1] = '3';
            }
        }

        // Debug.Log(vp);
        // Debug.Log(handA.PalmNormal.ToVector3());
        float ahAngle2 = Vector3.Angle(new Vector3(va.x, 0, va.z), new Vector3(vh.x, 0, vh.z));
        if (va.normalized.x < 0)
        {
            if (ahAngle2 > 5.4)
            {
                code1.wristCode[2] = '2';
            }
            else
            {
                code1.wristCode[2] = '1';
            }

        }
        else
        {
            code1.wristCode[2] = '1';
        }

        //手部空间状态编码100左，010上，001前
        float[] angp = new float[6];
        float[] angh = new float[6];
        Vector3 vpn = Vector3.Normalize(handA.PalmNormal.ToVector3());
        Vector3 vhn = Vector3.Normalize(handA.Direction.ToVector3());
        Vector3 vforw = new Vector3(0, 0, 1);
        Vector3 vback = new Vector3(0, 0, -1);
        Vector3 vleft = new Vector3(-1, 0, 0);
        Vector3 vright = new Vector3(1, 0, 0);
        Vector3 vup = new Vector3(0, 1, 0);
        Vector3 vdown = new Vector3(0, -1, 0);
        angp[0] = Vector3.Angle(vpn, vforw);
        angp[1] = Vector3.Angle(vpn, vback);
        angp[2] = Vector3.Angle(vpn, vleft);
        angp[3] = Vector3.Angle(vpn, vright);
        angp[4] = Vector3.Angle(vpn, vup);
        angp[5] = Vector3.Angle(vpn, vdown);

        angh[0] = Vector3.Angle(vhn, vforw);
        angh[1] = Vector3.Angle(vhn, vback);
        angh[2] = Vector3.Angle(vhn, vleft);
        angh[3] = Vector3.Angle(vhn, vright);
        angh[4] = Vector3.Angle(vhn, vup);
        angh[5] = Vector3.Angle(vhn, vdown);
        int num1 = Min(angp, 6);
        code1.orientCode[1] = char.Parse(num1.ToString());
        int num2 = Min(angh, 6);
        code1.orientCode[2] = char.Parse(num2.ToString());


        //左右手编码
        if (handA.IsLeft)
        {
            code1.lrHandState = "L";
        }
        else
        {
            code1.lrHandState = "R";
        }

        return code1;

    }

    List<string> handcodes = new List<string>();
    List<string> doublecodes = new List<string>();
    List<string> dynamiccodes = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        provider = FindObjectOfType<LeapProvider>() as LeapProvider; //获取当前的Provider
        //画圈
        posFloat = new List<float>();
        posVector3 = new List<Vector3>();

        LposFloat = new List<float>();
        LposVector3 = new List<Vector3>();


    }

    public string GetString(CODEUNIT code)
    {
        if (code.fingerTouch[0] == '0')
        {
            string str1 = new string(code.knuckleCode);
            string str3 = new string(code.abductionCode);
            string str4 = new string(code.wristCode);
            string str5 = new string(code.orientCode);
            string str6 = code.lrHandState;
            string handres = str1 + str3 + str4 + str5 + str6;
            return handres;

        }
        else
        {
            string str2 = new string(code.fingerTouch);
            string str1 = new string(code.knuckleCode);
            string str3 = new string(code.abductionCode);
            string str4 = new string(code.wristCode);
            string str5 = new string(code.orientCode);
            string str6 = code.lrHandState;
            string handres = str2 + str1 + str3 + str4 + str5 + str6;
            return handres;
        }
    }

    string[] hand_codes = new string[10000];
    int number = 0;
    string c;
    int one, two;

    public void BeginCountDown()
    {
        isStartCountDown = true;
    }

    public void ResetCountDown()
    {
        TimeData = 0;
        isStartCountDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        timetext.text = TimeData.ToString();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isStartCountDown = true;
        }

        if (isStartCountDown == false)
        {
            return;
        }


        handsTouch = null;
        TimeData += Time.deltaTime;
        if (TimeData > 6)
        {
            timetext.text = "停止识别";
            int max1 = 0;
            int num1;
            for (int i = 0; i < number; i++)
            {
                num1 = 1;
                for (int j = 0; j < number; j++)
                {
                    if (hand_codes[j] == hand_codes[i])
                    {
                        num1++;
                    }
                    if (max1 < num1)
                    {
                        max1 = num1;
                        c = hand_codes[i];
                    }
                }
                tx1.text = c;
            }
        }
        if (TimeData > 0 && TimeData <= 6)
        {
            timetext.text = TimeData.ToString();
        }

        if (TimeData > 0)
        {
            frame = provider.CurrentFrame;
            //单手code
            if (frame.Hands.Count == 1)
            {
                CODEUNIT codeh = SingleHandCode(frame.Hands[0]);
                staticsingle = GetString(codeh);
                one++;
                if (staticsingle != null)
                {
                    txstaticsingle.text = staticsingle;
                }

            }

            //双手code
            if (frame.Hands.Count == 2)
            {
                CODEUNIT codel = new CODEUNIT();
                CODEUNIT coder = new CODEUNIT();
                two++;
                if (frame.Hands[0].IsLeft && frame.Hands[1].IsRight)
                {
                    codel = SingleHandCode(frame.Hands[0]);
                    coder = SingleHandCode(frame.Hands[1]);

                }
                if (frame.Hands[0].IsRight && frame.Hands[1].IsLeft)
                {
                    codel = SingleHandCode(frame.Hands[1]);
                    coder = SingleHandCode(frame.Hands[0]);

                }

                if (frame.Hands[0].IsLeft)
                {

                    //左手手心接触
                    float disPalmT = (frame.Hands[0].PalmPosition.ToVector3() - frame.Hands[1].GetThumb().TipPosition.ToVector3()).magnitude;
                    float disPalmI = (frame.Hands[0].PalmPosition.ToVector3() - frame.Hands[1].GetIndex().TipPosition.ToVector3()).magnitude;
                    float disPalmM = (frame.Hands[0].PalmPosition.ToVector3() - frame.Hands[1].GetMiddle().TipPosition.ToVector3()).magnitude;
                    float disPalmR = (frame.Hands[0].PalmPosition.ToVector3() - frame.Hands[1].GetRing().TipPosition.ToVector3()).magnitude;
                    float disPalmP = (frame.Hands[0].PalmPosition.ToVector3() - frame.Hands[1].GetPinky().TipPosition.ToVector3()).magnitude;
                    float disPalmPalm = (frame.Hands[0].PalmPosition.ToVector3() - frame.Hands[1].PalmPosition.ToVector3()).magnitude;

                    if (disPalmT < 0.05f)
                    {
                        handsTouch = "H13";
                    }
                    Debug.Log(disPalmT);
                    if (disPalmI < 0.05f || disPalmM < 0.05f || disPalmR < 0.05f || disPalmP < 0.05f)
                    {
                        handsTouch = "H12";
                    }
                    if (disPalmPalm < 0.05f)
                    {
                        handsTouch = "H11";
                    }

                    //左手四指接触
                    //食指
                    float disIndexT = (frame.Hands[0].GetIndex().TipPosition.ToVector3() - frame.Hands[1].GetThumb().TipPosition.ToVector3()).magnitude;
                    float disIndexI = (frame.Hands[0].GetIndex().TipPosition.ToVector3() - frame.Hands[1].GetIndex().TipPosition.ToVector3()).magnitude;
                    float disIndexM = (frame.Hands[0].GetIndex().TipPosition.ToVector3() - frame.Hands[1].GetMiddle().TipPosition.ToVector3()).magnitude;
                    float disIndexR = (frame.Hands[0].GetIndex().TipPosition.ToVector3() - frame.Hands[1].GetRing().TipPosition.ToVector3()).magnitude;
                    float disIndexP = (frame.Hands[0].GetIndex().TipPosition.ToVector3() - frame.Hands[1].GetPinky().TipPosition.ToVector3()).magnitude;
                    float disIndexPalm = (frame.Hands[0].GetIndex().TipPosition.ToVector3() - frame.Hands[1].PalmPosition.ToVector3()).magnitude;

                    //中指
                    float disMiddleT = (frame.Hands[0].GetMiddle().TipPosition.ToVector3() - frame.Hands[1].GetThumb().TipPosition.ToVector3()).magnitude;
                    float disMiddleI = (frame.Hands[0].GetMiddle().TipPosition.ToVector3() - frame.Hands[1].GetIndex().TipPosition.ToVector3()).magnitude;
                    float disMiddleM = (frame.Hands[0].GetMiddle().TipPosition.ToVector3() - frame.Hands[1].GetMiddle().TipPosition.ToVector3()).magnitude;
                    float disMiddleR = (frame.Hands[0].GetMiddle().TipPosition.ToVector3() - frame.Hands[1].GetRing().TipPosition.ToVector3()).magnitude;
                    float disMiddleP = (frame.Hands[0].GetMiddle().TipPosition.ToVector3() - frame.Hands[1].GetPinky().TipPosition.ToVector3()).magnitude;
                    float disMiddlePalm = (frame.Hands[0].GetMiddle().TipPosition.ToVector3() - frame.Hands[1].PalmPosition.ToVector3()).magnitude;

                    //无名指
                    float disRingT = (frame.Hands[0].GetRing().TipPosition.ToVector3() - frame.Hands[1].GetThumb().TipPosition.ToVector3()).magnitude;
                    float disRingI = (frame.Hands[0].GetRing().TipPosition.ToVector3() - frame.Hands[1].GetIndex().TipPosition.ToVector3()).magnitude;
                    float disRingM = (frame.Hands[0].GetRing().TipPosition.ToVector3() - frame.Hands[1].GetMiddle().TipPosition.ToVector3()).magnitude;
                    float disRingR = (frame.Hands[0].GetRing().TipPosition.ToVector3() - frame.Hands[1].GetRing().TipPosition.ToVector3()).magnitude;
                    float disRingP = (frame.Hands[0].GetRing().TipPosition.ToVector3() - frame.Hands[1].GetPinky().TipPosition.ToVector3()).magnitude;
                    float disRingPalm = (frame.Hands[0].GetRing().TipPosition.ToVector3() - frame.Hands[1].PalmPosition.ToVector3()).magnitude;

                    //小指
                    float disPinkyT = (frame.Hands[0].GetPinky().TipPosition.ToVector3() - frame.Hands[1].GetThumb().TipPosition.ToVector3()).magnitude;
                    float disPinkyI = (frame.Hands[0].GetPinky().TipPosition.ToVector3() - frame.Hands[1].GetIndex().TipPosition.ToVector3()).magnitude;
                    float disPinkyM = (frame.Hands[0].GetPinky().TipPosition.ToVector3() - frame.Hands[1].GetMiddle().TipPosition.ToVector3()).magnitude;
                    float disPinkyR = (frame.Hands[0].GetPinky().TipPosition.ToVector3() - frame.Hands[1].GetRing().TipPosition.ToVector3()).magnitude;
                    float disPinkyP = (frame.Hands[0].GetPinky().TipPosition.ToVector3() - frame.Hands[1].GetPinky().TipPosition.ToVector3()).magnitude;
                    float disPinkyPalm = (frame.Hands[0].GetPinky().TipPosition.ToVector3() - frame.Hands[1].PalmPosition.ToVector3()).magnitude;

                    if (disIndexT < 0.05f || disMiddleT < 0.05f || disRingT < 0.05f || disPinkyT < 0.05f)
                    {
                        handsTouch = "H23";
                    }
                    if (disIndexPalm < 0.05f || disMiddlePalm < 0.05f || disRingPalm < 0.05f || disPinkyPalm < 0.05f)
                    {
                        handsTouch = "H21";
                    }
                    if (disIndexI < 0.05f || disIndexM < 0.05f || disIndexR < 0.05f || disIndexP < 0.05f || disMiddleI < 0.05f || disMiddleM < 0.05f || disMiddleR < 0.05f || disMiddleP < 0.05f || disRingI < 0.05f || disRingM < 0.05f || disRingR < 0.05f || disRingP < 0.05f || disPinkyI < 0.05f || disPinkyM < 0.05f || disPinkyR < 0.05f || disPinkyP < 0.05f)
                    {
                        handsTouch = "H22";
                    }


                    //左手拇指接触

                    float disTPalm = (frame.Hands[0].GetThumb().TipPosition.ToVector3() - frame.Hands[1].PalmPosition.ToVector3()).magnitude;
                    float disTThumb = (frame.Hands[0].GetThumb().TipPosition.ToVector3() - frame.Hands[1].GetThumb().TipPosition.ToVector3()).magnitude;
                    float disTIndex = (frame.Hands[0].GetThumb().TipPosition.ToVector3() - frame.Hands[1].GetIndex().TipPosition.ToVector3()).magnitude;
                    float disTMiddle = (frame.Hands[0].GetThumb().TipPosition.ToVector3() - frame.Hands[1].GetMiddle().TipPosition.ToVector3()).magnitude;
                    float disTRing = (frame.Hands[0].GetThumb().TipPosition.ToVector3() - frame.Hands[1].GetRing().TipPosition.ToVector3()).magnitude;
                    float disTPinky = (frame.Hands[0].GetThumb().TipPosition.ToVector3() - frame.Hands[1].GetPinky().TipPosition.ToVector3()).magnitude;

                    if (disTPalm < 0.05f)
                    {
                        handsTouch = "H31";
                    }
                    if (disTThumb < 0.05f)
                    {
                        handsTouch = "H33";
                    }
                    if (disTIndex < 0.05f || disTMiddle < 0.05f || disTRing < 0.05f || disTPinky < 0.05f)
                    {
                        handsTouch = "H32";
                    }
                }
                if (frame.Hands[1].IsLeft)
                {
                    //左手手心接触
                    float disPalmT = (frame.Hands[1].PalmPosition.ToVector3() - frame.Hands[0].GetThumb().TipPosition.ToVector3()).magnitude;
                    float disPalmI = (frame.Hands[1].PalmPosition.ToVector3() - frame.Hands[0].GetIndex().TipPosition.ToVector3()).magnitude;
                    float disPalmM = (frame.Hands[1].PalmPosition.ToVector3() - frame.Hands[0].GetMiddle().TipPosition.ToVector3()).magnitude;
                    float disPalmR = (frame.Hands[1].PalmPosition.ToVector3() - frame.Hands[0].GetRing().TipPosition.ToVector3()).magnitude;
                    float disPalmP = (frame.Hands[1].PalmPosition.ToVector3() - frame.Hands[0].GetPinky().TipPosition.ToVector3()).magnitude;
                    float disPalmPalm = (frame.Hands[1].PalmPosition.ToVector3() - frame.Hands[0].PalmPosition.ToVector3()).magnitude;

                    if (disPalmT < 0.05f)
                    {
                        handsTouch = "H13";
                    }

                    if (disPalmI < 0.05f || disPalmM < 0.05f || disPalmR < 0.05f || disPalmP < 0.05f)
                    {
                        handsTouch = "H12";
                    }
                    if (disPalmPalm < 0.05f)
                    {
                        handsTouch = "H11";
                    }


                    //左手四指接触
                    //食指
                    float disIndexT = (frame.Hands[1].GetIndex().TipPosition.ToVector3() - frame.Hands[0].GetThumb().TipPosition.ToVector3()).magnitude;
                    float disIndexI = (frame.Hands[1].GetIndex().TipPosition.ToVector3() - frame.Hands[0].GetIndex().TipPosition.ToVector3()).magnitude;
                    float disIndexM = (frame.Hands[1].GetIndex().TipPosition.ToVector3() - frame.Hands[0].GetMiddle().TipPosition.ToVector3()).magnitude;
                    float disIndexR = (frame.Hands[1].GetIndex().TipPosition.ToVector3() - frame.Hands[0].GetRing().TipPosition.ToVector3()).magnitude;
                    float disIndexP = (frame.Hands[1].GetIndex().TipPosition.ToVector3() - frame.Hands[0].GetPinky().TipPosition.ToVector3()).magnitude;
                    float disIndexPalm = (frame.Hands[1].GetIndex().TipPosition.ToVector3() - frame.Hands[0].PalmPosition.ToVector3()).magnitude;

                    //中指
                    float disMiddleT = (frame.Hands[1].GetMiddle().TipPosition.ToVector3() - frame.Hands[0].GetThumb().TipPosition.ToVector3()).magnitude;
                    float disMiddleI = (frame.Hands[1].GetMiddle().TipPosition.ToVector3() - frame.Hands[0].GetIndex().TipPosition.ToVector3()).magnitude;
                    float disMiddleM = (frame.Hands[1].GetMiddle().TipPosition.ToVector3() - frame.Hands[0].GetMiddle().TipPosition.ToVector3()).magnitude;
                    float disMiddleR = (frame.Hands[1].GetMiddle().TipPosition.ToVector3() - frame.Hands[0].GetRing().TipPosition.ToVector3()).magnitude;
                    float disMiddleP = (frame.Hands[1].GetMiddle().TipPosition.ToVector3() - frame.Hands[0].GetPinky().TipPosition.ToVector3()).magnitude;
                    float disMiddlePalm = (frame.Hands[1].GetMiddle().TipPosition.ToVector3() - frame.Hands[0].PalmPosition.ToVector3()).magnitude;

                    //无名指
                    float disRingT = (frame.Hands[1].GetRing().TipPosition.ToVector3() - frame.Hands[0].GetThumb().TipPosition.ToVector3()).magnitude;
                    float disRingI = (frame.Hands[1].GetRing().TipPosition.ToVector3() - frame.Hands[0].GetIndex().TipPosition.ToVector3()).magnitude;
                    float disRingM = (frame.Hands[1].GetRing().TipPosition.ToVector3() - frame.Hands[0].GetMiddle().TipPosition.ToVector3()).magnitude;
                    float disRingR = (frame.Hands[1].GetRing().TipPosition.ToVector3() - frame.Hands[0].GetRing().TipPosition.ToVector3()).magnitude;
                    float disRingP = (frame.Hands[1].GetRing().TipPosition.ToVector3() - frame.Hands[0].GetPinky().TipPosition.ToVector3()).magnitude;
                    float disRingPalm = (frame.Hands[1].GetRing().TipPosition.ToVector3() - frame.Hands[0].PalmPosition.ToVector3()).magnitude;

                    //小指
                    float disPinkyT = (frame.Hands[1].GetPinky().TipPosition.ToVector3() - frame.Hands[0].GetThumb().TipPosition.ToVector3()).magnitude;
                    float disPinkyI = (frame.Hands[1].GetPinky().TipPosition.ToVector3() - frame.Hands[0].GetIndex().TipPosition.ToVector3()).magnitude;
                    float disPinkyM = (frame.Hands[1].GetPinky().TipPosition.ToVector3() - frame.Hands[0].GetMiddle().TipPosition.ToVector3()).magnitude;
                    float disPinkyR = (frame.Hands[1].GetPinky().TipPosition.ToVector3() - frame.Hands[0].GetRing().TipPosition.ToVector3()).magnitude;
                    float disPinkyP = (frame.Hands[1].GetPinky().TipPosition.ToVector3() - frame.Hands[0].GetPinky().TipPosition.ToVector3()).magnitude;
                    float disPinkyPalm = (frame.Hands[1].GetPinky().TipPosition.ToVector3() - frame.Hands[0].PalmPosition.ToVector3()).magnitude;

                    if (disIndexT < 0.05f || disMiddleT < 0.05f || disRingT < 0.05f || disPinkyT < 0.05f)
                    {
                        handsTouch = "H23";
                    }
                    if (disIndexPalm < 0.05f || disMiddlePalm < 0.05f || disRingPalm < 0.05f || disPinkyPalm < 0.05f)
                    {
                        handsTouch = "H21";
                    }
                    if (disIndexI < 0.05f || disIndexM < 0.05f || disIndexR < 0.05f || disIndexP < 0.05f || disMiddleI < 0.05f || disMiddleM < 0.05f || disMiddleR < 0.05f || disMiddleP < 0.05f || disRingI < 0.05f || disRingM < 0.05f || disRingR < 0.05f || disRingP < 0.05f || disPinkyI < 0.05f || disPinkyM < 0.05f || disPinkyR < 0.05f || disPinkyP < 0.05f)
                    {
                        handsTouch = "H22";
                    }
                    //左手拇指接触

                    float disTPalm = (frame.Hands[1].GetThumb().TipPosition.ToVector3() - frame.Hands[0].PalmPosition.ToVector3()).magnitude;
                    float disTThumb = (frame.Hands[1].GetThumb().TipPosition.ToVector3() - frame.Hands[0].GetThumb().TipPosition.ToVector3()).magnitude;
                    float disTIndex = (frame.Hands[1].GetThumb().TipPosition.ToVector3() - frame.Hands[0].GetIndex().TipPosition.ToVector3()).magnitude;
                    float disTMiddle = (frame.Hands[1].GetThumb().TipPosition.ToVector3() - frame.Hands[0].GetMiddle().TipPosition.ToVector3()).magnitude;
                    float disTRing = (frame.Hands[1].GetThumb().TipPosition.ToVector3() - frame.Hands[0].GetRing().TipPosition.ToVector3()).magnitude;
                    float disTPinky = (frame.Hands[1].GetThumb().TipPosition.ToVector3() - frame.Hands[0].GetPinky().TipPosition.ToVector3()).magnitude;

                    if (disTPalm < 0.05f)
                    {
                        handsTouch = "H31";
                    }
                    if (disTThumb < 0.05f)
                    {
                        handsTouch = "H33";
                    }
                    if (disTIndex < 0.05f || disTMiddle < 0.05f || disTRing < 0.05f || disTPinky < 0.05f)
                    {
                        handsTouch = "H32";
                    }
                }

                handres3 = GetString(codel);
                handres4 = GetString(coder);
                string handresdb;
                if (handsTouch == null) handresdb = handres3 + "," + handres4;
                else handresdb = handres3 + "," + handres4 + "," + handsTouch;
                if (handresdb != handres1 && handresdb != null)
                {
                    txstaticdouble.text = handresdb;
                }
            }

        }


        if (TimeData > 3 && TimeData <= 6)
        {
            frame = provider.CurrentFrame;

            //单手
            if (frame.Hands.Count == 1)
            {
                CODEUNIT codeh = SingleHandCode(frame.Hands[0]);
                string handres2 = GetString(codeh);
                one++;
                if (handres2 != handres0 && handres2 != null)
                {
                    tx1.text = handres2;
                    tx1s.text = handres2;
                    tx1save.text = handres2;
                    // handcodes.Add(handres2 + "," + TimeData + "," + frame.Hands[0].PalmPosition.x.ToString() + "," + frame.Hands[0].PalmPosition.y.ToString() + "," + frame.Hands[0].PalmPosition.z.ToString() + "," + frame.Hands[0].IsLeft.ToString());
                    hand_codes[number] = handres2;
                }

            }

            //CSVs.Write(handcodes, "SingleHandData.csv");

            //双手code
            if (frame.Hands.Count == 2)
            {
                CODEUNIT codel = new CODEUNIT();
                CODEUNIT coder = new CODEUNIT();
                two++;
                if (frame.Hands[0].IsLeft && frame.Hands[1].IsRight)
                {
                    codel = SingleHandCode(frame.Hands[0]);
                    coder = SingleHandCode(frame.Hands[1]);

                }
                if (frame.Hands[0].IsRight && frame.Hands[1].IsLeft)
                {
                    codel = SingleHandCode(frame.Hands[1]);
                    coder = SingleHandCode(frame.Hands[0]);

                }

                if (frame.Hands[0].IsLeft)
                {

                    //左手手心接触
                    float disPalmT = (frame.Hands[0].PalmPosition.ToVector3() - frame.Hands[1].GetThumb().TipPosition.ToVector3()).magnitude;
                    float disPalmI = (frame.Hands[0].PalmPosition.ToVector3() - frame.Hands[1].GetIndex().TipPosition.ToVector3()).magnitude;
                    float disPalmM = (frame.Hands[0].PalmPosition.ToVector3() - frame.Hands[1].GetMiddle().TipPosition.ToVector3()).magnitude;
                    float disPalmR = (frame.Hands[0].PalmPosition.ToVector3() - frame.Hands[1].GetRing().TipPosition.ToVector3()).magnitude;
                    float disPalmP = (frame.Hands[0].PalmPosition.ToVector3() - frame.Hands[1].GetPinky().TipPosition.ToVector3()).magnitude;
                    float disPalmPalm = (frame.Hands[0].PalmPosition.ToVector3() - frame.Hands[1].PalmPosition.ToVector3()).magnitude;

                    if (disPalmT < 0.05f)
                    {
                        handsTouch = "H13";
                    }
                    Debug.Log(disPalmT);
                    if (disPalmI < 0.05f || disPalmM < 0.05f || disPalmR < 0.05f || disPalmP < 0.05f)
                    {
                        handsTouch = "H12";
                    }
                    if (disPalmPalm < 0.05f)
                    {
                        handsTouch = "H11";
                    }

                    //左手四指接触
                    //食指
                    float disIndexT = (frame.Hands[0].GetIndex().TipPosition.ToVector3() - frame.Hands[1].GetThumb().TipPosition.ToVector3()).magnitude;
                    float disIndexI = (frame.Hands[0].GetIndex().TipPosition.ToVector3() - frame.Hands[1].GetIndex().TipPosition.ToVector3()).magnitude;
                    float disIndexM = (frame.Hands[0].GetIndex().TipPosition.ToVector3() - frame.Hands[1].GetMiddle().TipPosition.ToVector3()).magnitude;
                    float disIndexR = (frame.Hands[0].GetIndex().TipPosition.ToVector3() - frame.Hands[1].GetRing().TipPosition.ToVector3()).magnitude;
                    float disIndexP = (frame.Hands[0].GetIndex().TipPosition.ToVector3() - frame.Hands[1].GetPinky().TipPosition.ToVector3()).magnitude;
                    float disIndexPalm = (frame.Hands[0].GetIndex().TipPosition.ToVector3() - frame.Hands[1].PalmPosition.ToVector3()).magnitude;

                    //中指
                    float disMiddleT = (frame.Hands[0].GetMiddle().TipPosition.ToVector3() - frame.Hands[1].GetThumb().TipPosition.ToVector3()).magnitude;
                    float disMiddleI = (frame.Hands[0].GetMiddle().TipPosition.ToVector3() - frame.Hands[1].GetIndex().TipPosition.ToVector3()).magnitude;
                    float disMiddleM = (frame.Hands[0].GetMiddle().TipPosition.ToVector3() - frame.Hands[1].GetMiddle().TipPosition.ToVector3()).magnitude;
                    float disMiddleR = (frame.Hands[0].GetMiddle().TipPosition.ToVector3() - frame.Hands[1].GetRing().TipPosition.ToVector3()).magnitude;
                    float disMiddleP = (frame.Hands[0].GetMiddle().TipPosition.ToVector3() - frame.Hands[1].GetPinky().TipPosition.ToVector3()).magnitude;
                    float disMiddlePalm = (frame.Hands[0].GetMiddle().TipPosition.ToVector3() - frame.Hands[1].PalmPosition.ToVector3()).magnitude;

                    //无名指
                    float disRingT = (frame.Hands[0].GetRing().TipPosition.ToVector3() - frame.Hands[1].GetThumb().TipPosition.ToVector3()).magnitude;
                    float disRingI = (frame.Hands[0].GetRing().TipPosition.ToVector3() - frame.Hands[1].GetIndex().TipPosition.ToVector3()).magnitude;
                    float disRingM = (frame.Hands[0].GetRing().TipPosition.ToVector3() - frame.Hands[1].GetMiddle().TipPosition.ToVector3()).magnitude;
                    float disRingR = (frame.Hands[0].GetRing().TipPosition.ToVector3() - frame.Hands[1].GetRing().TipPosition.ToVector3()).magnitude;
                    float disRingP = (frame.Hands[0].GetRing().TipPosition.ToVector3() - frame.Hands[1].GetPinky().TipPosition.ToVector3()).magnitude;
                    float disRingPalm = (frame.Hands[0].GetRing().TipPosition.ToVector3() - frame.Hands[1].PalmPosition.ToVector3()).magnitude;

                    //小指
                    float disPinkyT = (frame.Hands[0].GetPinky().TipPosition.ToVector3() - frame.Hands[1].GetThumb().TipPosition.ToVector3()).magnitude;
                    float disPinkyI = (frame.Hands[0].GetPinky().TipPosition.ToVector3() - frame.Hands[1].GetIndex().TipPosition.ToVector3()).magnitude;
                    float disPinkyM = (frame.Hands[0].GetPinky().TipPosition.ToVector3() - frame.Hands[1].GetMiddle().TipPosition.ToVector3()).magnitude;
                    float disPinkyR = (frame.Hands[0].GetPinky().TipPosition.ToVector3() - frame.Hands[1].GetRing().TipPosition.ToVector3()).magnitude;
                    float disPinkyP = (frame.Hands[0].GetPinky().TipPosition.ToVector3() - frame.Hands[1].GetPinky().TipPosition.ToVector3()).magnitude;
                    float disPinkyPalm = (frame.Hands[0].GetPinky().TipPosition.ToVector3() - frame.Hands[1].PalmPosition.ToVector3()).magnitude;

                    if (disIndexT < 0.05f || disMiddleT < 0.05f || disRingT < 0.05f || disPinkyT < 0.05f)
                    {
                        handsTouch = "H23";
                    }
                    if (disIndexPalm < 0.05f || disMiddlePalm < 0.05f || disRingPalm < 0.05f || disPinkyPalm < 0.05f)
                    {
                        handsTouch = "H21";
                    }
                    if (disIndexI < 0.05f || disIndexM < 0.05f || disIndexR < 0.05f || disIndexP < 0.05f || disMiddleI < 0.05f || disMiddleM < 0.05f || disMiddleR < 0.05f || disMiddleP < 0.05f || disRingI < 0.05f || disRingM < 0.05f || disRingR < 0.05f || disRingP < 0.05f || disPinkyI < 0.05f || disPinkyM < 0.05f || disPinkyR < 0.05f || disPinkyP < 0.05f)
                    {
                        handsTouch = "H22";
                    }


                    //左手拇指接触

                    float disTPalm = (frame.Hands[0].GetThumb().TipPosition.ToVector3() - frame.Hands[1].PalmPosition.ToVector3()).magnitude;
                    float disTThumb = (frame.Hands[0].GetThumb().TipPosition.ToVector3() - frame.Hands[1].GetThumb().TipPosition.ToVector3()).magnitude;
                    float disTIndex = (frame.Hands[0].GetThumb().TipPosition.ToVector3() - frame.Hands[1].GetIndex().TipPosition.ToVector3()).magnitude;
                    float disTMiddle = (frame.Hands[0].GetThumb().TipPosition.ToVector3() - frame.Hands[1].GetMiddle().TipPosition.ToVector3()).magnitude;
                    float disTRing = (frame.Hands[0].GetThumb().TipPosition.ToVector3() - frame.Hands[1].GetRing().TipPosition.ToVector3()).magnitude;
                    float disTPinky = (frame.Hands[0].GetThumb().TipPosition.ToVector3() - frame.Hands[1].GetPinky().TipPosition.ToVector3()).magnitude;

                    if (disTPalm < 0.05f)
                    {
                        handsTouch = "H31";
                    }
                    if (disTThumb < 0.05f)
                    {
                        handsTouch = "H33";
                    }
                    if (disTIndex < 0.05f || disTMiddle < 0.05f || disTRing < 0.05f || disTPinky < 0.05f)
                    {
                        handsTouch = "H32";
                    }
                }
                if (frame.Hands[1].IsLeft)
                {
                    //左手手心接触
                    float disPalmT = (frame.Hands[1].PalmPosition.ToVector3() - frame.Hands[0].GetThumb().TipPosition.ToVector3()).magnitude;
                    float disPalmI = (frame.Hands[1].PalmPosition.ToVector3() - frame.Hands[0].GetIndex().TipPosition.ToVector3()).magnitude;
                    float disPalmM = (frame.Hands[1].PalmPosition.ToVector3() - frame.Hands[0].GetMiddle().TipPosition.ToVector3()).magnitude;
                    float disPalmR = (frame.Hands[1].PalmPosition.ToVector3() - frame.Hands[0].GetRing().TipPosition.ToVector3()).magnitude;
                    float disPalmP = (frame.Hands[1].PalmPosition.ToVector3() - frame.Hands[0].GetPinky().TipPosition.ToVector3()).magnitude;
                    float disPalmPalm = (frame.Hands[1].PalmPosition.ToVector3() - frame.Hands[0].PalmPosition.ToVector3()).magnitude;

                    if (disPalmT < 0.05f)
                    {
                        handsTouch = "H13";
                    }

                    if (disPalmI < 0.05f || disPalmM < 0.05f || disPalmR < 0.05f || disPalmP < 0.05f)
                    {
                        handsTouch = "H12";
                    }
                    if (disPalmPalm < 0.05f)
                    {
                        handsTouch = "H11";
                    }


                    //左手四指接触
                    //食指
                    float disIndexT = (frame.Hands[1].GetIndex().TipPosition.ToVector3() - frame.Hands[0].GetThumb().TipPosition.ToVector3()).magnitude;
                    float disIndexI = (frame.Hands[1].GetIndex().TipPosition.ToVector3() - frame.Hands[0].GetIndex().TipPosition.ToVector3()).magnitude;
                    float disIndexM = (frame.Hands[1].GetIndex().TipPosition.ToVector3() - frame.Hands[0].GetMiddle().TipPosition.ToVector3()).magnitude;
                    float disIndexR = (frame.Hands[1].GetIndex().TipPosition.ToVector3() - frame.Hands[0].GetRing().TipPosition.ToVector3()).magnitude;
                    float disIndexP = (frame.Hands[1].GetIndex().TipPosition.ToVector3() - frame.Hands[0].GetPinky().TipPosition.ToVector3()).magnitude;
                    float disIndexPalm = (frame.Hands[1].GetIndex().TipPosition.ToVector3() - frame.Hands[0].PalmPosition.ToVector3()).magnitude;

                    //中指
                    float disMiddleT = (frame.Hands[1].GetMiddle().TipPosition.ToVector3() - frame.Hands[0].GetThumb().TipPosition.ToVector3()).magnitude;
                    float disMiddleI = (frame.Hands[1].GetMiddle().TipPosition.ToVector3() - frame.Hands[0].GetIndex().TipPosition.ToVector3()).magnitude;
                    float disMiddleM = (frame.Hands[1].GetMiddle().TipPosition.ToVector3() - frame.Hands[0].GetMiddle().TipPosition.ToVector3()).magnitude;
                    float disMiddleR = (frame.Hands[1].GetMiddle().TipPosition.ToVector3() - frame.Hands[0].GetRing().TipPosition.ToVector3()).magnitude;
                    float disMiddleP = (frame.Hands[1].GetMiddle().TipPosition.ToVector3() - frame.Hands[0].GetPinky().TipPosition.ToVector3()).magnitude;
                    float disMiddlePalm = (frame.Hands[1].GetMiddle().TipPosition.ToVector3() - frame.Hands[0].PalmPosition.ToVector3()).magnitude;

                    //无名指
                    float disRingT = (frame.Hands[1].GetRing().TipPosition.ToVector3() - frame.Hands[0].GetThumb().TipPosition.ToVector3()).magnitude;
                    float disRingI = (frame.Hands[1].GetRing().TipPosition.ToVector3() - frame.Hands[0].GetIndex().TipPosition.ToVector3()).magnitude;
                    float disRingM = (frame.Hands[1].GetRing().TipPosition.ToVector3() - frame.Hands[0].GetMiddle().TipPosition.ToVector3()).magnitude;
                    float disRingR = (frame.Hands[1].GetRing().TipPosition.ToVector3() - frame.Hands[0].GetRing().TipPosition.ToVector3()).magnitude;
                    float disRingP = (frame.Hands[1].GetRing().TipPosition.ToVector3() - frame.Hands[0].GetPinky().TipPosition.ToVector3()).magnitude;
                    float disRingPalm = (frame.Hands[1].GetRing().TipPosition.ToVector3() - frame.Hands[0].PalmPosition.ToVector3()).magnitude;

                    //小指
                    float disPinkyT = (frame.Hands[1].GetPinky().TipPosition.ToVector3() - frame.Hands[0].GetThumb().TipPosition.ToVector3()).magnitude;
                    float disPinkyI = (frame.Hands[1].GetPinky().TipPosition.ToVector3() - frame.Hands[0].GetIndex().TipPosition.ToVector3()).magnitude;
                    float disPinkyM = (frame.Hands[1].GetPinky().TipPosition.ToVector3() - frame.Hands[0].GetMiddle().TipPosition.ToVector3()).magnitude;
                    float disPinkyR = (frame.Hands[1].GetPinky().TipPosition.ToVector3() - frame.Hands[0].GetRing().TipPosition.ToVector3()).magnitude;
                    float disPinkyP = (frame.Hands[1].GetPinky().TipPosition.ToVector3() - frame.Hands[0].GetPinky().TipPosition.ToVector3()).magnitude;
                    float disPinkyPalm = (frame.Hands[1].GetPinky().TipPosition.ToVector3() - frame.Hands[0].PalmPosition.ToVector3()).magnitude;

                    if (disIndexT < 0.05f || disMiddleT < 0.05f || disRingT < 0.05f || disPinkyT < 0.05f)
                    {
                        handsTouch = "H23";
                    }
                    if (disIndexPalm < 0.05f || disMiddlePalm < 0.05f || disRingPalm < 0.05f || disPinkyPalm < 0.05f)
                    {
                        handsTouch = "H21";
                    }
                    if (disIndexI < 0.05f || disIndexM < 0.05f || disIndexR < 0.05f || disIndexP < 0.05f || disMiddleI < 0.05f || disMiddleM < 0.05f || disMiddleR < 0.05f || disMiddleP < 0.05f || disRingI < 0.05f || disRingM < 0.05f || disRingR < 0.05f || disRingP < 0.05f || disPinkyI < 0.05f || disPinkyM < 0.05f || disPinkyR < 0.05f || disPinkyP < 0.05f)
                    {
                        handsTouch = "H22";
                    }
                    //左手拇指接触

                    float disTPalm = (frame.Hands[1].GetThumb().TipPosition.ToVector3() - frame.Hands[0].PalmPosition.ToVector3()).magnitude;
                    float disTThumb = (frame.Hands[1].GetThumb().TipPosition.ToVector3() - frame.Hands[0].GetThumb().TipPosition.ToVector3()).magnitude;
                    float disTIndex = (frame.Hands[1].GetThumb().TipPosition.ToVector3() - frame.Hands[0].GetIndex().TipPosition.ToVector3()).magnitude;
                    float disTMiddle = (frame.Hands[1].GetThumb().TipPosition.ToVector3() - frame.Hands[0].GetMiddle().TipPosition.ToVector3()).magnitude;
                    float disTRing = (frame.Hands[1].GetThumb().TipPosition.ToVector3() - frame.Hands[0].GetRing().TipPosition.ToVector3()).magnitude;
                    float disTPinky = (frame.Hands[1].GetThumb().TipPosition.ToVector3() - frame.Hands[0].GetPinky().TipPosition.ToVector3()).magnitude;

                    if (disTPalm < 0.05f)
                    {
                        handsTouch = "H31";
                    }
                    if (disTThumb < 0.05f)
                    {
                        handsTouch = "H33";
                    }
                    if (disTIndex < 0.05f || disTMiddle < 0.05f || disTRing < 0.05f || disTPinky < 0.05f)
                    {
                        handsTouch = "H32";
                    }
                }

                handres3 = GetString(codel);
                handres4 = GetString(coder);
                string handresdb;
                if (handsTouch == null) handresdb = handres3 + "," + handres4;
                else handresdb = handres3 + "," + handres4 + "," + handsTouch;
                if (handresdb != handres1 && handresdb != null)
                {
                    tx2.text = handresdb;
                    tx2s.text = handresdb;
                    tx21.text = handres3;
                    tx22.text = handres4;
                    if (TimeData <= 5.8) tx2save.text = handresdb;
                    //doublecodes.Add(handresdb + "," + TimeData + "," + frame.Hands[0].PalmPosition.x.ToString() + "," + frame.Hands[0].PalmPosition.y.ToString() + "," + frame.Hands[0].PalmPosition.z.ToString() + "," + frame.Hands[0].IsLeft.ToString() + "," + frame.Hands[1].PalmPosition.x.ToString() + "," + frame.Hands[1].PalmPosition.y.ToString() + "," + frame.Hands[1].PalmPosition.z.ToString() + "," + frame.Hands[1].IsLeft.ToString());
                    hand_codes[number] = handresdb;
                    handres1 = handresdb;
                    if (TimeData > 5.8 && TimeData <= 6)
                    {
                        tx2save.text = handresdb;
                    }

                }
            

            }

            //单手动态识别100左，010上，001前

            //左右手分配
            if (frame.Hands.Count == 1)
            {
                Hand midhand = frame.Hands[0];
                if (midhand.IsLeft == true)
                {
                    LeftHand = midhand;
                    HaveLeftHand = true;
                    HaveRightHand = false;
                }
                else
                {
                    RightHand = midhand;
                    HaveRightHand = true;
                    HaveLeftHand = false;
                }
            }
            else if (frame.Hands.Count == 2)
            {
                Hand midhand = frame.Hands[0];
                if (midhand.IsLeft == true)
                {
                    LeftHand = midhand;
                    HaveLeftHand = true;
                    RightHand = frame.Hands[1];
                    HaveRightHand = true;
                }
                else
                {
                    RightHand = midhand;
                    HaveRightHand = true;
                    LeftHand = frame.Hands[1];
                    HaveLeftHand = true;
                }
            }
            else
            {
                HaveLeftHand = false;
                HaveRightHand = false;
            }

            if (HaveRightHand)
            {
                float[] angp1 = new float[10];
                Vector3 v1 = new Vector3(0, 0, 1);//前
                Vector3 v2 = new Vector3(0, 0, -1);
                Vector3 v3 = new Vector3(-1, 0, 0);//左
                Vector3 v4 = new Vector3(1, 0, 0);//右
                Vector3 v5 = new Vector3(0, 1, 0);
                Vector3 v6 = new Vector3(0, -1, 0);//下
                Vector3 v7 = new Vector3(1, 1, 0);//左上
                Vector3 v8 = new Vector3(1, -1, 0);
                Vector3 v9 = new Vector3(-1, 1, 0);//右上
                Vector3 v10 = new Vector3(-1, -1, 0);

                Hand handB = RightHand;
                Vector3 vccurent = handB.PalmPosition.ToVector3();
                Vector3 vsd1 = handB.PalmVelocity.ToVector3();
                angp1[0] = Vector3.Angle(vsd1, v1);
                angp1[1] = Vector3.Angle(vsd1, v2);
                angp1[2] = Vector3.Angle(vsd1, v3);
                angp1[3] = Vector3.Angle(vsd1, v4);
                angp1[4] = Vector3.Angle(vsd1, v5);
                angp1[5] = Vector3.Angle(vsd1, v6);
                angp1[6] = Vector3.Angle(vsd1, v7);
                angp1[7] = Vector3.Angle(vsd1, v8);
                angp1[8] = Vector3.Angle(vsd1, v9);
                angp1[9] = Vector3.Angle(vsd1, v10);


                // 画圈识别
                // 开始坐标和结束坐标小于某个值
                // 取得开始点和最远点的半径 以及他们的中间坐标
                // 将取得的点与中间坐标相比小于某个差值
                // 直线识别：最远的坐标就是结束点坐标
                if (!IsStationary(handB))
                {
                    if (!DynamicFirstIn)
                    {
                        DynamicStart_Time = TimeData;
                        DynamicFirstIn = true;
                    }

                    if (handWave == "W0" && EqualCode(codeStart, codeRefer))//
                    {
                        beginPos = vccurent;
                        codeStart = SingleHandCode(frame.Hands[0]);
                    }

                    beginTimer += Time.deltaTime;
                    // 1.2秒之内计算点
                    if (beginTimer > 2.0f)
                    {
                        beginTimer = 0f;
                    }
                    else
                    {
                        betweenTimer += Time.deltaTime;
                        // 每隔0.1秒取点
                        if (betweenTimer >= 0.1f)
                        {
                            posVector3.Add(vccurent);
                            float f = Vector3.Distance(beginPos, vccurent);
                            posFloat.Add(f);
                            betweenTimer = 0f;
                        }
                    }
                    // Debug.Log(GetString(codeEnd));

                    if ((vsd1.magnitude <= 0.15f) && EqualCode(codeEnd, codeRefer))
                    {
                        endPos = vccurent;
                        codeEnd = SingleHandCode(frame.Hands[0]);
                        beginTimer = 0f;
                        betweenTimer = 0f;
                        DynamicFirstIn = false;
                        for (int i = 1; i < posFloat.Count; i++)
                        {
                            if (posFloat[i] > posFloat[maxIndex])
                            {
                                maxIndex = i;
                            }

                        }
                        float m = Vector3.Distance(beginPos, endPos);
                        if (Mathf.Abs(maxIndex - posFloat.Count) < 5 && m > 0.1f) //说明直线运动
                        {
                            Debug.Log("直线");
                            int num1 = Min(angp1, 10);
                            var perp = endPos - beginPos;
                            var perlength = perp.magnitude;
                            perp /= perlength;
                            if (handB.IsLeft == false)
                            {
                                handWave = "W" + num1.ToString() + "," + m.ToString() + "," + perp.ToString() + "," + "Right";
                            }
                            else
                            {
                                handWave = "W" + num1.ToString() + "," + m.ToString() + "," + perp.ToString() + "," + "Left";
                            }
                        }
                        if (maxIndex != posFloat.Count && posFloat.Count >= point)
                        {

                            // 开始坐标和最远点的半径，以此作为判断依据
                            float radius1 = posFloat[maxIndex] / 2;
                            radius = radius1;
                            // 开始坐标和最远点的中间坐标 
                            betweenPos = (beginPos + posVector3[maxIndex]) / 2;
                            foreach (var item in posVector3)
                            {
                                // 判断获得的坐标和中间坐标的距离 和半径相减的绝对值 是不是小于一定范围
                                if (Mathf.Abs(Vector3.Distance(item, betweenPos) - radius) < num)
                                {
                                    i++;
                                }

                            }
                            if (i > point)
                            {

                                isBool = true;

                            }
                            if (Vector3.Distance(beginPos, endPos) <= radius && isBool)
                            {
                                var a = beginPos;
                                var b = beginPos;
                                if ((maxIndex % 2) == 0)
                                {
                                    b = posVector3[maxIndex / 2];
                                }
                                else
                                {
                                    b = posVector3[(maxIndex + 1) / 2];
                                }
                                var c = posVector3[maxIndex];
                                var side1 = b - c;
                                var side2 = a - c;
                                var perp = Vector3.Cross(side1, side2);
                                var perlength = perp.magnitude;
                                perp /= perlength;
                                // 画了一个圆
                                if (handB.IsLeft == false)
                                {
                                    handWave = "C" + "," + radius.ToString() + "," + perp.ToString() + "," + "Right";
                                }
                                else
                                {
                                    handWave = "C" + "," + radius.ToString() + "," + perp.ToString() + "," + "Left";
                                }
                                Debug.Log("圆");
                                Debug.Log(perp.ToString());
                            }

                            // 数据初始化
                            i = 0;
                            maxIndex = 0;
                            posFloat.Clear();
                            posVector3.Clear();
                            isBool = false;
                        }
                        if (!EqualCode(codeRefer, codeStart) && !EqualCode(codeRefer, codeEnd) && handWave != "W0")
                        {
                            handres5 = GetString(codeStart);
                            handres6 = GetString(codeEnd);
                            string handresdy = handWave;
                            tx3.text = handresdy;
                            dynamiccodes.Add(handresdy + "," + DynamicStart_Time + "," + TimeData);
                            //恢复初始值
                            handWave = "W0";
                            codeStart.Clear();
                            codeEnd.Clear();
                        }
                        else
                        {
                            //恢复初始值
                            handWave = "W0";
                            codeStart.Clear();
                            codeEnd.Clear();
                        }

                    }
                }
                else DynamicFirstIn = false;
            }

            //左手动态手势识别
            if (HaveLeftHand)
            {
                float[] angp1 = new float[10];
                Vector3 v1 = new Vector3(0, 0, 1);//前
                Vector3 v2 = new Vector3(0, 0, -1);
                Vector3 v3 = new Vector3(-1, 0, 0);//左
                Vector3 v4 = new Vector3(1, 0, 0);//右
                Vector3 v5 = new Vector3(0, 1, 0);
                Vector3 v6 = new Vector3(0, -1, 0);//下
                Vector3 v7 = new Vector3(1, 1, 0);//左上
                Vector3 v8 = new Vector3(1, -1, 0);
                Vector3 v9 = new Vector3(-1, 1, 0);//右上
                Vector3 v10 = new Vector3(-1, -1, 0);

                Hand handB = LeftHand;
                Vector3 vccurent = handB.PalmPosition.ToVector3();
                Vector3 vsd1 = handB.PalmVelocity.ToVector3();
                angp1[0] = Vector3.Angle(vsd1, v1);
                angp1[1] = Vector3.Angle(vsd1, v2);
                angp1[2] = Vector3.Angle(vsd1, v3);
                angp1[3] = Vector3.Angle(vsd1, v4);
                angp1[4] = Vector3.Angle(vsd1, v5);
                angp1[5] = Vector3.Angle(vsd1, v6);
                angp1[6] = Vector3.Angle(vsd1, v7);
                angp1[7] = Vector3.Angle(vsd1, v8);
                angp1[8] = Vector3.Angle(vsd1, v9);
                angp1[9] = Vector3.Angle(vsd1, v10);


                // 画圈识别
                // 开始坐标和结束坐标小于某个值
                // 取得开始点和最远点的半径 以及他们的中间坐标
                // 将取得的点与中间坐标相比小于某个差值
                // 直线识别：最远的坐标就是结束点坐标
                if (!IsStationary(handB))
                {

                    if (!LDynamicFirstIn)
                    {
                        LDynamicStart_Time = TimeData;
                        LDynamicFirstIn = true;
                    }

                    if (LhandWave == "W0" && EqualCode(LcodeStart, LcodeRefer))//
                    {
                        LbeginPos = vccurent;
                        LcodeStart = SingleHandCode(frame.Hands[0]);
                    }

                    LbeginTimer += Time.deltaTime;
                    // 1.2秒之内计算点
                    if (LbeginTimer > 2.0f)
                    {
                        LbeginTimer = 0f;
                    }
                    else
                    {
                        LbetweenTimer += Time.deltaTime;
                        // 每隔0.1秒取点
                        if (LbetweenTimer >= 0.1f)
                        {
                            LposVector3.Add(vccurent);
                            float f = Vector3.Distance(LbeginPos, vccurent);
                            LposFloat.Add(f);
                            LbetweenTimer = 0f;
                        }
                    }
                    // Debug.Log(GetString(codeEnd));

                    if ((vsd1.magnitude <= 0.15f) && EqualCode(LcodeEnd, LcodeRefer))
                    {
                        LendPos = vccurent;
                        LcodeEnd = SingleHandCode(frame.Hands[0]);
                        LbeginTimer = 0f;
                        LbetweenTimer = 0f;
                        LDynamicFirstIn = false;
                        for (int i = 1; i < LposFloat.Count; i++)
                        {
                            if (LposFloat[i] > LposFloat[LmaxIndex])
                            {
                                LmaxIndex = i;
                            }

                        }
                        float m = Vector3.Distance(LbeginPos, LendPos);
                        Debug.Log(m);
                        if (Mathf.Abs(LmaxIndex - LposFloat.Count) < 5 && m > 0.1f) //说明直线运动
                        {
                            Debug.Log("直线");
                            int num1 = Min(angp1, 10);
                            var perp = LendPos - LbeginPos;
                            var perlength = perp.magnitude;
                            perp /= perlength;
                            if (handB.IsLeft == false)
                            {
                                LhandWave = "W" + num1.ToString() + "," + m.ToString() + "," + perp.ToString() + "," + "Right";
                            }
                            else
                            {
                                LhandWave = "W" + num1.ToString() + "," + m.ToString() + "," + perp.ToString() + "," + "Left";
                            }
                        }
                        if (LmaxIndex != LposFloat.Count && LposFloat.Count >= point)
                        {

                            // 开始坐标和最远点的半径，以此作为判断依据
                            float radius1 = LposFloat[maxIndex] / 2;
                            Lradius = radius1;
                            // 开始坐标和最远点的中间坐标 
                            LbetweenPos = (LbeginPos + LposVector3[maxIndex]) / 2;
                            foreach (var item in LposVector3)
                            {
                                // 判断获得的坐标和中间坐标的距离 和半径相减的绝对值 是不是小于一定范围
                                if (Mathf.Abs(Vector3.Distance(item, LbetweenPos) - Lradius) < num)
                                {
                                    i++;
                                }

                            }
                            if (Li > point)
                            {

                                LisBool = true;

                            }
                            if (Vector3.Distance(LbeginPos, LendPos) <= Lradius && LisBool)
                            {
                                var a = LbeginPos;
                                var b = LbeginPos;
                                if ((LmaxIndex % 2) == 0)
                                {
                                    b = LposVector3[LmaxIndex / 2];
                                }
                                else
                                {
                                    b = LposVector3[(LmaxIndex + 1) / 2];
                                }
                                var c = LposVector3[LmaxIndex];
                                var side1 = b - c;
                                var side2 = a - c;
                                var perp = Vector3.Cross(side1, side2);
                                var perlength = perp.magnitude;
                                perp /= perlength;
                                // 画了一个圆
                                if (handB.IsLeft == false)
                                {
                                    LhandWave = "C" + "," + Lradius.ToString() + "," + perp.ToString() + "," + "Right";
                                }
                                else
                                {
                                    LhandWave = "C" + "," + Lradius.ToString() + "," + perp.ToString() + "," + "Left";
                                }
                                Debug.Log("圆");
                                Debug.Log(perp.ToString());
                            }

                            // 数据初始化
                            Li = 0;
                            LmaxIndex = 0;
                            LposFloat.Clear();
                            LposVector3.Clear();
                            LisBool = false;
                        }
                        if (!EqualCode(LcodeRefer, LcodeStart) && !EqualCode(LcodeRefer, LcodeEnd) && LhandWave != "W0")
                        {
                            handres5 = GetString(LcodeStart);
                            handres6 = GetString(LcodeEnd);
                            string handresdy = LhandWave;
                            tx3.text = handresdy;
                            dynamiccodes.Add(handresdy + "," + LDynamicStart_Time + "," + TimeData);
                            //恢复初始值
                            LhandWave = "W0";
                            LcodeStart.Clear();
                            LcodeEnd.Clear();
                        }
                        else
                        {
                            //恢复初始值
                            LhandWave = "W0";
                            LcodeStart.Clear();
                            LcodeEnd.Clear();
                        }

                    }
                }
                else LDynamicFirstIn = false;
            }
            number++;//计数
        }

    }

    //void OnApplicationQuit()
    //{
    //    CSVs.Write(doublecodes, testeename + "DoubleHandData.csv");
    //    CSVs.Write(handcodes, testeename + "SingleHandData.csv");
    //    CSVs.Write(dynamiccodes, testeename + "DynamicHandData.csv");
    //}


    protected bool IsStationary(Hand hand)// 固定不动的 
    {
        return hand.PalmVelocity.Magnitude < smallestVelocity;
    }

    //手心位置移动 手部空间100右，010下，001前

    protected bool IsSameDirection(Vector3 a, Vector3 b)
    {
        return Vector3.Angle(a, b) < handForwardDegree;
    }
    public bool EqualCode(CODEUNIT code1, CODEUNIT code2)
    {
        if (GetString(code1) == GetString(code2))
            return true;
        else
            return false;
    }
}
