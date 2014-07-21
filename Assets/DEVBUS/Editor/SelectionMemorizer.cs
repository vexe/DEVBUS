using UnityEditor;
using Object = UnityEngine.Object;
using DEVBUS;
using System;

/// <summary>
/// A simple utility class that memorizes object selection using BetterUndo.
/// Press Ctrl+Shift+- to go back, Ctrl+Shift+= to go forward
/// </summary>
[InitializeOnLoad]
public static class SelectionMemorizer
{
	private static Object[] previous = new Object[1] { null };
	private static bool isRunning;
	private const string MenuPath = "Tools/Vexe/SelectionMemorizer";
	private static BetterUndo undo = new BetterUndo();

	static SelectionMemorizer()
	{
		ToggleActive();
	}

	[MenuItem(MenuPath + "/Toggle StartStop")]
	public static void ToggleActive()
	{
		if (isRunning)
			EditorApplication.update -= Update;
		else
			EditorApplication.update += Update;
		isRunning = !isRunning;
	}

	[MenuItem(MenuPath + "/Select Last Object (Back) %#-")]
	public static void Back()
	{
		undo.Undo();
	}

	[MenuItem(MenuPath + "/Forward %#=")]
	public static void Forward()
	{
		undo.Redo();
	}

	static private void Update()
	{
		var current = Selection.objects;
		if (current != null)// && !current.IsEqualTo(previous))
		{
			Action a = () => previous = Selection.objects;
			undo.Register(new SelectionOperation
			{
				ToSelect = current,
				ToGoBackTo = previous,
				OnPerformed = a,
				OnUndone = a
			});
			previous = current;
		}
	}
}