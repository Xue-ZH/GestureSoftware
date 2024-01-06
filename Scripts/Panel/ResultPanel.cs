/**************************************************
* 创建作者：	咕咕咕
* 作用描述：	#搜索结果
***************************************************/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project
{
	public class ResultPanel : UIPanel
	{
		[SerializeField] ResultLine resultLine;
		[SerializeField] Transform resultContainer;
		[SerializeField] ResultInfo info;
		[SerializeField] Button saveBtn;
		[SerializeField] Button returnBtn;

		private Dictionary<int, ResultLine> lines;
		private List<int> keys;

		private void Init(List<int> _keys)
        {
			keys = _keys;
			lines = new Dictionary<int, ResultLine>(keys.Count);
            foreach (var k in keys)
            {
				Create(k);
            }
			OnSelected(keys[0]);
			saveBtn.onClick.AddListener(Save);
			returnBtn.onClick.AddListener(ReturnToSearch);
        }

        public override void Open(params object[] args)
        {
            base.Open(args);
			Init((List<int>)args[0]);
        }

        ResultLine Create(int _key)
        {
			ResultLine rl = Instantiate<ResultLine>(resultLine, resultContainer);
			rl.gameObject.SetActive(true);
			rl.Init(_key);
			lines.Add(_key, rl);
			rl.onClicked += OnSelected;
			return rl;
        }

		void OnSelected(int _key)
        {
            foreach (var l in lines.Values)
            {
				l.Selected(l.Key == _key);
            }
			info.Init(_key);
        }

		void Save()
        {
			info.Save();
        }

		void ReturnToSearch()
        {
			UIManager.Instance.Open("SearchPanel");
			UIManager.Instance.Close(PanelName, true);
        }
	}
}