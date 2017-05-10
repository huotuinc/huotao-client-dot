using System;
using iQQ.Net.WebQQCore.Im.Event;

namespace iQQ.Net.WebQQCore.Im
{
    /// <summary>
    /// 强类型的委托
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void QQNotifyListener(IQQClient sender, QQNotifyEvent e);

    ///// <summary>
    ///// QQ通知事件监听器
    ///// </summary>
    //public interface IQQNotifyListener
    //{
    //    // event QQNotifyHandler OnNotifyEvent;
    //    event EventHandler<QQNotifyEvent> OnNotifyEvent;
    //}
}
