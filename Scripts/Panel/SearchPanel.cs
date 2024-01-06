/**************************************************
* 创建作者：	咕咕咕
* 作用描述：	#搜索界面
***************************************************/

using UnityEngine;
using UnityEngine.UI;

namespace Project
{
	public class SearchPanel : UIPanel
	{
		[SerializeField] InputField input;
		[SerializeField] Dropdown dropDown;
		[SerializeField] Button searchBtn;
		[SerializeField] GameObject tips;

		private FieldType searchType;

		#region ----MonoBehaviour----
		void Start()
		{
			searchType = (FieldType)dropDown.value;
			searchBtn.onClick.AddListener(Search);
			dropDown.onValueChanged.AddListener(SelectDropDown);
			input.onValueChanged.AddListener(s => ShowTips(false));
		}
		#endregion

		#region ----私有方法----
		void Search()
		{
            if (!string.IsNullOrWhiteSpace(input.text))
            {
				var results = CodeDatas.Instance.Search(searchType, input.text);
                if (results == null || results.Count == 0)
                {
					tips.SetActive(true);
                }
                else
                {
					UIManager.Instance.Open("ResultPanel", results);
					UIManager.Instance.Close(PanelName, true);
                }
            }
		}

		void ShowTips(bool show)
        {
			tips.SetActive(show);
        }

		void SelectDropDown(int index)
        {
			searchType = (FieldType)index;
        }
		#endregion
	}
}