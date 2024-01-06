/**************************************************
* 创建作者：	咕咕咕
* 作用描述：	#字段类型
***************************************************/

namespace Project
{
	public enum FieldType
	{
		Encode = 0,
		Semantic,
		Source,
		Type,
		Other
	}

	public static class FieldTypeExtension
    {
		private static string[] fieldNames = new string[]
		{
			"编码","语义","来源","类型","其他"
		};

		public static string Name(this FieldType self)
        {
			return fieldNames[(int)self];
        }
    }
}