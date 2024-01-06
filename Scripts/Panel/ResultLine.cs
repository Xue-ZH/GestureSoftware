/**************************************************
* 创建作者：	咕咕咕
* 作用描述：	#行
***************************************************/

using System;
using UnityEngine;
using UnityEngine.UI;

namespace Project
{
	public class ResultLine : MonoBehaviour
	{
		[SerializeField] Image sprite;
		[SerializeField] Text idLabel;
		[SerializeField] GameObject flag;
		[SerializeField] Button btn;
		public Action<int> onClicked;
		private int key;

		public int Key => key;

		public void Init(int _key)
		{
			key = _key;
			var code = CodeDatas.Instance.Get(key);
			idLabel.text = $"{code.Key}";

			btn.onClick.AddListener(Click);
		}

        public void Selected(bool selected)
        {
			flag.SetActive(selected);
			btn.interactable = !selected;
        }

        void Click()
		{
			onClicked?.Invoke(key);
		}
	}
}