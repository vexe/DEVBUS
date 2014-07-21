namespace DEVBUS
{
	/// <summary>
	/// Clears a whole list - ClearList just inherits ClearRange and sets Count to List.Count when it performs the operation
	/// </summary>
	public class ClearList<T> : ClearRange<T>
	{
		/// <summary>
		/// Performs the clearning and executes OnPerformed afterwards
		/// </summary>
		public override void Perform()
		{
			Count = List.Count;
			base.Perform();
		}
	}
}