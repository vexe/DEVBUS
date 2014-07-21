using UnityEditor;
using UnityEngine;

namespace DEVBUS
{
	public class SelectionOperation : BasicOperation
	{
		public Object[] ToSelect { get; set; }
		public Object[] ToGoBackTo { get; set; }

		public override void Perform()
		{
			SelectObjects(ToSelect);
			base.Perform();
		}

		public override void Undo()
		{
			SelectObjects(ToGoBackTo);
			base.Undo();
		}

		private void SelectObjects(Object[] objects)
		{
			Selection.objects = objects;
		}
	}
}