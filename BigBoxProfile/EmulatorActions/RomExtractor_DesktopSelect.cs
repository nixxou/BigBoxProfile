using BigBoxProfile.RomExtractorUtils;
using BrightIdeasSoftware;
using CefSharp;
using ComponentFactory.Krypton.Toolkit;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BigBoxProfile.EmulatorActions
{
	public partial class RomExtractor_DesktopSelect : KryptonForm
	{

		RomExtractor_ArchiveFile _archiveFile;
		string _cachedir;


		public string Selected;
		public int EmulatorIndex;
		public bool TagsActive = false; //Show extra tags columns

		//Additionals filters
		public string filter_text = "";
		public bool filter_stars = false;
		public bool filter_french = false;
		public bool filter_english = false;
		public bool filter_romhacker = false;

		//For the copy/Paste savestate of retroarch
		public string base_launchbox_dir = "";
		public string buffer_savestatefile = "";
		public string ArchiveDir = "";
		public string ArchiveName = "";
		public string Plateform = "";
		public string Emulator_selected = "";

		public bool path_texture_set = false;
		public string path_texture_name = "";

		public Dictionary<string, string> SaveStatePathList = new Dictionary<string, string>();
		public bool current_emulator_is_retroarch = false;

		public bool useWebview = false;
		public bool useJsonMeta = true;
		public string HtmlTemplate = "";
		public dynamic JsonData;
		public string metadataFile = "";
		public string metadataFolder = "";
		public string colors_css = "";
		public List<string> Args = new List<string>();

		public string TexturePath = "";

		private CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser1;

		public RomExtractor_DesktopSelect(List<string> args, RomExtractor_ArchiveFile archiveFile, string cachedir)
		{
			Args = args;
			_archiveFile = archiveFile;
			_cachedir = cachedir;

			//Clear variables
			Selected = "";
			TagsActive = false; //Show extra tags columns
			filter_text = "";
			filter_french = false;
			filter_english = false;
			filter_romhacker = false;
			buffer_savestatefile = "";
			path_texture_name = "";
			SaveStatePathList.Clear();
			Rom.ClearRom();
			Texture.ClearTexture();

			current_emulator_is_retroarch = false;
			string executableWithPath = args[0];
			string executableExe = Path.GetFileName(executableWithPath);
			if (executableExe.ToLower() == "retroarch.exe")
			{
				//MessageBox.Show(executableWithPath);
				current_emulator_is_retroarch = true;
				string retroarchDir = Path.GetDirectoryName(executableWithPath);
				string savestatedir = Path.Combine(retroarchDir, "states");
				string savedir = Path.Combine(retroarchDir, "saves");
				if (Directory.Exists(savestatedir))
				{
					Rom.retroarch_savestatedir = savestatedir;
				}
				if (Directory.Exists(savedir))
				{
					Rom.retroarch_savedir = savedir;
				}
				string fullcmd = BigBoxUtils.ArgsToCommandLine(args.ToArray());
				if (fullcmd.Contains("mupen64plus"))
				{
					if (Directory.Exists(Path.Combine(retroarchDir, "system", "Mupen64plus")))
					{
						TexturePath = Path.Combine(retroarchDir, "system", "Mupen64plus", "cache");
						if (!Directory.Exists(TexturePath)) Directory.CreateDirectory(TexturePath);
					}
				}
			}
			if (executableExe.ToLower() == "project64.exe")
			{
				string retroarchDir = Path.GetDirectoryName(executableWithPath);
				if (Directory.Exists(Path.Combine(retroarchDir, "Plugin", "GFX")))
				{
					TexturePath = Path.Combine(retroarchDir, "Plugin", "GFX", "cache");
					if (!Directory.Exists(TexturePath)) Directory.CreateDirectory(TexturePath);
				}
			}

			if (_archiveFile.PriorityFile != string.Empty)
			{
				Selected = _archiveFile.PriorityFile;
			}

			InitializeComponent();
			InitializeWebView(Path.GetDirectoryName(_archiveFile.ArchiveFilePath), _archiveFile.ArchiveNameWithoutPath);
			InitializeListView();
			this.fastObjectListView1.Activation = System.Windows.Forms.ItemActivation.Standard;
			this.fastObjectListView1.HotTracking = false;
			this.fastObjectListView1.HoverSelection = false;

			TexturePath_txt.Text = TexturePath;
			/*
			UserInterface.ApplyTheme(this);
			*/

			archiveNameLabel.Text = _archiveFile.ArchiveNameWithoutPath;

			int i = 0;
			int selected_index = -1;
			foreach (string fl in _archiveFile.filelist_standalone)
			{
				bool isLastPlayed = _archiveFile.archiveMetaData.LastGamesPlayed.Contains(fl);
				bool isFavorite = _archiveFile.archiveMetaData.FavoritesGames.Contains(fl);
				string icon_img = "";
				if (fl == _archiveFile.TruePriorityFile && icon_img == "") icon_img = "star_yellow";
				if (isFavorite && icon_img == "") icon_img = "star_red";
				if (_archiveFile.topPriorityOnlyFiles.Contains(fl) && icon_img == "") icon_img = "star_blue";

				//if (fl == priority_file) icon_img = "star_yellow";
				//if (fl == selection) icon_img = "star_blue";
				Rom.AddRom(fl.ToString(), (long)_archiveFile.FileDataWithPath[fl].Size, icon_img, isLastPlayed, isFavorite);
				if (Selected != string.Empty && fl.ToString() == Selected) selected_index = i;
				i++;
			}

			foreach (string fl in _archiveFile.filelist_metadata)
			{
				if (Path.GetExtension(fl).ToLower() == ".htc" || Path.GetExtension(fl).ToLower() == ".hts")
				{
					string icon_img = "";
					string true_file = fl.Split(']')[1];
					path_texture_name = Path.GetFileNameWithoutExtension(true_file);
					string potential_out = Path.Combine(TexturePath, true_file);
					string true_out = "";
					if (File.Exists(potential_out + ".htc")) true_out = potential_out + ".htc";
					if (File.Exists(potential_out + ".hts")) true_out = potential_out + ".hts";
					if (File.Exists(true_out))
					{
						FileInfo fi = new FileInfo(true_out);
						if (fi.Length == (long)_archiveFile.FileDataWithPath[fl].Size) icon_img = "star_yellow";
					}
					Texture.AddTexture(fl.ToString(), (long)_archiveFile.FileDataWithPath[fl].Size, icon_img);
				}
			}

			this.FListView_Texture.SetObjects(Texture.GetTextures());
			//And set the fastObjectListView1 to use that list
			this.fastObjectListView1.SetObjects(Rom.GetRoms());

			if (Texture.GetTextures().Count == 0)
			{
				groupBox1.Visible = false;
				fastObjectListView1.Height = fastObjectListView1.Height + groupBox1.Height + 10;


			}
			else
			{
				EmulatorSelectedUpdate();
				groupBox1.Visible = true;
			}
			if (Selected != string.Empty && selected_index != -1)
			{
				fastObjectListView1.SelectedIndex = selected_index;
			}

			//By default, we hide extra tags
			HideTags();

			//Some option of additional fiters on context menu appears only if there is at least one match
			if (Rom.have_french) MenuItem_filterFrench.Visible = true;
			else MenuItem_filterFrench.Visible = false;

			if (Rom.have_english) MenuItem_filterEnglish.Visible = true;
			else MenuItem_filterEnglish.Visible = false;

			if (Rom.have_romhackernet) MenuItem_filterRH.Visible = true;
			else MenuItem_filterRH.Visible = false;

			fastObjectListView1.Focus();
		}

		void InitializeWebView(string dirpath, string archiveName)
		{
			CefSharpSettings.SubprocessExitIfParentProcessClosed = true;

			(bool foundmeta, string Metadata_file, string Metadata_template, string Metadata_htmlfolder) = find_metadata(dirpath, archiveName);
			this.metadataFile = Metadata_file;
			this.metadataFolder = Metadata_htmlfolder;
			this.useWebview = foundmeta;
			this.useJsonMeta = false;

			if (foundmeta)
			{
				this.colors_css = @"
                :root {
					--DialogAccentColor: #416494;
					--DialogHighlightColor: #4C4F62;
					--DialogBackgroundColor: #2A2B34;
					--DialogBorderColor: #2A2B34;
					--DialogForegroundColor:#F0F0F0;
					--backColorContrast1:#3F404E;
					--backColorContrast2:#343541;
                }
                ";
			}



			if (foundmeta && Metadata_file != "")
			{
				this.HtmlTemplate = File.ReadAllText(Metadata_template);
				this.JsonData = JObject.Parse(File.ReadAllText(Metadata_file));
				this.useJsonMeta = true;

				if (this.HtmlTemplate.Contains("mySoapMessage"))
				{
					//Old version of template, dirty edit to add style
					string old_css_hack = @"
                        <style>
                        " + colors_css + @"
                        .note{
                            background-color:var(--DialogBackgroundColor);
                        }
                        div label{
                            color:var(--DialogForegroundColor);
                            background-color:var(--DialogBackgroundColor);;
    
                        }
                        #myData{
                            background-color: var(--DialogBackgroundColor);    
                        }
                        .tab{
                            background-color: var(--DialogHighlightColor);
                        }
                        h3{
                            color:var(--DialogForegroundColor);
                        }
                        a:link, a:visited {
                          color: var(--DialogForegroundColor);
                        }
                        td{
                            color:var(--DialogForegroundColor);
                        }
                        td.val {
	                        color: var(--DialogForegroundColor);
                        }
                        td.title{
                            color:var(--DialogForegroundColor);
                        }
                        body{
                            background-color: var(--DialogBackgroundColor); 
                        }
                        </style>
                    ";

					this.HtmlTemplate = this.HtmlTemplate.Replace(@"</head>", old_css_hack + @"</head>");
					this.HtmlTemplate = this.HtmlTemplate.Replace(@"background: #EEE;", "background: var(--backColorContrast1);");
					this.HtmlTemplate = this.HtmlTemplate.Replace(@"background: #FFF;", "background: var(--backColorContrast2);");
				}
				else
				{
					this.HtmlTemplate = this.HtmlTemplate.Replace("[[CSSCOLOR]]", colors_css);
				}
			}

			if (this.useWebview)
			{

				this.chromiumWebBrowser1 = new CefSharp.WinForms.ChromiumWebBrowser();
				this.chromiumWebBrowser1.ActivateBrowserOnCreation = false;
				//this.chromiumWebBrowser1.Visible = false;
				this.chromiumWebBrowser1.Location = fakebrowser_txt.Location;
				this.chromiumWebBrowser1.Name = "chromiumWebBrowser1";
				this.chromiumWebBrowser1.Size = fakebrowser_txt.Size;

				var sett = new CefSharp.BrowserSettings();
				sett.BackgroundColor = ColorToUInt(Color.Black);
				chromiumWebBrowser1.BrowserSettings = sett;

				this.chromiumWebBrowser1.TabIndex = fakebrowser_txt.TabIndex;
				this.Controls.Remove(this.fakebrowser_txt);
				this.Controls.Add(this.chromiumWebBrowser1);

				this.chromiumWebBrowser1.LoadHtml(@"<html><head></head><body bgcolor=""#2A2B34""><h1>No Info</h1></body></html>");
				chromiumWebBrowser1.LifeSpanHandler = new MyCustomLifeSpanHandler();

			}
			else
			{
				this.Width = this.Width - this.fakebrowser_txt.Width;
			}
		}

		public static uint ColorToUInt(Color color)
		{
			return (uint)((color.A << 24) | (color.R << 16) | (color.G << 8) | (color.B << 0));
		}

		private void InitializeListView()
		{
			this.fastObjectListView1.FormatRow += delegate (object sender, FormatRowEventArgs e)
			{
				Rom s = (Rom)e.Model;
				if (s.IsLastPlayed)
				{
					e.Item.ForeColor = Color.DarkRed;
					e.Item.BackColor = Color.WhiteSmoke;
				}
				if (s.IconImg != "")
				{
					e.Item.BackColor = Color.WhiteSmoke;
				}
			};


			//Delegate to show the star image before the Title text
			this.titleColumnF.ImageGetter = delegate (object rowObject)
			{
				Rom s = (Rom)rowObject;
				return s.IconImg;
			};

			//Delegate to show the size in human readable form, but still keep it internaly as bytes (usefull for sorting)
			this.sizeColumnF.AspectToStringConverter = delegate (object x)
			{
				long size = (long)x;
				int[] limits = new int[] { 1024 * 1024 * 1024, 1024 * 1024, 1024 };
				string[] units = new string[] { "GB", "MB", "KB" };

				for (int i = 0; i < limits.Length; i++)
				{
					if (size >= limits[i])
						return String.Format("{0:#,##0.##} " + units[i], ((double)size / limits[i]));
				}

				return String.Format("{0} bytes", size); ;
			};


			//Delegate to show the star image before the Title text
			this.Texture_Col_File.ImageGetter = delegate (object rowObject)
			{
				Texture s = (Texture)rowObject;
				return s.IconImg;
			};

			//Delegate to show the size in human readable form, but still keep it internaly as bytes (usefull for sorting)
			this.Texture_Col_Size.AspectToStringConverter = delegate (object x)
			{
				long size = (long)x;
				int[] limits = new int[] { 1024 * 1024 * 1024, 1024 * 1024, 1024 };
				string[] units = new string[] { "GB", "MB", "KB" };

				for (int i = 0; i < limits.Length; i++)
				{
					if (size >= limits[i])
						return String.Format("{0:#,##0.##} " + units[i], ((double)size / limits[i]));
				}

				return String.Format("{0} bytes", size); ;
			};
			//To register the double click or enter in the list
			fastObjectListView1.ItemActivate += new System.EventHandler(this.fastObjectListView1_ItemActivate);
			//To execute this function before loading the context menu, usefull to hide some option if no rom is selected
			contextMenuStrip1.Opened += new System.EventHandler(this.contextMenuStrip1_Opened);
			//For the search textbox filter, to validate a new filter text, since there is no "ok" button
			MenuItem_textBoxFilter.LostFocus += new System.EventHandler(this.MenuItem_textBoxFilter_Leave);
			MenuItem_textBoxFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MenuItem_textBoxFilter_CheckEnterKeyPress);

		}

		private void fastObjectListView1_ItemActivate(object sender, EventArgs e)
		{
			if (fastObjectListView1.SelectedIndex >= 0)
			{

				Rom myrom = (Rom)this.fastObjectListView1.SelectedObject;
				Selected = myrom.Title;
				this.DialogResult = DialogResult.OK;
				this.Close();

			}
		}

		//Executed before the context menu open
		Control _sourceControl = null;
		private void contextMenuStrip1_Opened(object sender, EventArgs e)
		{
			_sourceControl = contextMenuStrip1.SourceControl;

			//If tags columns are active, only show the option to hide them, and the other way around if not
			if (this.TagsActive)
			{
				MenuItem_showTags.Visible = false;
				MenuItem_hideTags.Visible = true;
			}
			else
			{
				MenuItem_showTags.Visible = true;
				MenuItem_hideTags.Visible = false;
			}

			MenuItem_SetFavorite.Visible = false;
			//If a file is selected, some additional features : Copy/paste savestate and extractTo
			if (fastObjectListView1.SelectedIndex >= 0)
			{
				MenuItem_saveCopy.Visible = true;
				MenuItem_pasteCopy.Visible = true;
				MenuItem_extractTo.Visible = true;
				MenuItem_SetFavorite.Visible = true;

				Rom myrom = (Rom)this.fastObjectListView1.SelectedObject;

				if (myrom.IsFavorite) MenuItem_SetFavorite.Text = "Remove Favorite";
				else MenuItem_SetFavorite.Text = "Set as Favorite";

				//We load the save state, i do that here instead of doing globaly on form load to avoid useless and costly file lookup
				var liste_savestate = myrom.loadSave();
				if (liste_savestate.Count > 0)
				{
					MenuItem_saveCopy.Enabled = true;
					MenuItem_saveCopy.Text = string.Format("Copy SaveState ({0})", liste_savestate.Count);
				}
				else
				{
					MenuItem_saveCopy.Enabled = false;
					MenuItem_saveCopy.Text = "Copy SaveState";
				}
				MenuItem_loadSaveState0.Enabled = false;
				MenuItem_loadSaveState1.Enabled = false;
				MenuItem_loadSaveState2.Enabled = false;
				MenuItem_loadSaveState3.Enabled = false;
				MenuItem_loadSaveState4.Enabled = false;
				MenuItem_loadSaveState5.Enabled = false;
				MenuItem_loadSaveState6.Enabled = false;
				MenuItem_loadSaveState7.Enabled = false;
				MenuItem_loadSaveState8.Enabled = false;
				MenuItem_loadSaveState9.Enabled = false;
				foreach (var savestate in liste_savestate)
				{
					switch (savestate.Key)
					{
						case 0:
							MenuItem_loadSaveState0.Enabled = true;
							break;
						case 1:
							MenuItem_loadSaveState1.Enabled = true;
							break;
						case 2:
							MenuItem_loadSaveState2.Enabled = true;
							break;
						case 3:
							MenuItem_loadSaveState3.Enabled = true;
							break;
						case 4:
							MenuItem_loadSaveState4.Enabled = true;
							break;
						case 5:
							MenuItem_loadSaveState5.Enabled = true;
							break;
						case 6:
							MenuItem_loadSaveState6.Enabled = true;
							break;
						case 7:
							MenuItem_loadSaveState7.Enabled = true;
							break;
						case 8:
							MenuItem_loadSaveState8.Enabled = true;
							break;
						case 9:
							MenuItem_loadSaveState9.Enabled = true;
							break;
					}
				}

				if (this.buffer_savestatefile != "")
				{
					MenuItem_pasteCopy.Enabled = true;
					MenuItem_pasteSaveState0.Text = "Slot 0 <empty>";
					MenuItem_pasteSaveState1.Text = "Slot 1 <empty>";
					MenuItem_pasteSaveState2.Text = "Slot 2 <empty>";
					MenuItem_pasteSaveState3.Text = "Slot 3 <empty>";
					MenuItem_pasteSaveState4.Text = "Slot 4 <empty>";
					MenuItem_pasteSaveState5.Text = "Slot 5 <empty>";
					MenuItem_pasteSaveState6.Text = "Slot 6 <empty>";
					MenuItem_pasteSaveState7.Text = "Slot 7 <empty>";
					MenuItem_pasteSaveState8.Text = "Slot 8 <empty>";
					MenuItem_pasteSaveState9.Text = "Slot 9 <empty>";

					MenuItem_pasteSaveState0.BackColor = MenuItem_showTags.BackColor;
					MenuItem_pasteSaveState1.BackColor = MenuItem_showTags.BackColor;
					MenuItem_pasteSaveState2.BackColor = MenuItem_showTags.BackColor;
					MenuItem_pasteSaveState3.BackColor = MenuItem_showTags.BackColor;
					MenuItem_pasteSaveState4.BackColor = MenuItem_showTags.BackColor;
					MenuItem_pasteSaveState5.BackColor = MenuItem_showTags.BackColor;
					MenuItem_pasteSaveState6.BackColor = MenuItem_showTags.BackColor;
					MenuItem_pasteSaveState7.BackColor = MenuItem_showTags.BackColor;
					MenuItem_pasteSaveState8.BackColor = MenuItem_showTags.BackColor;
					MenuItem_pasteSaveState9.BackColor = MenuItem_showTags.BackColor;

					foreach (var savestate in liste_savestate)
					{
						switch (savestate.Key)
						{
							case 0:
								MenuItem_pasteSaveState0.Text = "Slot 0";
								MenuItem_pasteSaveState0.BackColor = Color.Red;
								break;
							case 1:
								MenuItem_pasteSaveState1.Text = "Slot 1";
								MenuItem_pasteSaveState1.BackColor = Color.Red;
								break;
							case 2:
								MenuItem_pasteSaveState2.Text = "Slot 2";
								MenuItem_pasteSaveState2.BackColor = Color.Red;
								break;
							case 3:
								MenuItem_pasteSaveState3.Text = "Slot 3";
								MenuItem_pasteSaveState3.BackColor = Color.Red;
								break;
							case 4:
								MenuItem_pasteSaveState4.Text = "Slot 4";
								MenuItem_pasteSaveState4.BackColor = Color.Red;
								break;
							case 5:
								MenuItem_pasteSaveState5.Text = "Slot 5";
								MenuItem_pasteSaveState5.BackColor = Color.Red;
								break;
							case 6:
								MenuItem_pasteSaveState6.Text = "Slot 6";
								MenuItem_pasteSaveState6.BackColor = Color.Red;
								break;
							case 7:
								MenuItem_pasteSaveState7.Text = "Slot 7";
								MenuItem_pasteSaveState7.BackColor = Color.Red;
								break;
							case 8:
								MenuItem_pasteSaveState8.Text = "Slot 8";
								MenuItem_pasteSaveState8.BackColor = Color.Red;
								break;
							case 9:
								MenuItem_pasteSaveState9.Text = "Slot 9";
								MenuItem_pasteSaveState9.BackColor = Color.Red;
								break;
						}
					}

				}
				else
				{
					MenuItem_pasteCopy.Enabled = false;
				}

				/*
				if (Zip.SupportedType(myrom.Title))
				{
					MenuItem_extractTo.Visible = true;
				}
				*/

			}
			else
			{
				MenuItem_saveCopy.Visible = false;
				MenuItem_pasteCopy.Visible = false;
				MenuItem_extractTo.Visible = false;
				MenuItem_SetFavorite.Visible = false;
			}


		}

		//The 10 MenuItem_loadSaveState point to the same function, we use the last character to determine the slot
		private void MenuItem_loadSaveState_Click(object sender, EventArgs e)
		{
			var MenuItem = (System.Windows.Forms.ToolStripMenuItem)sender;
			string lastCharacter = MenuItem.Name.ToString().Substring(MenuItem.Name.ToString().Length - 1);
			int slot = Int32.Parse(lastCharacter);
			var selected_rom = (Rom)fastObjectListView1.SelectedObject;
			this.buffer_savestatefile = selected_rom.loadSave(false)[slot];
		}

		private void MenuItem_pasteSaveState_Click(object sender, EventArgs e)
		{
			var MenuItem = (System.Windows.Forms.ToolStripMenuItem)sender;
			string lastCharacter = MenuItem.Name.ToString().Substring(MenuItem.Name.ToString().Length - 1);
			int slot = Int32.Parse(lastCharacter);
			var selected_rom = (Rom)fastObjectListView1.SelectedObject;
			string state_str = ".state";
			if (slot > 0) state_str = state_str + slot.ToString();
			string out_savestatefile = Path.GetDirectoryName(this.buffer_savestatefile) + "\\" + selected_rom.TitleWithoutExt + state_str;
			if (File.Exists(out_savestatefile))
			{
				File.Delete(out_savestatefile);
			}
			File.Copy(this.buffer_savestatefile, out_savestatefile);
			this.buffer_savestatefile = "";
			selected_rom.loadSave(true);
		}

		//Function to update filters, we use addionals filters to be able to use it alongside the filter option from right click on a menu header.
		private void Updatefilter()
		{
			List<IModelFilter> filter_list = new List<IModelFilter>();
			if (this.filter_text != "")
			{
				if (this.filter_text.Contains("*") || this.filter_text.Contains("?"))
				{
					filter_list.Add(new ModelFilter(delegate (object x)
					{
						return ((Rom)x).Match(this.filter_text);
					}));
				}
				else
				{
					filter_list.Add(TextMatchFilter.Contains(this.fastObjectListView1, this.filter_text));
				}
				MenuItem_textBoxFilter.BackColor = Color.Yellow;
			}
			else MenuItem_textBoxFilter.BackColor = MenuItem_showTags.BackColor;

			if (this.filter_stars)
			{
				filter_list.Add(new ModelFilter(delegate (object x)
				{
					if (((Rom)x).IconImg != "" || ((Rom)x).IsLastPlayed) return true;
					//if (_archiveFile.archiveMetaData.LastGamesPlayed.Contains(((Rom)x).Title)) return true;
					return false;
				}));
				MenuItem_filterStar.BackColor = Color.Yellow;
			}
			else MenuItem_filterStar.BackColor = MenuItem_showTags.BackColor;

			if (this.filter_french)
			{
				filter_list.Add(new ModelFilter(delegate (object x)
				{
					return ((Rom)x).is_french;
				}));
				MenuItem_filterFrench.BackColor = Color.Yellow;
			}
			else MenuItem_filterFrench.BackColor = MenuItem_showTags.BackColor;

			if (this.filter_english)
			{
				filter_list.Add(new ModelFilter(delegate (object x)
				{
					return ((Rom)x).is_english;
				}));
				MenuItem_filterEnglish.BackColor = Color.Yellow;
			}
			else MenuItem_filterEnglish.BackColor = MenuItem_showTags.BackColor;

			if (this.filter_romhacker)
			{
				filter_list.Add(new ModelFilter(delegate (object x)
				{
					return ((Rom)x).is_romhackernet;
				}));
				MenuItem_filterRH.BackColor = Color.Yellow;
			}
			else MenuItem_filterRH.BackColor = MenuItem_showTags.BackColor;

			if (filter_list.Count > 0)
			{
				this.fastObjectListView1.AdditionalFilter = new CompositeAllFilter(filter_list);
				MenuItem_clearFilters.Enabled = true;
			}
			else
			{
				this.fastObjectListView1.AdditionalFilter = null;
				MenuItem_clearFilters.Enabled = false;
			}


		}

		//Show the extra tags columns, only show it if there is at least one match
		private void ShowTags()
		{
			this.tag1ColumnF.IsVisible = false;
			this.tag2ColumnF.IsVisible = false;
			this.tag3ColumnF.IsVisible = false;
			this.tag4ColumnF.IsVisible = false;
			this.tag5ColumnF.IsVisible = false;
			this.tag6ColumnF.IsVisible = false;
			this.tag7ColumnF.IsVisible = false;
			this.sizeColumnF.FillsFreeSpace = false;

			bool redraw = false;
			if (Rom.validTagColumns[1])
			{
				redraw = true;
				this.tag1ColumnF.IsVisible = true;
			}
			if (Rom.validTagColumns[2])
			{
				redraw = true;
				this.tag2ColumnF.IsVisible = true;
			}
			if (Rom.validTagColumns[3])
			{
				redraw = true;
				this.tag3ColumnF.IsVisible = true;
			}
			if (Rom.validTagColumns[4])
			{
				redraw = true;
				this.tag4ColumnF.IsVisible = true;
			}
			if (Rom.validTagColumns[5])
			{
				redraw = true;
				this.tag5ColumnF.IsVisible = true;
			}
			if (Rom.validTagColumns[6])
			{
				redraw = true;
				this.tag6ColumnF.IsVisible = true;
			}
			if (Rom.validTagColumns[7])
			{
				redraw = true;
				this.tag7ColumnF.IsVisible = true;
			}
			if (Rom.validTagColumns[8])
			{
				redraw = true;
				this.tag8ColumnF.IsVisible = true;
			}
			if (Rom.validTagColumns[9])
			{
				redraw = true;
				this.tag9ColumnF.IsVisible = true;
			}

			//We redraw to set columns size to fit the contents
			if (redraw)
			{
				this.fastObjectListView1.RebuildColumns();
				this.fastObjectListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
				this.fastObjectListView1.RebuildColumns();
			}
			this.TagsActive = true;
		}

		private void HideTags()
		{
			this.tag1ColumnF.IsVisible = false;
			this.tag2ColumnF.IsVisible = false;
			this.tag3ColumnF.IsVisible = false;
			this.tag4ColumnF.IsVisible = false;
			this.tag5ColumnF.IsVisible = false;
			this.tag6ColumnF.IsVisible = false;
			this.tag7ColumnF.IsVisible = false;
			this.tag8ColumnF.IsVisible = false;
			this.tag9ColumnF.IsVisible = false;
			this.sizeColumnF.FillsFreeSpace = true;
			this.fastObjectListView1.RebuildColumns();
			this.TagsActive = false;
		}

		private void MenuItem_textBoxFilter_Click(object sender, EventArgs e)
		{

		}
		private void MenuItem_hideTags_Click(object sender, EventArgs e)
		{
			this.HideTags();
		}

		private void MenuItem_showTags_Click(object sender, EventArgs e)
		{
			this.ShowTags();
		}
		private void MenuItem_textBoxFilter_Leave(object sender, EventArgs e)
		{
			if (MenuItem_textBoxFilter.Text != this.filter_text)
			{
				this.filter_text = MenuItem_textBoxFilter.Text;
				Updatefilter();
			}
		}
		private void MenuItem_textBoxFilter_CheckEnterKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Return)
			{
				// Then Do your Thang
				contextMenuStrip1.Hide();
				if (MenuItem_textBoxFilter.Text != this.filter_text)
				{
					this.filter_text = MenuItem_textBoxFilter.Text;
					Updatefilter();
				}
			}
		}

		private void MenuItem_filterStar_Click(object sender, EventArgs e)
		{
			this.filter_stars = !this.filter_stars;
			Updatefilter();
		}

		private void MenuItem_filterFrench_Click(object sender, EventArgs e)
		{
			this.filter_french = !this.filter_french;
			Updatefilter();
		}

		private void MenuItem_filterEnglish_Click(object sender, EventArgs e)
		{
			this.filter_english = !this.filter_english;
			Updatefilter();
		}

		private void MenuItem_filterRH_Click(object sender, EventArgs e)
		{
			this.filter_romhacker = !this.filter_romhacker;
			Updatefilter();
		}

		private void MenuItem_clearFilters_Click(object sender, EventArgs e)
		{
			this.filter_stars = false;
			this.filter_english = false;
			this.filter_french = false;
			this.filter_romhacker = false;
			MenuItem_textBoxFilter.Text = "";
			this.filter_text = "";
			Updatefilter();
		}


		private void MenuItem_extractTo_Click(object sender, EventArgs e)
		{
			if (fastObjectListView1.SelectedIndex >= 0)
			{
				Rom myrom = (Rom)this.fastObjectListView1.SelectedObject;
				saveFileDialog_extractTo.Filter = "Rom|*" + Path.GetExtension(myrom.Title);
				saveFileDialog_extractTo.Title = "Save Rom";
				saveFileDialog_extractTo.FileName = myrom.Title;
				saveFileDialog_extractTo.ShowDialog();
			}
		}

		private void saveFileDialog_extractTo_FileOk(object sender, CancelEventArgs e)
		{

			if (fastObjectListView1.SelectedIndex >= 0)
			{
				Rom myrom = (Rom)this.fastObjectListView1.SelectedObject;

				var frm = new RomExtractor_PopupExtract(_archiveFile, myrom.Title, saveFileDialog_extractTo.FileName, myrom.SizeInBytes);
				frm.TopMost = true; // Affiche la fenêtre devant toutes les autres
				var result = frm.ShowDialog();
				frm.Focus(); // Donne le focus à la fenêtre
			}

		}

		private void InstallTexture_btn_Click(object sender, EventArgs e)
		{

			//I don't think that should trigger, this condition must be check before enabling the button, but in case of...
			if (Directory.Exists(TexturePath_txt.Text) == false)
			{
				MessageBox.Show("Invalid Dir");
				return;
			}

			Texture selected_texture = (Texture)FListView_Texture.SelectedObject;



			//Check free space
			ulong FreeBytesAvailable;
			ulong TotalNumberOfBytes;
			ulong TotalNumberOfFreeBytes;
			bool success = BigBoxUtils.GetDiskFreeSpaceEx(TexturePath_txt.Text, out FreeBytesAvailable, out TotalNumberOfBytes, out TotalNumberOfFreeBytes);
			if (!success) throw new System.ComponentModel.Win32Exception();
			if (FreeBytesAvailable < (ulong)selected_texture.SizeInBytes)
			{
				MessageBox.Show("Not enought free space to install texture");
				return;
			}



			string potential_out = TexturePath_txt.Text + @"\" + path_texture_name;
			if (File.Exists(potential_out + ".htc")) File.Delete(potential_out + ".htc");
			if (File.Exists(potential_out + ".hts")) File.Delete(potential_out + ".hts");



			string true_file = selected_texture.Title.Split(']')[1];
			string true_out = TexturePath_txt.Text + @"\" + true_file;

			var frm = new RomExtractor_PopupExtract(_archiveFile, selected_texture.Title, true_out, selected_texture.SizeInBytes);
			frm.TopMost = true; // Affiche la fenêtre devant toutes les autres
			var result = frm.ShowDialog();
			frm.Focus(); // Donne le focus à la fenêtre

			selected_texture.IconImg = "star_yellow";
			EmulatorSelectedUpdate();

		}

		private void EmulatorSelectedUpdate()
		{
			if (TexturePath_txt.Text != "" && FListView_Texture.SelectedIndex >= 0)
			{
				InstallTexture_btn.Enabled = true;
			}
			else InstallTexture_btn.Enabled = false;

			RemoveTexture_btn.Enabled = false;
			bool found_texture_match = false;
			if (TexturePath_txt.Text != "")
			{
				string potential_out = TexturePath_txt.Text + @"\" + path_texture_name;
				string true_out = "";
				if (File.Exists(potential_out + ".htc")) true_out = potential_out + ".htc";
				if (File.Exists(potential_out + ".hts")) true_out = potential_out + ".hts";

				if (File.Exists(true_out))
				{
					RemoveTexture_btn.Enabled = true;
					FileInfo fi = new FileInfo(true_out);
					foreach (Texture t in FListView_Texture.Objects)
					{
						if (t.SizeInBytes == fi.Length)
						{
							found_texture_match = true;
							lbl_installed_texture.Text = "Installed Texture : " + t.Title;
							t.IconImg = "star_yellow";
						}
						else t.IconImg = "";
					}
					if (found_texture_match == false)
					{
						lbl_installed_texture.Text = "Installed Texture : " + path_texture_name + " (Unknow)";
					}

				}
				else
				{
					lbl_installed_texture.Text = "Installed Texture : None";
				}
			}
			else lbl_installed_texture.Text = "";

			if (found_texture_match == false)
			{
				foreach (Texture t in FListView_Texture.Objects)
				{
					if (t.IconImg != "")
					{
						t.IconImg = "";
					}
				}
			}
			FListView_Texture.Refresh();
		}

		private void TexturePath_btn_Click(object sender, EventArgs e)
		{

			using (var fbd = new FolderBrowserDialog())
			{

				DialogResult result = fbd.ShowDialog();
				if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath) && Directory.Exists(fbd.SelectedPath))
				{
					TexturePath_txt.Text = fbd.SelectedPath;
				}
			}
			EmulatorSelectedUpdate();

		}

		private void FListView_Texture_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.useWebview && FListView_Texture.SelectedIndex >= 0)
			{
				InstallTexture_btn.Enabled = true;
				Texture myrom = (Texture)this.FListView_Texture.SelectedObject;

				if (this.metadataFolder != "" && File.Exists(this.metadataFolder + "\\" + myrom.Title + ".html"))
				{
					string html_data = File.ReadAllText(this.metadataFolder + "\\" + myrom.Title + ".html");
					this.HtmlTemplate.Replace("[[CSSCOLOR]]", this.colors_css);
					this.chromiumWebBrowser1.LoadHtml(html_data, true);
					this.chromiumWebBrowser1.Visible = true;
					return;
				}

				if (this.useJsonMeta && this.JsonData.ContainsKey(myrom.Title))
				{
					string sval = this.JsonData[myrom.Title].ToString();
					string html_data = this.HtmlTemplate.Replace("[[JSONDATA]]", sval);
					this.chromiumWebBrowser1.LoadHtml(html_data, true);
					//System.IO.File.WriteAllText("testtexture.html", html_data);
					this.chromiumWebBrowser1.Visible = true;
					return;
				}
				this.chromiumWebBrowser1.LoadHtml(@"<html><head></head><body bgcolor=""#2A2B34""><h1>No Info</h1></body></html>");
			}
			else InstallTexture_btn.Enabled = false;

		}

		private void RemoveTexture_btn_Click(object sender, EventArgs e)
		{

			string potential_out = TexturePath_txt.Text + @"\" + path_texture_name;
			if (File.Exists(potential_out + ".htc")) File.Delete(potential_out + ".htc");
			if (File.Exists(potential_out + ".hts")) File.Delete(potential_out + ".hts");
			EmulatorSelectedUpdate();

		}

		private (bool foundmeta, string Metadata_file, string Metadata_template, string Metadata_folder) find_metadata(string dirpath, string archiveName)
		{
			string res_Metadata_file = "";
			string res_Metadata_template = "";
			string res_Metadata_htmlfolder = "";

			string Metadata_file = "";
			string Metadata_template = "";
			bool valid_meta = false;

			DirectoryInfo dinfo = new DirectoryInfo(dirpath);
			string Metadata_folder = Path.Combine(dinfo.Parent.FullName, "metadata", dinfo.Name);
			if (Directory.Exists(Metadata_folder))
			{
				if (Directory.Exists(Metadata_folder + "\\" + archiveName))
				{
					res_Metadata_htmlfolder = Metadata_folder + "\\" + archiveName;
					valid_meta = true;
				}
				Metadata_file = Metadata_folder + "\\" + Path.GetFileNameWithoutExtension(archiveName) + ".json";
				if (File.Exists(Metadata_file))
				{
					Metadata_template = Metadata_folder + "\\template.html";
					if (File.Exists(Metadata_template))
					{
						res_Metadata_file = Metadata_file;
						res_Metadata_template = Metadata_template;
						valid_meta = true;
					}
					Metadata_template = Metadata_folder + "\\template.BB.html";
					if (File.Exists(Metadata_template))
					{
						res_Metadata_file = Metadata_file;
						res_Metadata_template = Metadata_template;
						valid_meta = true;
					}
				}
				if (valid_meta) return (true, res_Metadata_file, res_Metadata_template, res_Metadata_htmlfolder);
			}

			Metadata_folder = Path.Combine(_cachedir, "metadata", dinfo.Name);
			if (Directory.Exists(Metadata_folder))
			{
				if (Directory.Exists(Metadata_folder + "\\" + archiveName))
				{
					res_Metadata_htmlfolder = Metadata_folder + "\\" + archiveName;
					valid_meta = true;
				}

				Metadata_file = Metadata_folder + "\\" + Path.GetFileNameWithoutExtension(archiveName) + ".json";
				if (File.Exists(Metadata_file))
				{
					Metadata_template = Metadata_folder + "\\template.html";
					if (File.Exists(Metadata_template))
					{
						res_Metadata_file = Metadata_file;
						res_Metadata_template = Metadata_template;
						valid_meta = true;
					}
					Metadata_template = Metadata_folder + "\\template.BB.html";
					if (File.Exists(Metadata_template))
					{
						res_Metadata_file = Metadata_file;
						res_Metadata_template = Metadata_template;
						valid_meta = true;
					}
				}
				if (valid_meta) return (true, res_Metadata_file, res_Metadata_template, res_Metadata_htmlfolder);
			}

			Metadata_folder = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "metadata", dinfo.Name);
			if (Directory.Exists(Metadata_folder))
			{
				if (Directory.Exists(Metadata_folder + "\\" + archiveName))
				{
					res_Metadata_htmlfolder = Metadata_folder + "\\" + archiveName;
					valid_meta = true;
				}

				Metadata_file = Metadata_folder + "\\" + Path.GetFileNameWithoutExtension(archiveName) + ".json";
				if (File.Exists(Metadata_file))
				{
					Metadata_template = Metadata_folder + "\\template.html";
					if (File.Exists(Metadata_template))
					{
						res_Metadata_file = Metadata_file;
						res_Metadata_template = Metadata_template;
						valid_meta = true;
					}
					Metadata_template = Metadata_folder + "\\template.BB.html";
					if (File.Exists(Metadata_template))
					{
						res_Metadata_file = Metadata_file;
						res_Metadata_template = Metadata_template;
						valid_meta = true;
					}
				}
				if (valid_meta) return (true, res_Metadata_file, res_Metadata_template, res_Metadata_htmlfolder);
			}

			if (EmulatorLauncher.BigBoxFolder != "")
			{
				Metadata_folder = Path.Combine(EmulatorLauncher.BigBoxFolder, "metadata", dinfo.Name);
				if (Directory.Exists(Metadata_folder))
				{
					if (Directory.Exists(Metadata_folder + "\\" + archiveName))
					{
						res_Metadata_htmlfolder = Metadata_folder + "\\" + archiveName;
						valid_meta = true;
					}

					Metadata_file = Metadata_folder + "\\" + Path.GetFileNameWithoutExtension(archiveName) + ".json";
					if (File.Exists(Metadata_file))
					{
						Metadata_template = Metadata_folder + "\\template.html";
						if (File.Exists(Metadata_template))
						{
							res_Metadata_file = Metadata_file;
							res_Metadata_template = Metadata_template;
							valid_meta = true;
						}
						Metadata_template = Metadata_folder + "\\template.BB.html";
						if (File.Exists(Metadata_template))
						{
							res_Metadata_file = Metadata_file;
							res_Metadata_template = Metadata_template;
							valid_meta = true;
						}
					}
					if (valid_meta) return (true, res_Metadata_file, res_Metadata_template, res_Metadata_htmlfolder);
				}
			}


			return (false, "", "", "");
		}

		private void fastObjectListView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.useWebview && fastObjectListView1.SelectedIndex >= 0)
			{
				Rom myrom = (Rom)this.fastObjectListView1.SelectedObject;

				if (this.metadataFolder != "" && File.Exists(this.metadataFolder + "\\" + myrom.Title + ".html"))
				{
					string html_data = File.ReadAllText(this.metadataFolder + "\\" + myrom.Title + ".html");
					this.HtmlTemplate.Replace("[[CSSCOLOR]]", this.colors_css);
					this.chromiumWebBrowser1.LoadHtml(html_data, true);
					this.chromiumWebBrowser1.Visible = true;
					return;
				}

				if (this.useJsonMeta && this.JsonData.ContainsKey(myrom.Title))
				{
					string sval = this.JsonData[myrom.Title].ToString();
					string html_data = this.HtmlTemplate.Replace("[[JSONDATA]]", sval);

					//this.chromiumWebBrowser1.LoadHtml(html_data,true);
					this.chromiumWebBrowser1.LoadHtml(html_data, true);
					//System.IO.File.WriteAllText("test2.html", html_data);
					this.chromiumWebBrowser1.Visible = true;
					return;
				}
				this.chromiumWebBrowser1.LoadHtml(@"<html><head></head><body bgcolor=""#2A2B34""><h1>No Info</h1></body></html>");

			}
		}


		private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
		{

		}


		private void RomExtractor_DesktopSelect_Load(object sender, EventArgs e)
		{

		}


		private void MenuItem_SetFavorite_Click(object sender, EventArgs e)
		{
			if (fastObjectListView1.SelectedIndex >= 0)
			{
				Rom myrom = (Rom)this.fastObjectListView1.SelectedObject;
				if (myrom.IsFavorite)
				{
					if (_archiveFile.archiveMetaData.FavoritesGames.Contains(myrom.Title))
					{
						_archiveFile.archiveMetaData.FavoritesGames.Remove(myrom.Title);
						_archiveFile.archiveMetaData.Save();
					}
					myrom.IsFavorite = false;
					if (myrom.IconImg == "star_red")
					{
						myrom.IconImg = "";
						this.fastObjectListView1.Refresh();
					}
				}
				else
				{
					if (!_archiveFile.archiveMetaData.FavoritesGames.Contains(myrom.Title))
					{
						_archiveFile.archiveMetaData.FavoritesGames.Add(myrom.Title);
						_archiveFile.archiveMetaData.Save();
					}
					myrom.IsFavorite = true;
					if (myrom.IconImg == "")
					{
						myrom.IconImg = "star_red";
						this.fastObjectListView1.Refresh();
					}
				}

			}

		}

		private void RemoveTexture_btn_Click_1(object sender, EventArgs e)
		{

		}

		private void okButton_Click(object sender, EventArgs e)
		{
			if (fastObjectListView1.SelectedIndex >= 0)
			{

				Rom myrom = (Rom)this.fastObjectListView1.SelectedObject;
				Selected = myrom.Title;
				this.DialogResult = DialogResult.OK;
				this.Close();

			}
			else
			{
				MessageBox.Show("No Game selected");
			}
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{

			Selected = "";
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void TexturePath_btn_Click_1(object sender, EventArgs e)
		{

		}
	}
}
