using System;

namespace BigBoxProfile
{
	internal class DataContractSerializer
	{
		private Type type;

		public DataContractSerializer(Type type)
		{
			this.type = type;
		}
	}
}