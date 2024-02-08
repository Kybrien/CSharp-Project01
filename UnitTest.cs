using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace game.Tests
{
    [TestClass]
    public class DisplayPokeStatTests
    {
        [TestMethod]
        public void ShowPokeMenu_InputValidNumber_ReturnsTrue()
        {
            // Arrange
            DisplayPokeStat displayPokeStat = new DisplayPokeStat();
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            Console.SetIn(new StringReader("1\n")); // Simule l'entrée utilisateur pour sélectionner le premier Pokémon

            // Act
            displayPokeStat.ShowPokeMenu();
            string consoleOutput = sw.ToString();

            // Assert
            Assert.IsTrue(consoleOutput.Contains("=== Statistiques de BULBIBOZAR ===")); // Vérifie que le Pokémon a été affiché
        }

        [TestMethod]
        public void ShowPokeMenu_InputInvalidNumber_ReturnsTrue()
        {
            // Arrange
            DisplayPokeStat displayPokeStat = new DisplayPokeStat();
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            Console.SetIn(new StringReader("0\n")); // Simule une entrée utilisateur invalide

            // Act
            displayPokeStat.ShowPokeMenu();
            string consoleOutput = sw.ToString();

            // Assert
            Assert.IsTrue(consoleOutput.Contains("Veuillez entrer un numéro valide.")); // Vérifie que le message d'erreur a été affiché
        }

        [TestMethod]
        public void ShowPokeMenu_InputOutOfRange_ReturnsTrue()
        {
            // Arrange
            DisplayPokeStat displayPokeStat = new DisplayPokeStat();
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            Console.SetIn(new StringReader($"{displayPokeStat.team_poke.Count + 1}\n")); // Simule une entrée hors de la plage valide

            // Act
            displayPokeStat.ShowPokeMenu();
            string consoleOutput = sw.ToString();

            // Assert
            Assert.IsTrue(consoleOutput.Contains("Veuillez entrer un numéro valide.")); // Vérifie que le message d'erreur a été affiché
        }
    }
}
