using Xunit;

namespace NetSchool.Lecture_4.Example.Text
{
    public class MatrixTest
    {
        [Fact]
        public void FillTest()
        {
            var m = new Matrix(2, 3);
            m.Fill(1);

            Assert.True(m.data[0, 0] == 1);
            Assert.True(m.data[0, 1] == 2);
            Assert.True(m.data[0, 2] == 3);
            Assert.True(m.data[1, 0] == 6);
            Assert.True(m.data[1, 1] == 5);
            Assert.True(m.data[1, 2] == 4);
        }
    }
}
