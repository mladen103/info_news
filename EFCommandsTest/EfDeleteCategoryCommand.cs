using Application.Commands.Delete;
using Application.Exceptions;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mladja
{
    public class EfDeleteCategoryCommand : BaseEfCommand, IDelete
    {
        public EfDeleteCategoryCommand(Context context) : base(context)
        {

        }

        public void Execute(int request)
        {
            var category = this.Context.Categories.Find(request);

            if (category == null)
                throw new EntityNotFoundException();

            this.Context.Categories.Remove(category);
            this.Context.SaveChanges();
        }
    }
}
