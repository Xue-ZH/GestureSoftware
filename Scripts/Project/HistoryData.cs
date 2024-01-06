/**************************************************
* 创建作者：	咕咕咕
* 作用描述：	#历史记录
***************************************************/

using System.Text;
using System;
using System.Collections.Generic;

namespace Project
{
	public class HistoryData : DataBase<FieldType>
	{
		public const int MaxLine = 5;

		private string historys;
		private readonly List<string> datas = new List<string>();
        public Action onChange;

        public List<string> Datas => datas;

		public HistoryData() { }

        public HistoryData(FieldType _fieldType) => key = _fieldType;

        public void Init()
        {
            string[] strs = historys.Split('|');
            foreach (var s in strs)
            {
                if (!string.IsNullOrWhiteSpace(s))
                {
                    Add(s);
                }
            }
        }

        public void Add(string content)
        {
            if (datas.Count == MaxLine)
            {
                datas.RemoveAt(0);
            }
            foreach (var d in datas)
            {
                if (d == content) return;
            }
            datas.Add(content);
            onChange?.Invoke();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var d in datas)
            {
                sb.Append(d + "|");
            }
            return $"{key},{sb.ToString()}";
        }
    }
}