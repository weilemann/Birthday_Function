using System;
using System.Collections.Generic;

namespace BirthdayFunction.Templates
{
    public class Congratulations
    {
        public string GetRandomCongratulations()
        {
            List<int> numbers = new List<int>();

            for (var i = 0; i <= 5; i++)
            {
                numbers.Add(i);
            }
            Random random = new Random();
            int randomNumber = random.Next(0, numbers.Count);
            string congratulations;

            switch (randomNumber)
            {
                case 0:
                    congratulations = "Parabéns! Que Deus lhe conceda bençãos e um caminho iluminado! Viva cada momento com amor, responsabilidade, sabedoria, discernimento e alegria. Continue a ser sempre essa pessoa cativa e querida por nós. Obrigado por sua existência e sua amizade. Feliz dia do seu aniversário!";
                    break;
                case 1:
                    congratulations = "Parabéns pelo teu aniversário! Vida e saúde! Que a coragem esteja sempre contigo e que a alegria impulsione os teus passos. Que o sol brilhe sempre em tuas aspirações. Eu te desejo toda felicidade. Viva a vida!";
                    break;
                case 2:
                    congratulations = "Por mais um ano de vida, sempre com dedicação, um feliz aniversário! Sorte, amor e união! Muito êxito porque hoje quem brilha é você! Abraços... Tudo de bom.";
                    break;
                case 3:
                    congratulations = "É o seu dia! Meus parabéns a você! Que traga renovação. E feliz aniversário! Desejo de coração: Saúde, paz e amor em um ano promissor. Muita realização!";
                    break;
                case 4:
                    congratulations = "Feliz aniversário, amigo! O que pensas quando digo isso? Em presentes? Pois o melhor presente quem ganha sou eu, amigo, que tenho a tua companhia, teu amor, teu apoio, teu carinho, tenho você do meu lado!";
                    break;
                case 5:
                    congratulations = "Fazer aniversário é olhar pra trás com gratidão e pra frente com fé! Cada um tem a idade do seu coração, da sua experiência, da sua fé. Cada idade tem a sua beleza e essa beleza deve sempre ser uma liberdade. Nunca terás outra idade senão a do seu coração. Meus parabéns!";
                    break;
                //case 6:
                //    congratulations = "Template Parabéns 7";
                //    break;
                //case 7:
                //    congratulations = "Template Parabéns 8";
                //    break;
                //case 8:
                //    congratulations = "Template Parabéns 9";
                //    break;
                //case 9:
                //    congratulations = "Template Parabéns 10";
                //    break;
                //case 10:
                //    congratulations = "Template Parabéns 11";
                //    break;
                //case 11:
                //    congratulations = "Template Parabéns 12";
                //    break;
                //case 12:
                //    congratulations = "Template Parabéns 13";
                //    break;
                //case 13:
                //    congratulations = "Template Parabéns 14";
                //    break;
                //case 14:
                //    congratulations = "Template Parabéns 15";
                //    break;
                //case 15:
                //    congratulations = "Template Parabéns 16";
                //    break;
                default:
                    congratulations = "Error: Number not found";
                    break;
            }

            return congratulations;
        }
    }
}
