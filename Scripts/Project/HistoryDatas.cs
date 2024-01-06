/**************************************************
* 创建作者：	咕咕咕
* 作用描述：	#
***************************************************/

using System;
using UnityEngine;

namespace Project
{
	public class HistoryDatas : DataCollection<HistoryData, FieldType, HistoryDatas>
	{
        public override string Path => Application.streamingAssetsPath + "/HistoryData.csv";
        public override string[] Fields => new string[] { "key", "historys" };

        private HistoryDatas() { }

        public void AddEmpty(FieldType _fieldType)
        {
            if (!collection.ContainsKey(_fieldType))
            {
                collection.Add(_fieldType, new HistoryData(_fieldType));
            }
        }

    }
}