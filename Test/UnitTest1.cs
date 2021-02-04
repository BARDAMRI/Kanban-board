using System;
using NUnit.Framework;
using Moq;
using IntroSE.Kanban.Backend.BussinessLayer;
using IntroSE.Kanban.Backend.DAL.DTO;
using IntroSE.Kanban.Backend;

namespace Test
{

    public class UnitTest1
    {
        public BoardB board1;
        public Mock<ColumnB> column1;
        public Mock<ColumnB> column2;
        public Mock<ColumnB> column3;
        public Mock<BoardDTO> dalboard;
        public ColumnB[] columns;

        [SetUp]
        public void setup()
        {
            column1 = new Mock<ColumnB>();
            column2 = new Mock<ColumnB>();
            column3 = new Mock<ColumnB>();
            columns = new ColumnB[3];
            dalboard = new Mock<BoardDTO>();
            columns[0] = column1.Object;
            columns[1] = column2.Object;
            columns[2] = column3.Object;
            board1 = new BoardB("b@gmail.com", columns);
        }

        [Test]
        public void moveColumnRight()
        {
            Assert.AreEqual(board1.MoveColumnRight(1), columns[2].getColumn());

        }

        [TestCase(2)]
        [TestCase(-1)]
        [TestCase(4)]
        public void moveColumnRight1(int i)
        {
            Assert.Throws<KanbanException>(() => board1.MoveColumnRight(i));
        }

        [Test]
        public void moveColumnLeft()
        {
            Assert.AreEqual(board1.MoveColumnLeft(1), columns[0].getColumn());
        }

        [TestCase(0)]
        [TestCase(4)]
        [TestCase(3)]
        public void moveColumnLeft1(int i)
        {
            Assert.Throws<KanbanException>(()=>board1.MoveColumnLeft(i));

        }
        [Test]
        public void getTask()
        {

            column1.Setup(x => x.hasTask(0)).Returns(true);
            column1.Setup(x => x.getTask(0)).Returns(new TaskB("b@gmail.com", 0, "title", DateTime.Now, DateTime.MaxValue, "body", "b@gmail.com"));
            TaskB tas = new TaskB("b@gmail.com", 0, "title", DateTime.Now, DateTime.MaxValue, "body", "b@gmail.com");
            Assert.AreEqual(board1.getTask(0),tas);
        }
        [Test]
        public void getTaskWithWrongId()
        {
        column1.Setup(x => x.hasTask(0)).Returns(false);
        TaskB tas = new TaskB("b@gmail.com", 0, "title", DateTime.Now, DateTime.MaxValue, "body", "b@gmail.com");
        Assert.IsNull(board1.getTask(0));
        }

    }
}
