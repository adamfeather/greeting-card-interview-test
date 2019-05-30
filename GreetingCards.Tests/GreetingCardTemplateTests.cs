using System;
using GreetingCards.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace GreetingCards.Tests
{
    [TestClass]
    public class GreetingCardTemplateTests
    {
        [TestMethod]
        public void Should_Create_A_Card_Instance_From_Template()
        {
            var template = new GreetingCardTemplate(1, "Test Card", new Bitmap("./TestImages/test.bmp"), 4.99m, "Test Cards");

            var instance = template.CreateInstance("You", "Happy day of the event!", "Me");

            Assert.IsInstanceOfType(instance, typeof(GreetingCardInstance));
            Assert.IsInstanceOfType(instance.Image, typeof(Bitmap));
            Assert.IsInstanceOfType(instance.Template, typeof(GreetingCardTemplate));
            Assert.AreEqual("Me", instance.Sender);
            Assert.AreEqual("You", instance.Recipient);
            Assert.AreEqual("Happy day of the event!", instance.Message);

            instance.Image.Save($"./TestImages/{DateTime.Now:yyyy_MM_dd_HH_mm_ss_fff}.bmp");
        }
    }
}
