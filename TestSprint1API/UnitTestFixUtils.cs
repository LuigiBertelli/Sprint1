using Sprint1ApiProject.Utils;

namespace TestProjectSprint1API
{
    public class UnitTestFixUtils
    {
       //Testa método converter que deve retornar um dicionário<tags, valores> a partir de um FIX
       [Fact(DisplayName = "Testa método converter da classe FixUtils")]
        public void TestConverter()
        {
            var expectedResult = new Dictionary<int, string>() {
                {8, "FIX.4.4"},
                {9, "132"},
                {35, "D"},
                {49, "CLIENT1"},
                {56, "EXECUTOR"},
                {34, "3"},
                {52, "20230918-19:40:31"},
                {11, "1288152766"},
                {21, "1"},
                {55, "1288152767"},
                {54, "1"},
                {60, "20230918-19:40:31"},
                {40, "2"},
                {44, "50"},
                {38, "1000"}
            };

            var inputFix = "8=FIX.4.4\u00019=132\u000135=D\u000149=CLIENT1\u000156=EXECUTOR\u000134=3\u0001" +
            "52=20230918-19:40:31\u000111=1288152766\u000121=1\u000155=1288152767\u000154=1\u0001" +
            "60=20230918-19:40:31\u000140=2\u000144=50\u000138=1000\u0001";
            var actualResult = FixUtils.Converter(inputFix);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}