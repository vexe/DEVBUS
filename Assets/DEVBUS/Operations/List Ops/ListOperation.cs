using System;
using System.Collections.Generic;

namespace DEVBUS
{
	/// <summary>
	/// A base for generic list operations
	/// </summary>
	public abstract class ListOperation<T> : BasicOperation
	{
		/// <summary>
		/// The list getter/setter
		/// </summary>
		public Func<List<T>> GetList { get; set; }

		protected List<T> List
		{
			set { GetList = () => value; }
			get { return GetList(); }
		}
	}
}