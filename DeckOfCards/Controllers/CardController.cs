using DeckOfCards.Models;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeckOfCards.Controllers
{
    public class CardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewDeck()
        {
            
            return RedirectToAction("Draw Five");
        }

        public IActionResult DrawFive( string deck_id) 
        {
            string apiUri = "https://deckofcardsapi.com/api/deck/new/shuffle";
            var apiTask = apiUri.GetJsonAsync<Deck>();
            apiTask.Wait();
            Deck result = apiTask.Result;
            
            apiUri = $"https://deckofcardsapi.com/api/deck/{result.deck_id}/draw/?count=5";
            var apiTaskCard = apiUri.GetJsonAsync<DrawnCards>();
            apiTaskCard.Wait();
            DrawnCards resultcard = apiTaskCard.Result;
            return View(resultcard.cards);
        }
    }
}
