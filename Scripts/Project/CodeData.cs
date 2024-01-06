/**************************************************
* 创建作者：	咕咕咕
* 作用描述：	#
***************************************************/

using System;

namespace Project
{
	public class CodeData : DataBase<int>
	{
		private string encode;
		private string semantic;
		private string source;
		private string type;
		private string other;

		public Action<FieldType, string> onChangeFields;

		public string Encode => encode;
		public string Semantic => semantic;
		public string Source => source;
		public string Type => type;
		public string Other => other;

		public void SetContent(FieldType _fieldType, string _content)
        {
            switch (_fieldType)
            {
				case FieldType.Encode: encode = _content;break;
				case FieldType.Semantic: semantic = _content;break;
				case FieldType.Source: source = _content;break;
				case FieldType.Type: type = _content;break;
				case FieldType.Other: other = _content;break;
            }
			onChangeFields?.Invoke(_fieldType, _content);
        }

		public string GetContent(FieldType _fieldType)
        {
			switch (_fieldType)
			{
				case FieldType.Encode: return encode;
				case FieldType.Semantic: return semantic;
				case FieldType.Source: return source;
				case FieldType.Type: return type;
				case FieldType.Other: return other;
			}
			return string.Empty;
		}

		#region ----公有方法----
		public override string ToString()
		{
			return $"{key},{encode},{semantic},{source},{type},{other}";
		}
		#endregion

	}
}