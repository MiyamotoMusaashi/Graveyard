using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KeyAuth
{
	// Token: 0x02000002 RID: 2
	public class api
	{
		// Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00000258
		public api(string name, string ownerid, string secret, string version, string path = null)
		{
			if (ownerid.Length != 10 || secret.Length != 64)
			{
				Process.Start("https://youtube.com/watch?v=RfDTdiBq4_o");
				Process.Start("https://keyauth.cc/app/");
				Thread.Sleep(2000);
				api.error("Application not setup correctly. Please watch the YouTube video for setup.");
				Environment.Exit(0);
			}
			this.name = name;
			this.ownerid = ownerid;
			this.secret = secret;
			this.version = version;
			this.path = path;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002108 File Offset: 0x00000308
		public void init()
		{
			string text = encryption.iv_key();
			api.enckey = text + "-" + this.secret;
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "init";
			nameValueCollection["ver"] = this.version;
			nameValueCollection["hash"] = api.checksum(Process.GetCurrentProcess().MainModule.FileName);
			nameValueCollection["enckey"] = text;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			NameValueCollection nameValueCollection2 = nameValueCollection;
			if (!string.IsNullOrEmpty(this.path))
			{
				nameValueCollection2.Add("token", File.ReadAllText(this.path));
				nameValueCollection2.Add("thash", api.TokenHash(this.path));
			}
			string text2 = api.req(nameValueCollection2);
			if (text2 == "KeyAuth_Invalid")
			{
				api.error("Application not found");
				Environment.Exit(0);
			}
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				if (response_structure.newSession)
				{
					Thread.Sleep(100);
				}
				api.sessionid = response_structure.sessionid;
				this.initialized = true;
				return;
			}
			if (response_structure.message == "invalidver")
			{
				this.app_data.downloadLink = response_structure.download;
			}
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002264 File Offset: 0x00000464
		public static string TokenHash(string tokenPath)
		{
			string result;
			using (SHA256 sha = SHA256.Create())
			{
				using (FileStream fileStream = File.OpenRead(tokenPath))
				{
					result = BitConverter.ToString(sha.ComputeHash(fileStream)).Replace("-", string.Empty);
				}
			}
			return result;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000022D0 File Offset: 0x000004D0
		public void CheckInit()
		{
			if (!this.initialized)
			{
				api.error("You must run the function KeyAuthApp.init(); first");
				Environment.Exit(0);
			}
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000022EC File Offset: 0x000004EC
		public string expirydaysleft(string Type, int subscription)
		{
			this.CheckInit();
			DateTime d = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
			d = d.AddSeconds((double)long.Parse(this.user_data.subscriptions[subscription].expiry)).ToLocalTime();
			TimeSpan timeSpan = d - DateTime.Now;
			string a = Type.ToLower();
			if (a == "months")
			{
				return Convert.ToString(timeSpan.Days / 30);
			}
			if (a == "days")
			{
				return Convert.ToString(timeSpan.Days);
			}
			if (!(a == "hours"))
			{
				return null;
			}
			return Convert.ToString(timeSpan.Hours);
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000023A8 File Offset: 0x000005A8
		public void register(string username, string pass, string key, string email = "")
		{
			this.CheckInit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "register";
			nameValueCollection["username"] = username;
			nameValueCollection["pass"] = pass;
			nameValueCollection["key"] = key;
			nameValueCollection["email"] = email;
			nameValueCollection["hwid"] = value;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			string json = api.req(nameValueCollection);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(json);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				this.load_user_data(response_structure.info);
			}
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002480 File Offset: 0x00000680
		public void forgot(string username, string email)
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "forgot";
			nameValueCollection["username"] = username;
			nameValueCollection["email"] = email;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			string json = api.req(nameValueCollection);
			api.response_structure data = this.response_decoder.string_to_generic<api.response_structure>(json);
			this.load_response_struct(data);
		}

		// Token: 0x06000009 RID: 9 RVA: 0x0000250C File Offset: 0x0000070C
		public void login(string username, string pass)
		{
			this.CheckInit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "login";
			nameValueCollection["username"] = username;
			nameValueCollection["pass"] = pass;
			nameValueCollection["hwid"] = value;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			string json = api.req(nameValueCollection);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(json);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				this.load_user_data(response_structure.info);
			}
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000025C8 File Offset: 0x000007C8
		public void logout()
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "logout";
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			string json = api.req(nameValueCollection);
			api.response_structure data = this.response_decoder.string_to_generic<api.response_structure>(json);
			this.load_response_struct(data);
		}

		// Token: 0x0600000B RID: 11 RVA: 0x0000263C File Offset: 0x0000083C
		public void web_login()
		{
			this.CheckInit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			HttpListener httpListener;
			HttpListenerRequest request;
			HttpListenerResponse httpListenerResponse;
			for (;;)
			{
				httpListener = new HttpListener();
				string text = "handshake";
				text = "http://localhost:1337/" + text + "/";
				httpListener.Prefixes.Add(text);
				httpListener.Start();
				HttpListenerContext context = httpListener.GetContext();
				request = context.Request;
				httpListenerResponse = context.Response;
				httpListenerResponse.AddHeader("Access-Control-Allow-Methods", "GET, POST");
				httpListenerResponse.AddHeader("Access-Control-Allow-Origin", "*");
				httpListenerResponse.AddHeader("Via", "hugzho's big brain");
				httpListenerResponse.AddHeader("Location", "your kernel ;)");
				httpListenerResponse.AddHeader("Retry-After", "never lmao");
				httpListenerResponse.Headers.Add("Server", "\r\n\r\n");
				if (!(request.HttpMethod == "OPTIONS"))
				{
					break;
				}
				httpListenerResponse.StatusCode = 200;
				Thread.Sleep(1);
				httpListener.Stop();
			}
			httpListener.AuthenticationSchemes = AuthenticationSchemes.Negotiate;
			httpListener.UnsafeConnectionNtlmAuthentication = true;
			httpListener.IgnoreWriteExceptions = true;
			string text2 = request.RawUrl.Replace("/handshake?user=", "").Replace("&token=", " ");
			string value2 = text2.Split(Array.Empty<char>())[0];
			string value3 = text2.Split(new char[]
			{
				' '
			})[1];
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "login";
			nameValueCollection["username"] = value2;
			nameValueCollection["token"] = value3;
			nameValueCollection["hwid"] = value;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			string json = api.req(nameValueCollection);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(json);
			this.load_response_struct(response_structure);
			bool flag = true;
			if (response_structure.success)
			{
				this.load_user_data(response_structure.info);
				httpListenerResponse.StatusCode = 420;
				httpListenerResponse.StatusDescription = "SHEESH";
			}
			else
			{
				Console.WriteLine(response_structure.message);
				httpListenerResponse.StatusCode = 200;
				httpListenerResponse.StatusDescription = response_structure.message;
				flag = false;
			}
			byte[] bytes = Encoding.UTF8.GetBytes("Whats up?");
			httpListenerResponse.ContentLength64 = (long)bytes.Length;
			httpListenerResponse.OutputStream.Write(bytes, 0, bytes.Length);
			Thread.Sleep(1);
			httpListener.Stop();
			if (!flag)
			{
				Environment.Exit(0);
			}
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000028C8 File Offset: 0x00000AC8
		public void button(string button)
		{
			this.CheckInit();
			HttpListener httpListener = new HttpListener();
			string uriPrefix = "http://localhost:1337/" + button + "/";
			httpListener.Prefixes.Add(uriPrefix);
			httpListener.Start();
			HttpListenerContext context = httpListener.GetContext();
			HttpListenerRequest request = context.Request;
			HttpListenerResponse httpListenerResponse = context.Response;
			httpListenerResponse.AddHeader("Access-Control-Allow-Methods", "GET, POST");
			httpListenerResponse.AddHeader("Access-Control-Allow-Origin", "*");
			httpListenerResponse.AddHeader("Via", "hugzho's big brain");
			httpListenerResponse.AddHeader("Location", "your kernel ;)");
			httpListenerResponse.AddHeader("Retry-After", "never lmao");
			httpListenerResponse.Headers.Add("Server", "\r\n\r\n");
			httpListenerResponse.StatusCode = 420;
			httpListenerResponse.StatusDescription = "SHEESH";
			httpListener.AuthenticationSchemes = AuthenticationSchemes.Negotiate;
			httpListener.UnsafeConnectionNtlmAuthentication = true;
			httpListener.IgnoreWriteExceptions = true;
			httpListener.Stop();
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000029AC File Offset: 0x00000BAC
		public void upgrade(string username, string key)
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "upgrade";
			nameValueCollection["username"] = username;
			nameValueCollection["key"] = key;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			string json = api.req(nameValueCollection);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(json);
			response_structure.success = false;
			this.load_response_struct(response_structure);
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002A40 File Offset: 0x00000C40
		public void license(string key)
		{
			this.CheckInit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "license";
			nameValueCollection["key"] = key;
			nameValueCollection["hwid"] = value;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			string json = api.req(nameValueCollection);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(json);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				this.load_user_data(response_structure.info);
			}
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002AF0 File Offset: 0x00000CF0
		public void check()
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "check";
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			string json = api.req(nameValueCollection);
			api.response_structure data = this.response_decoder.string_to_generic<api.response_structure>(json);
			this.load_response_struct(data);
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002B64 File Offset: 0x00000D64
		public void setvar(string var, string data)
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "setvar";
			nameValueCollection["var"] = var;
			nameValueCollection["data"] = data;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			string json = api.req(nameValueCollection);
			api.response_structure data2 = this.response_decoder.string_to_generic<api.response_structure>(json);
			this.load_response_struct(data2);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002BF0 File Offset: 0x00000DF0
		public string getvar(string var)
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "getvar";
			nameValueCollection["var"] = var;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			string json = api.req(nameValueCollection);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(json);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				return response_structure.response;
			}
			return null;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002C80 File Offset: 0x00000E80
		public void ban(string reason = null)
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "ban";
			nameValueCollection["reason"] = reason;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			string json = api.req(nameValueCollection);
			api.response_structure data = this.response_decoder.string_to_generic<api.response_structure>(json);
			this.load_response_struct(data);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002D00 File Offset: 0x00000F00
		public string var(string varid)
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "var";
			nameValueCollection["varid"] = varid;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			string json = api.req(nameValueCollection);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(json);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				return response_structure.message;
			}
			return null;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002D90 File Offset: 0x00000F90
		public List<api.users> fetchOnline()
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "fetchOnline";
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			string json = api.req(nameValueCollection);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(json);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				return response_structure.users;
			}
			return null;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002E14 File Offset: 0x00001014
		public void fetchStats()
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "fetchStats";
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			string json = api.req(nameValueCollection);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(json);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				this.load_app_data(response_structure.appinfo);
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002E9C File Offset: 0x0000109C
		public List<api.msg> chatget(string channelname)
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "chatget";
			nameValueCollection["channel"] = channelname;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			string json = api.req(nameValueCollection);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(json);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				return response_structure.messages;
			}
			return null;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002F2C File Offset: 0x0000112C
		public bool chatsend(string msg, string channelname)
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "chatsend";
			nameValueCollection["message"] = msg;
			nameValueCollection["channel"] = channelname;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			string json = api.req(nameValueCollection);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(json);
			this.load_response_struct(response_structure);
			return response_structure.success;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002FC4 File Offset: 0x000011C4
		public bool checkblack()
		{
			this.CheckInit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "checkblacklist";
			nameValueCollection["hwid"] = value;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			string json = api.req(nameValueCollection);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(json);
			this.load_response_struct(response_structure);
			return response_structure.success;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00003060 File Offset: 0x00001260
		public string webhook(string webid, string param, string body = "", string conttype = "")
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "webhook";
			nameValueCollection["webid"] = webid;
			nameValueCollection["params"] = param;
			nameValueCollection["body"] = body;
			nameValueCollection["conttype"] = conttype;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			string json = api.req(nameValueCollection);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(json);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				return response_structure.response;
			}
			return null;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00003118 File Offset: 0x00001318
		public byte[] download(string fileid)
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "file";
			nameValueCollection["fileid"] = fileid;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			string json = api.req(nameValueCollection);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(json);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				return encryption.str_to_byte_arr(response_structure.contents);
			}
			return null;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000031B0 File Offset: 0x000013B0
		public void log(string message)
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "log";
			nameValueCollection["pcuser"] = Environment.UserName;
			nameValueCollection["message"] = message;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			api.req(nameValueCollection);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x0000322C File Offset: 0x0000142C
		public void changeUsername(string username)
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "changeUsername";
			nameValueCollection["newUsername"] = username;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			string json = api.req(nameValueCollection);
			api.response_structure data = this.response_decoder.string_to_generic<api.response_structure>(json);
			this.load_response_struct(data);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000032AC File Offset: 0x000014AC
		public static string checksum(string filename)
		{
			string result;
			using (MD5 md = MD5.Create())
			{
				using (FileStream fileStream = File.OpenRead(filename))
				{
					result = BitConverter.ToString(md.ComputeHash(fileStream)).Replace("-", "").ToLowerInvariant();
				}
			}
			return result;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x0000331C File Offset: 0x0000151C
		public static void LogEvent(string content)
		{
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location);
			string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "KeyAuth", "debug", fileNameWithoutExtension);
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			string path2 = string.Format("{0:MMM_dd_yyyy}_logs.txt", DateTime.Now);
			string text = Path.Combine(path, path2);
			try
			{
				JObject jobject = JsonConvert.DeserializeObject<JObject>(content);
				api.RedactField(jobject, "sessionid");
				api.RedactField(jobject, "ownerid");
				api.RedactField(jobject, "app");
				api.RedactField(jobject, "secret");
				api.RedactField(jobject, "version");
				api.RedactField(jobject, "fileid");
				api.RedactField(jobject, "webhooks");
				api.RedactField(jobject, "nonce");
				string arg = jobject.ToString(0, Array.Empty<JsonConverter>());
				using (StreamWriter streamWriter = File.AppendText(text))
				{
					streamWriter.WriteLine(string.Format("[{0}] [{1}] {2}", DateTime.Now, AppDomain.CurrentDomain.FriendlyName, arg));
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error logging data: " + ex.Message);
			}
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00003460 File Offset: 0x00001660
		private static void RedactField(JObject jsonObject, string fieldName)
		{
			JToken jtoken;
			if (jsonObject.TryGetValue(fieldName, ref jtoken))
			{
				jsonObject[fieldName] = "REDACTED";
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x0000348C File Offset: 0x0000168C
		public static void error(string message)
		{
			string path = "Logs";
			string text = Path.Combine(path, "ErrorLogs.txt");
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			if (!File.Exists(text))
			{
				using (File.Create(text))
				{
					File.AppendAllText(text, DateTime.Now.ToString() + " > This is the start of your error logs file");
				}
			}
			File.AppendAllText(text, DateTime.Now.ToString() + " > " + message + Environment.NewLine);
			Process.Start(new ProcessStartInfo("cmd.exe", "/c start cmd /C \"color b && title Error && echo " + message + " && timeout /t 5\"")
			{
				CreateNoWindow = true,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false
			});
			Environment.Exit(0);
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00003568 File Offset: 0x00001768
		private static string req(NameValueCollection post_data)
		{
			string result;
			try
			{
				using (WebClient webClient = new WebClient())
				{
					webClient.Proxy = null;
					ServicePointManager.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback)Delegate.Combine(ServicePointManager.ServerCertificateValidationCallback, new RemoteCertificateValidationCallback(api.assertSSL));
					Stopwatch stopwatch = new Stopwatch();
					stopwatch.Start();
					byte[] bytes = webClient.UploadValues("https://keyauth.win/api/1.2/", post_data);
					stopwatch.Stop();
					api.responseTime = stopwatch.ElapsedMilliseconds;
					ServicePointManager.ServerCertificateValidationCallback = ((object <p0>, X509Certificate <p1>, X509Chain <p2>, SslPolicyErrors <p3>) => true);
					api.sigCheck(Encoding.UTF8.GetString(bytes), webClient.ResponseHeaders["signature"], post_data.Get(0));
					api.LogEvent(Encoding.Default.GetString(bytes) + "\n");
					result = Encoding.Default.GetString(bytes);
				}
			}
			catch (WebException ex)
			{
				if (((HttpWebResponse)ex.Response).StatusCode == (HttpStatusCode)429)
				{
					api.error("You're connecting too fast to loader, slow down.");
					api.LogEvent("You're connecting too fast to loader, slow down.");
					Environment.Exit(0);
					result = "";
				}
				else
				{
					api.error("Connection failure. Please try again, or contact us for help.");
					api.LogEvent("Connection failure. Please try again, or contact us for help.");
					Environment.Exit(0);
					result = "";
				}
			}
			return result;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000036C0 File Offset: 0x000018C0
		private static bool assertSSL(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			if ((!certificate.Issuer.Contains("Google Trust Services") && !certificate.Issuer.Contains("Let's Encrypt")) || sslPolicyErrors != SslPolicyErrors.None)
			{
				api.error("SSL assertion fail, make sure you're not debugging Network. Disable internet firewall on router if possible. & echo: & echo If not, ask the developer of the program to use custom domains to fix this.");
				api.LogEvent("SSL assertion fail, make sure you're not debugging Network. Disable internet firewall on router if possible. If not, ask the developer of the program to use custom domains to fix this.");
				return false;
			}
			return true;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00003700 File Offset: 0x00001900
		private static void sigCheck(string resp, string signature, string type)
		{
			if (type == "log" || type == "file")
			{
				return;
			}
			try
			{
				if (!encryption.CheckStringsFixedTime(encryption.HashHMAC((type == "init") ? api.enckey.Substring(17, 64) : api.enckey, resp), signature))
				{
					api.error("Signature checksum failed. Request was tampered with or session ended most likely. & echo: & echo Response: " + resp);
					api.LogEvent(resp + "\n");
					Environment.Exit(0);
				}
			}
			catch
			{
				api.error("Signature checksum failed. Request was tampered with or session ended most likely. & echo: & echo Response: " + resp);
				api.LogEvent(resp + "\n");
				Environment.Exit(0);
			}
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000037BC File Offset: 0x000019BC
		private void load_app_data(api.app_data_structure data)
		{
			this.app_data.numUsers = data.numUsers;
			this.app_data.numOnlineUsers = data.numOnlineUsers;
			this.app_data.numKeys = data.numKeys;
			this.app_data.version = data.version;
			this.app_data.customerPanelLink = data.customerPanelLink;
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00003820 File Offset: 0x00001A20
		private void load_user_data(api.user_data_structure data)
		{
			this.user_data.username = data.username;
			this.user_data.ip = data.ip;
			this.user_data.hwid = data.hwid;
			this.user_data.createdate = data.createdate;
			this.user_data.lastlogin = data.lastlogin;
			this.user_data.subscriptions = data.subscriptions;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00003893 File Offset: 0x00001A93
		private void load_response_struct(api.response_structure data)
		{
			this.response.success = data.success;
			this.response.message = data.message;
		}

		// Token: 0x04000001 RID: 1
		public string name;

		// Token: 0x04000002 RID: 2
		public string ownerid;

		// Token: 0x04000003 RID: 3
		public string secret;

		// Token: 0x04000004 RID: 4
		public string version;

		// Token: 0x04000005 RID: 5
		public string path;

		// Token: 0x04000006 RID: 6
		public static long responseTime;

		// Token: 0x04000007 RID: 7
		private static string sessionid;

		// Token: 0x04000008 RID: 8
		private static string enckey;

		// Token: 0x04000009 RID: 9
		private bool initialized;

		// Token: 0x0400000A RID: 10
		public api.app_data_class app_data = new api.app_data_class();

		// Token: 0x0400000B RID: 11
		public api.user_data_class user_data = new api.user_data_class();

		// Token: 0x0400000C RID: 12
		public api.response_class response = new api.response_class();

		// Token: 0x0400000D RID: 13
		private json_wrapper response_decoder = new json_wrapper(new api.response_structure());

		// Token: 0x02000003 RID: 3
		[DataContract]
		private class response_structure
		{
			// Token: 0x17000001 RID: 1
			// (get) Token: 0x06000027 RID: 39 RVA: 0x000038B7 File Offset: 0x00001AB7
			// (set) Token: 0x06000028 RID: 40 RVA: 0x000038BF File Offset: 0x00001ABF
			[DataMember]
			public bool success { get; set; }

			// Token: 0x17000002 RID: 2
			// (get) Token: 0x06000029 RID: 41 RVA: 0x000038C8 File Offset: 0x00001AC8
			// (set) Token: 0x0600002A RID: 42 RVA: 0x000038D0 File Offset: 0x00001AD0
			[DataMember]
			public bool newSession { get; set; }

			// Token: 0x17000003 RID: 3
			// (get) Token: 0x0600002B RID: 43 RVA: 0x000038D9 File Offset: 0x00001AD9
			// (set) Token: 0x0600002C RID: 44 RVA: 0x000038E1 File Offset: 0x00001AE1
			[DataMember]
			public string sessionid { get; set; }

			// Token: 0x17000004 RID: 4
			// (get) Token: 0x0600002D RID: 45 RVA: 0x000038EA File Offset: 0x00001AEA
			// (set) Token: 0x0600002E RID: 46 RVA: 0x000038F2 File Offset: 0x00001AF2
			[DataMember]
			public string contents { get; set; }

			// Token: 0x17000005 RID: 5
			// (get) Token: 0x0600002F RID: 47 RVA: 0x000038FB File Offset: 0x00001AFB
			// (set) Token: 0x06000030 RID: 48 RVA: 0x00003903 File Offset: 0x00001B03
			[DataMember]
			public string response { get; set; }

			// Token: 0x17000006 RID: 6
			// (get) Token: 0x06000031 RID: 49 RVA: 0x0000390C File Offset: 0x00001B0C
			// (set) Token: 0x06000032 RID: 50 RVA: 0x00003914 File Offset: 0x00001B14
			[DataMember]
			public string message { get; set; }

			// Token: 0x17000007 RID: 7
			// (get) Token: 0x06000033 RID: 51 RVA: 0x0000391D File Offset: 0x00001B1D
			// (set) Token: 0x06000034 RID: 52 RVA: 0x00003925 File Offset: 0x00001B25
			[DataMember]
			public string download { get; set; }

			// Token: 0x17000008 RID: 8
			// (get) Token: 0x06000035 RID: 53 RVA: 0x0000392E File Offset: 0x00001B2E
			// (set) Token: 0x06000036 RID: 54 RVA: 0x00003936 File Offset: 0x00001B36
			[DataMember(IsRequired = false, EmitDefaultValue = false)]
			public api.user_data_structure info { get; set; }

			// Token: 0x17000009 RID: 9
			// (get) Token: 0x06000037 RID: 55 RVA: 0x0000393F File Offset: 0x00001B3F
			// (set) Token: 0x06000038 RID: 56 RVA: 0x00003947 File Offset: 0x00001B47
			[DataMember(IsRequired = false, EmitDefaultValue = false)]
			public api.app_data_structure appinfo { get; set; }

			// Token: 0x1700000A RID: 10
			// (get) Token: 0x06000039 RID: 57 RVA: 0x00003950 File Offset: 0x00001B50
			// (set) Token: 0x0600003A RID: 58 RVA: 0x00003958 File Offset: 0x00001B58
			[DataMember]
			public List<api.msg> messages { get; set; }

			// Token: 0x1700000B RID: 11
			// (get) Token: 0x0600003B RID: 59 RVA: 0x00003961 File Offset: 0x00001B61
			// (set) Token: 0x0600003C RID: 60 RVA: 0x00003969 File Offset: 0x00001B69
			[DataMember]
			public List<api.users> users { get; set; }
		}

		// Token: 0x02000004 RID: 4
		public class msg
		{
			// Token: 0x1700000C RID: 12
			// (get) Token: 0x0600003E RID: 62 RVA: 0x0000397A File Offset: 0x00001B7A
			// (set) Token: 0x0600003F RID: 63 RVA: 0x00003982 File Offset: 0x00001B82
			public string message { get; set; }

			// Token: 0x1700000D RID: 13
			// (get) Token: 0x06000040 RID: 64 RVA: 0x0000398B File Offset: 0x00001B8B
			// (set) Token: 0x06000041 RID: 65 RVA: 0x00003993 File Offset: 0x00001B93
			public string author { get; set; }

			// Token: 0x1700000E RID: 14
			// (get) Token: 0x06000042 RID: 66 RVA: 0x0000399C File Offset: 0x00001B9C
			// (set) Token: 0x06000043 RID: 67 RVA: 0x000039A4 File Offset: 0x00001BA4
			public string timestamp { get; set; }
		}

		// Token: 0x02000005 RID: 5
		public class users
		{
			// Token: 0x1700000F RID: 15
			// (get) Token: 0x06000045 RID: 69 RVA: 0x000039AD File Offset: 0x00001BAD
			// (set) Token: 0x06000046 RID: 70 RVA: 0x000039B5 File Offset: 0x00001BB5
			public string credential { get; set; }
		}

		// Token: 0x02000006 RID: 6
		[DataContract]
		private class user_data_structure
		{
			// Token: 0x17000010 RID: 16
			// (get) Token: 0x06000048 RID: 72 RVA: 0x000039BE File Offset: 0x00001BBE
			// (set) Token: 0x06000049 RID: 73 RVA: 0x000039C6 File Offset: 0x00001BC6
			[DataMember]
			public string username { get; set; }

			// Token: 0x17000011 RID: 17
			// (get) Token: 0x0600004A RID: 74 RVA: 0x000039CF File Offset: 0x00001BCF
			// (set) Token: 0x0600004B RID: 75 RVA: 0x000039D7 File Offset: 0x00001BD7
			[DataMember]
			public string ip { get; set; }

			// Token: 0x17000012 RID: 18
			// (get) Token: 0x0600004C RID: 76 RVA: 0x000039E0 File Offset: 0x00001BE0
			// (set) Token: 0x0600004D RID: 77 RVA: 0x000039E8 File Offset: 0x00001BE8
			[DataMember]
			public string hwid { get; set; }

			// Token: 0x17000013 RID: 19
			// (get) Token: 0x0600004E RID: 78 RVA: 0x000039F1 File Offset: 0x00001BF1
			// (set) Token: 0x0600004F RID: 79 RVA: 0x000039F9 File Offset: 0x00001BF9
			[DataMember]
			public string createdate { get; set; }

			// Token: 0x17000014 RID: 20
			// (get) Token: 0x06000050 RID: 80 RVA: 0x00003A02 File Offset: 0x00001C02
			// (set) Token: 0x06000051 RID: 81 RVA: 0x00003A0A File Offset: 0x00001C0A
			[DataMember]
			public string lastlogin { get; set; }

			// Token: 0x17000015 RID: 21
			// (get) Token: 0x06000052 RID: 82 RVA: 0x00003A13 File Offset: 0x00001C13
			// (set) Token: 0x06000053 RID: 83 RVA: 0x00003A1B File Offset: 0x00001C1B
			[DataMember]
			public List<api.Data> subscriptions { get; set; }
		}

		// Token: 0x02000007 RID: 7
		[DataContract]
		private class app_data_structure
		{
			// Token: 0x17000016 RID: 22
			// (get) Token: 0x06000055 RID: 85 RVA: 0x00003A24 File Offset: 0x00001C24
			// (set) Token: 0x06000056 RID: 86 RVA: 0x00003A2C File Offset: 0x00001C2C
			[DataMember]
			public string numUsers { get; set; }

			// Token: 0x17000017 RID: 23
			// (get) Token: 0x06000057 RID: 87 RVA: 0x00003A35 File Offset: 0x00001C35
			// (set) Token: 0x06000058 RID: 88 RVA: 0x00003A3D File Offset: 0x00001C3D
			[DataMember]
			public string numOnlineUsers { get; set; }

			// Token: 0x17000018 RID: 24
			// (get) Token: 0x06000059 RID: 89 RVA: 0x00003A46 File Offset: 0x00001C46
			// (set) Token: 0x0600005A RID: 90 RVA: 0x00003A4E File Offset: 0x00001C4E
			[DataMember]
			public string numKeys { get; set; }

			// Token: 0x17000019 RID: 25
			// (get) Token: 0x0600005B RID: 91 RVA: 0x00003A57 File Offset: 0x00001C57
			// (set) Token: 0x0600005C RID: 92 RVA: 0x00003A5F File Offset: 0x00001C5F
			[DataMember]
			public string version { get; set; }

			// Token: 0x1700001A RID: 26
			// (get) Token: 0x0600005D RID: 93 RVA: 0x00003A68 File Offset: 0x00001C68
			// (set) Token: 0x0600005E RID: 94 RVA: 0x00003A70 File Offset: 0x00001C70
			[DataMember]
			public string customerPanelLink { get; set; }

			// Token: 0x1700001B RID: 27
			// (get) Token: 0x0600005F RID: 95 RVA: 0x00003A79 File Offset: 0x00001C79
			// (set) Token: 0x06000060 RID: 96 RVA: 0x00003A81 File Offset: 0x00001C81
			[DataMember]
			public string downloadLink { get; set; }
		}

		// Token: 0x02000008 RID: 8
		public class app_data_class
		{
			// Token: 0x1700001C RID: 28
			// (get) Token: 0x06000062 RID: 98 RVA: 0x00003A8A File Offset: 0x00001C8A
			// (set) Token: 0x06000063 RID: 99 RVA: 0x00003A92 File Offset: 0x00001C92
			public string numUsers { get; set; }

			// Token: 0x1700001D RID: 29
			// (get) Token: 0x06000064 RID: 100 RVA: 0x00003A9B File Offset: 0x00001C9B
			// (set) Token: 0x06000065 RID: 101 RVA: 0x00003AA3 File Offset: 0x00001CA3
			public string numOnlineUsers { get; set; }

			// Token: 0x1700001E RID: 30
			// (get) Token: 0x06000066 RID: 102 RVA: 0x00003AAC File Offset: 0x00001CAC
			// (set) Token: 0x06000067 RID: 103 RVA: 0x00003AB4 File Offset: 0x00001CB4
			public string numKeys { get; set; }

			// Token: 0x1700001F RID: 31
			// (get) Token: 0x06000068 RID: 104 RVA: 0x00003ABD File Offset: 0x00001CBD
			// (set) Token: 0x06000069 RID: 105 RVA: 0x00003AC5 File Offset: 0x00001CC5
			public string version { get; set; }

			// Token: 0x17000020 RID: 32
			// (get) Token: 0x0600006A RID: 106 RVA: 0x00003ACE File Offset: 0x00001CCE
			// (set) Token: 0x0600006B RID: 107 RVA: 0x00003AD6 File Offset: 0x00001CD6
			public string customerPanelLink { get; set; }

			// Token: 0x17000021 RID: 33
			// (get) Token: 0x0600006C RID: 108 RVA: 0x00003ADF File Offset: 0x00001CDF
			// (set) Token: 0x0600006D RID: 109 RVA: 0x00003AE7 File Offset: 0x00001CE7
			public string downloadLink { get; set; }
		}

		// Token: 0x02000009 RID: 9
		public class user_data_class
		{
			// Token: 0x17000022 RID: 34
			// (get) Token: 0x0600006F RID: 111 RVA: 0x00003AF0 File Offset: 0x00001CF0
			// (set) Token: 0x06000070 RID: 112 RVA: 0x00003AF8 File Offset: 0x00001CF8
			public string username { get; set; }

			// Token: 0x17000023 RID: 35
			// (get) Token: 0x06000071 RID: 113 RVA: 0x00003B01 File Offset: 0x00001D01
			// (set) Token: 0x06000072 RID: 114 RVA: 0x00003B09 File Offset: 0x00001D09
			public string ip { get; set; }

			// Token: 0x17000024 RID: 36
			// (get) Token: 0x06000073 RID: 115 RVA: 0x00003B12 File Offset: 0x00001D12
			// (set) Token: 0x06000074 RID: 116 RVA: 0x00003B1A File Offset: 0x00001D1A
			public string hwid { get; set; }

			// Token: 0x17000025 RID: 37
			// (get) Token: 0x06000075 RID: 117 RVA: 0x00003B23 File Offset: 0x00001D23
			// (set) Token: 0x06000076 RID: 118 RVA: 0x00003B2B File Offset: 0x00001D2B
			public string createdate { get; set; }

			// Token: 0x17000026 RID: 38
			// (get) Token: 0x06000077 RID: 119 RVA: 0x00003B34 File Offset: 0x00001D34
			// (set) Token: 0x06000078 RID: 120 RVA: 0x00003B3C File Offset: 0x00001D3C
			public string lastlogin { get; set; }

			// Token: 0x17000027 RID: 39
			// (get) Token: 0x06000079 RID: 121 RVA: 0x00003B45 File Offset: 0x00001D45
			// (set) Token: 0x0600007A RID: 122 RVA: 0x00003B4D File Offset: 0x00001D4D
			public List<api.Data> subscriptions { get; set; }
		}

		// Token: 0x0200000A RID: 10
		public class Data
		{
			// Token: 0x17000028 RID: 40
			// (get) Token: 0x0600007C RID: 124 RVA: 0x00003B56 File Offset: 0x00001D56
			// (set) Token: 0x0600007D RID: 125 RVA: 0x00003B5E File Offset: 0x00001D5E
			public string subscription { get; set; }

			// Token: 0x17000029 RID: 41
			// (get) Token: 0x0600007E RID: 126 RVA: 0x00003B67 File Offset: 0x00001D67
			// (set) Token: 0x0600007F RID: 127 RVA: 0x00003B6F File Offset: 0x00001D6F
			public string expiry { get; set; }

			// Token: 0x1700002A RID: 42
			// (get) Token: 0x06000080 RID: 128 RVA: 0x00003B78 File Offset: 0x00001D78
			// (set) Token: 0x06000081 RID: 129 RVA: 0x00003B80 File Offset: 0x00001D80
			public string timeleft { get; set; }
		}

		// Token: 0x0200000B RID: 11
		public class response_class
		{
			// Token: 0x1700002B RID: 43
			// (get) Token: 0x06000083 RID: 131 RVA: 0x00003B89 File Offset: 0x00001D89
			// (set) Token: 0x06000084 RID: 132 RVA: 0x00003B91 File Offset: 0x00001D91
			public bool success { get; set; }

			// Token: 0x1700002C RID: 44
			// (get) Token: 0x06000085 RID: 133 RVA: 0x00003B9A File Offset: 0x00001D9A
			// (set) Token: 0x06000086 RID: 134 RVA: 0x00003BA2 File Offset: 0x00001DA2
			public string message { get; set; }
		}
	}
}
