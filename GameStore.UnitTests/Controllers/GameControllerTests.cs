using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameStore.WebUI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Domain.Entities;
using GameStore.Domain.Abstract;
using Moq;
using GameStore.WebUI.Models;

namespace GameStore.WebUI.Controllers.Tests
{
    [TestClass()]
    public class GameControllerTests
    {
        [TestMethod()]
        public void ListTest()
        {
            Mock<IGameRepository> mock = new Mock<IGameRepository>();
            mock.Setup(m => m.Games).Returns(new List<Game>
            {
                new Game { GameId = 1, Name = "Игра1"},
                new Game { GameId = 2, Name = "Игра2"},
                new Game { GameId = 3, Name = "Игра3"},
                new Game { GameId = 4, Name = "Игра4"},
                new Game { GameId = 5, Name = "Игра5"}
            });
            GameController controller = new GameController(mock.Object)
            {
                pageSize = 3
            };

            // Действие (act)
            IEnumerable<Game> result = (IEnumerable<Game>)((GamesListViewModel)controller.List(2).Model).Games;

            // Утверждение (assert)
            List<Game> games = result.ToList();
            Assert.IsTrue(games.Count == 2);
            Assert.AreEqual(games[0].Name, "Игра4");
            Assert.AreEqual(games[1].Name, "Игра5");
        }

        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            Mock<IGameRepository> mock = new Mock<IGameRepository>();
            mock.Setup(x => x.Games).Returns(new List<Game>
            {
                new Game { GameId = 1, Name = "Игра1"},
                new Game { GameId = 2, Name = "Игра2"},
                new Game { GameId = 3, Name = "Игра3"},
                new Game { GameId = 4, Name = "Игра4"},
                new Game { GameId = 5, Name = "Игра5"}
            });

            GameController controller = new GameController(mock.Object);
            controller.pageSize = 3;

            GamesListViewModel model = (GamesListViewModel)controller.List(2).Model;
            PagingInfo info = model.PagingInfo;

            Assert.AreEqual(2, info.CurrentPage);
            Assert.AreEqual(3, info.ItemsPerPage);
            Assert.AreEqual(5, info.TotalItems);
            Assert.AreEqual(2, info.TotalPages);
        }



    }
}