namespace PrintBin_Interview0520
{
    /// <summary>
    /// 面试题 05.02. 二进制数转字符串
    /// 
    /// 二进制数转字符串。给定一个介于0和1之间的实数（如0.72），类型为double，打印它的二进制表达式。如果该数字无法精确地用32位以内的二进制表示，则打印“ERROR”。
    /// 
    /// 示例1:
    /// 
    ///  输入：0.625
    ///  输出："0.101"
    ///  
    /// 示例2:
    /// 
    ///  输入：0.1
    ///  输出："ERROR"
    ///  提示：0.1无法被二进制准确表示
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = PrintBin(0.625);
            var result2 = PrintBin2(0.625);
        }

        public static string PrintBin(double num)
        {
            var a = num.ToString();
            if (a.Last() != '5')
            {
                return "ERROR";
            }

            var result = "0.";
            return Calc(num, result);
        }

        public static string Calc(double num, string result)
        {
            var temp = num * 2;
            var integer = Math.Floor(temp);
            result = result + integer;
            if (result.Length > 32)
            {
                return "ERROR";
            }
            if (temp - 1 == 0)
            {
                return result;
            }

            var next = temp - integer;
            return Calc(next, result);
        }

        public static string PrintBin2(double num)
        {
            var result = "0.";
            while (result.Length <= 32 && num != 0)
            {
                var temp = num * 2;
                var integer = Math.Floor(temp);
                num = temp - integer;
                result += integer;
            }

            return result.Length <= 32 ? result : "ERROR";
        }
    }
}