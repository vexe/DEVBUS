using System;
using UnityEditor;
using UnityEngine;
using DEVBUS;

namespace DEVBUS
{
	public static class BetterUndoMenuItems
	{
		private const string MenuPath = "Tools/Vexe/BetterUndo";
		private static BetterUndo current { get { return BetterUndo.Current; } }

		[MenuItem(MenuPath + "/Undo %&u")]
		public static void Undo()
		{
			current.Undo();
		}

		[MenuItem(MenuPath + "/Redo %&r")]
		public static void Redo()
		{
			current.Redo();
		}

		[MenuItem(MenuPath + "/Print Undo stack length")]
		public static void PrintUndoStackLength()
		{
			Debug.Log(current.UndoStackLength);
		}
	}
}