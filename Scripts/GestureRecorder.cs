using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OfficeOpenXml;
using UnityEngine.UI;
using Excel;
using System.IO;
using System.Data;

public class GestureRecorder : MonoBehaviour
{
    FileInfo GestureRecordedData;
    public GameObject Upperarm;
    public GameObject Lowerarm;
    public GameObject Hand;
    public GameObject StateCode;
    public List<Quaternion> UpperarmRotations=new List<Quaternion>();
    public List<Quaternion> LowerarmRotations = new List<Quaternion>();
    public List<Quaternion> HandRotations = new List<Quaternion>();
    public List<string> StateCodes = new List<string>();
    public void RecordOnece()
    {
        UpperarmRotations.Add(Upperarm.transform.localRotation);
        LowerarmRotations.Add(Lowerarm.transform.localRotation);
        HandRotations.Add(Hand.transform.localRotation);
        StateCodes.Add(StateCode.GetComponent<InputField>().text);
    }
    public void UndoRecordOnece()
    {
        UpperarmRotations.Remove(UpperarmRotations[UpperarmRotations.Count-1]);
        LowerarmRotations.Remove(LowerarmRotations[LowerarmRotations.Count - 1]);
        HandRotations.Remove(HandRotations[HandRotations.Count - 1]);
        StateCodes.Remove(StateCodes[StateCodes.Count - 1]);
    }
    private void OnApplicationQuit()
    {
        string path = Application.dataPath + "/Resourse/Testee4.xlsx";
        GestureRecordedData = new FileInfo(path);
        if(StateCodes.Count!=0)
        {
            using (ExcelPackage package = new ExcelPackage(GestureRecordedData))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("RecordTimes-" + package.Workbook.Worksheets.Count.ToString());
                for (int i = 0; i < StateCodes.Count; i++)
                {
                    worksheet.Cells[i + 1, 1].Value = StateCodes[i];
                    worksheet.Cells[i + 1, 2].Value = UpperarmRotations[i];
                    worksheet.Cells[i + 1, 3].Value = LowerarmRotations[i];
                    worksheet.Cells[i + 1, 4].Value = HandRotations[i];

                }
                package.Save();
            }
        }
    }
}
