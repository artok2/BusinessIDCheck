using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIdSpecificationCheck
{
    /// <summary>
    /// ISpecification is the base interface. Contains all methods for performing 
    /// basic company businessid verification. 
    /// Class that implements interface must have ReasonsForDissatisfaction and IsSatisfiedBy implemented
    ///  This interface can be implicitly cast to MORE DERIVED (downcasting)
    /// </summary>
    public interface ISpecification<in TEntity>
    {
        IEnumerable<string> ReasonsForDissatisfaction { get; }

        bool IsSatisfiedBy(TEntity entity);
    }
}
