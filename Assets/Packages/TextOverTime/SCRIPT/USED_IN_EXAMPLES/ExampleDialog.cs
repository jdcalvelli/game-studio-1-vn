namespace TextOverTime_Examples
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using JulienFoucher;

	public class ExampleDialog : MonoBehaviour
	{

		public string[] m_DialogSentences;
		int mCurrentSentence = 0;

		public TextOverTime mTextOverTimeTarget;

		public void HitTheCube()
		{
			if (!mTextOverTimeTarget.IsFullDisplayed())
				mTextOverTimeTarget.DisplayAllTargetText();
			else
			{
				GoToNext();
			}
		}

		void GoToNext()
		{
			mCurrentSentence++;
			if (mCurrentSentence >= m_DialogSentences.Length)
				mCurrentSentence = 0;
			mTextOverTimeTarget.SetTargetText(m_DialogSentences[mCurrentSentence]);
			mTextOverTimeTarget.Reset();
			mTextOverTimeTarget.StartEffect();
		}
	}
}