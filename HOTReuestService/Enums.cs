/*
 * 版权所有:杭州火图科技有限公司
 * 地址:浙江省杭州市滨江区西兴街道阡陌路智慧E谷B幢4楼在地图中查看
 * (c) Copyright Hangzhou Hot Technology Co., Ltd.
 * Floor 4,Block B,Wisdom E Valley,Qianmo Road,Binjiang District
 * 2013-2017. All rights reserved.
 * author guomw
**/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HOTReuestService
{
    /// <summary>
    /// 发送微信模板消息场景类型
    /// </summary>
    public enum WeChatTemplateMessageSceneType
    {
        客户端离线 = 0,
        微信离线 = 1,
        群异常 = 2,
        阿里妈妈离线 = 3
    }    
}
