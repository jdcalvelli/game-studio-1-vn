namespace TextOverTime_Examples
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;

	public class ScrollViewSnap : MonoBehaviour
	{

		ScrollRect m_ScrollRectComponent;

		void Awake()
		{
			m_ScrollRectComponent = GetComponent<ScrollRect>();
		}

		void Update()
		{
			m_ScrollRectComponent.verticalNormalizedPosition = 0;
		}
	}
}