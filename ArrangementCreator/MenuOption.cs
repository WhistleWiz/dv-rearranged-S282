using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrangementCreator
{
	internal class MenuOption
	{
		public string Text;
		public event Action? OnPick;

		public MenuOption(string text, params Action[] onPick)
		{
			Text = text;

			for (int i = 0; i < onPick.Length; i++)
			{
				OnPick += onPick[i];
			}
		}

		public void Choose()
		{
			OnPick?.Invoke();
		}
	}
}
