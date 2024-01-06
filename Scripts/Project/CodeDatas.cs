/**************************************************
* 创建作者：	咕咕咕
* 作用描述：	#
***************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Project
{
	public class CodeDatas : DataCollection<CodeData, int, CodeDatas>
	{
        public override string[] Fields => new string[] { "key","encode", "semantic","source","type","other"};
        public override string Path => Application.streamingAssetsPath + "/CodeData.csv";

		private CodeDatas() { }

        protected override void OnLoadFinish()
        {
            if (File.Exists(HistoryDatas.Instance.Path))
            {
                HistoryDatas.Instance.Load(false, h => h.Init());
            }
            else
            {
                var fields = Enum.GetValues(typeof(FieldType));
                foreach (FieldType f in fields)
                {
                    HistoryDatas.Instance.AddEmpty(f);
                }
                HistoryDatas.Instance.Save();
            }
        }

        public List<int> Search(FieldType _type, string _matchStr, int _size = 2)
        {
            List<int> keys = new List<int>();
            foreach (var c in collection.Values)
            {
                if (c.GetContent(_type).Contains(_matchStr))
                {
                    keys.Add(c.Key);
                    if (keys.Count >= _size) break;
                }
            }
            return keys;
        }
	}
}