using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException()
        {

        }

        // interpolation sintax
        public EntityNotFoundException(string entity) : base($"The chosen {entity} not found.")
        {

        }
    }
}
