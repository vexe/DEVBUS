namespace DEVBUS
{
	/// <summary>
	/// List element insertion operation
	/// </summary>
	public class InsertToList<T> : ListOperation<T>
	{
		protected int? index;
		protected T element;

		/// <summary>
		/// The index of which to insert the element at
		/// </summary>
		public virtual int Index { get { return index.Value; } set { index = value; } }

		/// <summary>
		/// The element to insert value
		/// </summary>
		public virtual T Value { get { return element; } set { element = value; } }

		/// <summary>
		/// Performs the insertion operation and executes OnPerformed
		/// </summary>
		public override void Perform()
		{
			List.Insert(Index, Value);
			base.Perform();
		}

		/// <summary>
		/// Undoes the insertion (removes the element) and executes OnUndone
		/// </summary>
		public override void Undo()
		{
			List.RemoveAt(Index - (Index == List.Count ? 1 : 0));
			base.Undo();
		}
	}
}