using Cirrious.MvvmCross.ViewModels;
using System.Collections.Generic;

namespace MvxListWithHeader.Core.ViewModels
{
    public class FirstViewModel
        : MvxViewModel
    {
        #region private List<string> _quotes = new List<string>(){...}

        /// <summary>
        /// A list of strings to display.  Nothing fancy.
        /// </summary>
        /// <remarks>
        /// Source: http://www.afi.com/100years/quotes.aspx
        /// </remarks>
        private List<string> _quotes = new List<string>()
        {
            "Frankly, my dear, I don't give a damn.",
"I'm gonna make him an offer he can't refuse.",
"You don't understand! I coulda had class. I coulda been a contender. I could've been somebody, instead of a bum, which is what I am.",
"Toto, I've a feeling we're not in Kansas anymore.",
"Here's looking at you, kid.",
"Go ahead, make my day.",
"All right, Mr. DeMille, I'm ready for my close-up.",
"May the Force be with you.",
"Fasten your seatbelts. It's going to be a bumpy night.",
"You talking to me?",
"What we've got here is failure to communicate.",
"I love the smell of napalm in the morning.",
"Love means never having to say you're sorry.",
"The stuff that dreams are made of.",
"E.T. phone home.",
"They call me Mister Tibbs!",
"Rosebud.",
"Made it, Ma! Top of the world!",
"I'm as mad as hell, and I'm not going to take this anymore!",
"Louis, I think this is the beginning of a beautiful friendship.",
"A census taker once tried to test me. I ate his liver with some fava beans and a nice Chianti.",
"Bond. James Bond.",
"There's no place like home.",
"I am big! It's the pictures that got small.",
"Show me the money!",
"Why don't you come up sometime and see me?",
"I'm walking here! I'm walking here!",
"Play it, Sam. Play 'As Time Goes By.'",
"You can't handle the truth!",
"I want to be alone.",
"After all, tomorrow is another day!",
"Round up the usual suspects.",
"I'll have what she's having.",
"You know how to whistle, don't you, Steve? You just put your lips together and blow.",
"You're gonna need a bigger boat.",
"Badges? We ain't got no badges! We don't need no badges! I don't have to show you any stinking badges!",
"I'll be back.",
"Today, I consider myself the luckiest man on the face of the earth.",
"If you build it, he will come.",
"My mama always said life was like a box of chocolates. You never know what you're gonna get.",
"We rob banks.",
"Plastics.",
"We'll always have Paris.",
"I see dead people.",
"Stella! Hey, Stella!",
"Oh, Jerry, don't let's ask for the moon. We have the stars.",
"Shane. Shane. Come back!",
"Well, nobody's perfect.",
"It's alive! It's alive!",
"Houston, we have a problem.",
"You've got to ask yourself one question: 'Do I feel lucky?' Well, do ya, punk?",
"One morning I shot an elephant in my pajamas. How he got in my pajamas, I don't know.",
"There's no crying in baseball!",
"La-dee-da, la-dee-da.",
"A boy's best friend is his mother.",
"Greed, for lack of a better word, is good.",
"Keep your friends close, but your enemies closer.",
"As God is my witness, I'll never be hungry again.",
"Well, here's another nice mess you've gotten me into!",
"What a dump.",
"Mrs. Robinson, you're trying to seduce me. Aren't you?",
"Gentlemen, you can't fight in here! This is the War Room!",
"Elementary, my dear Watson.",
"Take your stinking paws off me, you damned dirty ape.",
"Of all the gin joints in all the towns in all the world, she walks into mine.",
"Here's Johnny!",
"They're here!",
"Is it safe?",
"Wait a minute, wait a minute. You ain't heard nothin' yet!",
"No wire hangers, ever!",
"Mother of mercy, is this the end of Rico?",
"Forget it, Jake, it's Chinatown.",
"I have always depended on the kindness of strangers.",
"Hasta la vista, baby.",
"Soylent Green is people!",
"Open the pod bay doors, HAL.",
"Striker: Surely you can't be serious. ",
"Rumack: I am serious...and don't call me Shirley.",
"Yo, Adrian!",
"Hello, gorgeous.",
"Toga! Toga!",
"Listen to them. Children of the night. What music they make.",
"Oh, no, it wasn't the airplanes. It was Beauty killed the Beast.",
"My precious.",
"Attica! Attica!",
"Sawyer, you're going out a youngster, but you've got to come back a star!",
"Listen to me, mister. You're my knight in shining armor. Don't you forget it. You're going to get back on that horse, and I'm going to be right behind you, holding on tight, and away we're gonna go, go, go!",
"Tell 'em to go out there with all they got and win just one for the Gipper.",
"A martini. Shaken, not stirred.",
"Who's on first.",
"Cinderella story. Outta nowhere. A former greenskeeper, now, about to become the Masters champion. It looks like a mirac...It's in the hole! It's in the hole! It's in the hole!",
"Life is a banquet, and most poor suckers are starving to death!",
"I feel the need - the need for speed!",
"Carpe diem. Seize the day, boys. Make your lives extraordinary.",
"Snap out of it!",
"My mother thanks you. My father thanks you. My sister thanks you. And I thank you.",
"Nobody puts Baby in a corner.",
"I'll get you, my pretty, and your little dog, too!",
"I'm the king of the world!",
        };

        #endregion private List<string> _quotes = new List<string>(){...}

        public List<string> Quotes
        {
            get { return _quotes; }
            set { _quotes = value; RaisePropertyChanged(() => Quotes); }
        }
    }
}