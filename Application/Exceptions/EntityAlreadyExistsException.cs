using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class EntityAlreadyExistsException : Exception
    {
        public EntityAlreadyExistsException()
        {

        }

        // interpolation sintax
        public EntityAlreadyExistsException(string entity) : base($"The chosen {entity} already exists.")
        {

        }
    }
}
