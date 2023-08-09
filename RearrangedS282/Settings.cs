using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityModManagerNet;

namespace RearrangedS282
{
	public class Settings : UnityModManager.ModSettings, IDrawable
	{
		public enum X82Options
		{
			vanilla,
			small_wheels,
			small_wheels_alternate
		}

		public enum X102Options
		{
			vanilla,
			small_wheels,
		}

		[Draw("Spawn S282 with random wheel arrangement:")] public bool spawnRandomWA = true;
		[Draw(DrawType.PopupList, Label = "0-8-2/2-8-2/4-8-2 trailing truck style (reapply wheel arrangement to update):")] public X82Options x82Options = X82Options.small_wheels;
		[Draw(DrawType.PopupList, Label = "0-10-2/2-10-2/4-10-2 trailing truck style (reapply wheel arrangement to update):")] public X102Options x102Options = X102Options.small_wheels;

		public override void Save(UnityModManager.ModEntry modEntry)
		{
			base.Save(modEntry);
			
		}

		public void OnChange() {

		}
	}
}
