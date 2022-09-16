namespace TextOverTime_Examples
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.Events;

	public class ClickTrigger : MonoBehaviour
	{

		public UnityEvent mToTriggerOnClick;

		void OnMouseDown()
		{
			mToTriggerOnClick.Invoke();
		}
	}
}

