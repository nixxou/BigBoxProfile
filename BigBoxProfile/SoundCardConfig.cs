using ComponentFactory.Krypton.Toolkit;
using System;
using System.Windows.Forms;

namespace BigBoxProfile
{
	public partial class SoundCardConfig : KryptonForm
	{
		public string result = Profile.ActiveProfile.Configuration["soundcard"];
		public SoundCardConfig()
		{
			InitializeComponent();
		}

		private void SoundCardConfig_Load(object sender, EventArgs e)
		{
			cmb_SoundCardList.Items.Clear();
			cmb_SoundCardList.Items.Add("<dontchange>");

			foreach (var soundcard in SoundCardUtils.GetSoundCards())
			{
				cmb_SoundCardList.Items.Add($"{soundcard}");
			}
			string selected = Profile.ActiveProfile.Configuration["soundcard"];
			var index = cmb_SoundCardList.Items.IndexOf(selected);
			if (index >= 0) cmb_SoundCardList.SelectedIndex = index;

		}


		private void btn_ok_Click(object sender, EventArgs e)
		{
			result = cmb_SoundCardList.SelectedItem.ToString();
			this.DialogResult = DialogResult.OK;
			this.Close();

		}

		private void btn_cancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
