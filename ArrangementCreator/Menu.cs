using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrangementCreator
{
	internal class Menu
	{
		public int CurrentOption;
		public List<MenuOption> Options;
		public event Action? OnDraw;


		public Menu(params MenuOption[] options)
		{
			CurrentOption = 0;
			Options = options.ToList();
		}

		public Menu(Action onDraw, params MenuOption[] options)
		{
			CurrentOption = 0;
			Options = options.ToList();
			OnDraw += onDraw;
		}

		public Menu(Action onDraw, List<MenuOption> options)
		{
			CurrentOption = 0;
			Options = options;
			OnDraw += onDraw;
		}

		public void Draw()
		{
			Console.Clear();

			OnDraw?.Invoke();

			for (int i = 0; i < Options.Count; i++)
			{
				Console.WriteLine((i == CurrentOption ? "> " : "  ") + Options[i].Text);
			}
		}

		public void AwaitInput()
		{
			ConsoleKeyInfo key = Console.ReadKey(true);

			switch (key.Key)
			{
				case ConsoleKey.Backspace:
					break;
				case ConsoleKey.UpArrow:
					CurrentOption--;

					if (CurrentOption < 0)
					{
						CurrentOption = Options.Count - 1;
					}
					break;
				case ConsoleKey.DownArrow:
					CurrentOption = (CurrentOption + 1) % Options.Count;
					break;
				case ConsoleKey.Enter:
				case ConsoleKey.Select:
					Options[CurrentOption].Choose();
					break;
				default:
					break;
			}
		}

		public void ResetOptions(params MenuOption[] options)
		{
			Options = options.ToList();
			CurrentOption = 0;
		}
	}
}
