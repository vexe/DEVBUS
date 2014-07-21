using UnityEngine;
using System;
using Object = UnityEngine.Object;
using DEVBUS;

namespace Vexe.Editor.Extensions
{
	public static class BetterUndoEditorExtensions
	{
		public static void RecordSelection(this BetterUndo undo, Object[] toSelect, Object[] toGoBackTo, Action onPerformed = null, Action onUndone = null)
		{
			undo.RegisterThenPerform(new SelectionOperation { ToSelect = toSelect, ToGoBackTo = toGoBackTo, OnPerformed = onPerformed, OnUndone = onUndone });
		}
		
		public static void RecordSelection(this BetterUndo undo, Object toSelect, Object toGoBackTo, Action onPerformed = null, Action onUndone = null)
		{
			undo.RegisterThenPerform(new SelectionOperation { ToSelect = new Object[] { toSelect }, ToGoBackTo = new Object[] { toGoBackTo }, OnPerformed = onPerformed, OnUndone = onUndone });
		}
	}
}