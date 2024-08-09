using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Fleck;
using Newtonsoft.Json;

namespace SS728M05WebSocket
{
	public partial class Form1 : Form
	{
		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_reader_open();

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_reader_close(int icdev);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_id_ResetID2Card(int icdev);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_id_read_card(int icdev, int Flag = 0);

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
		public static extern int ss_id_query_photo_file(int icdev, byte _Format, string ImagePath);

		[DllImport("SS728M05_SDK.dll")]
		public static extern int ss_id_query_photo_data(int icdev, byte _Format, StringBuilder ImageData, ref int ImageLen);

        /// <summary>
        /// 神思SDK
        /// </summary>
        private const string DllPath = "SS728M05_SDK.dll";

        /// <summary>
        /// 
        /// </summary>
        private string ExePath = "";

        /// <summary>
        /// 
        /// </summary>
        private bool IsCloseForm;

        /// <summary>
        /// 写日志
        /// </summary>
		public void WriteLog(string msg)
		{
			string text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			string path = Path.Combine(text, "SS728M05_WEBSOCKET@" + DateTime.Today.ToString("yyyy-MM-dd") + ".txt");
			File.Exists(path);
			StreamWriter streamWriter = new StreamWriter(path, true, Encoding.Unicode);
			streamWriter.WriteLine(DateTime.Now.ToString("HH:mm:ss") + "\t" + msg + "\n");
			streamWriter.Close();
			streamWriter.Dispose();
		}

        /// <summary>
        /// 
        /// </summary>
		public Form1()
		{
			this.InitializeComponent();
		}

        /// <summary>
        /// 
        /// </summary>
		private void Form1_Load(object sender, EventArgs e)
		{
			this.ExePath = AppDomain.CurrentDomain.BaseDirectory;
			new WebSocketServer("ws://0.0.0.0:6932").Start(delegate(IWebSocketConnection socket)
			{
				socket.OnOpen = delegate()
				{
				};
				socket.OnClose = delegate()
				{
				};
				socket.OnMessage = delegate(string message)
				{
					try
					{
						ModelIn modelIn = JsonConvert.DeserializeObject<ModelIn>(message);
						ModelOut modelOut = new ModelOut();
						modelOut.MethodName = modelIn.MethodName;
						string methodName = modelIn.MethodName;
						if (!(methodName == "OpenDevice"))
						{
							if (!(methodName == "ReadSSSECard"))
							{
								if (!(methodName == "ReadIDCard"))
								{
									if (!(methodName == "ReadM1Card"))
									{
										if (!(methodName == "ReadBankCard"))
										{
											if (!(methodName == "CloseDevice"))
											{
												modelOut.RespCode = -6;
											}
											else
											{
												int num = ReadCard.closedevice();
												modelOut.RespCode = num;
											}
										}
										else
										{
											StringBuilder stringBuilder = new StringBuilder(256);
											int num = ReadCard.ss_bankCard_Read(stringBuilder);
											if (num == 0)
											{
												modelOut.RespData = stringBuilder.ToString();
											}
											modelOut.RespCode = num;
										}
									}
									else
									{
										M1Info respData = new M1Info();
										int num = ReadCard.ss_M1Card_Read(uint.Parse(modelIn.MethodData.Adr.ToString()), modelIn.MethodData.PassWord, out respData);
										if (num == 0)
										{
											modelOut.RespData = respData;
										}
										modelOut.RespCode = num;
									}
								}
								else
								{
									IDCardInfo respData2 = new IDCardInfo();
									int num = ReadCard.ss_IDCard_Read(out respData2);
									if (num == 0)
									{
										modelOut.RespData = respData2;
									}
									modelOut.RespCode = num;
								}
							}
							else
							{
								SocialSecurityCardInfo respData3 = new SocialSecurityCardInfo();
								int num = ReadCard.ss_socialCard_Read(out respData3);
								if (num == 0)
								{
									modelOut.RespData = respData3;
								}
								modelOut.RespCode = num;
							}
						}
						else
						{
							int num = ReadCard.opendevice();
							if (num > 0)
							{
								modelOut.RespCode = 0;
							}
							else
							{
								modelOut.RespCode = num;
							}
						}
						if (modelOut.RespCode != 0)
						{
							modelOut.RespData = ReadCard.GetCodeMsg(modelOut.RespCode);
						}
						string message2 = JsonConvert.SerializeObject(modelOut);
						socket.Send(message2);
					}
					catch (Exception ex)
					{
						this.WriteLog(ex.ToString());
					}
				};
			});
			base.Hide();
			base.ShowInTaskbar = false;
		}

		/// <summary>
		/// 退出
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void 退出程序ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("确定退出程序？\n\n退出后无法执行读卡操作！", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				this.IsCloseForm = true;
				base.Close();
			}
		}

        /// <summary>
        /// 显示界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void 显示界面ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Normal;
			base.Show();
		}


		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.IsCloseForm)
			{
				base.OnClosing(e);
				return;
			}
			base.Hide();
			e.Cancel = true;
		}

		private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			base.WindowState = FormWindowState.Normal;
			base.Show();
		}

	}
}
