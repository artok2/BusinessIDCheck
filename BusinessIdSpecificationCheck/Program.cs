using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIdSpecificationCheck
{



    class Program
    {
      
        static void Main(string[] args)
        {
            Console.WriteLine("BusinessID test cases validation check");
            Console.WriteLine();
            Console.WriteLine("Case 1 Empty string ()");
            /// <summary>
            /// BusinessIdSpecification test cases. 
            /// 1. Case Empty string => false, range check fails,invalid code, and check sum
            /// </summary>
            /// <returns>false, if businessId is valid</returns>
            BusinessIdSpecification bis = new BusinessIdSpecification();
            bool bResult = bis.IsSatisfiedBy("");
            IEnumerable<string> Dis_reasons = bis.ReasonsForDissatisfaction;
            if (!bResult)
                Dis_reasons.WriteLine();
            else
                Console.WriteLine("Correct ID");


            Console.WriteLine("Case 2 Invalid length (12345678-9)");
            /// <summary>
            /// 2.Case Invalid length  => false, range check fails,invalid code, and check sum
            /// </summary>
            bResult = bis.IsSatisfiedBy("12345678-9");
            Dis_reasons = bis.ReasonsForDissatisfaction;
            if (!bResult)
                Dis_reasons.WriteLine();
            else
                Console.WriteLine("Correct ID");

            Console.WriteLine("Case 3 Invalid number (1532862-0)");
            /// <summary>
            /// 3.Case Invalid number  => false, check sum
            /// </summary>
            bResult = bis.IsSatisfiedBy("1532862-0");
            Dis_reasons = bis.ReasonsForDissatisfaction;
            if (!bResult)
                Dis_reasons.WriteLine();
            else
                Console.WriteLine("Correct ID");

            Console.WriteLine("Case 4 Invalid number, contains character (1532A62-0)");
            /// <summary>
            /// 4.Case Invalid number  => false, invalid businesid code and  check sum
            /// </summary>
            bResult = bis.IsSatisfiedBy("1532A62-0");
            Dis_reasons = bis.ReasonsForDissatisfaction;
            if (!bResult)
                Dis_reasons.WriteLine();
            else
                Console.WriteLine("Correct ID");

            Console.WriteLine("Case 5 Invalid number format (15-728600)");
            /// <summary>
            /// 5.Case Invalid number  => false, invalid businesid code and  check sum
            /// </summary>
            bResult = bis.IsSatisfiedBy("15-728600");
            Dis_reasons = bis.ReasonsForDissatisfaction;
            if (!bResult)
                Dis_reasons.WriteLine();
            else
                Console.WriteLine("Correct ID");


            Console.WriteLine("Case 6 Correct BusinessId (0737546-2) ");
            /// <summary>
            /// 6.Case Invalid length  => True
            /// </summary>
            bResult = bis.IsSatisfiedBy("0737546-2");
            Dis_reasons = bis.ReasonsForDissatisfaction;
            if (!bResult)
                Dis_reasons.WriteLine();
            else
                Console.WriteLine("Correct ID");

            Console.ReadLine();


        }

      
    }
}
