using System;
using System.Collections;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using mshtml;
using SHDocVw;

namespace jcTBot
{
	public class Program
	{
		[STAThread]
		public static int Main(string[] args)
		{
			String loginUrl = ConfigurationManager.AppSettings["loginUrl"];
			String resourcesUrl = ConfigurationManager.AppSettings["resourcesUrl"];
			String resourcesBuildUrl = ConfigurationManager.AppSettings["resourcesBuildUrl"];
			String buildingsUrl = ConfigurationManager.AppSettings["buildingsUrl"];
			String sendUnitsUrl = ConfigurationManager.AppSettings["sendUnitsUrl"];
			String loginUsername = ConfigurationManager.AppSettings["loginUsername"];
			String loginPassword = ConfigurationManager.AppSettings["loginPassword"];
			//String loginUsername = "jezonsky";
			//String loginPassword = "pimpek";
			String fileAttacks = ConfigurationManager.AppSettings["fileAttacks"];
			String fileDistribution = ConfigurationManager.AppSettings["fileDistribution"];
			String fileResources = ConfigurationManager.AppSettings["fileResources"];
			String fileBuildings = ConfigurationManager.AppSettings["fileBuildings"];

			const bool enableAttacks = true;
			const bool enableDistribution = true;
			const bool enableResources = false;
			const bool enableBuildings = true;
			try
			{
				InternetExplorer ie = new InternetExplorerClass();

				HTMLDocument myDoc = Login(ie, loginUrl, loginUsername, loginPassword);

				String bodyData = myDoc.body.innerText;
				bool logedIn = IsLogenIn(bodyData);
				if (!logedIn)
				{
					Console.Write("Not Loged In!!!");
					Console.WriteLine(bodyData);
					Login(ie, loginUrl, loginUsername, loginPassword);
					return 0;
				}

				int i = 0;
				do
				{
					if (!logedIn)
					{
						Console.Write("Not Loged In!!!");
						Console.WriteLine(bodyData);
						Login(ie, loginUrl, loginUsername, loginPassword);
					}
					else
					{
						#region attacks
						using (StreamReader sr = new StreamReader(fileAttacks))
						{
							while (enableAttacks && (sr.Peek() >= 0))
							{
								String line = sr.ReadLine();
								if ((!line.StartsWith("#")) && (line.Length > 5))
								{
									String[] sections = line.Split('|');
									String time = sections[0];
									//String sourceX = sections[1];
									//String sourceY = sections[2];
									String destinationX = sections[3];
									String destinationY = sections[4];
									String attackType = sections[5];
									String[] troopList = sections[6].Split(',');
									String villageID = sections[7];
									//String attackID = sections[8];
									String enabled = sections[9];
									String timenow = DateTime.Now.ToString("HH:mm");
									//Console.WriteLine(timenow + "//" + line);
									if ( (enabled.Equals("1")) && (timenow.Equals(time)) )
									{
										Console.WriteLine("\n\rtimenow=" + timenow);
										Random rnd = new Random();
										Int32 parA = rnd.Next(10001, 99999);
										StringBuilder troops = new StringBuilder();
										for (int t=0;t<11;t++)
										{
											troops.AppendFormat("&t{0}={1}", (t + 1), troopList[t]);
										}
										/*
										 * if i understund this .... :)
										 * 
										 * tolko teoria, mas tam vsak este volania js fcie xy(), 
										 * ktora sa mi nepaci uz koli jej nazvu :Very Happy. 
										 * Ale ak nerobi ziadne vylomeniny, 
										 * tak ti staci premennu s1.x naplnat nahodnymi cislami od 0 do 79 
										 * a s1.y nahodnymi cislami od 0 do 19 (popripade konstantami)... a mas pokoj										 
										 */
										String attackID =
											String.Format("&s1.x={0}&s1.y={1}&s1=ok", rnd.Next(0, 79), rnd.Next(0, 19));
										String parPost = 
											String.Format(CultureInfo.InvariantCulture, 
											"id=39&a={0}&c={1}&kid={2}{3}{4}",
											parA, 
											attackType, 
											CovertXY(Int32.Parse(destinationX), Int32.Parse(destinationY)),
											troops,
											attackID
											);
										Console.WriteLine("ATTACK:" + parPost);
										object flags = null;
										object headers = "Content-Type: application/x-www-form-urlencoded\n\r";
										object name = null;
										object data = Encoding.ASCII.GetBytes(parPost); 
										ie.Navigate(sendUnitsUrl + villageID, ref flags, ref name, ref data, ref headers);
										WaitForComplete(ie);
										Thread.Sleep(500);
									}
								}
							}
						}
						#endregion
						
						#region distribution
						using (StreamReader sr = new StreamReader(fileDistribution))
						{
							while (enableDistribution && (sr.Peek() >= 0))
							{
								String line = sr.ReadLine();
								if ((!line.StartsWith("#")) && (line.Length > 5))
								{
									//id=33&r1=&r2=750&r3=1500&r4=&dname=&x=-27&y=-71&s1.x=26&s1.y=13&s1=ok
									String[] sections = line.Split('|');
									String time = sections[0];
									String destinationX = sections[1];
									String destinationY = sections[2];
									String marketId = sections[3];
									String[] resourcesList = sections[4].Split(',');
									//String distributionID = sections[7];
									String villageID = sections[5];
									String enabled = sections[6];
									String timenow = DateTime.Now.ToString("HH:mm");
									if ((enabled.Equals("1")) && (timenow.Equals(time)))
									{
										StringBuilder resources = new StringBuilder();
										for (int r = 0; r < 4; r++)
										{
											resources.AppendFormat("&r{0}={1}", (r + 1), resourcesList[r]);
										}
										Random rnd = new Random();
										String distributionID =
											String.Format("&s1.x={0}&s1.y={1}&s1=ok", rnd.Next(0, 79), rnd.Next(0, 19));
										String parPost =
											String.Format(CultureInfo.InvariantCulture,
											              "id={0}{1}&dname=&x={2}&y={3}{4}",
											              marketId,
											              resources,
											              destinationX,
											              destinationY,
											              distributionID
												);
										Console.WriteLine("\n\rSEND:" + parPost);
										object flags = null;
										object headers = "Content-Type: application/x-www-form-urlencoded\n\r";
										object name = null;
										object data = Encoding.ASCII.GetBytes(parPost);
										//http://s3.travian.si/build.php?newdid=100227&gid=17&id=33
										String url = String.Format("{0}{1}&gid=17&id={2}", resourcesBuildUrl, villageID, marketId);
										ie.Navigate(url, ref flags, ref name, ref data, ref headers);
									}
								}
							}
						}

						#endregion

						//#region resources
						////<h1><b>�itno polje Stopnja 6</b></h1>
						////String headName;
						////myDoc = Browse("http://s1.travian.si/build.php?id=1", ie);
						////headName = Find.TagByName(ie, "h1");
						////Console.WriteLine("headName=" + headName);
						////myDoc = Browse("http://s1.travian.si/build.php?id=2", ie);
						////headName = Find.TagByName(ie, "h1");
						////Console.WriteLine("headName=" + headName);
						////myDoc = Browse("http://s1.travian.si/build.php?id=3", ie);
						////headName = Find.TagByName(ie, "h1");
						////Console.WriteLine("headName=" + headName);
						//ArrayList resourcesCollection = new ArrayList();

						//for (int r = 1; r < 19; r++)
						//{
						//    String headName;
						//    myDoc = Browse(resourcesBuildUrl + "?id=" + r, ie);
						//    headName = Find.TagByName(ie, "h1");
						//    String[] resColl = headName.Split(' ');
						//    //Console.WriteLine(r + "\theadName=" + headName);
						//    String resource = null;
						//    resource = GetResourceName(headName, resource);
						//    resourcesCollection.Add(r + "|" + resource + "|" + resColl[resColl.Length - 1]);
						//}

						//foreach (string col in resourcesCollection)
						//{
						//    Console.WriteLine(col);
						//}

						//using (StreamReader sr = new StreamReader(fileResources))
						//{
						//    while (sr.Peek() >= 0)
						//    {
						//        String line = sr.ReadLine();
						//        if ((!line.StartsWith("#")) && (line.Length > 5))
						//        {
						//            //villageID|resource|level|||
						//            //Gozdar
						//            //Zitno polje
						//            //Rudnik zeleza
						//            //Glinokop
						//            String[] sections = line.Split('|');
						//            String villageID = sections[0];
						//            String resourceName = sections[1];
						//            Int32 resourceLevel = Int32.Parse(sections[2]);


						//        }
						//    }
						//}

						//#endregion

						#region buildings
						using (StreamReader sr = new StreamReader(fileBuildings))
						{
							while ( (i % 10 == 0) && enableBuildings && (sr.Peek() >= 0))
							{
								String line = sr.ReadLine();
								if ((!line.StartsWith("#")) && (line.Length > 5))
								{
									//villageID|buildingID|level|enabled
									String[] sections = line.Split('|');
									String villageID = sections[0];
									String buildingID = sections[1];
									Int32 level = Int32.Parse(sections[2]);
									String enabled = sections[3];
									Browse(buildingsUrl + villageID, ie);
									WaitForComplete(ie);
									Browse(resourcesBuildUrl + buildingID, ie);
									WaitForComplete(ie);
									String headName;
									headName = Find.TagByName(ie, "h1");
									String[] head = headName.Split(' ');
									Int32 buildingLevel = Int32.Parse(head[head.Length - 1]);
									if (!enabled.Equals("1"))
									{
										continue;
									}
									if (buildingLevel < level)
									{
										Console.WriteLine("Trying to upgrade " + headName);
										String link;
										link = Find.AttributeByTagName(ie, "a", "href");
										if (!link.Equals("xxxx"))
										{
											Console.WriteLine("Upgrading " + headName);
											Browse(link, ie);
										}
									}
								}
							}
						}

						#endregion

						Thread.Sleep(60000);
					}

					Console.Write(".");
					Browse(buildingsUrl, ie);
					myDoc = Browse(resourcesUrl, ie);
					bodyData = myDoc.body.innerText;
					logedIn = IsLogenIn(bodyData);
					
					i++;
					if ( i > 1000 )
					{
						i = 0;
					}

				} while (true);

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
			finally
			{
				Console.WriteLine("EXIT");
			}
			return 0;
		}

		private static string GetResourceName(string headName, string resource)
		{
			if (headName.StartsWith("Gozdar"))
			{
				resource = "WOOD";
			}
			else if (headName.IndexOf("polje") > -1)
			{
				resource = "CROP";
			}
			else if (headName.StartsWith("Rudnik"))
			{
				resource = "IRON";
			}
			else
			{
				resource = "CLAY";
			}
			return resource;
		}

		private static Int32 CovertXY(Int32 x, Int32 y)
		{
			return ((x + 401) + ((400 - y) * 801));
		}

		private static HTMLDocument Browse(String resourcesUrl, IWebBrowser2 ie)
		{
			object flags = null;
			object headers = null;
			object name = null;
			object data = null;
			ie.Navigate(resourcesUrl, ref flags, ref name, ref data, ref headers);
			WaitForComplete(ie);
			HTMLDocument myDoc = (HTMLDocument)ie.Document;
			return myDoc;
		}

		private static bool IsLogenIn(String bodyData)
		{
			//Console.WriteLine("LogIn Check... ");
			bool isLogedIn = false;
			if (bodyData.Contains("Proizvodnja:"))
			{
				isLogedIn = true;
			}
			return isLogedIn;
		}

		private static HTMLDocument Login(InternetExplorer ie, string loginUrl, string loginUsername, string loginPassword)
		{
			Console.WriteLine("Login to '"+loginUrl+"' as '"+loginUsername+"' ('"+loginPassword+"')");
			object nil = null;
			ie.Navigate(loginUrl, ref nil, ref nil, ref nil, ref nil);
			WaitForComplete(ie);
			//Console.WriteLine(ie.Document);
			//Find username textbox
			HTMLDocument myDoc = (HTMLDocument)ie.Document;
			String loginUsernameTextBoxName = Find.InputTagByType(ie, "text");
			if (loginUsernameTextBoxName.Equals("xxxx"))
			{
				Console.WriteLine(myDoc.body.innerText);
				return myDoc;
			}
			//Console.WriteLine("Username TextBox Name = '" + loginUsernameTextBoxName + "'");
			//String loginUsernameTextBoxValue = Find.TextBoxValue(ie, "text", loginUsernameTextBoxName);
			//Console.WriteLine("Username TextBox Value = '" + loginUsernameTextBoxValue + "'");
			HTMLInputElement loginUsernameTextBox = 
				(HTMLInputElement)myDoc.all.item(loginUsernameTextBoxName, 0);
			loginUsernameTextBox.value = loginUsername;
			//String loginUsernameTextBoxNewValue = Find.TextBoxValue(ie, "text", loginUsernameTextBoxName);
			//Console.WriteLine("Username TextBox Value = '" + loginUsernameTextBoxNewValue + "'");
			//Find password textbox
			String loginPasswordTextBoxName = Find.InputTagByType(ie, "password");
			//Console.WriteLine("Password TextBox Name = '" + loginPasswordTextBoxName + "'");
			//String loginPasswordTextBoxValue = Find.TextBoxValue(ie, "password", loginPasswordTextBoxName);
			//Console.WriteLine("Password TextBox Value = '" + loginPasswordTextBoxValue + "'");
			myDoc = (HTMLDocument)ie.Document;
			HTMLInputElement loginPasswordTextBox = 
				(HTMLInputElement)myDoc.all.item(loginPasswordTextBoxName, 0);
			loginPasswordTextBox.value = loginPassword;
			//String loginPasswordTextBoxNewValue = Find.TextBoxValue(ie, "password", loginPasswordTextBoxName);
			//Console.WriteLine("Password TextBox Value = '" + loginPasswordTextBoxNewValue + "'");
			//Find login button
			String loginImageButtonName = Find.InputTagByType(ie, "image");
			//Console.WriteLine("Login Image Name = '" + loginImageButtonName + "'");
			myDoc = (HTMLDocument)ie.Document;
			HTMLInputElement loginImageButton = 
				(HTMLInputElement)myDoc.all.item(loginImageButtonName, 0);
			loginImageButton.click();
			WaitForComplete(ie);
			return myDoc;
		}

		private static void WaitForComplete(IWebBrowser2 ieWAIT)
		{
			do
			{
				Thread.Sleep(500);
			} while (ieWAIT.ReadyState != tagREADYSTATE.READYSTATE_COMPLETE);
		}

	}
}