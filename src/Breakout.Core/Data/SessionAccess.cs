using Breakout.Core.Models.Data;
using Breakout.Core.Utilities;
using System;
using System.IO;
using System.Xml.Serialization;

namespace Breakout.Core.Data
{
	public class SessionAccess
	{
		public Result<Session> LoadSession()
		{
			try
			{
				Session session = new Session();

				using (FileStream stream = new FileStream(Session.FullPath, FileMode.Open))
				{
					XmlSerializer serializer = new XmlSerializer(typeof(Session));
					session = serializer.Deserialize(stream) as Session;
				}

				return new Result<Session>(session, "Loading successful", "", Status.Success);
			}
			catch (Exception ex)
			{
				return new Result<Session>(Session.Default, "Error occured on loading session", "", Status.Error, ex);
			}
		}

		public Result SaveSession(Session settings)
		{
			try
			{
				if (!Directory.Exists(Session.Directory))
					Directory.CreateDirectory(Session.Directory);

				using (FileStream stream = new FileStream(Session.FullPath, FileMode.Create))
				{
					XmlSerializer serializer = new XmlSerializer(typeof(Session));
					serializer.Serialize(stream, settings);
				}

				return new Result(Status.Success);
			}
			catch (Exception ex)
			{
				return new Result("Error occured on saving session", Status.Error, ex);
			}
		}
	}
}
