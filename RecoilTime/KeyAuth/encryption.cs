using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace KeyAuth
{
	// Token: 0x0200000D RID: 13
	public static class encryption
	{
		// Token: 0x0600008B RID: 139 RVA: 0x00003BBC File Offset: 0x00001DBC
		public static string HashHMAC(string enckey, string resp)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(enckey);
			byte[] bytes2 = Encoding.UTF8.GetBytes(resp);
			return encryption.byte_arr_to_str(new HMACSHA256(bytes).ComputeHash(bytes2));
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00003BF0 File Offset: 0x00001DF0
		public static string byte_arr_to_str(byte[] ba)
		{
			StringBuilder stringBuilder = new StringBuilder(ba.Length * 2);
			foreach (byte b in ba)
			{
				stringBuilder.AppendFormat("{0:x2}", b);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00003C34 File Offset: 0x00001E34
		public static byte[] str_to_byte_arr(string hex)
		{
			byte[] result;
			try
			{
				int length = hex.Length;
				byte[] array = new byte[length / 2];
				for (int i = 0; i < length; i += 2)
				{
					array[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
				}
				result = array;
			}
			catch
			{
				api.error("The session has ended, open program again.");
				Environment.Exit(0);
				result = null;
			}
			return result;
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00003C9C File Offset: 0x00001E9C
		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public static bool CheckStringsFixedTime(string str1, string str2)
		{
			if (str1.Length != str2.Length)
			{
				return false;
			}
			int num = 0;
			for (int i = 0; i < str1.Length; i++)
			{
				num |= (int)(str1[i] ^ str2[i]);
			}
			return num == 0;
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00003CE4 File Offset: 0x00001EE4
		public static string iv_key()
		{
			return Guid.NewGuid().ToString().Substring(0, 16);
		}
	}
}
