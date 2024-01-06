/**************************************************
* 创建作者：	咕咕咕
* 作用描述：	#具体信息
***************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
	public class ResultInfo : MonoBehaviour
	{
		[SerializeField] FieldsInfo fieldPrefab;
		[SerializeField] Transform fieldContainer;

		private readonly List<FieldsInfo> fieldsTemp = new List<FieldsInfo>();
		private int key;

		public int Key => key;

		public void Init(int _key)
		{
			key = _key;
            foreach (var f in fieldsTemp)
            {
				Destroy(f.gameObject);
            }
			fieldsTemp.Clear();

			var fieldList = Enum.GetValues(typeof(FieldType));
            foreach (FieldType ft in fieldList)
            {
				Create(ft);
            }
		}

		public void Save()
        {
            foreach (var f in fieldsTemp)
            {
				f.Save();
            }
        }

		FieldsInfo Create(FieldType _type)
        {
			FieldsInfo fi = Instantiate<FieldsInfo>(fieldPrefab, fieldContainer);
			fi.gameObject.SetActive(true);
			fi.Init(key, _type);
			fieldsTemp.Add(fi);
			return fi;
        }
	}
}