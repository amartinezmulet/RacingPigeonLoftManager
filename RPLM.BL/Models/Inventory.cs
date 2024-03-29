﻿using RPLM.BL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPLM.BL.Models
{
    public static class Inventory
    {
        public static int TotalOfPigeonsInLoft => PigeonDataHelper.Pigeons.Values.Where(x => ((x.Status == "Breeding")
                                                                                           ||(x.Status == "Racing")
                                                                                           ||(x.Status == "Squeaker")
                                                                                           ||(x.Status == "Standby"))
                                                                                           &&(x.Origin != "Ancestor")).Count();

        public static int TotalOfPigeonsBredInLoft => PigeonDataHelper.Pigeons.Values.Where(x => ((x.Status == "Breeding")
                                                                                         ||(x.Status == "Racing")
                                                                                         ||(x.Status == "Squeaker")
                                                                                         ||(x.Status == "Standby"))
                                                                                         &&(x.Origin == "Bred")
                                                                                         && (x.Origin != "Ancestor")).Count();
        public static int TotalOfPigeonsReceivedGift => PigeonDataHelper.Pigeons.Values.Where(x => ((x.Status == "Breeding")
                                                                                          || (x.Status == "Racing")
                                                                                          || (x.Status == "Squeaker")
                                                                                          || (x.Status == "Standby"))
                                                                                          && (x.Origin == "Gift")).Count();
        public static int TotalOfPigeonsPurchased => PigeonDataHelper.Pigeons.Values.Where(x => (x.Origin == "Purchased")
                                                                                                &&((x.Status == "Breeding")
                                                                                                || (x.Status == "Racing")
                                                                                                || (x.Status == "Squeaker")
                                                                                                || (x.Status == "Standby"))).Count();
                                                                                               

        public static int TotalofCocksInLoft => PigeonDataHelper.Pigeons.Values.Where(x => ((x.Status == "Breeding")
                                                                                  || (x.Status == "Racing")
                                                                                  || (x.Status == "Squeaker")
                                                                                  || (x.Status == "Standby"))
                                                                                  && (x.Sex == "Cock")
                                                                                  && (x.Origin != "Ancestor")).Count();
        public static int TotalofHensInLoft => PigeonDataHelper.Pigeons.Values.Where(x => ((x.Status == "Breeding")
                                                                                 || (x.Status == "Racing")
                                                                                 || (x.Status == "Squeaker")
                                                                                 || (x.Status == "Standby"))
                                                                                 && (x.Sex == "Hen")
                                                                                 && (x.Origin != "Ancestor")).Count();
        public static int TotalofUnsexedInLoft => PigeonDataHelper.Pigeons.Values.Where(x => ((x.Status == "Breeding")
                                                                                    || (x.Status == "Racing")
                                                                                    || (x.Status == "Squeaker")
                                                                                    || (x.Status == "Standby"))
                                                                                    && (x.Sex == "Unknown")
                                                                                    && (x.Origin != "Ancestor")).Count();

        public static int TotalOfBreeders => PigeonDataHelper.Pigeons.Values.Where(x => (x.Status == "Breeding") && (x.Origin != "Ancestor")).Count();
        public static int TotalOfSqueakers => PigeonDataHelper.Pigeons.Values.Where(x => (x.Status == "Squeaker") && (x.Origin != "Ancestor")).Count();
        public static int TotalOfPigeonsRacing => PigeonDataHelper.Pigeons.Values.Where(x => (x.Status == "Racing") && (x.Origin != "Ancestor")).Count();
        public static int TotalOfPigeonsInStandBy => PigeonDataHelper.Pigeons.Values.Where(x => (x.Status == "Standby") && (x.Origin != "Ancestor")).Count();







    }
}
