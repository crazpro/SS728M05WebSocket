using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Text;

namespace SS728M05WebSocket
{
	internal class ReadCard
	{
        public static int devHandle;

		public static string GetCodeMsg(int code)
		{
			Dictionary<int, string> dictionary = new Dictionary<int, string>
			{
				{
					0,
					"命令成功"
				},
				{
					-1,
					"卡片类型不对"
				},
				{
					-2,
					"无卡"
				},
				{
					-3,
					"多卡片冲突"
				},
				{
					-4,
					"卡片无应答"
				},
				{
					-5,
					"接口设备故障"
				},
				{
					-6,
					"不支持该命令"
				},
				{
					-7,
					"命令长度错误"
				},
				{
					-8,
					"命令参数错误"
				},
				{
					-9,
					"信息校验和出错"
				},
				{
					-11,
					"SAM卡没有插入"
				},
				{
					-63,
					"sm2获取哈希数据失败"
				},
				{
					-64,
					"sm3获取哈希数据失败"
				},
				{
					-65,
					"计算过程密钥错误"
				},
				{
					-66,
					"SAM卡选择文件错误"
				},
				{
					-67,
					"SAM卡校验PIN失败"
				},
				{
					-68,
					"SAM卡没有插入"
				},
				{
					-201,
					"没有寻卡医联卡"
				},
				{
					-202,
					"没有连接设备"
				},
				{
					-203,
					"内部认证失败"
				},
				{
					-204,
					"选择文件失败或外部认证失败"
				},
				{
					-205,
					"读文件失败(没有文件或记录)"
				},
				{
					-206,
					"写文件失败"
				},
				{
					-207,
					"读照片解码失败"
				},
				{
					-208,
					"照片解码失败"
				},
				{
					-209,
					"写照片时，解码失败"
				},
				{
					-210,
					"擦除记录失败"
				},
				{
					-211,
					"读卡器通讯出错"
				},
				{
					-9991,
					"卡版本判断失败"
				},
				{
					-26301,
					"外部认证失败，外部认证次数还剩1次"
				},
				{
					-26302,
					"外部认证失败，外部认证次数还剩2次"
				},
				{
					-26303,
					"外部认证失败，外部认证次数还剩3次"
				},
				{
					-26983,
					"此应用已锁定"
				},
				{
					-30001,
					"读卡器连接故障"
				},
				{
					-30002,
					"读卡器通信故障"
				},
				{
					-30003,
					"参数错"
				},
				{
					-30004,
					"非法密钥"
				},
				{
					-30005,
					"调用DLL失败"
				},
				{
					-30006,
					"照片解码失败"
				},
				{
					-30007,
					"照片文件创建"
				},
				{
					-30099,
					"命令执行失败"
				}
			};
			if (dictionary.ContainsKey(code))
			{
				return dictionary[code];
			}
			return "";
		}

		public static int opendevice()
		{
			ReadCard.devHandle = SS728M05_SDK.ss_reader_open();
			int num = ReadCard.devHandle;
			return ReadCard.devHandle;
		}

		public static int closedevice()
		{
			if (ReadCard.devHandle <= 0)
			{
				return 0;
			}
			int num = SS728M05_SDK.ss_reader_close(ReadCard.devHandle);
			if (num != 0)
			{
				return num;
			}
			ReadCard.devHandle = 0;
			return num;
		}

		public static int ss_socialCard_Read(out SocialSecurityCardInfo ssc)
		{
			ssc = new SocialSecurityCardInfo();
			if (ReadCard.devHandle <= 0)
			{
				return -5;
			}
			int num = SS728M05_SDK.ss_rf_sb_FindCard(0);
			if (num != 0)
			{
				return num;
			}
			StringBuilder stringBuilder = new StringBuilder(50);
			StringBuilder stringBuilder2 = new StringBuilder(50);
			StringBuilder stringBuilder3 = new StringBuilder(50);
			StringBuilder stringBuilder4 = new StringBuilder(50);
			StringBuilder stringBuilder5 = new StringBuilder(50);
			StringBuilder stringBuilder6 = new StringBuilder(50);
			StringBuilder stringBuilder7 = new StringBuilder(50);
			num = SS728M05_SDK.ss_rf_sb_ReadCardIssuers(stringBuilder, stringBuilder2, stringBuilder3, stringBuilder4, stringBuilder5, stringBuilder6, stringBuilder7);
			if (num != 0)
			{
				return num;
			}
			ssc.ksbm = stringBuilder.ToString();
			ssc.gfbb = stringBuilder3.ToString();
			ssc.klb = stringBuilder2.ToString();
			ssc.fkjg = stringBuilder4.ToString();
			ssc.fkrq = stringBuilder5.ToString();
			ssc.kyxq = stringBuilder6.ToString();
			ssc.CardNo = stringBuilder7.ToString();
			StringBuilder stringBuilder8 = new StringBuilder(50);
			StringBuilder stringBuilder9 = new StringBuilder(50);
			StringBuilder name_ = new StringBuilder(50);
			StringBuilder stringBuilder10 = new StringBuilder(50);
			StringBuilder stringBuilder11 = new StringBuilder(50);
			StringBuilder stringBuilder12 = new StringBuilder(50);
			StringBuilder stringBuilder13 = new StringBuilder(50);
			num = SS728M05_SDK.ss_rf_sb_ReadCardholder(stringBuilder8, stringBuilder9, name_, stringBuilder10, stringBuilder11, stringBuilder12, stringBuilder13);
			if (num != 0)
			{
				return num;
			}
			ssc.sfzh = stringBuilder8.ToString();
			ssc.xm = stringBuilder9.ToString();
			ssc.xb = stringBuilder10.ToString();
			ssc.mz = stringBuilder11.ToString();
			ssc.csd = stringBuilder12.ToString();
			ssc.csrq = stringBuilder13.ToString();
			return num;
		}

		public static int ss_IDCard_Read(out IDCardInfo idc)
		{
			idc = new IDCardInfo();
			if (ReadCard.devHandle <= 0)
			{
				return -5;
			}
			int num = SS728M05_SDK.ss_id_ResetID2Card(ReadCard.devHandle);
			if (num != 0)
			{
				return num;
			}
			short num2 = -1;
			num = SS728M05_SDK.ss_fid_read_card(ReadCard.devHandle, ref num2);
			if (num != 0)
			{
				return num;
			}
			StringBuilder stringBuilder = new StringBuilder(1024);
			StringBuilder stringBuilder2 = new StringBuilder(1024);
			StringBuilder stringBuilder3 = new StringBuilder(1024);
			StringBuilder stringBuilder4 = new StringBuilder(1024);
			new StringBuilder(1024);
			StringBuilder stringBuilder5 = new StringBuilder(1024);
			StringBuilder stringBuilder6 = new StringBuilder(1024);
			StringBuilder stringBuilder7 = new StringBuilder(1024);
			StringBuilder stringBuilder8 = new StringBuilder(1024);
			StringBuilder stringBuilder9 = new StringBuilder(1024);
			StringBuilder stringBuilder10 = new StringBuilder(1024);
			if (num2 == 1)
			{
				num = SS728M05_SDK.ss_id_query_name(ReadCard.devHandle, stringBuilder);
				num = SS728M05_SDK.ss_id_query_sexL(ReadCard.devHandle, stringBuilder3);
				num = SS728M05_SDK.ss_id_query_folkL(ReadCard.devHandle, stringBuilder4);
				num = SS728M05_SDK.ss_id_query_birth(ReadCard.devHandle, stringBuilder5);
				num = SS728M05_SDK.ss_id_query_address(ReadCard.devHandle, stringBuilder6);
				num = SS728M05_SDK.ss_id_query_number(ReadCard.devHandle, stringBuilder7);
				num = SS728M05_SDK.ss_id_query_organ(ReadCard.devHandle, stringBuilder8);
				num = SS728M05_SDK.ss_id_query_termbegin(ReadCard.devHandle, stringBuilder9);
				num = SS728M05_SDK.ss_id_query_termend(ReadCard.devHandle, stringBuilder10);
			}
			else if (num2 == 2)
			{
				num = SS728M05_SDK.ss_fid_query_name(ReadCard.devHandle, stringBuilder);
				num = SS728M05_SDK.ss_fid_query_sexL(ReadCard.devHandle, stringBuilder3);
				num = SS728M05_SDK.ss_fid_query_nationL(ReadCard.devHandle, stringBuilder4);
				num = SS728M05_SDK.ss_fid_query_birth(ReadCard.devHandle, stringBuilder5);
				num = SS728M05_SDK.ss_fid_query_ename(ReadCard.devHandle, stringBuilder2);
				num = SS728M05_SDK.ss_fid_query_number(ReadCard.devHandle, stringBuilder7);
				num = SS728M05_SDK.ss_fid_query_termbegin(ReadCard.devHandle, stringBuilder9);
				num = SS728M05_SDK.ss_fid_query_termend(ReadCard.devHandle, stringBuilder10);
			}
			string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
			if (num2 == 1)
			{
				num = SS728M05_SDK.ss_id_query_photo_file(ReadCard.devHandle, 1, baseDirectory + "photo");
			}
			else
			{
				num = SS728M05_SDK.ss_fid_query_photo_file(ReadCard.devHandle, 1, baseDirectory + "photo");
			}
			Bitmap bitmap = new Bitmap(baseDirectory + "photo-id2.bmp");
			bitmap.Save(baseDirectory + "zp.jpg", ImageFormat.Jpeg);
			bitmap.Dispose();
			FileStream fileStream = new FileStream(baseDirectory + "zp.jpg", FileMode.OpenOrCreate);
			byte[] array = new byte[fileStream.Length];
			fileStream.Read(array, 0, (int)fileStream.Length);
			fileStream.Close();
			idc.CardType = num2.ToString().Trim();
			idc.Name = stringBuilder.ToString().Trim();
			idc.EName = stringBuilder2.ToString().Trim();
			idc.Sex = stringBuilder3.ToString().Trim();
			idc.Nation = stringBuilder4.ToString().Trim();
			idc.Birthday = stringBuilder5.ToString().Trim();
			idc.Address = stringBuilder6.ToString().Trim();
			idc.CardId = stringBuilder7.ToString().Trim();
			idc.Police = stringBuilder8.ToString().Trim();
			idc.ValidStart = stringBuilder9.ToString().Trim();
			idc.ValidEnd = stringBuilder10.ToString().Trim();
			idc.PictureData = "data:image/jpg;base64," + Convert.ToBase64String(array);
			return 0;
		}

		public static int StringToBytes(string hex, ref byte[] asc)
		{
			if (hex.Length % 2 != 0)
			{
				return -1;
			}
			for (int i = 0; i < hex.Length / 2; i++)
			{
				asc[i] = byte.Parse(hex.Substring(i * 2, 2), NumberStyles.HexNumber);
			}
			return 0;
		}

		public static int ss_M1Card_Read(uint _Adr, string Password, out M1Info _Data)
		{
			_Data = new M1Info();
			if (ReadCard.devHandle <= 0)
			{
				return -5;
			}
			int num = SS728M05_SDK.ss_CardMifare_Reset(ReadCard.devHandle);
			if (num != 0)
			{
				return num;
			}
			byte[] array = new byte[16];
			num = SS728M05_SDK.ss_CardMifare_GetUID(ReadCard.devHandle, array);
			_Data.UID = Encoding.GetEncoding(936).GetString(array).Replace("\0", "").Trim();
			byte[] password = new byte[6];
			ReadCard.StringToBytes(Password, ref password);
			num = SS728M05_SDK.ss_CardMifare_Authentication(ReadCard.devHandle, 0U, _Adr, password);
			if (num != 0)
			{
				return num;
			}
			byte[] array2 = new byte[17];
			num = SS728M05_SDK.ss_CardMifare_ReadBlock(ReadCard.devHandle, _Adr, array2);
			_Data.HexData = BitConverter.ToString(array2).Replace("-", "");
			_Data.AsciiData = Encoding.Default.GetString(array2).Replace("\0", "");
			return num;
		}

		public static int ss_bankCard_Read(StringBuilder cardnum)
		{
			if (ReadCard.devHandle <= 0)
			{
				return -5;
			}
			return SS728M05_SDK.SS_PBOC_ReadCardNum(ReadCard.devHandle, cardnum);
		}

	}
}
