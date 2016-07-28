using System;
using System.Collections.Generic;
using System.Linq;

namespace RaysHotDogs.Core
{
	public class HotDogRepository
	{
		public HotDogRepository()
		{
		}

		public List<HotDog> GetAllHotDogs() {
			IEnumerable<HotDog> hotDogs =
				from hotDogGroup in hotDogGroups
				from hotDog in hotDogGroup.HotDogs

				select hotDog;
			return hotDogs.ToList();
		}

		public HotDog GetHotDogById(int hotDogId) {
			IEnumerable<HotDog> hotDogs =
				from hotDogGroup in hotDogGroups
				from hotDog in hotDogGroup.HotDogs
					where hotDog.HotDogId == hotDogId
				select hotDog;
			return hotDogs.FirstOrDefault();
		}

		public List<HotDogGroup> GetGroupedHotDogs() { 
			return hotDogGroups; 
		}

		public List<HotDog> GetHotDogsForGroup(int hotDogGroupId) {
			var group = hotDogGroups.Where(h => h.HotDogGroupId == hotDogGroupId).FirstOrDefault();

			if (group != null) 
				return group.HotDogs;

			return null;
		}

		public List<HotDog> GetFavoriteHotDogs() {
			IEnumerable<HotDog> hotDogs =
				from hotDogGroup in hotDogGroups
				from hotDog in hotDogGroup.HotDogs
				where hotDog.IsFavorite
				select hotDog;
			return hotDogs.ToList<HotDog>();
		}

		private static List<HotDogGroup> hotDogGroups = new List<HotDogGroup> {
			new HotDogGroup() {
				HotDogGroupId = 1, Title = "Meat lovers", ImagePath = "", HotDogs = new List<HotDog> {
					new HotDog() {
						HotDogId = 1,
						Name = "Regular Hot Dog",
						ShortDescription = "The best there is on the planet",
						Description = "Manchego smelly cheese danish fontina. Hard cheese covered",
						ImagePath = "hotdog1",
						Available = true,
						PrepTime = 10,
						Ingredients = new List<string>() {"Regular bun", "Sausage", "Ketchup"},
						Price = 8,
						IsFavorite = true
					},
					new HotDog() {
						HotDogId = 2,
						Name = "Haute Dog",
						ShortDescription = "The classy one",
						Description = "Bacon, Turkey, Ham, with a gourmet Sausage added to it",
						ImagePath = "hotdog2",
						Available = true,
						PrepTime = 10,
						Ingredients = new List<string>() {"Baked bun", "Gourmet Sausage", "Onion"},
						Price = 8,
						IsFavorite = true
					},
					new HotDog() {
						HotDogId = 3,
						Name = "Extra Long",
						ShortDescription = "For when a regular one isn't enough",
						Description = "Capicola short loin shoulder strip steak ribeye prok",
						ImagePath = "hotdog3",
						Available = true,
						PrepTime = 10,
						Ingredients = new List<string>() {"Extra long bun", "Extra long sausage", "Ketchup"},
						Price = 8,
						IsFavorite = true
					}
				}

			},
			new HotDogGroup() {
				HotDogGroupId = 2, Title = "Veggie Lovers", ImagePath = "", HotDogs = new List<HotDog> {
					new HotDog() {
						HotDogId = 4,
						Name = "Veggie Hot Dog",
						ShortDescription = "American for non-meat lovers",
						Description = "Veggie Dog for the vegetarians that love a solid hot dog",
						ImagePath = "hotdog4",
						Available = true,
						PrepTime = 5,
						Ingredients = new List<string>() {"Regular bun", "Veggie Sausage", "Relish", "Cucumber"},
						Price = 15,
						IsFavorite = false
					}
				}
			}
		};
	}
}

