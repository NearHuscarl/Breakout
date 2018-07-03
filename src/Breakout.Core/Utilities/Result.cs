using System;
using System.Diagnostics;

namespace Breakout.Core.Utilities
{
	/// <summary>
	/// Result class without return value. To be used instead of "void"
	/// </summary>
	public class Result
	{
		public Status Status { get; set; }
		public string Message { get; set; }
		public string InnerMessage { get; set; }
		public Exception Exception { get; set; }

		public Result()
		{

		}

		public Result(Status status)
		{
			this.Status = status;
		}

		public Result(Result result)
		{
			this.Status = result.Status;
			this.Message = result.Message;
			this.InnerMessage = result.InnerMessage;
			this.Exception = result.Exception;
		}

		public Result(string message, Status status = Status.NULL, Exception exception = null)
		{
			this.Status = status;
			this.Message = message;
			this.InnerMessage = "";
			this.Exception = exception;
		}

		public Result(string message, string innerMessage = "", Status status = Status.NULL, Exception exception = null)
		{
			this.Status = status;
			this.Message = message;
			this.InnerMessage = innerMessage;
			this.Exception = exception;
		}

		public void Print()
		{
			Debug.WriteLine($"Status: {Status}");
			Debug.WriteLine($"Message: {Message}");
			Debug.WriteLine($"Inner Message: {InnerMessage}");
			Debug.WriteLine($"Exception: {Exception}");
		}
	}

	/// <summary>
	/// Result class which can be used to return a value
	/// </summary>
	/// <typeparam name="T">The type of the value which is returned</typeparam>
	public class Result<T> : Result
	{
		public T Data { get; set; }

		public Result()
		{

		}

		public Result(T data)
		{
			this.Data = data;
		}

		public Result(Result result)
		{
			this.Status = result.Status;
			this.Message = result.Message;
			this.InnerMessage = result.InnerMessage;
			this.Exception = result.Exception;

		}

		public Result(string message, string innerMessage = "", Status status = Status.NULL, Exception exception = null)
		{
			this.Status = status;
			this.Message = message;
			this.InnerMessage = innerMessage;
			this.Exception = exception;
		}

		public Result(T data, Result result)
		{
			this.Status = result.Status;
			this.Message = result.Message;
			this.InnerMessage = result.InnerMessage;
			this.Exception = result.Exception;
			this.Data = data;

		}

		public Result(T data, string message, string innerMessage = "", Status status = Status.NULL, Exception exception = null)
		{
			this.Status = status;
			this.Message = message;
			this.InnerMessage = innerMessage;
			this.Exception = exception;
			this.Data = data;

		}

		public Result(T data, string message, Status status)
		{
			this.Data = data;
			this.Message = message;
			this.Status = status;
		}
	}

	/// <summary>
	/// Enumeration for a Status, to avoid using a boolean
	/// </summary>
	public enum Status
	{
		Success,
		Warning,
		Error,
		Information,
		NULL
	}
}
