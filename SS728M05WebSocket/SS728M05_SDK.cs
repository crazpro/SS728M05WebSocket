using System;
using System.Runtime.InteropServices;
using System.Text;

namespace SS728M05WebSocket
{
	internal class SS728M05_SDK
	{
		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_reader_open();

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_reader_close(int ReaderHandle);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int SS_PBOC_ReadCardNum(int icdev, StringBuilder CardNum);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_dev_beep(int icdev, ushort _Amount, ushort _Msec);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int SS_Reader_Reset(int ReaderHandle, byte[] ICC_Slot_No, byte[] Response, ref int RespLen);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int SS_Reader_AutoFindCard(long ReaderHandle);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ICC_Reader_Open();

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ICC_Reader_Reset(int ReaderHandle, int ICC_Slot_No, byte[] Response, ref int RespLen);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ICC_Reader_Application(int ReaderHandle, int ICC_Slot_No, int Length_of_Command_APDU, byte[] Command_APDU, byte[] Response_APDU, ref int RespLen);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_rf_sb_FindCard(int no_psam = 0);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_rf_sb_ReadCardIssuers(StringBuilder CardIdentifier, StringBuilder CardType, StringBuilder CardVersion, StringBuilder IssuersID, StringBuilder IssuingDate, StringBuilder EffectiveData, StringBuilder CardID);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_rf_sb_ReadCardholder(StringBuilder CardID, StringBuilder Name, StringBuilder Name_, StringBuilder Sex, StringBuilder Nation, StringBuilder Address, StringBuilder Birthday);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int SS_MC_ReadInfo(int icdev, StringBuilder buf1, StringBuilder buf2, StringBuilder buf3, int WaitTime);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_id_GetManageNo(int icdev, byte[] uid);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_CardMifare_Reset(int icdev);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_CardMifare_Authentication(int icdev, uint _Mode, uint _SecNr, byte[] Password);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_CardMifare_GetUID(int icdev, byte[] _UID);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_CardMifare_WriteBlock(int icdev, uint _Adr, byte[] _Data);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_CardMifare_ReadBlock(int icdev, uint _Adr, byte[] _Data);

		public static int ss_M1Card_Read(int icdev, uint _Adr, byte[] Password, byte[] _Data)
		{
			int num = SS728M05_SDK.ss_CardMifare_Reset(icdev);
			if (num != 0)
			{
				return num;
			}
			num = SS728M05_SDK.ss_CardMifare_Authentication(icdev, 0U, _Adr, Password);
			if (num != 0)
			{
				return num;
			}
			return SS728M05_SDK.ss_CardMifare_ReadBlock(icdev, _Adr, _Data);
		}

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_id_ResetID2Card(int icdev);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_id_read_card(int icdev, short Flag = 0);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_id_query_name(int icdev, StringBuilder _Name);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_id_query_sex(int icdev, StringBuilder _Sex);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_id_query_sexL(int icdev, StringBuilder _Sex);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_id_query_folk(int icdev, StringBuilder _Folk);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_id_query_folkL(int icdev, StringBuilder _Folk);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_id_query_birth(int icdev, StringBuilder _Date);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_id_query_address(int icdev, StringBuilder _Addr);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_id_query_number(int icdev, StringBuilder _Number);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_id_query_organ(int icdev, StringBuilder _Organ);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_id_query_termbegin(int icdev, StringBuilder _Date);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_id_query_termend(int icdev, StringBuilder _Date);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_id_query_photo_data(int icdev, int _Format, byte[] ImageData, ref int ImageLen);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_id_query_photo_file(int icdev, int _Format, string ImagePath);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_fid_read_card(int icdev, ref short cardtype);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_fid_query_name(int icdev, StringBuilder _Name);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_fid_query_ename(int icdev, StringBuilder _Name);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_fid_query_sex(int icdev, StringBuilder _Sex);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_fid_query_sexL(int icdev, StringBuilder _Sex);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_fid_query_nation(int icdev, StringBuilder _Folk);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_fid_query_nationL(int icdev, StringBuilder _Folk);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_fid_query_birth(int icdev, StringBuilder _Date);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_fid_query_number(int icdev, StringBuilder _Number);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_fid_query_termbegin(int icdev, StringBuilder _Date);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_fid_query_termend(int icdev, StringBuilder _Date);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_fid_query_photo_data(int icdev, int _Format, byte[] ImageData, ref int ImageLen);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_fid_query_photo_file(int icdev, int _Format, string ImagePath);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_sle_reset_card(int icdev, byte slot, byte[] Response, ref int RespLen);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_sle4428_read_card(int icdev, int datatype, int pos, byte[] info, int lenInfo);
	}
}
