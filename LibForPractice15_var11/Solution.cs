namespace LibForPractice15_var11
{
    public class ClassExample
    {
        /// <summary>
        /// Проверяет, является ли число чётным
        /// </summary>
        /// <param name="a">Число</param>
        /// <returns>True - число чётное; False - нечётное</returns>
        public bool IsEven(int a)
        {
            return a % 2 == 0;
        }
        /// <summary>
        /// Проверяет, оканчивается ли число единицей
        /// </summary>
        /// <param name="a">Число</param>
        /// <returns>True - число оканчивается на единицу; False - нет</returns>
        public bool IsEndingWith1(int a) 
        {
            return a % 10 == 1; 
        }
        /// <summary>
        /// Проверяет, начинается ли число с двойки
        /// </summary>
        /// <param name="a">Число</param>
        /// <returns>True - число начинается с двойки; False - нет</returns>
        public bool IsStartingWith2(int a)
        {
            return (int)(a / Math.Pow(10, (int)Math.Floor(Math.Log10(a)))) == 2;
        }
    }
}