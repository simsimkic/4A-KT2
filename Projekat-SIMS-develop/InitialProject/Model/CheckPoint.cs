using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Model

{
	public enum CheckPointType
	{
		Start = 1,
		Middle = 2,
		End = 3,

	}

	public class CheckPoint
	{
		public int ID { get; set; }
		public string Title { get; set; }
		public CheckPointType Type { get; set; }
		public bool IsCovered { get; set; } 


		public CheckPoint(CheckPoint checkPoint) { }

		public CheckPoint(int id, string title, CheckPointType type, bool isCovered)
		{
			this.ID = id;
			this.Title = title;
			this.Type = type;
			this.IsCovered = isCovered;
		}
		public string ToString()
		{
			return ID.ToString() + "," + Title + "," + Type.ToString() + "," + IsCovered.ToString();

		}

	}
}