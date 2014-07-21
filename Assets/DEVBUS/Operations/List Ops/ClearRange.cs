using System;

namespace DEVBUS
{
	/// <summary>
	/// A list operations that clears a certain range within that list by means of a start index and a count or an end index
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class ClearRange<T> : ListOperation<T>
	{
		private BetterUndo internalUndo = new BetterUndo();

		/// <summary>
		/// The start index
		/// </summary>
		public int Start { get; set; }

		/// <summary>
		/// How many elements to go starting from 'Start'
		/// </summary>
		public int? Count { get; set; }

		/// <summary>
		/// The end index. If Count is defined, it is used and the end index is ignored
		/// </summary>
		public int? End { get; set; }

		private int Length
		{
			get
			{
				if (Count.HasValue)
					return Count.Value;
				if (End.HasValue)
					return (End - Start).Value;
				throw new InvalidOperationException("Couldn't determine the length of the range to clear. Either a Count or an End index has to be specified");
			}
		}

		/// <summary>
		/// Performs the clearing of the range and executes OnPerformed afterwards
		/// </summary>
		public override void Perform()
		{
			for (int i = 0; i < Length; i++)
			{
				internalUndo.RecordRemoveFromList(GetList, Start);
			}
			base.Perform();
		}

		/// <summary>
		/// Undoes the clearning of the range and executes OnUndone afterwards
		/// </summary>
		public override void Undo()
		{
			internalUndo.Undo(Length);
			base.Undo();
		}
	}
}