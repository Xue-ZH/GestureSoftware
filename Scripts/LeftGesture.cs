using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OfficeOpenXml;
using UnityEngine.UI;
using Excel;
using System.IO;
using System.Data;
using ICSharpCode.SharpZipLib;

public class LeftGesture : MonoBehaviour
{
    FileInfo GestureRecordedData;
    public GameObject LUpperarm;
    public GameObject LLowerarm;
    public GameObject LHand;
    //public GameObject StateCode;
    public List<Quaternion> LUpperarmRotations = new List<Quaternion>();
    public List<Quaternion> LLowerarmRotations = new List<Quaternion>();

    public int LEXCNumSet = 0;

    //public List<Quaternion> HandRotations = new List<Quaternion>();
    public List<string> LStateCodes = new List<string>();

    Quaternion Lstandard = new Quaternion(0.206f, 0.187f, -0.605f, 0.747f);
    Quaternion LThisUpperArm;

    //动作复制
    HumanPoseHandler Linitbody;
    HumanPoseHandler Lmidbody;
    public GameObject Linitmodel;
    public GameObject Lmidlmodel;
    public GameObject Lmidforearm;
    public GameObject Lmidlowarm;
    public GameObject Lsetforearm;
    public GameObject Lsetlowarm;


    private void Start()
    {
        LThisUpperArm = LUpperarm.transform.localRotation;
        //Debug.Log(Upperarm.transform.localRotation);
        string path = Application.dataPath + "/Resourse/LeftHand.xls";
        FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read);
        IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
        DataSet result = excelReader.AsDataSet();
        int rows = result.Tables[LEXCNumSet].Rows.Count;//获取行数
        //从第一行开始读
        for (int i = 0; i < rows; i++)
        {
            LUpperarmRotations.Add(LStringtoq(result.Tables[LEXCNumSet].Rows[i][0].ToString()));
            LLowerarmRotations.Add(LStringtoq(result.Tables[LEXCNumSet].Rows[i][1].ToString()));
            //HandRotations.Add(Stringtoq(result.Tables[0].Rows[i][2].ToString()));
            LStateCodes.Add(result.Tables[LEXCNumSet].Rows[i][3].ToString());
        }

        Linitbody = new HumanPoseHandler(Linitmodel.GetComponent<Animator>().avatar, Linitmodel.transform);
        Lmidbody = new HumanPoseHandler(Lmidlmodel.GetComponent<Animator>().avatar, Lmidlmodel.transform);
    }
    // Start is called before the first frame update
    public void LSetGesture(Text initcode)
    {
        string aimcode = initcode.text;
        for (int i = 0; i < LStateCodes.Count; i++)
        {
            if (aimcode == LStateCodes[i])
            {
                LUpperarm.transform.localRotation = LUpperarmRotations[i];
                LLowerarm.transform.localRotation = LLowerarmRotations[i];

                HumanPose m_humanPose = new HumanPose();
                Linitbody.GetHumanPose(ref m_humanPose);
                Lmidbody.SetHumanPose(ref m_humanPose);
                Lsetforearm.transform.rotation = Lmidforearm.transform.rotation;
                Lsetlowarm.transform.rotation = Lmidlowarm.transform.rotation;
            }
        }
    }
    Quaternion LStringtoq(string InitString)
    {
        if (InitString.Length <= 0)
            return Quaternion.identity;
        InitString = InitString.Replace("(", string.Empty).Replace(")", string.Empty);
        string[] tmp_sValues = InitString.Trim(' ').Split(',');
        if (tmp_sValues != null && tmp_sValues.Length == 4)
        {
            float tmp_fX = float.Parse(tmp_sValues[0]);
            float tmp_fY = float.Parse(tmp_sValues[1]);
            float tmp_fZ = float.Parse(tmp_sValues[2]);
            float tmp_fH = float.Parse(tmp_sValues[3]);

            return new Quaternion(tmp_fX, tmp_fY, tmp_fZ, tmp_fH);
        }
        return Quaternion.identity;
    }
}
