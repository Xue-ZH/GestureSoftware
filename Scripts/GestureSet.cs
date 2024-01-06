using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OfficeOpenXml;
using UnityEngine.UI;
using Excel;
using System.IO;
using System.Data;
using ICSharpCode.SharpZipLib;

public class GestureSet : MonoBehaviour
{
    FileInfo GestureRecordedData;
    public GameObject Upperarm;
    public GameObject Lowerarm;
    public GameObject Hand;
    //public GameObject StateCode;
    public List<Quaternion> UpperarmRotations = new List<Quaternion>();
    public List<Quaternion> LowerarmRotations = new List<Quaternion>();

    public int EXCNumSet = 0;

    //public List<Quaternion> HandRotations = new List<Quaternion>();
    public List<string> StateCodes = new List<string>();

    Quaternion standard =new Quaternion(0.206f, 0.187f, -0.605f, 0.747f);
    Quaternion ThisUpperArm;

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
        ThisUpperArm = Upperarm.transform.localRotation;
        //Debug.Log(Upperarm.transform.localRotation);
        string path = Application.dataPath + "/Resourse/Testee4.xls";
        FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read);
        IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
        DataSet result = excelReader.AsDataSet();
        int rows = result.Tables[EXCNumSet].Rows.Count;//获取行数
        //从第一行开始读
        for (int i = 0; i < rows; i++)
        {
            UpperarmRotations.Add(Stringtoq(result.Tables[EXCNumSet].Rows[i][0].ToString()));
            LowerarmRotations.Add(Stringtoq(result.Tables[EXCNumSet].Rows[i][1].ToString()));
            //HandRotations.Add(Stringtoq(result.Tables[0].Rows[i][2].ToString()));
            StateCodes.Add(result.Tables[EXCNumSet].Rows[i][3].ToString());
        }

        initbody = new HumanPoseHandler(initmodel.GetComponent<Animator>().avatar, initmodel.transform);
        midbody = new HumanPoseHandler(midlmodel.GetComponent<Animator>().avatar, midlmodel.transform);
    }
    // Start is called before the first frame update
    public void SetGesture(Text initcode)
    {
        string aimcode= initcode.text;
        for (int i = 0; i < StateCodes.Count; i++)
        {
            if (aimcode == StateCodes[i])
            {
                Upperarm.transform.localRotation = UpperarmRotations[i];
                Lowerarm.transform.localRotation = LowerarmRotations[i];

                HumanPose m_humanPose = new HumanPose();
                initbody.GetHumanPose(ref m_humanPose);
                midbody.SetHumanPose(ref m_humanPose);
                setforearm.transform.rotation = midforearm.transform.rotation;
                setlowarm.transform.rotation = midlowarm.transform.rotation;
            }
        }
    }
    Quaternion Stringtoq(string InitString)
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
