using Sprint1MobileProject.Utils;

namespace TestSprint1MobileProject
{
    public class UnitTestUtils
    {
        //String retornada deve conter os 4 primeiros caracteres sendo letras maiúscula e o último digito sendo um número
        [Fact(DisplayName = "Teste referente a geração da tag 55(Symbol)")]
        public void TestTag55()
        {
            var flag = true;
            var tag = FixUtil.GenerateRandomTag55().ToCharArray();

            if(tag.Length != 5 || !char.IsDigit(tag.Last()))
            {
                flag = false;
            } 
            else
            {
                for(int i = 0; i < 4; i++)
                {
                    if (!char.IsUpper(tag[i]))
                    {
                        flag = false;
                    }
                }
            }

            Assert.True(flag);
        }

        //Decimal retornado pelo método testado deve estar entre 0 e 100 e possuir duas casas decimais
        [Fact(DisplayName = "Teste referente a geração aleatória da tag 44(Price)")]
        public void TestTag44() 
        {
            var flag = true;
            var tag = FixUtil.GenerateRandomTag44();

            if(tag < 0 || tag > 100)
            {
                flag = false;
            }

            Assert.True(flag);
        }

        //O valor gerado deve ser sempre o mod 256 da soma de todos os caracteres(ASCII) passados para o método, contando divisores
        [Theory(DisplayName = "Teste referente a geração da tag 10(SumCheck)")]
        [InlineData(
            "8=FIX.4.4\u00019=132\u000135=D\u000149=CLIENT1\u000156=EXECUTOR\u000134=3\u0001" +
            "52=20230918-19:40:31\u000111=1288152766\u000121=1\u000155=1288152767\u000154=1\u0001" +
            "60=20230918-19:40:31\u000140=2\u000144=50\u000138=1000\u0001",
            "028")]
        [InlineData(
            "8=FIX.4.2\u00019=178\u000135=8\u000149=PHLX\u000156=PERS\u0001" +
            "52=20071123-05:30:00.000\u000111=ATOMNOCCC9990900\u000120=3\u0001" +
            "150=E\u000139=E\u000155=MSFT\u0001167=CS\u000154=1\u000138=15\u0001" +
            "40=2\u000144=15\u000158=PHLX EQUITY TESTING\u000159=0\u000147=C\u0001" +
            "32=0\u000131=0\u0001151=15\u000114=0\u00016=0\u0001",
            "128")]
        [InlineData(
            "8=FIX.4.2\u00019=65\u000135=A\u000149=SERVER\u000156=CLIENT\u0001" +
            "34=177\u000152=20090107-18:15:16\u000198=0\u0001108=30\u0001",
            "062")]
        public void TestTag10(string fix, string expectedResult)
        {
            var actualResult = FixUtil.GenerateTag10(fix);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}