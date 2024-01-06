/**************************************************
* 创建作者：	咕咕咕
* 作用描述：	#单例接口
***************************************************/

using System;

namespace Project
{
	public interface ISingleton : IDisposable
	{
		void OnInit();
	}
}