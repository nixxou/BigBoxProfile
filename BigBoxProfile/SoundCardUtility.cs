using CoreAudioApi;
using System.Collections.Generic;


namespace BigBoxProfile
{


	public static class SoundCardUtils
	{


		public static bool SetDefaultMic(string id)
		{
			MMDeviceCollection DeviceCollection = null;
			MMDeviceEnumerator DevEnum = new MMDeviceEnumerator();

			// Enumerate all enabled devices in a collection
			DeviceCollection = DevEnum.EnumerateAudioEndPoints(EDataFlow.eAll, EDeviceState.DEVICE_STATE_ACTIVE);
			// For every MMDevice in DeviceCollection
			for (int i = 0; i < DeviceCollection.Count; i++)
			{
				var soundDevice = DeviceCollection[i];

				if (soundDevice.DataFlow.ToString() == "eRender" && soundDevice.FriendlyName == id)
				{
					// Create a new audio PolicyConfigClient
					PolicyConfigClient client = new PolicyConfigClient();
					// Using PolicyConfigClient, set the given device as the default playback communication device
					//client.SetDefaultEndpoint(DeviceCollection[i].ID, ERole.eCommunications);
					// Using PolicyConfigClient, set the given device as the default playback device
					client.SetDefaultEndpoint(DeviceCollection[i].ID, ERole.eMultimedia);
					return true;
				}
				// If this MMDevice's ID is the same as the ID of the MMDevice received by the InputObject parameter
			}

			return false;
		}

		public static List<string> GetSoundCards()
		{

			List<string> soundCards = new List<string>();

			MMDeviceCollection DeviceCollection = null;
			MMDeviceEnumerator DevEnum = new MMDeviceEnumerator();

			// Enumerate all enabled devices in a collection
			DeviceCollection = DevEnum.EnumerateAudioEndPoints(EDataFlow.eAll, EDeviceState.DEVICE_STATE_ACTIVE);
			// For every MMDevice in DeviceCollection
			for (int i = 0; i < DeviceCollection.Count; i++)
			{
				var soundDevice = DeviceCollection[i];

				if (soundDevice.DataFlow.ToString() == "eRender")
				{
					soundCards.Add(soundDevice.FriendlyName);
				}
				// If this MMDevice's ID is the same as the ID of the MMDevice received by the InputObject parameter
			}




			/*
			// Obtenir la collection des périphériques audio de rendu (cartes son)
			MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
			MMDeviceCollection devices = enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active);

			// Récupérer le nom de chaque carte son
			foreach (MMDevice device in devices)
			{
				soundCards.Add(device.FriendlyName);
			}
			*/
			return soundCards;
		}


		public static string GetMainCards()
		{
			MMDeviceEnumerator DevEnum = new MMDeviceEnumerator();
			// Enumerate all enabled devices in a collection
			MMDevice defaultdevice = DevEnum.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia);
			return defaultdevice.FriendlyName;


		}

		public static float GetMainVolume()
		{
			MMDeviceEnumerator DevEnum = new MMDeviceEnumerator();
			// Enumerate all enabled devices in a collection
			MMDevice defaultdevice = DevEnum.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia);
			var volume = defaultdevice.AudioEndpointVolume;
			float masterVolumePercent = volume.MasterVolumeLevelScalar * 100;
			return masterVolumePercent;
		}

		public static void SetMainVolume(float value)
		{
			MMDeviceEnumerator DevEnum = new MMDeviceEnumerator();
			// Enumerate all enabled devices in a collection
			MMDevice defaultdevice = DevEnum.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia);
			var volume = defaultdevice.AudioEndpointVolume;
			volume.MasterVolumeLevelScalar = (value/100f);
		}

	}

}
