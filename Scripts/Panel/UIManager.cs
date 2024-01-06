/**************************************************
* 创建作者：	咕咕咕
* 作用描述：	#
***************************************************/

using UnityEngine;
using System.Collections.Generic;

namespace Project
{
	public class UIManager : Singleton<UIManager>
	{
        Canvas canvas;
        Transform container;
        public const string Path = "Panel/";

        Dictionary<string, UIPanel> panels;

        private UIManager() { }

        #region ----公有方法----
        public override void OnInit()
        {
            var go = GameObject.Find("Canvas");
            canvas = go.GetComponent<Canvas>();
            Debug.Assert(canvas != null, "找不到Canvas组件!");
            GameObject.DontDestroyOnLoad(go);
            container = go.transform.Find("Panel");
            panels = new Dictionary<string, UIPanel>();
        }

        public UIPanel Open(string panelName, params object[] args)
        {
            UIPanel p = null;
            if (panels.TryGetValue(panelName, out p))
            {
                p.Open(args);
            }
            else
            {
                p = LoadPanel(panelName);
                panels.Add(panelName, p);
                p.Open(args);
            }
            return p;
        }

        public void Close(string panelName, bool destory = false)
        {
            UIPanel p = null;
            if (panels.TryGetValue(panelName, out p))
            {
                if (destory) panels.Remove(panelName);
                p.Close(destory);
            }
        }
        #endregion

        #region ----私有方法----
        UIPanel LoadPanel(string name)
        {
            var go = GameObject.Instantiate(Resources.Load<GameObject>(Path + name), container);
            go.name = name;
            UIPanel p = go.GetComponent<UIPanel>();
            return p;
        }
        #endregion
    }
}