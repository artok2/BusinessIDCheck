using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BusinessIdSpecificationCheck
{
     /// <summary>
    /// Extension that converts char to int also  covers hexadecimal representation
    /// </summary>
    public static class GenExtensions
    {
        public static void WriteLine(this IEnumerable<string> theList)
        {

            foreach (string item in theList)
            {
                Console.WriteLine("{0}\t", item.ToString());

            }
            Console.WriteLine();
        }
                
        public static int CharToInt(this char c)
        {
            if (c >= '0' && c <= '9')
            {
                return c - '0';
            }
            else if (c >= 'a' && c <= 'f')
            {
                return 10 + c - 'a';
            }
            else if (c >= 'A' && c <= 'F')
            {
                return 10 + c - 'A';
            }

            return -1;
        }
    }
    /// <summary>
    /// Class Checks  businessId with  the validation constraints
    /// Specs: http://tarkistusmerkit.teppovuori.fi/tarkmerk.htm#y-tunnus2
    /// </summary>

    class BusinessIdSpecification : ISpecification <string>
    {
      
        private List<string> _ReasonsForDissatisfaction;

        public BusinessIdSpecification()
        {         
          
            _ReasonsForDissatisfaction = new List<string>();
        }

        public IEnumerable<string> ReasonsForDissatisfaction
        {
            get
            {
                return _ReasonsForDissatisfaction;
            }
        }

        /// <summary>
        /// Implementation of ISpecification<in TEntity > interface
        /// Finnish company businessid validation
        /// </summary>      
        /// <returns>true if businessId is valid</returns>
        public bool IsSatisfiedBy(string businessId)
        {
            bool bOk = true;
            int[] arrmultiply = { 7, 9, 10, 5, 8, 4, 2 };
            int iLenBId = businessId.Length;
            _ReasonsForDissatisfaction.Clear();
            /// < remarks >Fixed length </ remarks >
            if (iLenBId != 9)
            {
                _ReasonsForDissatisfaction.Add(BusinessIdSpecificationCheck.Properties.Resources.ERRLEN);
                bOk = false;
            }
            /// < remarks >Business has to be in format NNNNNNN-T </ remarks >
            string pattern = @"^[0-9]{7}-\d{1};";
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection match = rgx.Matches(businessId+";");
            if (match.Count == 0)
            {                    
                _ReasonsForDissatisfaction.Add(BusinessIdSpecificationCheck.Properties.Resources.ERRSYN);
                 bOk = false;             
            }
            /// < remarks >  BusinessId Checksum calculation</ remarks >
            int CodeSum = 0;
            int iLn = arrmultiply.Length;
            
            for (int i = 0; i < iLenBId && i < iLn; i++)
            {
                CodeSum += arrmultiply[i] * businessId[i].CharToInt();
            }
            /// < remarks >  sum is divided  11 and if modulus is etc zero then check sum is zero </ remarks >
            CodeSum = CodeSum % 11;
            int ichecksum = 0;
            /// < remarks >  IF modulus is 2..10, then  11 miinus reminder is checsum.</ remarks >
            ichecksum = ((CodeSum == 0) || (CodeSum == 1)) ? 0 : (11 - CodeSum);

            /// < remarks > no businessIds with checksum 1, Or  and  the last character in company businessId must be the same as checksum /// </ remarks > 
            if ((CodeSum == 1) || ((iLenBId == 0) || (ichecksum != businessId[iLenBId - 1].CharToInt())))
            {              
                _ReasonsForDissatisfaction.Add(BusinessIdSpecificationCheck.Properties.Resources.ERRCSU);               
                bOk = false;
            }

            return bOk;
        }
    }


}


