using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Newtonsoft.Json;

namespace iQQ.Net.WebQQCore.Im.Bean
{

    public class QQGroup
    {

        /// <summary>
        /// 登录QQ
        /// </summary>
        public long LoginQQ { get; set; }

        public long Gid { get; set; }
        public long Gin { get; set; }
        public long Code { get; set; }
        public int Clazz { get; set; }
        public long Flag { get; set; }
        public int Level { get; set; }
        public int Mask { get; set; }
        public string Name { get; set; }
        public string Memo { get; set; }
        public string FingerMemo { get; set; }
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 别名
        /// </summary>
        public string Alias { get; set; }
        /// <summary>
        /// 是否添加监控
        /// </summary>
        public bool isListen { get; set; } = false;

        [JsonIgnore]
        public Image Face { get; set; }

        public List<QQGroupMember> Members { get; set; } = new List<QQGroupMember>();

        public QQGroupMember GetMemberByUin(long uin)
        {
            return Members.FirstOrDefault(mem => mem.Uin == uin);
        }

        public override int GetHashCode()
        {
            return (int)this.Code;
        }

        public override bool Equals(object obj)
        {
            var other = obj as QQGroup;
            return Code == other?.Code;
        }

        public override string ToString()
        {
            return "QQGroup [gid=" + Gid + ", code=" + Code + ", name=" + Name + "]";
        }

        /// <summary>
        /// 获取群名称，如果有别名，则显示别名,否则显示群名
        /// </summary>
        /// <returns></returns>
        public string GetGroupName()
        {
            return string.IsNullOrEmpty(Alias) ? Name : Alias;
        }
    }
}
