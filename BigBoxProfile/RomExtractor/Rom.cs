using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;


namespace BigBoxProfile.RomExtractorUtils
{
	public class Rom
	{
		public Rom()
		{
		}

		public Rom(string title, long sizeInBytes, string iconImg = "", bool isLastPlayed = false, bool isFavorite = false)
		{
			this.Title = title;
			this.SizeInBytes = sizeInBytes;
			this.IconImg = iconImg;
			this.IsFavorite = isFavorite;
			this.IsLastPlayed = isLastPlayed;
			SetTags();
			SetFiltersVars();
		}

		public string Title;
		public long SizeInBytes;
		public string IconImg;
		public string Tag1 = "";
		public string Tag2 = "";
		public string Tag3 = "";
		public string Tag4 = "";
		public string Tag5 = "";
		public string Tag6 = "";
		public string Tag7 = "";
		public string Tag8 = "";
		public string Tag9 = "";
		public bool is_french = false;
		public bool is_english = false;
		public bool is_romhackernet = false;
		public Dictionary<int, string> Savestate = new Dictionary<int, string>();
		public string TitleWithoutExt = "";
		public bool IsLastPlayed = false;
		public bool IsFavorite = false;

		public static string retroarch_savedir = "";
		public static string retroarch_savestatedir = "";
		static public List<Rom> AllRoms = new List<Rom>();
		static public Dictionary<int, bool> validTagColumns = new Dictionary<int, bool>();
		static public bool have_french = false;
		static public bool have_english = false;
		static public bool have_romhackernet = false;

		public void SetFiltersVars()
		{
			string valstr = this.Title.Trim();
			if (valstr.Contains("[T.Fre") || valstr.Contains("[T-Fre") || valstr.Contains("[T+Fre") || valstr.ToUpper().Contains("[FRANCE]") || valstr.ToUpper().Contains("[FR]"))
			{
				this.is_french = true;
				Rom.have_french = true;
			}
			if (valstr.Contains("[T.Eng") || valstr.Contains("[T-Eng") || valstr.Contains("[T+Eng"))
			{
				this.is_english = true;
				Rom.have_english = true;
			}
			if (Regex.Match(valstr, @"\[H\.([^\]]*)-([0-9]+)\]").Success)
			{
				this.is_romhackernet = true;
				Rom.have_romhackernet = true;
			}
		}

		public void SetTags()
		{
			string pattern = @"\[([^[]*)\]";
			RegexOptions options = RegexOptions.Multiline;
			MatchCollection matches = Regex.Matches(this.Title, pattern, options);
			int i = 0;
			int category = -1;
			int is_goodset = -1;
			int target_tag = 6;
			foreach (Match m in matches)
			{
				i++;
				string valtag = m.Value.Trim().ToUpper();
				if (valtag == "[USA]" || valtag == "[EUROPE]" || valtag == "[FRANCE]" || valtag == "[JAPAN]" || valtag == "[AUSTRALIA]" || valtag == "[GERMANY]" || valtag == "[ITALY]")
				{
					this.Tag1 += m.Value.Trim();
					validTagColumns[1] = true;
					continue;
				}

				if (valtag == "[MEGAPACK]" || valtag == "[GRH-MEGAPACK-21]" || valtag == "[SMWH]")
				{
					category = i + 1;
					this.Tag2 += m.Value.Trim();
					validTagColumns[2] = true;
					continue;
				}
				if (valtag == "[GOODSET]" || valtag == "[N64V]" || valtag == "[RHCOM]" || valtag == "[HTGDB]")
				{
					if (valtag == "[GOODSET]") is_goodset = i;
					this.Tag2 += m.Value.Trim();
					validTagColumns[2] = true;
					continue;
				}
				if (m.Value.Trim().StartsWith("[H.") || m.Value.Trim().StartsWith("[T.") || m.Value.Trim().StartsWith("[T+") || m.Value.Trim().StartsWith("[T-"))
				{
					this.Tag3 += m.Value.Trim();
					validTagColumns[3] = true;
					continue;
				}
				if (is_goodset > 0 && i > is_goodset && valtag.Contains("HACK"))
				{
					this.Tag3 += m.Value.Trim();
					validTagColumns[3] = true;
					continue;
				}
				if (i == category)
				{
					this.Tag4 += m.Value.Trim();
					validTagColumns[4] = true;
					continue;
				}
				if (valtag.Length <= 5)
				{
					validTagColumns[5] = true;
					this.Tag5 += m.Value.Trim();
					continue;
				}
				if (target_tag == 6)
				{
					validTagColumns[6] = true;
					this.Tag6 += m.Value.Trim();
					target_tag++;
					continue;
				}
				if (target_tag == 7)
				{
					validTagColumns[7] = true;
					this.Tag7 += m.Value.Trim();
					target_tag++;
					continue;
				}
				if (target_tag == 8)
				{
					validTagColumns[8] = true;
					this.Tag8 += m.Value.Trim();
					target_tag++;
					continue;
				}
				if (target_tag == 9)
				{
					validTagColumns[9] = true;
					this.Tag9 += m.Value.Trim();
					continue;
				}


			}
		}

		public Dictionary<int, string> loadSave(bool force_refresh = false)
		{
			//MessageBox.Show("this.TitleWithoutExt = " + this.TitleWithoutExt);
			//MessageBox.Show("Rom.retroarch_savestatedir = " + Rom.retroarch_savestatedir);
			if (this.TitleWithoutExt != "" && force_refresh == false) return this.Savestate;
			this.TitleWithoutExt = Path.GetFileNameWithoutExtension(this.Title);
			this.Savestate.Clear();
			if (Rom.retroarch_savestatedir != "" && Directory.Exists(Rom.retroarch_savestatedir))
			{
				string[] liste_savestate = Directory.GetFiles(Rom.retroarch_savestatedir, string.Format("{0}.*", this.TitleWithoutExt));
				foreach (string save_file in liste_savestate)
				{
					if (this.TitleWithoutExt == Path.GetFileNameWithoutExtension(save_file))
					{
						string ext = Path.GetExtension(save_file);
						int slot = 0;
						Match m = Regex.Match(ext, @"\.state([0-9]*)$");
						if (m.Success)
						{
							string res = m.Value.ToString().Replace(".state", "");
							if (res != "") slot = Int32.Parse(res);
							this.Savestate[slot] = save_file;
						}

					}
				}


			}

			return this.Savestate;
		}

		public double GetSizeInMb()
		{
			return ((double)this.SizeInBytes) / (1024.0 * 1024.0);
		}

		public bool Match(string input)
		{
			return Wildcard.Match(this.Title.ToLower(), input.ToLower().Trim());
		}

		static internal void ClearSaveState()
		{
			//MessageBox.Show("Clear");
			Rom.retroarch_savestatedir = "";
			foreach (var arom in AllRoms)
			{
				arom.TitleWithoutExt = "";
				arom.Savestate.Clear();

			}
		}

		static internal void ClearRom()
		{
			Rom.retroarch_savedir = "";
			Rom.retroarch_savestatedir = "";
			Rom.have_french = false;
			Rom.have_english = false;
			Rom.have_romhackernet = false;

			AllRoms.Clear();
			validTagColumns.Clear();
			for (int z = 1; z <= 9; z++)
			{
				validTagColumns[z] = false;
			}
		}
		static internal void AddRom(string title, long sizeInBytes, string iconImg = "", bool isLastPlayed = false, bool isFavorite = false)
		{
			AllRoms.Add(new Rom(title, sizeInBytes, iconImg, isLastPlayed, isFavorite));
		}
		static internal List<Rom> GetRoms()
		{
			return Rom.AllRoms;
		}
		static internal Dictionary<int, bool> GetValidTagColumns()
		{
			return Rom.validTagColumns;
		}

	}
}
