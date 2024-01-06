/**************************************************
* 创建作者：	咕咕咕
* 作用描述：	#
***************************************************/

using UnityEngine;
using UnityEngine.UI;

namespace Project
{
	public class FieldsInfo : MonoBehaviour
	{
		[SerializeField] Text title;
		[SerializeField] InputField input;
		[SerializeField] Dropdown dropDown;
		private int key;
		private FieldType type;

		public int Key => key;

		public void Init(int _key, FieldType _type)
        {
			key = _key;
			type = _type;
			var code = CodeDatas.Instance.Get(key);
			title.text = type.Name() + ":";
			input.text = code.GetContent(type);

			var history = HistoryDatas.Instance.Get(type);
			UpdateHistory();
			dropDown.onValueChanged.AddListener(UseHistory);
			history.onChange += UpdateHistory;
        }

		public void Save()
        {
			HistoryDatas.Instance.Get(type).Add(input.text);
			CodeDatas.Instance.Get(key).SetContent(type, input.text);
		}

        private void OnDisable()
        {
			var history = HistoryDatas.Instance.Get(type);
            if (history != null)
            {
				history.onChange -= UpdateHistory;
            }
		}

        void UpdateHistory()
        {
			dropDown.ClearOptions();
			var datas = HistoryDatas.Instance.Get(type).Datas;
			string current = input.text;
			dropDown.options.Add(new Dropdown.OptionData(current));
			foreach (var h in datas)
			{
				if (h == current) continue;
				dropDown.options.Add(new Dropdown.OptionData(h));
			}
			dropDown.SetValueWithoutNotify(0);
		}

		void UseHistory(int index)
        {
			input.text = dropDown.options[index].text;
        }
	}
}