﻿using System;

namespace ConsoleApp1
{
	public class MessageInputModel
	{
		public int FromId { get; set; }
		public int ToId { get; set; }
		public string Content { get; set; }
		public DateTime CreateAt { get; set; } = DateTime.Now;
	}
}
