using System;
using UnityEngine;

public class EventHandle
{

	public static event Action EventChangeScene;
	public static void CallEventChangeScene()
	{
		Action events = EventHandle.EventChangeScene;
		if (events == null)
		{
			return;
		}
		events();
	}
	public static event Action<int> EventShowLineTip;
	public static void CallEventShowLineTip(int index)
	{
		Action<int>events = EventHandle.EventShowLineTip;
		if (events == null)
		{
			return;
		}
		events(index);
	}

	public static event Action<int> EventHideLineTip;
	public static void CallEventHideLineTip(int index)
	{
		Action<int> events = EventHandle.EventHideLineTip;
		if (events == null)
		{
			return;
		}
		events(index);
	}
}
