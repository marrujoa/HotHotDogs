using System;
using System.Collections.Generic;

namespace RaysHotDogs.Core
{
	public class HotDogDataService
	{

		private static HotDogRepository hotDogRepository = new HotDogRepository();

		public HotDogDataService()
		{
		}

		public HotDog GetHotDogById(int hotDogId) {
			return hotDogRepository.GetHotDogById(hotDogId);
		}

		public List<HotDog> GetAllHotDogs() {
			return hotDogRepository.GetAllHotDogs();
		}

		public List<HotDogGroup> GetGroupedHotDogs() {
			return hotDogRepository.GetGroupedHotDogs();
		}

		public List<HotDog> GetHotDogsForGroup(int hotDogGroupId) {
			return hotDogRepository.GetHotDogsForGroup(hotDogGroupId);
		}

	}
}

