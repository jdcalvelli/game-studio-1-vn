namespace TextOverTime_Examples
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using JulienFoucher;

	public class ExampleScenario : MonoBehaviour
	{

		public enum ScenarioState
		{
			START = 0,
			DISPLAYING_PRESS_ANY_KEY,
			PRESS_ANY_KEY,
			LOADING_STUFF,
			//LOADING_STUFF_END,
			HACKER_TYPE,
			ACCESS_GRANTED,
			END_STATE
		}

		public TextOverTime m_PressAnyKey;
		public TextOverTime m_LoadingStuff;
		public HackerTyper m_HackFun;
		public TextOverTime m_AccessGranted;
		public ScenarioState m_State = ScenarioState.START;

		public void GoToNextStep()
		{
			m_State = (ScenarioState)((int)m_State + 1);
		}

		void Update()
		{
			switch (m_State)
			{
				case ScenarioState.START:
					m_PressAnyKey.StartEffect();
					m_State = ScenarioState.DISPLAYING_PRESS_ANY_KEY;
					break;
				case ScenarioState.DISPLAYING_PRESS_ANY_KEY:
					if (HasPressedAnyKey())
						m_PressAnyKey.DisplayAllTargetText();
					break;
				case ScenarioState.PRESS_ANY_KEY:
					if (HasPressedAnyKey())
					{
						m_PressAnyKey.StopBlinkCursor();
						m_LoadingStuff.StartEffect();
						m_State = ScenarioState.LOADING_STUFF;
					}
					break;
				case ScenarioState.LOADING_STUFF:
					if (HasPressedAnyKey())
						m_LoadingStuff.DisplayAllTargetText();
					break;
				case ScenarioState.END_STATE:
					if (HasPressedResetKey())
					{
						Reset();
					}
					break;
			}
		}

		public void StartHackerTyper()
		{
			m_HackFun.StartEffect();
			m_State = ScenarioState.HACKER_TYPE;
		}

		public void DisplayAccessGranted()
		{
			m_AccessGranted.StartEffect();
			m_State = ScenarioState.ACCESS_GRANTED;
		}

		bool HasPressedAnyKey()
		{
			return Input.anyKeyDown && !Input.GetMouseButtonDown(0) && !Input.GetMouseButtonDown(1);
		}

		bool HasPressedResetKey()
		{
			return Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.Escape);
		}

		void Reset()
		{
			m_State = ScenarioState.START;
			m_PressAnyKey.Reset();
			m_LoadingStuff.Reset();
			m_HackFun.Reset();
			m_AccessGranted.Reset();
			m_PressAnyKey.StartEffect();
		}
	}
}