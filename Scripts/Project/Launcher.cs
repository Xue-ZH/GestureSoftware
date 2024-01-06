/**************************************************
* 创建作者：	咕咕咕
* 作用描述：	#启动入口
***************************************************/

using UnityEngine;

namespace Project
{
	public class Launcher : MonoBehaviour
	{
		#region ----MonoBehaviour----
		void Awake()
		{
			DontDestroyOnLoad(gameObject);

			// 加载配置文件
			CodeDatas.Instance.Load(false);

			//开始逻辑
			StartGame();
		}

        private void OnApplicationQuit()
        {
			HistoryDatas.Instance.Save();
			CodeDatas.Instance.Save();
        }
        #endregion

        #region ----私有方法----
        private void StartGame()
		{
			UIManager.Instance.Open("SearchPanel");
		}
		#endregion
	}
}