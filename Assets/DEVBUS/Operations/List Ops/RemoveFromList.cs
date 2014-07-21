using UnityEngine;

namespace DEVBUS
{
	/// <summary>
	/// Removes a single element from a list by means of an index or value
	/// </summary>
	public class RemoveFromList<T> : InsertToList<T>
	{
		/// <summary>
		/// Performs the removal
		/// </summary>
		public override void Perform()
		{
			base.Undo();
		}

		/// <summary>
		/// Undoes the removal (inserts back the element)
		/// </summary>
		public override void Undo()
		{
			base.Perform();
		}

		/// <summary>
		/// The value to remove
		/// </summary>
		public override T Value
		{
			get { return base.Value; }
			set
			{
				if (!index.HasValue)
					index = List.IndexOf(value);
				base.Value = value;
			}
		}

		/// <summary>
		/// The index of the value to remove
		/// </summary>
		public override int Index
		{
			get { return base.Index; }
			set
			{
				if (element == null)
					element = List[value];
				base.Index = value;
			}
		}
	}
}