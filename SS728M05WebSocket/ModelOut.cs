using System;

namespace SS728M05WebSocket
{
	public class ModelOut
	{
		public string MethodName { get; set; }

		public object RespData { get; set; }

		public int RespCode { get; set; }
	}
}
