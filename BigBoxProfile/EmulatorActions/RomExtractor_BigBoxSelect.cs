using BigBoxProfile.RomExtractorUtils;
using CefSharp;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigBoxProfile.EmulatorActions
{
	public partial class RomExtractor_BigBoxSelect : Form
	{
		RomExtractor_ArchiveFile _archiveFile;
		string _cachedir;


		public string base_launchbox_dir = "";
		public bool useWebview = false;
		public bool useJsonMeta = true;
		public string HtmlTemplate = "";
		public dynamic JsonData;
		public string metadataFile = "";
		public string metadataFolder = "";
		public string colors_css = "";
		private CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser1;


		public RomExtractor_BigBoxSelect(RomExtractor_ArchiveFile archiveFile, string cachedir)
		{
			_archiveFile = archiveFile;
			_cachedir = cachedir;
			InitializeComponent();
			InitializeWebView(Path.GetDirectoryName(_archiveFile.ArchiveFilePath), _archiveFile.ArchiveNameWithoutPath);

			archiveNameLabel.Text = _archiveFile.ArchiveNameWithoutPath;
			fileListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			fileListBox.MeasureItem += lst_MeasureItem;
			fileListBox.DrawItem += lst_DrawItem;

			fileListBox.Items.Clear();
			fileListBox.Items.AddRange(_archiveFile.filelist.Except(_archiveFile.filelist_metadata).ToArray());
			if (_archiveFile.PriorityFile != string.Empty)
			{
				fileListBox.SelectedItem = _archiveFile.PriorityFile;
			}
			if (fileListBox.SelectedItems.Count == 0)
			{
				fileListBox.SelectedIndex = 0;
			}

			if (_archiveFile.filelist_metadata.Count > 0)
			{
				var fileHiddenType = new Dictionary<string, int>();
				foreach(var metadatafile in _archiveFile.filelist_metadata)
				{
					var extension = Path.GetExtension(metadatafile).ToLower().Trim().Trim('.').Trim();
					if (fileHiddenType.ContainsKey(extension)) fileHiddenType[extension] += 1;
					else fileHiddenType[extension] = 1;
				}

				string hidden_str = "";
				int nbh = 0;
				foreach (var fh in fileHiddenType)
				{
					hidden_str += fh.Key + ": " + fh.Value.ToString() + " ,";
					nbh += fh.Value;
				}
				hidden_str = hidden_str.Trim(',');
				hidden_str = hidden_str.Trim();
				if (nbh == 1) hidden_str = "File hidden : " + hidden_str;
				else hidden_str = "Files hidden : " + hidden_str;
				Texture_Label.Text = hidden_str;
			}
			else
			{
				fileListBox.Height += Texture_Label.Height;
				Texture_Label.Visible = false;
			}

			


		}

		private void lst_MeasureItem(object sender, MeasureItemEventArgs e)
		{
			e.ItemHeight = (int)e.Graphics.MeasureString(fileListBox.Items[e.Index].ToString(), fileListBox.Font, fileListBox.Width).Height;
		}

		private void lst_DrawItem(object sender, DrawItemEventArgs e)
		{
			e.DrawBackground();

			Graphics g = e.Graphics;
			Brush brush = ((e.State & DrawItemState.Selected) == DrawItemState.Selected) ?
							new SolidBrush(Color.FromArgb(0x5F, 0x33, 0x99, 0xFF)) : new SolidBrush(e.BackColor);
			g.FillRectangle(brush, e.Bounds);
			e.DrawFocusRectangle();
			e.Graphics.DrawString(fileListBox.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
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
			Metadata_folder = Path.Combine(_cachedir,"metadata",dinfo.Name);

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


			return (false, "", "", "");
		}

		void InitializeWebView(string dirpath, string archiveName)
		{
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

				this.chromiumWebBrowser1.LoadHtml("<html><body bgcolor=\"#2A2B34;\">No Info</body></html>");
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

		private void RomExtractor_BigBoxSelect_Load(object sender, EventArgs e)
		{
			fileListBox.Focus();
		}

		private void fileListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.useWebview && fileListBox.SelectedIndex >= 0)
			{
				string selected_file = fileListBox.SelectedItem.ToString();

				if (this.metadataFolder != "" && File.Exists(this.metadataFolder + "\\" + selected_file + ".html"))
				{
					string html_data = File.ReadAllText(this.metadataFolder + "\\" + selected_file + ".html");
					this.HtmlTemplate.Replace("[[CSSCOLOR]]", this.colors_css);
					this.chromiumWebBrowser1.LoadHtml(html_data, true);
					this.chromiumWebBrowser1.Visible = true;
					return;
				}

				if (this.useJsonMeta && this.JsonData.ContainsKey(selected_file))
				{
					string sval = this.JsonData[selected_file].ToString();
					string html_data = this.HtmlTemplate.Replace("[[JSONDATA]]", sval);
					this.chromiumWebBrowser1.LoadHtml(html_data, true);
					//System.IO.File.WriteAllText("test2.html", html_data);
					this.chromiumWebBrowser1.Visible = true;
					return;
				}
				this.chromiumWebBrowser1.LoadHtml("<html><body bgcolor=\"#2A2B34;\">No Info</body></html>");
			}
		}
	}
}
