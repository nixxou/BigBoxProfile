using System.Collections.Generic;

namespace BigBoxProfile.RomExtractorUtils
{
	public class Texture
	{
		public Texture()
		{
		}

		public Texture(string title, long sizeInBytes, string iconImg = "")
		{
			this.Title = title;
			this.SizeInBytes = sizeInBytes;
			this.IconImg = iconImg;
		}

		public string Title;
		public long SizeInBytes;
		public string IconImg;
		static public List<Texture> AllTextures = new List<Texture>();

		public double GetSizeInMb()
		{
			return ((double)this.SizeInBytes) / (1024.0 * 1024.0);
		}

		static internal void ClearTexture()
		{
			AllTextures.Clear();
		}
		static internal void AddTexture(string title, long sizeInBytes, string iconImg = "")
		{
			AllTextures.Add(new Texture(title, sizeInBytes, iconImg));
		}
		static internal List<Texture> GetTextures()
		{
			return Texture.AllTextures;
		}

	}
}
