using System;

namespace SS728M05WebSocket
{
    public class IDCardInfo
    {
        /// <summary>
        /// 卡类型
        /// </summary>
        public string CardType { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 出生年月
        /// </summary>
        public string Birthday { get; set; }

        /// <summary>
        /// 卡号
        /// </summary>
        public string CardId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 英文名
        /// </summary>
        public string EName { get; set; }

        /// <summary>
        /// 民族
        /// </summary>
        public string Nation { get; set; }

        /// <summary>
        /// 发证机关
        /// </summary>
        public string Police { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 有效期限
        /// </summary>
        public string ValidEnd { get; set; }

        /// <summary>
        /// 有效期限
        /// </summary>
        public string ValidStart { get; set; }

        /// <summary>
        /// 图像
        /// </summary>
        public string PictureData { get; set; }
    }
}
