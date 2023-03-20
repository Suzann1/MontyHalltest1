using MontyHall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using RoutePrefixAttribute = System.Web.Http.RoutePrefixAttribute;

namespace MontyHall.Controllers
{
    [RoutePrefix("api/calculate")]
    public class MontyHallController : ApiController
    {
        public MontyHallController() 
        { 
            // Här kan man ha loggning och annat
        }
        [ResponseType(typeof(WinLoose))]
        [System.Web.Http.Route("simulations")]
        public IHttpActionResult Get(int simulations, int doorChange) 
        { 
            //change door 0 = no, 1 = yes
            Random randomGen = new Random();
            int wins = 0;
            int losses = 0;
            
            for (int i = 0; i < simulations; i++)
            {                   
                bool result = MontyHallPick(randomGen.Next(3), doorChange, randomGen.Next(3), randomGen.Next(1));

                if (result)
                    wins++;
                else
                    losses++;
            }

            var winsResult = wins;
            var loosesResult = losses;
            var winslosses = wins + losses;
           
            var resultTotal = MapToResponse(winsResult, loosesResult);
            return Ok(resultTotal);

        }
        public static bool MontyHallPick(int doorChoosed, int doorChange, int doorWithCar, int doorWithGoatRemove)
        {
            bool win = false;
           
            int goatLeft = 0;
            int goatRight = 2;
            switch (doorChoosed)
            {
                case 0: goatLeft = 1; goatRight = 2; break;
                case 1: goatLeft = 0; goatRight = 2; break;
                case 2: goatLeft = 0; goatRight = 1; break;
            }

            int keepGoat = doorWithGoatRemove == 0 ? goatRight : goatLeft;
            
            if (doorChange == 0)
            {                
                win = doorWithCar == doorChoosed;
            }
            else
            {                
                win = doorWithCar != keepGoat;
            }
            return win;
        }
        private WinLoose MapToResponse(int winsResult, int loosesResult)
        {
            return new WinLoose
            {
                Loose = loosesResult,
                Win = winsResult
            };

        }

    }
}