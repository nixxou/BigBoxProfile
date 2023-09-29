using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigBoxProfile
{
	public class VariableData
	{
		public string VariableName { get; set; }
		public string SourceData { get; set; }
		public string RegexToMatch { get; set; }

		public string VariableValue { get; set; }

		public VariableData()
		{
			this.VariableName = "";
			this.VariableValue = "";
			this.RegexToMatch = "";
			this.SourceData = "arg";
		}

		public VariableData(string json)
		{
			try
			{
				VariableData DeserializeData = JsonConvert.DeserializeObject<VariableData>(json);
				this.VariableName = DeserializeData.VariableName;
				this.VariableValue = DeserializeData.VariableValue;
				this.RegexToMatch = DeserializeData.RegexToMatch;
				this.SourceData = DeserializeData.SourceData;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		public string[] ToStringArray()
		{
			var arrayString = new string[5];
			arrayString[0] = Serialize();
			arrayString[1] = this.VariableName;
			arrayString[2] = this.SourceData;
			arrayString[3] = this.RegexToMatch;
			arrayString[4] = this.VariableValue;
			return arrayString;

		}

		public string Serialize()
		{
			string json = JsonConvert.SerializeObject(this, Formatting.Indented);
			return json;
		}


	}
}
