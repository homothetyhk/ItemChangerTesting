using ItemChanger.Items;
using ItemChanger.Locations;

namespace ItemChangerTesting
{
    public class TestArgs
    {
        public ItemFlags ItemFlags = new ItemFlags();
        public StartFlags StartFlags = new StartFlags();

        static TestArgs()
        {
            string[] items = ItemNames.ToArray();
            georocks = items.Where(i => i.StartsWith("Geo_Rock")).ToArray();
        }

        static string[] georocks;
        public void OnStart()
        {
            StartLocation _start = Finder.GetLocation("Start") as StartLocation;
            //_start.name = "Silent_Start";
            //_start.MessageType = MessageType.None;
            AbstractPlacement start = _start.Wrap();

            if (StartFlags.IncreasedNailDamage)
            {
                PlayerData.instance.nailDamage = 500;
            }
            if (StartFlags.Movement)
            {
                start.Add(Finder.GetItem(ItemNames.Mothwing_Cloak));
                start.Add(Finder.GetItem(ItemNames.Mantis_Claw));
                start.Add(Finder.GetItem(ItemNames.Crystal_Heart));
                start.Add(Finder.GetItem(ItemNames.Monarch_Wings));
                start.Add(Finder.GetItem(ItemNames.Shade_Cloak));
                start.Add(Finder.GetItem(ItemNames.Ismas_Tear));
            }
            if (StartFlags.DreamNail)
            {
                start.Add(Finder.GetItem(ItemNames.Dream_Nail));
            }
            if (StartFlags.Spells)
            {
                start.Add(Finder.GetItem(ItemNames.Vengeful_Spirit));
                start.Add(Finder.GetItem(ItemNames.Shade_Soul));
                start.Add(Finder.GetItem(ItemNames.Desolate_Dive));
                start.Add(Finder.GetItem(ItemNames.Descending_Dark));
                start.Add(Finder.GetItem(ItemNames.Howling_Wraiths));
                start.Add(Finder.GetItem(ItemNames.Abyss_Shriek));
                start.Add(Finder.GetItem(ItemNames.Soul_Totem_B));
            }
            if (StartFlags.StartGeo)
            {
                start.Add(new AddGeoItem { amount = 10000, name = "10000 geo" });
            }

            ItemChangerMod.AddPlacements(new[] { start });
        }
        public IEnumerable<AbstractItem> Items
        {
            get
            {
                if (ItemFlags.Charm)
                {
                    yield return Finder.GetItem(ItemNames.Grubsong);
                }
                if (ItemFlags.Soul)
                {
                    yield return Finder.GetItem(ItemNames.Soul_Totem_B);
                }
                if (ItemFlags.BigItem)
                {
                    yield return Finder.GetItem(ItemNames.Cyclone_Slash);
                }
                if (ItemFlags.Grub)
                {
                    yield return Finder.GetItem(ItemNames.Grub);
                }
                if (ItemFlags.Lore)
                {
                    yield return Finder.GetItem(ItemNames.Lore_Tablet_Kings_Pass_Focus);
                }
                if (ItemFlags.GeoRock)
                {
                    yield return Finder.GetItem(georocks[new Random().Next(georocks.Length)]);
                }
                if (ItemFlags.Lore)
                {
                    yield return Finder.GetItem(ItemNames.Lore_Tablet_Fungal_Wastes_Hidden);
                }
                if (ItemFlags.Lifeblood)
                {
                    yield return Finder.GetItem(ItemNames.Lifeblood_Cocoon_Large);
                }
                if (ItemFlags.Lore)
                {
                    yield return Finder.GetItem(ItemNames.Lore_Tablet_City_Entrance);
                }
                if (ItemFlags.Mimic)
                {
                    yield return Finder.GetItem(ItemNames.Mimic_Grub);
                }
            }
        }
    }

    public class ItemFlags
    {
        public bool Charm = true;
        public bool BigItem = true;
        public bool Grub = true;
        public bool GeoRock = true;
        public bool Lore = true;
        public bool Soul = true;
        public bool Lifeblood = true;
        public bool Mimic = false;
    }

    public class StartFlags
    {
        public bool IncreasedNailDamage = true;
        public bool Movement = true;
        public bool DreamNail = true;
        public bool Spells = true;
        public bool StartGeo = true;
    }
}
