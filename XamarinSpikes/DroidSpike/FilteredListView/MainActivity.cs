using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace FilteredListView
{
    [Activity(Label = "FilteredListView", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            // http://www.westeros.org/GoT/Characters/
            items = new string[] {
          "Alliser Thorne",
"Alton Lannister",
"Anguy, Anguy the Archer",
"Aremca",
"Arya Stark",
"Asha Greyjoy",
"Assassin",
"Balon Greyjoy",
"Barristan Selmy, Barristan the Bold",
"Benjen Stark",
"Beric Dondarrion, The Lightning Lord",
"Biter",
"Bran Stark",
"Brienne of Tarth, Brienne the Beauty",
"Bronn",
"Brynden Tully, The Blackfish",
"Captain’s Daughter",
"Catelyn Stark",
"Cersei Lannister",
"Craster",
"Daario Naharis",
"Daenerys Targaryen, Daenerys Stormborn",
"Dagmer, Dagmer Cleftjaw",
"Daisy",
"Dareon",
"Davos Seaworth, The Onion Knight",
"Dontos Hollard",
"Doreah",
"Drowned Priest",
"Edd Tollett, Dolorous Edd",
"Eddard Stark",
"Edmure Tully",
"Ellaria Sand",
"Galbart Glover",
"Gared",
"Gendry, The Bull",
"Gilly",
"Gold Cloak",
"Grand Maester Pycelle",
"Gregor Clegane, The Mountain that Rides",
"Grenn, Aurochs",
"Grey Worm",
"Hallyne",
"Hodor",
"Hot Pie",
"Hugh of the Vale",
"Illyrio Mopatis",
"Ilyn Payne",
"Irri",
"Jaime Lannister, The Kingslayer",
"Janos Slynt",
"Jaqen H’ghar",
"Jeor Mormont, The Old Bear",
"Jhiqui",
"Joffrey Baratheon",
"Jojen Reed",
"Jon Arryn",
"Jon Snow",
"Jon Umber, The Greatjon",
"Jonos Bracken",
"Jorah Mormont",
"Jory Cassel",
"Kevan Lannister",
"Khal Drogo",
"Kovarro",
"Kraznys",
"Lancel Lannister",
"Lannister Bannerman",
"Locke",
"Lommy Greenhands",
"Loras Tyrell, The Knight of Flowers",
"Lorren, Black Lorren",
"Lysa Arryn",
"Mace Tyrell",
"Maester Aemon",
"Maester Cressen",
"Maester Luwin",
"Mago",
"Mance Rayder",
"Margaery Tyrell",
"Marillion",
"Masha Heddle",
"Matthos Seaworth",
"Meera Reed",
"Melisandre of Asshai",
"Mero, Titan's Bastard",
"Meryn Trant",
"Mhaegen",
"Mirri Maz Duur",
"Mord",
"Mycah",
"Myrcella Baratheon",
"Night’s Watch Officer",
"Oberyn Nymeros Martell, The Red Viper",
"Old Nan",
"Olenna Tyrell, Queen of Thorns",
"Orell",
"Osha",
"Petyr Baelish, Littlefinger",
"Podrick Payne",
"Polliver",
"Pyat Pree",
"Pypar",
"Qhorin, Qhorin Halfhand",
"Qotho",
"Quaithe",
"Qyburn",
"Rakharo",
"Ramsay Snow",
"Rast",
"Rattleshirt",
"Renly Baratheon",
"Rickard Karstark",
"Rickon Stark",
"Robb Stark",
"Robert Baratheon",
"Robin Arryn",
"Rodrik Cassel",
"Roose Bolton",
"Rorge",
"Ros",
"Roslin Frey",
"Salladhor Saan",
"Samwell Tarly",
"Sandor Clegane, The Hound",
"Sansa Stark",
"Selyse Baratheon",
"Septa Mordane",
"Shae",
"Shagga",
"Stableboy",
"Stannis Baratheon",
"Stiv",
"Syrio Forel",
"Talisa Maegyr",
"The Spice King",
"The Tickler",
"Theon Greyjoy",
"Thoros of Myr",
"Timett son of Timett",
"Tobho Mott",
"Tommen Baratheon",
"Tormund, Giantsbane",
"Tycho Nestoris",
"Tyrion Lannister, The Imp",
"Tywin Lannister",
"Vardis Egan",
"Varys, The Spider",
"Viserys Targaryen, The Beggar King",
"Walder Frey",
"Waymar Royce",
"Will",
"Wineseller",
"Xaro Xhoan Daxos",
"Ygritte",
"Yoren",
            };

            var list = FindViewById<ListView>(Resource.Id.lv);
            var edit = FindViewById<EditText>(Resource.Id.et);

            ListAdapter = new MyAdapter(this, items);
            list.Adapter = ListAdapter;


            edit.TextChanged += (s, e) =>
            {
                ListAdapter.Filter.InvokeFilter(edit.Text);
            };
        }

        public string[] items { get; set; }

        public MyAdapter ListAdapter { get; set; }
    }
}

