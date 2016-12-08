using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AdaBot.Services
{

    [LuisModel("", "")]
    [Serializable]
    public class AdaGuidDialog : LuisDialog<object>
    {
        private Activity _message;

        protected override async Task MessageReceived(IDialogContext context, IAwaitable<IMessageActivity> item)
        {
            _message = (Activity)await item;
            await base.MessageReceived(context, item);
        }

        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = $"Je n'ai pas compris :/";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
            message = $"Tu peux demander à Luis de m'aider à mieux te comprendre ! Il est juste sur ta gauche :D";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("SayHello")]
        public async Task SayHello(IDialogContext context, LuisResult result)
        {
            string message = $"Bonjour ! Je suis Ada, l'assistante virtuelle du MIC :-)";
            await context.PostAsync(message);
            message = $"Que puis-je faire pour toi ?";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("GeMicInformations")]
        public async Task GeMicInformations(IDialogContext context, LuisResult result)
        {
            string message = $"Le MIC est un endroit où le Buisness rencontre la technologie !";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("GeInternshipInformations")]
        public async Task GeInternshipInformations(IDialogContext context, LuisResult result)
        {
            string message = $"Depuis 2010, le MIC encadre des stages pour les entreprises, que ce soit une startup ou une PME. De nombreux étudiants postulent chaque année au MIC dans l’espoir d’obtenir un stage. Afin d’y parvenir, l’étudiant doit passer un test. Ensuite, le MIC sélectionne les meilleurs étudiants pour une durée de quinze semaines, durant la période de janvier à mai.";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("GetPersonInformations")]
        public async Task GetPersonInformations(IDialogContext context, LuisResult result)
        {
            string message = "";
            switch (result.Entities[0].Entity)
            {
                case "xavier":
                    message = "Xavier c'est le boss du MIC. Tout porte à croire qu'il serait en fait le véritable Père Noël <|:-)";
                    break;
                case "thomas":
                    message = "Thomas incarne le dark lord du MIC. Un IoT boy carnivore qui a été pilote de F1 dans une vie antérieure";
                    break;
                case "aitor":
                    message = "Aitors'occupe du marketing et de l'image du MIC. Bref, il a beaucoup de travail :p";
                    break;
                case "elba":
                    message = "Elba c'est celle qui est en train de te prendre en photo là bas ! Elle produit tous les contenus vidéos du MIC :D";
                    break;
                case "martine":
                    message = "Martinette la trottinette c'est la maman du MIC et de tout les dragons. Prend garde à toi si tu porte un kilt :o)";
                    break;
                case "fred":
                    message = "Fred c'est le beau gosse du MIC. Il peut paraître impressionnant mais en fait il est plutôt sympa.";
                    break;
                default:
                    message = $"Je suis certain que {result.Entities[0].Entity} est quelqu'un de super mais je ne le connais malheureusement pas :'(";
                    break;
            }

            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("BookRoom")]
        public async Task BookRoom(IDialogContext context, LuisResult result)
        {
            string message = $"Martine ! Maaaaaaaaartiiine !!!";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
            message = $".... bah oui je ne sais pas encore reserver une salle toute seule :'( :'( :'(";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("BorrowEquipment")]
        public async Task BorrowEquipment(IDialogContext context, LuisResult result)
        {
            string message = $"Ok ! Je passe le message à Tom, il va s'occuper de te fournir tout ça si c'est possible.";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("GetEquipmentInformations")]
        public async Task GetEquipmentInformations(IDialogContext context, LuisResult result)
        {
            string message = $"Le equipement est un endroit où le Buisness rencontre la technologie !";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

    }
}