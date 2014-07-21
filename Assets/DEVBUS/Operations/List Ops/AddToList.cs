using System;

namespace DEVBUS
{
	/// <summary>
	/// Acts like InsertToList. Inserts the element at the end of the list
	/// </summary>
	public class AddToList<T> : InsertToList<T>
	{
		public override int Index
		{
			get { return List.Count; }
			set { throw new InvalidOperationException("Can't set index. You only add to the end of the list. If you want to specify an index, use InsertToList instead"); }
		}
	}
}